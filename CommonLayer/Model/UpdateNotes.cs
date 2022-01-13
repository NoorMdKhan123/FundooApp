using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class UpdateNotes
    {
        public string Title { get; set; }

        public string TakeANote { get; set; }

        public string RemindMe { get; set; }

        public string Colour { get; set; }

        public string Image { get; set; }

        public bool IsArchive { get; set; }

        public bool IsTrash { get; set; }

        public bool IsNotePinned { get; set; }
    }
}
