using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System;

namespace FundooApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesBL notesBL;
        public NotesController(INotesBL _notesBL)
        {
            this.notesBL = _notesBL;
        }
       [HttpPost]
        [Route("addnote")]
        public IActionResult MakeANote([FromBody] AddingNotes notes)
        {
            try
            {
                string result = this.notesBL.MakeANote(notes);
                if (result != "New note created successfully")
                {
                    return this.Ok(new ResponseModl<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModl<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModl<string>() { Status = false, Message = ex.Message });
            }
        }

    }
}