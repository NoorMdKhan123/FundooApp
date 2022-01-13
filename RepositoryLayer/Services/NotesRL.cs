using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NotesRL : INotesRL
    {


        private readonly Context context;
        public IConfiguration Configuration;
        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRL"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="userContext">The user context.</param>
        public NotesRL(IConfiguration configuration, Context userContext)
        {
            this.Configuration = configuration;
            this.context = userContext;
        }

        /// <summary>
        /// Noteses this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Notes> Notes()
        {
            return context.notesTable.ToList();
        }
        /// <summary>
        /// Makes a note.
        /// </summary>
        /// <param name="notes">The notes.</param>
        /// <returns></returns>
        public string MakeANote(AddingNotes notes)
        {
            try
            {

                Notes newNotes = new Notes();
                newNotes.Id = notes.Id;
                newNotes.Title = notes.Title;
                newNotes.TakeANote = notes.TakeANote;
                newNotes.RemindMe = notes.RemindMe;
                newNotes.Colour = notes.Colour;
                newNotes.Image = notes.Image;
                newNotes.IsArchive = notes.IsArchive;
                newNotes.IsNotePinned = notes.IsNotePinned;
                //Adding the data to database
                this.context.notesTable.Add(newNotes);
                //Save the changes in database
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return "New notes saved";
                }
                else
                {
                    return "No Notes saved";
                }
            }

            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="notes">The notes.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">
        /// No user with given Id
        /// or
        /// </exception>
        public string UpdateNotes(long notesId, UpdateNotes notes)
        {
            try
            {

                var result = this.context.notesTable.Find(notesId);
                if (result == null)
                {

                    throw new Exception("No user with given Id");
                }
                result.Title = notes.Title;
                result.TakeANote = notes.TakeANote;
                var response = this.context.notesTable.Update(result);
                this.context.SaveChanges();
                if (response != null)
                {
                    return "Data Updated";
                }
                else
                {
                    return "records not updated";
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }
        /// <summary>
        /// Changes the color.
        /// </summary>
        /// <param name="NotesId">The notes identifier.</param>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">
        /// </exception>
        public bool ChangeColor(long NotesId, string colour)
        {
            try
            {
                var colorNote = this.context.notesTable.Where(x => x.NotesId == NotesId).FirstOrDefault();
                {
                    if (colorNote == null)
                    {
                        throw new Exception(colour);
                    }
                    colorNote.Colour = colour;
                    this.context.notesTable.Update(colorNote);
                    int result = this.context.SaveChanges();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// Archives the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public string ArchiveNote(long notesId)
        {
            try
            {
                string msg;
                var validNote = this.context.notesTable.Where(x => x.NotesId == notesId).FirstOrDefault();
                if (validNote != null)
                {
                    if (validNote.IsArchive == false)
                    {
                        validNote.IsArchive = true;

                        if (validNote.IsNotePinned == true)
                        {
                            validNote.IsNotePinned = false;
                            msg = "The note is unpinned and archive successfully";
                        }
                        else
                        {
                            msg = "The notes was initially not pinned  but now archived succcessfuly";
                        }
                    }
                    else
                    {
                        validNote.IsArchive = false;
                        msg = "Note archived successfully";
                    }
                    this.context.Update(validNote);
                    this.context.SaveChanges();
                }
                else
                {
                    msg = "This notes doesn't exist please create  a new note";
                }
                return msg;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Pins the notes.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public string PinNotes(long notesId)
        {
            try
            {
                string msg;
                var pinNote = this.context.notesTable.Where(x => x.NotesId.Equals(notesId)).FirstOrDefault();
                if (pinNote != null)
                {
                    if (pinNote.IsNotePinned == false)
                    {
                        pinNote.IsNotePinned = true;

                        if (pinNote.IsArchive == true)
                        {
                            pinNote.IsArchive = false;
                            msg = "notes unarchived and pinned successfully";

                        }
                        else
                        {
                            msg = "notes initially not archived and pinned successfully now";
                        }
                    }
                    pinNote.IsNotePinned = false;
                    msg = "notes unpinned successfully";
                    this.context.notesTable.Update(pinNote);
                    this.context.SaveChanges();
                }
                else
                {
                    msg = "There is no notes prsent to pin";
                }
                return msg;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Adds the image.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public string AddImage(long notesId, IFormFile path)
        {
            try
            {
                var validNoteId = this.context.notesTable.Where(x => x.NotesId == notesId).FirstOrDefault();
                if (validNoteId != null)
                {
                    var cloudinary = new Cloudinary(
                                                new Account(
                                                 "dlks7fjos",
                                                 "666647221918192",
                                                 "lSIlRpLq-DUQX-UB11aOnjmDUNE"));

                    var uploadImage = new ImageUploadParams()
                    {
                        File = new FileDescription(path.FileName, path.OpenReadStream())
                    };
                    var uploadResult = cloudinary.Upload(uploadImage);
                    var uploadPath = uploadResult.Url;
                    validNoteId.Image = uploadPath.ToString();
                    this.context.SaveChanges();
                    return "Image uploaded successfully";
                }
                else
                {
                    return "Note does not Exist";
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}





    

            


           
   
