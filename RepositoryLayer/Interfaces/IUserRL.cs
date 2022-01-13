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
        IEnumerable<User> Users();
        LoginResponse Login(UserLogin user1);
        bool DeleteARecord(int id);
        bool UpdateARecord(long Id, UpdateUserDetails user);
        //bool ResetPassword(string email);
        string ForgotAPassword(string email);

        string ResetAPassword(ResetPasswordModel model);
    }
}
