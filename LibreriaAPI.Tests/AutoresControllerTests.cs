using LibreriaAPI.Controllers;
using LibreriaAPI.Data;
using LibreriaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibreriaAPI.Tests
{
    public class AutoresControllerTests
    {
        private AppDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new AppDbContext(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }

        [Fact]
        public async Task GetAutores_RetornaListaDeAutores()
        {
            var context = GetDatabaseContext();
            context.Autores.Add(new Autor { nombre = "Autor de Prueba Unitario", nacionalidad = "Dominicana" });
            await context.SaveChangesAsync();

            var controller = new AutoresController(context);

            var result = await controller.GetAutores();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<Autor>>>(result);
            var listaAutores = Assert.IsAssignableFrom<IEnumerable<Autor>>(actionResult.Value);

            Assert.Single(listaAutores);
            Assert.Equal("Autor de Prueba Unitario", listaAutores.First().nombre);
        }
    }
}