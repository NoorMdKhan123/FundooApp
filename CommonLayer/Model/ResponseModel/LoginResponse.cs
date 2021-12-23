using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model.ResponseModel
{
    public class LoginResponse
    {
        public long Id
        {
            get; set;
        }
       
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        

        public string EmailId { get; set; }

        

        public DateTime? Createat { get; set; }

       
        public DateTime? Modifiedat { get; set; }


    }
}
