using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entities;
using RepositoryLayer.Services;
using System;

namespace FundooApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        ILabelBL labelBL;
        IConfiguration config;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelController"/> class.
        /// </summary>
        /// <param name="_labelBL">The label bl.</param>
        /// <param name="_config">The configuration.</param>
        public LabelController(ILabelBL _labelBL, IConfiguration _config)
        {
            config = _config;
            labelBL = _labelBL;
        }
        /// <summary>
        /// Adds the label by notes identifier.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost("{notesId}")]
        public IActionResult AddLabelByNotesId(long notesId, LabelModel model)
        {
            try
            {
                string value = this.labelBL.AddLabelByNotesId(notesId, model);
                if (value != null)
                {
                    return this.Ok(new { Status = true, Message = "Label added", Data = value });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Label not added" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.InnerException });
            }

        }
        /// <summary>
        /// Adds the label by user identifier.
        /// </summary>
        /// <param name="labelData">The label data.</param>
        /// <returns></returns>
        [HttpPost("addById")]
        public IActionResult AddLabelByUserId([FromBody] LabelModelData labelData)
        {
            try
            {
                string result = this.labelBL.AddLabelByUserId(labelData);

                if (result.Equals("Label added successfully"))
                {

                    return this.Ok(new { Status = true, Message = "Label added successully", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Label not added" });
                }
            }

            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.InnerException });
            }
        }
        /// <summary>
        /// Edits the label.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut("{labelId}")]
        public IActionResult EditLabel(long labelId, LabelModel model)
        {
            try
            {
                var result = this.labelBL.EditLable(labelId, model);
                if (result != null)
                {

                    return this.Ok(new { Status = true, Message = "Label modifed successully", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Label not modified" });
                }
            }

            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.InnerException });
            }
        }
        [HttpGet("databyNotesId/{notesId}")]
        public IActionResult GetLabelByNoteId(long notesId)
        {
            try
            {
                var result = this.labelBL.GetLabelByNoteId(notesId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Fetched all labels", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "labels not fetched" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, StackTraceException = ex.StackTrace });
            }
        }
        [HttpGet("dataById/{userId}")]
        public IActionResult GetLabelByUserId(long userId)
        {
            try
            {
                var result = this.labelBL.GetLabelByUserId(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Fetched all labels", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "labels not fetched" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, StackTraceException = ex.StackTrace });
            }
        }

        [HttpDelete("{labelId}")]
        public IActionResult RemoveLabel(long labelId)
        {
            try
            {
                var result = this.labelBL.RemoveLabel(labelId);
                if (result != null)
                {

                    return this.Ok(new { Status = true, Message = "Label removed", Data = result });

                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Label not removed" });
                }
            }

            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.InnerException });
            }
        }
    }
}










