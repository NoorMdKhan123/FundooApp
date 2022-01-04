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
        bool Registration(UserRegistration user);
        IEnumerable<User> GetAllUser();
        LoginResponse GetLogin(UserLogin user1);
        bool Delete(int id);
        bool Update(int id, UpdateUserDetails user);
   
        //bool ResetPassword(string email);
        string ForgotPassword(string email);
        string ResetPassword(ResetPasswordModel model);
    }
}
