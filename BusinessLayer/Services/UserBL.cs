﻿using BusinessLayer.Interfaces;
using CommonLayer.Model;
using CommonLayer.Model.ResponseModel;
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
        public bool Registration(UserRegistarion user)
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

        public LoginResponse GetLogin(UserLogin user1)
        {
            try
            {
                return this.userRL.GetLogin(user1);

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
