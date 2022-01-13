using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer
{
    public class Notes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long NotesId { get; set; }

        //inluding reference navigation property of the type User in Notes entity class.


        //Foreign Key comumn in notesTable match a Primary Key in Users table.


        public string Title { get; set; }

        public string TakeANote { get; set; }

        public string RemindMe { get; set; }

        public string Colour { get; set; }

        public string Image { get; set; }

        [DefaultValue(false)]
        public bool IsArchive { get; set; }

        [DefaultValue(false)]
        public bool IsTrash { get; set; }

        [DefaultValue(false)]
        public bool IsNotePinned { get; set; }

        public long Id { get; set; }

        public ICollection<Collaborator> collaborators { get; set; }

        public ICollection<Label> labels { get; set; }
    }
}













   









   
