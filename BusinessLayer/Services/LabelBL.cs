
using BusinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class LabelBL : ILabelBL
    {
        ILabelRL labelRL;
        public LabelBL(ILabelRL _labelRL)
        {
            labelRL = _labelRL;
        }
        public string AddLabelByNotesId(long notesId,  LabelModel model)
        {
            try
            {
                return this.labelRL.AddLabelByNotesId(notesId, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        

        public string AddLabelByUserId(LabelModelData labelData)
        {
            try
            {
                return this.labelRL.AddLabelByUserId(labelData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EditLable(long labelId, LabelModel model)
        {
            try
            {
                return this.labelRL.EditLable(labelId, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public IEnumerable<Label> GetLabelByNoteId(long notesId)
        {
            try
            {
                return this.labelRL.GetLabelByNoteId(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public IEnumerable<Label> GetLabelByUserId(long userId)
        {
            try
            {
                return this.labelRL.GetLabelByNoteId(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }



        public string RemoveLabel(long labelId)
        {
            try
            {
                return this.labelRL.RemoveLabel(labelId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        
    }

       
}
          