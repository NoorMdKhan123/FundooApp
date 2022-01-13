using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ICollaboratorBL
    {

        CollaboratorModel AddColaborator(CollaboratorModel model, long tokenId, long notesId);

        List<Collaborator> GetAllCollaborator();


        bool Collaborator(long collabid);

        List<Collaborator> CollaboratorById(long id);
        List<Collaborator> CollaboratorByNotesId(long notesId);
    }
}
