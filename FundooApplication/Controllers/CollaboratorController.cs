using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entities;
using System;
using System.Linq;
using System.Security.Claims;

namespace FundooApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        
        private readonly ICollaboratorBL collaboratorBL;
        private IConfiguration _config;
        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorController"/> class.
        /// </summary>
        /// <param name="collaboratorBL">The collaborator bl.</param>
        /// <param name="_config">The configuration.</param>
        public CollaboratorController(ICollaboratorBL collaboratorBL, IConfiguration _config)
        {
           
            this.collaboratorBL = collaboratorBL;
            this._config = _config;

        }
        /// <summary>
        /// Adds the colaborator.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("addColabs/{notesId}")]
        public IActionResult AddColaborator(CollaboratorModel model, long notesId)
        {
            try
            {
                long tokenId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                if (tokenId != 0 && notesId != 0)
                {
                    CollaboratorModel collaboratorModel = collaboratorBL.AddColaborator(model, notesId, tokenId);

                    return this.Ok(new { Status = true, Message = "Collaborator added", Data = collaboratorModel });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Collaborator not added" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.InnerException });
            }

        }

        /// <summary>
        /// Gets all collaborator.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllCollaborator()
        {
            try
            {
                var result = this.collaboratorBL.GetAllCollaborator();
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Fetched all collaborators", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "collaoarator not fetched" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, StackTraceException = ex.StackTrace });
            }
        }
       
        /// <summary>
        /// Gets the collabs by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public IActionResult GetCollabsById(long Id)
        {
            try {
                var result = this.collaboratorBL.CollaboratorById(Id);

                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Collaborator got deleted", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "collaoarator not deleted" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, StackTraceException = ex.StackTrace });
            }
        }
    }
}
