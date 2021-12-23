using CommonLayer.Model;
using CommonLayer.Model.ResponseModel;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        Context context;
        public UserRL(Context context)
        {
            this.context = context;
        }

        public LoginResponse GetLogin(UserLogin user1)
        {
            try
            {
                
                User validLogin= this.context.Users.Where(x => x.EmailId == user1.Email &&  x.Password == user1.Password ).FirstOrDefault();
 
                
                if (validLogin.Id != 0 && validLogin.EmailId != null)
                {
                    LoginResponse loginResponse = new LoginResponse();
                    loginResponse.Id = validLogin.Id;
                    loginResponse.FirstName = validLogin.FirstName;
                    loginResponse.LastName = validLogin.LastName;
                    loginResponse.EmailId = validLogin.EmailId;
                    loginResponse.Createat = validLogin.Createat;
                    loginResponse.Modifiedat = validLogin.Modifiedat;
                    return loginResponse;
                }
                else
                {
                    return null;
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool  Registration(UserRegistarion user)
        {
            try
            {
                User newUser = new User();
                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.EmailId = user.EmailId;
                newUser.Password = user.Password;
                newUser.Createat = DateTime.Now;

                this.context.Users.Add(newUser);
                int result = this.context.SaveChanges();
                if(result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
