using BusinessLayer.Interfaces;
using CommonLayer.Model;
using CommonLayer.Model.ResponseModel;
using RepositoryLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        /// <summary>
        /// The user rl
        /// </summary>
        IUserRL userRL;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserBL"/> class.
        /// </summary>
        /// <param name="userRL">The user rl.</param>
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        /// <summary>
        /// Registrations the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public bool Registration(UserRegistration user)
        {
            try
            {
                return this.userRL.Registration(user);

            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// Gets the login.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns></returns>
        public LoginResponse Login(UserLogin credentials)
        {
            try
            {
                return this.userRL.Login(credentials);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IEnumerable<User> Users()
        {
            
                return this.userRL.Users();
            
        }

        public bool DeleteARecord(int id)
        {
            try
            {
                return this.userRL.DeleteARecord(id);

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool UpdateARecord( int id, UpdateUserDetails user)
        {
            try
            {
                return this.userRL.UpdateARecord(id, user);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        
        public string ForgotAPassword(string email)
        {
            try
            {
                return this.userRL.ForgotAPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ResetAPassword(ResetPasswordModel model)
        {
            try
            {
                return this.userRL.ResetAPassword(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}
