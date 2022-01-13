using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface INotesRL
    {
        /// <summary>
        /// Makes a note.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns></returns>
        string MakeANote(AddingNotes notesModel);
        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="notes">The notes.</param>
        /// <returns></returns>
        string UpdateNotes(long notesId, UpdateNotes notes);
        /// <summary>
        /// Changes the color.
        /// </summary>
        /// <param name="NotesId">The notes identifier.</param>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        bool ChangeColor(long NotesId, string colour);
        /// <summary>
        /// Archives the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns></returns>

        string ArchiveNote(long notesId);
        /// <summary>
        /// Pins the notes.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns></returns>
        string PinNotes(long notesId);
        /// <summary>
        /// Adds the image.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        string AddImage(long notesId, IFormFile path);
        /// <summary>
        /// Noteses this instance.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Notes> Notes();


    }
}
