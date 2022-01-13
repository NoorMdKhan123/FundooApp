using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class LabelRL : ILabelRL
    {
        Context context;
        IConfiguration configuration;
        /// <summary>
        /// Initializes a new instance of the <see cref="LabelRL"/> class.
        /// </summary>
        /// <param name="_configuration">The configuration.</param>
        /// <param name="_context">The context.</param>
        public LabelRL(IConfiguration _configuration, Context _context)
        {
            configuration = _configuration;
            context = _context;
        }
        /// <summary>
        /// Adds the label by notes identifier.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public string AddLabelByNotesId(long notesId, LabelModel model)
        {
            try
            {
                var validId = this.context.notesTable.Where(x => x.NotesId == notesId).FirstOrDefault();
                if(validId != null)
                {
                    Label label = new Label();
                    label.LabelName= model.LabelName;
                    label.NotesId = notesId;
                    label.Id = model.Id;
                    this.context.Add(label);
                    this.context.SaveChanges();
                    return "label added successfully";

                }
                else
                {
                    return "Label not added";
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        /// <summary>
        /// Adds the label by user identifier.
        /// </summary>
        /// <param name="labelData">The label data.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
      public string AddLabelByUserId(LabelModelData labelData)
        {
            try
            {
                var validLabel = this.context.Labels.Where(x => x.Id == labelData.Id && x.LabelName != labelData.LabelName && x.NotesId == null).FirstOrDefault();
                if (validLabel == null)
                {
                    Label label = new Label();
                    label.LabelName = labelData.LabelName;
                    label.Id = labelData.Id;
                    this.context.Add(label);
                    this.context.SaveChanges();
                    return "label added successfully";
                }
                return "The label with this name already exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Edits the lable.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="Exception">ex.Message</exception>
        public string EditLable(long labelId, LabelModel model)
        {
            try
            {
                var info = this.context.Labels.Where(x => x.LabelId == labelId).FirstOrDefault();
                if (info != null)
                {
                  
                    info.LabelName = model.LabelName;
                    this.context.Update(info);
                    this.context.SaveChanges();
                    return "label modified successfully";
                    
                }
                else
                {
                    return "label not modified";
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        /// <summary>
        /// Removes the label.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">ex.Message</exception>
        public string RemoveLabel(long labelId)
        {
            try
            {
                var info = this.context.Labels.Where(x => x.LabelId == labelId).FirstOrDefault();
                if (info != null)
                {
                    this.context.Remove(info);
                    this.context.SaveChanges();
                    return "Label removed successfully";
                }
                else
                {
                    return "Label removed successfully";
                }

            }
            catch(Exception ex)

            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Gets the label by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">ex.Message</exception>
      public IEnumerable<Label> GetLabelByUserId(long userId)
        {
            try
            {
                IEnumerable<Label> validLabel = this.context.Labels.Where(x => x.Id == userId);
                if (validLabel != null)
                {
                    return validLabel;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Gets the label by note identifier.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">ex.Message</exception>
        public IEnumerable<Label> GetLabelByNoteId(long notesId)
        {
            try
            {
                IEnumerable<Label> validLabel = this.context.Labels.Where(x => x.NotesId == notesId);
                if (validLabel != null)
                {
                    return validLabel;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


   
