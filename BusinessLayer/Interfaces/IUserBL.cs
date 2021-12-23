using CommonLayer.Model;
using CommonLayer.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        bool Registration(UserRegistarion user);

        LoginResponse GetLogin(UserLogin user1);
    }
}
