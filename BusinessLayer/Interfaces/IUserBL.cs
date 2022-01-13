using CommonLayer.Model;
using CommonLayer.Model.ResponseModel;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        /// <summary>
        /// Registrations the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        bool Registration(UserRegistration user);
        /// <summary>
        /// Userses this instance.
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> Users();
        /// <summary>
        /// Gets the login.
        /// </summary>
        /// <param name="user1">The user1.</param>
        /// <returns></returns>
        LoginResponse Login(UserLogin user1);
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        bool DeleteARecord(int id);
        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        bool UpdateARecord(int id, UpdateUserDetails user);
        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        string ForgotAPassword(string email);
        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        string ResetAPassword(ResetPasswordModel model);

    }
}
