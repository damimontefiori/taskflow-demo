# Especificación Ejecutiva: TaskFlow

## Objetivo del Sistema
TaskFlow es una aplicación web estilo Trello diseñada para facilitar la gestión colaborativa de proyectos mediante tableros, listas y tarjetas de tareas. Permite a los equipos organizar, priorizar y supervisar el progreso de sus actividades de manera visual e intuitiva.

## Roles de Usuario
- **Administrador:** Gestiona usuarios, tableros y permisos.
- **Usuario estándar:** Crea y gestiona tableros, listas y tarjetas dentro de sus permisos.

## Historias de Usuario y Criterios de Aceptación

1. **Como usuario, quiero crear un tablero para organizar mis proyectos.**
    - Criterios:
      - El usuario puede ingresar un nombre y descripción para el tablero.
      - El tablero aparece en la lista de tableros del usuario.

2. **Como usuario, quiero crear listas dentro de un tablero para categorizar tareas.**
    - Criterios:
      - El usuario puede añadir, editar y eliminar listas en un tablero.
      - Las listas se muestran ordenadas dentro del tablero.

3. **Como usuario, quiero crear tarjetas de tareas dentro de una lista.**
    - Criterios:
      - El usuario puede añadir, editar y eliminar tarjetas en una lista.
      - Las tarjetas muestran título y descripción.

4. **Como usuario, quiero mover tarjetas entre listas para reflejar el estado de las tareas.**
    - Criterios:
      - El usuario puede arrastrar y soltar tarjetas entre listas.
      - El cambio se refleja inmediatamente en la interfaz.

5. **Como usuario, quiero asignar miembros a tarjetas para definir responsables.**
    - Criterios:
      - El usuario puede seleccionar miembros del tablero y asignarlos a tarjetas.
      - Los miembros asignados se muestran en la tarjeta.

6. **Como usuario, quiero agregar comentarios a las tarjetas para colaborar con el equipo.**
    - Criterios:
      - El usuario puede escribir y ver comentarios en cada tarjeta.
      - Los comentarios muestran autor y fecha.

7. **Como usuario, quiero establecer fechas límite en las tarjetas para gestionar plazos.**
    - Criterios:
      - El usuario puede seleccionar una fecha límite al crear o editar una tarjeta.
      - La fecha límite se muestra en la tarjeta.

8. **Como administrador, quiero invitar usuarios a tableros para colaborar en proyectos.**
    - Criterios:
      - El administrador puede enviar invitaciones por correo electrónico.
      - Los usuarios invitados reciben acceso al tablero.

9. **Como administrador, quiero eliminar tableros que ya no se utilizan.**
    - Criterios:
      - El administrador puede seleccionar y eliminar tableros.
      - El sistema solicita confirmación antes de eliminar.

10. **Como usuario, quiero buscar tarjetas por título o descripción para encontrarlas fácilmente.**
     - Criterios:
        - El usuario puede ingresar palabras clave en un campo de búsqueda.
        - El sistema muestra tarjetas que coinciden con la búsqueda.

        ## Backlog Prioritario

        | ID   | Descripción breve                                                      | Criterio de aceptación principal                                 | Prioridad |
        |------|-----------------------------------------------------------------------|------------------------------------------------------------------|-----------|
        | US1  | Crear tableros para organizar proyectos                               | El usuario puede crear tableros con nombre y descripción         | Alta      |
        | US2  | Crear listas dentro de tableros para categorizar tareas               | El usuario puede añadir, editar y eliminar listas                | Alta      |
        | US3  | Crear tarjetas de tareas dentro de listas                             | El usuario puede añadir, editar y eliminar tarjetas              | Alta      |
        | US4  | Mover tarjetas entre listas para reflejar el estado                   | El usuario puede arrastrar y soltar tarjetas entre listas        | Alta      |
        | US5  | Asignar miembros a tarjetas para definir responsables                 | El usuario puede asignar miembros del tablero a tarjetas         | Media     |
        | US6  | Agregar comentarios a las tarjetas para colaborar                     | El usuario puede escribir y ver comentarios en cada tarjeta      | Media     |
        | US7  | Establecer fechas límite en las tarjetas                              | El usuario puede seleccionar una fecha límite en la tarjeta      | Media     |
        | US8  | Invitar usuarios a tableros para colaborar                            | El administrador puede enviar invitaciones por correo electrónico| Baja      |
        | US9  | Eliminar tableros que ya no se utilizan                               | El administrador puede eliminar tableros con confirmación        | Baja      |
        | US10 | Buscar tarjetas por título o descripción                              | El usuario puede buscar tarjetas por palabras clave              | Media     |

