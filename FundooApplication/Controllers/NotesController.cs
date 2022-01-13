using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryLayer;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FundooApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        
        private readonly INotesBL notesBL;
        private IConfiguration _config;

        
        public static IWebHostEnvironment webHostEnvironment;
        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="_environment">The environment.</param>
        /// <param name="_notesBL">The notes bl.</param>
        /// <param name="_config">The configuration.</param>
        public NotesController(IWebHostEnvironment _environment, INotesBL _notesBL, IConfiguration _config)
        {
            this.notesBL = _notesBL;
            this._config = _config;
            webHostEnvironment = _environment;
        }


        /// <summary>
        /// Gets all notes.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("allnotes")]
        public IActionResult GetAllNotes()
        {
            try
            {
                var result = this.notesBL.Notes();
                if(result !=null)
                { 
                    return this.Ok(new {  Status = true, Message = "Notes added", Data = result });
            }
                else
            {
                return this.BadRequest(new {  Status = false, Message = "Notes not added", Data = result });
            }
        }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = true, Message = ex.InnerException, StackTraceException = ex.StackTrace });

            }
        }

        /// <summary>
        /// Makes a note.
        /// </summary>
        /// <param name="notes">The notes.</param>
        /// <returns></returns>
        [HttpPost("addNote")]
        public IActionResult MakeNote([FromBody] AddingNotes notes)
        {
            try
            {
                string result = this.notesBL.MakeANote(notes);
                if (result == "New notes saved")
                {
                    return this.Ok(new { Status = true, Message = "Notes added", Data = notes });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Notes not added" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = true, Message = ex.InnerException, StackTraceException = ex.StackTrace });
            }
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="NotesId">The notes identifier.</param>
        /// <param name="notes">The notes.</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("updateNotes/{notesId}")]
        public IActionResult UpdateAllNotes(long notesId, UpdateNotes notes)
        {
            try
            {
                var result = this.notesBL.UpdateNotes(notesId, notes);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Notes updated", Data = notes });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Notes updated"});
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = true, Message = ex.InnerException, StackTraceException = ex.StackTrace });
            }
        }

        /// <summary>
        /// Changes the color.
        /// </summary>
        /// <param name="NotesId">The notes identifier.</param>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("changeColor/{notesId}")]
        public IActionResult ColorChange(long NotesId, string colour)
        {
            try
            {
                var result = this.notesBL.ChangeColor(NotesId, colour);
                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "colour changed", data = colour });
                }
                return BadRequest(new { Success = false, message = "color not changed" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = true, Message = ex.InnerException, StackTraceException = ex.StackTrace });
            }

        }

        /// <summary>
        /// Archives the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns></returns>

        [HttpPut("archive/{notesId}")]
        public IActionResult ArchiveNotes(long notesId)
        {
            try
            {
                var result = notesBL.ArchiveNote(notesId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "It got archived" });
                }
                return BadRequest(new { Success = false, message = "Not archive" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = true, Message = ex.InnerException, StackTraceException = ex.StackTrace });
            }


        }
        /// <summary>
        /// Adds the image.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("uploadImage/{notesId}")]
        public IActionResult UploadImage(long notesId, IFormFile path)
        {
            try
            {
                string result = this.notesBL.AddImage(notesId, path);
                if (result.Equals("Image uploaded successfully"))
                { 
                    return this.Ok(new { Status = true, Message = "Image added sucessfully", Data =path });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Image not added" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = true, Message = ex.InnerException, StackTraceException = ex.StackTrace });
            }
        }

        /// <summary>
        /// Pins the notes.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns></returns>
        [HttpPut("pin/{notesId}")]
        public IActionResult PinNote(long notesId)
        {
            try
            {
                var result = this.notesBL.PinNotes(notesId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, Message = "It got pinned" });
                }
                return BadRequest(new { Success = false, Message = "Not able to pin" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = true, Message = ex.InnerException, StackTraceException = ex.StackTrace });
            }


        }


    }

}