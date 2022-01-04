
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NotesRL : INotesRL
    {
        
        private readonly Context context;
        public IConfiguration Configuration { get; }
        public NotesRL(IConfiguration configuration, Context userContext)
        {
            this.Configuration = configuration;
            this.context = userContext;
        }
        public string MakeANote(AddingNotes notes)
        {
            try
            {
                Notes newNotes = new Notes();
                newNotes.Title = notes.Title;
                newNotes.TakeANote = notes.TakeANote;
                newNotes.RemindMe = notes.RemindMe;
                newNotes.Colour = notes.Colour;
                newNotes.Image = notes.Image;
                newNotes.IsArchive = notes.IsArchive;
                newNotes.IsNotePinned= notes.IsNotePinned;
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
    }


}
