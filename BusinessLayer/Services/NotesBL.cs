using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class NotesBL : INotesBL
    {
        INotesRL notesRL;
        /// <summary>
        /// Initializes a new instance of the <see cref="NotesBL"/> class.
        /// </summary>
        /// <param name="_notesRL">The notes rl.</param>
        public NotesBL(INotesRL _notesRL)
        {
            this.notesRL = _notesRL;
        }


        /// <summary>
        /// Makes a note.
        /// </summary>
        /// <param name="notes">The notes.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public string MakeANote(AddingNotes notes)
        {
            try
            {
                return this.notesRL.MakeANote(notes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="notes">The notes.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public string UpdateNotes(long notesId, UpdateNotes notes)
        {
            try
            {
                return this.notesRL.UpdateNotes(notesId, notes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Changes the color.
        /// </summary>
        /// <param name="NotesId">The notes identifier.</param>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool ChangeColor(long NotesId, string colour)
        {
            try
            {
                return this.notesRL.ChangeColor(NotesId, colour);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                return this.notesRL.ArchiveNote(notesId);
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
                return this.notesRL.PinNotes(notesId);
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
                return this.notesRL.AddImage(notesId, path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Noteses this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Notes> Notes()
        {
            return this.notesRL.Notes();
        }

    }
     
}
