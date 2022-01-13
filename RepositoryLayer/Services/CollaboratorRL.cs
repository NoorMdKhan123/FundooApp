using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class CollaboratorRL : ICollaboratorRL
    {
        private readonly Context context;
        IConfiguration Configuration;
        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorRL"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="userContext">The user context.</param>
        public CollaboratorRL(IConfiguration configuration, Context userContext)
        {
            this.Configuration = configuration;
            this.context = userContext;
        }
        /// <summary>
        /// Adds the colaborator.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="notesId">The notes identifier.</param>
        /// <param name="tokenId">The token identifier.</param>
        /// <returns></returns>
        public CollaboratorModel AddColaborator(CollaboratorModel model, long notesId, long tokenId)
        {
            try
            {
                var validId = this.context.Users.Where(x => x.Id == tokenId).FirstOrDefault();
                if (validId != null)
                {
                    Collaborator collaborator = new Collaborator();
                    collaborator.Id = tokenId;
                    collaborator.NotesId = notesId;
                    collaborator.EmailCollaborated = model.EmailId;
                    this.context.Add(collaborator);
                    this.context.SaveChanges();
                    return model;
                }
                return model;
            }
            catch (Exception ex)
            {
                throw;

            }
        }
        /// <summary>
        /// Gets all collaborator.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public List<Collaborator> GetAllCollaborator()
        {
            try { 
                return context.Collaborator.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Collaborators the specified collabid.
        /// </summary>
        /// <param name="collabid">The collabid.</param>
        /// <returns></returns>
        public bool Collaborator(long collabid)
        {
            try
            {
                var result = this.context.Collaborator.Where(x => x.CollaboratorId == collabid).FirstOrDefault();
                if (result != null)
                {
                    this.context.Collaborator.Remove(result);
                    this.context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw;

            }

        }

       
    }
}





