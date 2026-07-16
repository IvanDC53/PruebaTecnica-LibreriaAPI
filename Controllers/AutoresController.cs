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
    public class AutoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AutoresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            return await _context.Autores.ToListAsync();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAutores), new { id = autor.autor_id }, autor);
        }

        [Authorize(Roles = "Administrador")] 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, Autor autor)
        {
            if (id != autor.autor_id) return BadRequest("El ID no coincide.");

            _context.Entry(autor).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Autores.Any(e => e.autor_id == id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null) return NotFound();

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}