using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class ResetPasswordModel
    {
        [Required]
        public string EmailId { get; set; }
        public string NewPassword { get; set; }
    }
}




   
