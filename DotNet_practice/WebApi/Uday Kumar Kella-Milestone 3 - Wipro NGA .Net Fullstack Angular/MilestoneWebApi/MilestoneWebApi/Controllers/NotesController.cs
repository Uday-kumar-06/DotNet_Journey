using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilestoneWebApi.Data;
using MilestoneWebApi.DTOs;
using MilestoneWebApi.Models;
using System.Security.Claims;

namespace MilestoneWebApi.Controllers
{
    //This is Notes Contoller where i had added all my endpoints logic
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

        //Endpoints
        //This is the end point for adding note
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
        //Here i used this endpoint logic for getting all the notes of the user
        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var notes = await _context.Notes
                .Where(x => x.UserId == GetUserId())
                .ToListAsync();

            return Ok(notes);
        }
        //we can use this for get the note by id we have 
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

        //i use this end point for delete the note by id

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