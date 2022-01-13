using BusinessLayer.Interfaces;
using CommonLayer.Model;
using CommonLayer.Model.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace FundooApplication.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// 

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        /// <summary>
        /// The user bl
        /// </summary>
        private readonly IUserBL userBL;
        private IConfiguration _config;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userBL">The user bl.</param>
        /// <param name="_config">The configuration.</param>
        public UserController(IUserBL userBL, IConfiguration _config)
        {
            this.userBL = userBL;
            this._config = _config;
        }
        /// <summary>
        /// Gets all user.
        /// </summary>
        /// <returns></returns>

        [Authorize]
        [HttpGet("allUsers")]
        public IActionResult GetAllUser()
        {

            try
            {
                var userDetails = this.userBL.Users();
                if (userDetails == null)
                {
                    return this.BadRequest(new { Success = false, message = " User records not found" });
                }
                return this.Ok(new { Success = true, message = "User records found", userdata = userDetails });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, StackTraceException = ex.StackTrace });

            }
        }
        /// <summary>
        /// Users the registration.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("register")]
        public IActionResult UserRegistration(UserRegistration user)
        {
            try
            {
                if (this.userBL.Registration(user))
                {
                    return this.Ok(new { Success = true, message = "Registration Succesful", Data = user });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Registration Unsuccesful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, StackTraceException = ex.StackTrace });

            }
        }

        /// <summary>
        /// Gets the login.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult GetLogin([FromBody] UserLogin credentials)
        {
            try
            {
                LoginResponse result = this.userBL.Login(credentials);
                if (result.EmailId == null)
                {
                    return BadRequest(new { Success = false, message = "Email or Password not Found" });
                }
                return this.Ok(new { Success = true, message = "Login Successful", data = result });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{Id}")]

        public IActionResult Delete(int Id)
        {
            try
            {
                if (this.userBL.DeleteARecord(Id))
                {
                    return this.Ok(new { Success = true, message = "Record Deleted Succesfully" });

                }
                return this.BadRequest(new { Success = false, message = "Unsuccesful deletion of record" });

            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, StackTraceException = ex.StackTrace });
            }
        }
        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>

        [HttpPut("update/{Id}")]
        public IActionResult Update(int Id, UpdateUserDetails user)
        {
            try
            {

                if (this.userBL.UpdateARecord(Id, user))
                {
                    return this.Ok(new { Success = true, message = "Records Updated Succesfully", data = user });
                }
                return this.BadRequest(new { Success = false, message = "No data to update" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, StackTraceException = e.StackTrace });

            }
        }



        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        [HttpPost("forgotPassword/{email}")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                string result = this.userBL.ForgotAPassword(email);
                if (result.Equals("Email is sent sucessfully"))
                {
                    return this.Ok(new { Status = true, Message = "Email sent successfully to reset password", Data = email });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Password not Uppdated", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, StackTraceException = ex.StackTrace });
            }

        }


        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("resetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel model)
        {
            try
            {
                var value = this.userBL.ResetAPassword(model);
                if (value.Equals("Password is updated"))
                {
                    return this.Ok(new { Status = true, Message = "Reseted susccessfully ", Data = model });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Not done reset" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message, StackTraceException = ex.StackTrace });
            }
        }
    }
}




        
        
   









