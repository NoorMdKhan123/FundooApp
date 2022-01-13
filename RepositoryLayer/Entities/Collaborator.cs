using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entities
{
    public class Collaborator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CollaboratorId { get; set; }

        public string EmailCollaborated { get; set; }

        public Notes notes { get; set; }
        public long NotesId { get; set; }

        public User User { get; set; }
        public long Id { get; set; }
    }
}
        

        
        













    
