using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CommonLayer.Model
{
    public class AddingNotes
    {
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

