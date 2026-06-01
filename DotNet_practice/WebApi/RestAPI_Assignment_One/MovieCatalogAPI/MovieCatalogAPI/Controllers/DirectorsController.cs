using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalogAPI.Data;

namespace MovieCatalogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DirectorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDirectors()
        {
            return Ok(await _context.Directors.ToListAsync());
        }

        [HttpGet("{directorId}/movies")]
        public async Task<IActionResult> GetMoviesByDirector(
            int directorId)
        {
            var director =
                await _context.Directors.FindAsync(directorId);

            if (director == null)
                return NotFound("Director not found");

            var movies = await _context.Movies
                .Where(m => m.DirectorId == directorId)
                .ToListAsync();

            return Ok(movies);
        }
    }
}