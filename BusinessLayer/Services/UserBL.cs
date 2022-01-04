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
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
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
        public LoginResponse GetLogin(UserLogin credentials)
        {
            try
            {
                return this.userRL.GetLogin(credentials);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAllUser()
        {
            
                return this.userRL.GetAllUser();
            
        }

        public bool Delete(int id)
        {
            try
            {
                return this.userRL.Delete(id);

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool Update( int id, UpdateUserDetails user)
        {
            try
            {
                return this.userRL.Update(id, user);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        
        public string ForgotPassword(string email)
        {
            try
            {
                return this.userRL.ForgotPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ResetPassword(ResetPasswordModel model)
        {
            try
            {
                return this.userRL.ResetPassword(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}
