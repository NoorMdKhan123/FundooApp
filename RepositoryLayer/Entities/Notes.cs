using CommonLayer.Model;
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
        public User user { get; set; }

        [ForeignKey("Users")]
        public long Id { get; set; }
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
    }
}









   
