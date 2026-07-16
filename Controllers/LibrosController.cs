using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibreriaAPI.Data;
using LibreriaAPI.Models;

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LibrosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            return await _context.Libros.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            var autorExiste = await _context.Autores.AnyAsync(a => a.autor_id == libro.autor_id);
            if (!autorExiste)
            {
                return BadRequest(new { mensaje = $"Error: El autor con ID {libro.autor_id} no existe en la base de datos." });
            }

            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLibros), new { id = libro.libro_id }, libro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            if (id != libro.libro_id) return BadRequest("El ID no coincide.");

            _context.Entry(libro).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Libros.Any(e => e.libro_id == id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null) return NotFound();

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("clasicos")]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibrosClasicos()
        {
            var librosClasicos = await _context.Libros
                .Where(l => l.año_publicacion < 2000)
                .ToListAsync();

            if (!librosClasicos.Any())
            {
                return NotFound(new { mensaje = "No se encontraron libros publicados antes del año 2000." });
            }

            return Ok(librosClasicos);
        }
    }
}