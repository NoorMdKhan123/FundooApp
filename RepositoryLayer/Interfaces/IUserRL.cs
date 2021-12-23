using CommonLayer.Model;
using CommonLayer.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        bool Registration(UserRegistarion user);
        LoginResponse GetLogin(UserLogin user1);


    }
}
