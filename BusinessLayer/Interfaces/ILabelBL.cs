using System;
using CommonLayer.Model;
using RepositoryLayer.Entities;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ILabelBL 
    {
        string AddLabelByNotesId(long notesId, LabelModel model);
        string AddLabelByUserId(LabelModelData labelData);
        string EditLable(long labelId, LabelModel model);
      
        string RemoveLabel(long labelId);
        IEnumerable<Label> GetLabelByNoteId(long notesId);
        IEnumerable<Label> GetLabelByUserId(long userId);
        
    }
}
