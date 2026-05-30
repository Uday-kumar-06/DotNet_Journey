using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilestoneWebApi.Data;
using MilestoneWebApi.DTOs;
using MilestoneWebApi.Models;
using System.Security.Claims;

namespace MilestoneWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        private int GetUserId()
        {
            return int.Parse(
                User.FindFirstValue(
                ClaimTypes.NameIdentifier)!);
        }

        [HttpPost]
        public async Task<IActionResult> AddNote(NoteDto dto)
        {
            var note = new Note
            {
                Title = dto.Title,
                Content = dto.Content,
                UserId = GetUserId()
            };

            _context.Notes.Add(note);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message =
                "Note added successfully.",
                noteId = note.Id
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var notes = await _context.Notes
                .Where(x => x.UserId == GetUserId())
                .ToListAsync();

            return Ok(notes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(
            int id,
            NoteDto dto)
        {
            var note = await _context.Notes
                .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.UserId == GetUserId());

            if (note == null)
                return NotFound();

            note.Title = dto.Title;
            note.Content = dto.Content;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Updated"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var note = await _context.Notes
                .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.UserId == GetUserId());

            if (note == null)
                return NotFound();

            _context.Notes.Remove(note);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Deleted"
            });
        }
    }
}