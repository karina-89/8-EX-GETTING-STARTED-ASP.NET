using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using empleados.Data;
using empleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace empleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpleadoContexto _contexto;

        public EmpleadosController(EmpleadoContexto contexto)
        {
            _contexto = contexto;
        }

        // GET: api/Empleados
        // GET api/Empleados/Luis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleadoItems()
        {
            return await _contexto.EmpleadoItems.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleadoItem(int id)
        {
            var empleadoItem = await _contexto.EmpleadoItems.FindAsync(id);
            if (empleadoItem == null)
            {
                return NotFound();
            }

            return empleadoItem;
        }

        [HttpGet("nombre/{nombre}")]
        public string GetPorNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                return "Hola mundo";
            else
                return $"Hola {nombre}";
        }

        [HttpGet("id/")]
        [HttpGet("id/{id}")]
        public string GetPorID(int id)
        {
            if (id == 0)
                return "Hola mundo";
            var empleadoItem = _contexto.EmpleadoItems.Find(id);
            if (empleadoItem == null)
                return $"No se ha encontrado el empleado {id}.";
            return $"Hola {empleadoItem.Nombre}";
        }

        // POST api/Empleados
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleadoItem([FromBody] Empleado empleado)
        {
            _contexto.EmpleadoItems.Add(empleado);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpleadoItem), new { id = empleado.Id }, empleado);
        }

        // PUT api/Empleados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleadoItem(int id, [FromBody] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return BadRequest();
            }

            _contexto.Entry(empleado).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleadoItem(int id)
        {
            var empleadoItem = await _contexto.EmpleadoItems.FindAsync(id);
            if (empleadoItem == null)
            {
                return NotFound();
            }

            _contexto.EmpleadoItems.Remove(empleadoItem);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }
    }
}
