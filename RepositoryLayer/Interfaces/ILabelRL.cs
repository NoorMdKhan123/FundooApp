using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ILabelRL
    {
        string AddLabelByNotesId(long notesId,  LabelModel model);
        string AddLabelByUserId(LabelModelData labelData);
        string EditLable(long labelId , LabelModel model);
        string RemoveLabel(long labelId);
        IEnumerable<Label> GetLabelByNoteId(long notesId);
        IEnumerable<Label> GetLabelByUserId(long userId);
    }
}
