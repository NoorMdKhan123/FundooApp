using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ICollaboratorRL
    {

        CollaboratorModel AddColaborator(CollaboratorModel model, long notesId, long tokenId);

        List<Collaborator> GetAllCollaborator();

        bool Collaborator(long collabid);
       
    }
}
