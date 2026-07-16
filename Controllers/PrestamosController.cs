using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using LibreriaAPI.Data;
using LibreriaAPI.Models;

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PrestamosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PrestamosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetPrestamos()
        {
            return await _context.Prestamos.ToListAsync();
        }

        [HttpGet("pendientes")]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetPrestamosPendientes()
        {
            var prestamosPendientes = await _context.Prestamos.Where(p => p.fecha_devolucion == null).ToListAsync();
            if (!prestamosPendientes.Any()) return NotFound(new { mensaje = "No hay préstamos pendientes." });
            return Ok(prestamosPendientes);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<Prestamo>> PostPrestamo(Prestamo prestamo)
        {
            var libroExiste = await _context.Libros.AnyAsync(l => l.libro_id == prestamo.libro_id);
            if (!libroExiste) return BadRequest(new { mensaje = "El libro no existe." });

            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPrestamos), new { id = prestamo.prestamo_id }, prestamo);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrestamo(int id, Prestamo prestamo)
        {
            if (id != prestamo.prestamo_id) return BadRequest(new { mensaje = "Los IDs no coinciden." });

            var prestamoExistente = await _context.Prestamos.FindAsync(id);
            if (prestamoExistente == null) return NotFound(new { mensaje = "Préstamo no encontrado." });

            prestamoExistente.fecha_devolucion = prestamo.fecha_devolucion;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrestamo(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null) return NotFound(new { mensaje = "El préstamo no existe." });

            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "El préstamo fue eliminado." });
        }
    }
}