
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
    public class CollaboratorBL : ICollaboratorBL
    {
        ICollaboratorRL collaboratorRL;

        public CollaboratorBL(ICollaboratorRL collaboratorRL)
        {
            this.collaboratorRL = collaboratorRL;
        }

        

        public CollaboratorModel AddColaborator(CollaboratorModel model, long notesId, long tokenId)
        {
            try
            {
                return this.collaboratorRL.AddColaborator(model, notesId, tokenId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public bool Collaborator(long collabid)
        {
            try
            {
                return this.collaboratorRL.Collaborator(collabid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Collaborator> CollaboratorById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Collaborator> CollaboratorByNotesId(long notesId)
        {
            throw new NotImplementedException();
        }

        public List<Collaborator> GetAllCollaborator()
        {
            try
            {
                return this.collaboratorRL.GetAllCollaborator();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }

   
}
