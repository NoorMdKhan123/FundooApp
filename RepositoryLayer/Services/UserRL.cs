using CommonLayer.Model;
using CommonLayer.Model.ResponseModel;
using Experimental.System.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        
        Context context;
        IConfiguration _config;

        public UserRL(Context _context, IConfiguration _config)
        {
            this.context = _context;
            this._config = _config;
        }


        public LoginResponse Login(UserLogin user1)
        {
            try
            {

                User validLogin = this.context.Users.Where
                    (x => x.EmailId == user1.Email ).FirstOrDefault();



                if (SecureData.ConvertToDecrypt(validLogin.Password) == user1.Password)
                {
                    LoginResponse loginResponse = new LoginResponse();
                    string token = "";
                    token = GenerateJWTToken(validLogin.EmailId, validLogin.Id);
                    loginResponse.Id = validLogin.Id;
                    loginResponse.FirstName = validLogin.FirstName;
                    loginResponse.LastName = validLogin.LastName;
                    loginResponse.EmailId = validLogin.EmailId;
                    loginResponse.Createat = validLogin.Createat;
                    loginResponse.Modifiedat = validLogin.Modifiedat;
                    loginResponse.token = token;
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
        public IEnumerable<User> Users()
        {
            return context.Users.ToList();
        }

        public bool Registration(UserRegistration user)
        {
            try
            {
                User newUser = new User();
                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.EmailId = user.EmailId;
                newUser.Password = SecureData.ConvertToEncrypt(user.Password);
                newUser.Createat = DateTime.Today;
                newUser.Modifiedat = DateTime.Now;

                this.context.Users.Add(newUser);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        private string GenerateJWTToken(string EmailId, long UserId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim("EmailId",EmailId),
                   new Claim("UserId",UserId.ToString())
            };
            

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        _config["Jwt:Issuer"],
        claims,
        expires: DateTime.Now.AddMinutes(120),
        signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool DeleteARecord(int id)
        {

            try { 

               User data = this.context.Users.Where(s => s.Id == id).FirstOrDefault();

                if (data != null)
                {
                    this.context.Users.Remove(data);
                    this.context.SaveChanges();
                }
                return true;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool UpdateARecord(long Id, UpdateUserDetails user)
        {

            try
            {
                var person = this.context.Users.Find(Id);
                if (person == null)
                {
                    
                    throw new Exception("No user with given Id");
                }
                person.FirstName = user.FirstName;
                person.LastName = user.LastName;
                person.EmailId = user.EmailId;
                person.Password = SecureData.ConvertToEncrypt(user.Password);
                person.Createat = DateTime.Now;
                var response = this.context.Users.Update(person);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
                var validatedData = this.context.Users.Where(e => e.EmailId == email).FirstOrDefault();
                if (validatedData != null)
                {
                    var token = GenerateJWTToken(validatedData.EmailId, validatedData.Id);
                    new MsmqModel().MsmqSender(token);
                    return "Email is sent sucessfully";
                }
                else
                {
                    return "Email not sent";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ResetAPassword(ResetPasswordModel model)
        {
            try
            {
                var resetPassword = this.context.Users.FirstOrDefault(e => e.EmailId == model.EmailId);
                if (resetPassword != null)
                {
                    resetPassword.Password = SecureData.ConvertToEncrypt(model.NewPassword);
                    this.context.SaveChanges();
                    return "Password is updated";
                }
                return "Password not updated";
            }
            catch (Exception)
            {
                throw;
            }
        }
        //with message in email
        //public string ResetPassword(ResetPasswordModel model)
        //{
        //    try
        //    {
        //        var userData = this.context.Users.Where
        //             (x => x.EmailId == model.Email).FirstOrDefault();
        //        if (userData != null)
        //        {
        //            userData.Password = SecureData.ConvertToEncrypt(model.NewPassword);
        //            this.context.Update(userData);
        //            this.context.SaveChanges();
        //            return "Password is updated";
        //        }

        //        return "Password is not updated, please register yourself first";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public string ForgotPassword(string email)
        //{
        //    try
        //    {

        //        MailMessage mail = new MailMessage();
        //        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        //        mail.From = new MailAddress(this._config["Credentials:testEmailId"]);
        //        mail.To.Add(email);
        //        mail.Subject = "Test Mail";
        //        SendMSMQ();
        //        mail.Body = ReceiveMSMQ();
        //        SmtpServer.Host = "smtp.gmail.com";
        //        SmtpServer.Port = 587;
        //        SmtpServer.UseDefaultCredentials = false;
        //        SmtpServer.Credentials = new System.Net.NetworkCredential(this._config["Credentials:testEmailId"], this._config["Credentials:testEmailPassword"]);
        //        SmtpServer.EnableSsl = true;
        //        SmtpServer.Send(mail);
        //        return "Email is sent sucessfully";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}
        //public void SendMSMQ()
        //{
        //    MessageQueue msgQueue;
        //    if (MessageQueue.Exists(@".\Private$\fundoo"))
        //    {
        //        msgQueue = new MessageQueue(@".\Private$\fundoo");
        //    }
        //    else
        //    {
        //        msgQueue = MessageQueue.Create(@".\Private$\fundoo");
        //    }
        //    Message message = new Message();
        //    var formatter = new BinaryMessageFormatter();
        //    message.Formatter = formatter;
        //    message.Body = "This token is to reset password";
        //    msgQueue.Label = "MailBody";
        //    msgQueue.Send(message);
        //}
        //public string ReceiveMSMQ()
        //{
        //    var receivequeue = new MessageQueue(@".\Private$\fundoo");
        //    var receivemsg = receivequeue.Receive();
        //    receivemsg.Formatter = new BinaryMessageFormatter();
        //    return receivemsg.Body.ToString();
        //}






    }

    //public async Task<IActionResult> SendPasswordRessetCode(string email)
    //{

    //    if(string.IsNullOrEmpty(email))
    //    {
    //        throw new Exception("Email not found");
    //    }
    //    var user = this.context.Users.FindByNameAsync(User, email);
    //}
















    //this.context.Users.RemoveRange(data);
    //    int result = this.context.SaveChanges();
    //    if (result > 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        throw;
    //    }
    //public bool Delete(int id)
    //{
    //    try
    //    {
    //        User details = this.context.Users.Where
    //            (s => s.Id == id)
    //            .FirstOrDefault();
    //        this.context.Users.RemoveRange();
    //        int result = this.context.SaveChanges();
    //        if (result > 0)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        throw;
    //    }

    //}



}


     
    

