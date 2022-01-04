using CommonLayer.Model;
using CommonLayer.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        bool Registration(UserRegistration user);
        IEnumerable<User> GetAllUser();
        LoginResponse GetLogin(UserLogin user1);
        bool Delete(int id);
        bool Update(long Id, UpdateUserDetails user);
        //bool ResetPassword(string email);
        string ForgotPassword(string email);

        string ResetPassword(ResetPasswordModel model);
    }
}
