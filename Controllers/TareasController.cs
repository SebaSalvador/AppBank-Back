// Controllers/TareasController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")] // La URL para acceder será /api/tareas
public class TareasController : ControllerBase
{
    // Simula una base de datos en memoria con una lista estática
    private static List<Tarea> _tareas = new List<Tarea>
    {
        new Tarea { Id = 1, Titulo = "Configurar el backend", Completada = true },
        new Tarea { Id = 2, Titulo = "Conectar con el frontend", Completada = false }
    };

    // GET: api/tareas -> Para OBTENER todas las tareas
    [HttpGet]
    public ActionResult<List<Tarea>> Get()
    {
        return Ok(_tareas);
    }

    // POST: api/tareas -> Para CREAR una nueva tarea
    [HttpPost]
    public ActionResult<Tarea> Post(Tarea nuevaTarea)
    {
        // Asigna un nuevo ID
        nuevaTarea.Id = _tareas.Any() ? _tareas.Max(t => t.Id) + 1 : 1;
        _tareas.Add(nuevaTarea);
        return Ok(nuevaTarea); // Devuelve la tarea creada
    }

    // DELETE: api/tareas/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tarea = _tareas.FirstOrDefault(t => t.Id == id);
        if (tarea == null)
        {
            return NotFound(); // Devuelve 404 si no se encuentra la tarea
        }

        _tareas.Remove(tarea);
        return NoContent(); // Devuelve 204 No Content, que significa éxito
    }
}