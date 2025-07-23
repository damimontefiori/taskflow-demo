using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Models;
using TaskFlow.Api.DTOs;

namespace TaskFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardsController : ControllerBase
    {
        private readonly TaskFlowDbContext _context;

        public BoardsController(TaskFlowDbContext context)
        {
            _context = context;
        }

        // GET: api/boards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoardResponse>>> GetBoards()
        {
            var boards = await _context.Boards
                .Include(b => b.User)
                .Include(b => b.Lists)
                .Select(b => new BoardResponse
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt,
                    UserId = b.UserId,
                    UserName = b.User.Name,
                    ListsCount = b.Lists.Count
                })
                .ToListAsync();

            return Ok(boards);
        }

        // GET: api/boards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Board>> GetBoard(int id)
        {
            var board = await _context.Boards
                .Include(b => b.User)
                .Include(b => b.Lists)
                    .ThenInclude(l => l.Cards)
                .Include(b => b.BoardMembers)
                    .ThenInclude(bm => bm.User)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (board == null)
            {
                return NotFound($"Board with ID {id} not found.");
            }

            return Ok(board);
        }

        // POST: api/boards
        [HttpPost]
        public async Task<ActionResult<BoardResponse>> CreateBoard(CreateBoardRequest request)
        {
            // Verificar que el usuario existe
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
            {
                return BadRequest($"User with ID {request.UserId} not found.");
            }

            var board = new Board
            {
                Name = request.Name,
                Description = request.Description,
                UserId = request.UserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Boards.Add(board);
            await _context.SaveChangesAsync();

            // Crear respuesta
            var response = new BoardResponse
            {
                Id = board.Id,
                Name = board.Name,
                Description = board.Description,
                CreatedAt = board.CreatedAt,
                UpdatedAt = board.UpdatedAt,
                UserId = board.UserId,
                UserName = user.Name,
                ListsCount = 0
            };

            return CreatedAtAction(nameof(GetBoard), new { id = board.Id }, response);
        }

        // PUT: api/boards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBoard(int id, UpdateBoardRequest request)
        {
            var board = await _context.Boards.FindAsync(id);
            if (board == null)
            {
                return NotFound($"Board with ID {id} not found.");
            }

            // Actualizar campos
            board.Name = request.Name;
            board.Description = request.Description;
            board.UpdatedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/boards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            var board = await _context.Boards.FindAsync(id);
            if (board == null)
            {
                return NotFound($"Board with ID {id} not found.");
            }

            _context.Boards.Remove(board);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/boards/user/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<BoardResponse>>> GetBoardsByUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            var boards = await _context.Boards
                .Where(b => b.UserId == userId)
                .Include(b => b.Lists)
                .Select(b => new BoardResponse
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt,
                    UserId = b.UserId,
                    UserName = user.Name,
                    ListsCount = b.Lists.Count
                })
                .ToListAsync();

            return Ok(boards);
        }

        private bool BoardExists(int id)
        {
            return _context.Boards.Any(e => e.Id == id);
        }
    }
}
