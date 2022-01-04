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
    
    [Route("Api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        private IConfiguration _config;

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
        [HttpGet("UserDetails")]
        public IActionResult GetAllUser()
        {

            try
            {
                var userDetails = this.userBL.GetAllUser();
                if (userDetails == null)
                {
                    return this.BadRequest(new { Success = false, message = " User records not found" });
                }
                return this.Ok(new { Success = true, message = "User records found", userdata = userDetails });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }
        /// <summary>
        /// Users the registration.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost("Register")]
        public IActionResult UserRegistration(UserRegistration user)
        {
            try
            {
                if (this.userBL.Registration(user))
                {
                    return this.Ok(new { Success = true, message = "Registration Succesful" });

                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Registration Unsuccesful" });

                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }
        /// <summary>
        /// Gets the login.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns></returns>
        [HttpPost("Login")]
        public IActionResult GetLogin([FromBody] UserLogin credentials)
        {
            try
            {

                LoginResponse result = this.userBL.GetLogin(credentials);
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
        [HttpDelete("DeleteById")]
        public IActionResult Delete(int Id)
        {
            try {




                if (this.userBL.Delete(Id))
                {
                    return this.Ok(new { Success = true, message = "Records Deletes Succesfully" });

                }
                return this.BadRequest(new { Success = false, message = " Unsuccesful" });

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });

            }

         }
        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPut("UpdateDetails")]
        public IActionResult Update(int Id, UpdateUserDetails user)
        {
            try
            {

                if (this.userBL.Update(Id, user))
                {
                    return this.Ok(new { Success = true, message = "Records Updated Succesfully" });
                }
                return this.BadRequest(new { Success = false, message = " No data to update" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });

            }


        }
        //[HttpGet]
        //public IActionResult ResetPassword(string email)
        //{
        //    try
        //    {

        //        if (this.userBL.ResetPassword(email))
        //        {
        //            return this.Ok(new { Success = true, message = "Reset link sent successfully" });
        //        }
        //        return this.BadRequest(new { Success = false, message = "Email Id not found" });
        //    }
        //    catch (Exception e)
        //    {
        //        return this.BadRequest(new { Success = false, message = e.Message });

        //    }
        //}
        [HttpPost("ForgotPassword")]
        
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                string result = this.userBL.ForgotPassword(email);
                if (result.Equals("Email is sent sucessfully"))
                {
                    return this.Ok(new ResponseModl<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModl<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModl<string>() { Status = false, Message = ex.Message });
            }

        }
        [HttpPut("ResetPassword")]
        
        public IActionResult ResetPassword([FromBody] ResetPasswordModel model)
        {
            try
            {
                string value = this.userBL.ResetPassword(model);
                if (value.Equals("Got an email"))
                {
                    return this.Ok(new ResponseModl<string>() { Status = true, Message = value });
                }
                else
                {
                    return this.BadRequest(new ResponseModl<string>() { Status = false, Message = value });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModl<string>() { Status = false, Message = ex.Message });
            }
        }




        
        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult<User>> DeleteEmployee(int id)
        //{
        //    try
        //    {
        //        var employeeToDelete = await employeeRepository.GetEmployee(id);

        //        if (employeeToDelete == null)
        //        {
        //            return NotFound($"Employee with Id = {id} not found");
        //        }

        //        return await employeeRepository.DeleteEmployee(id);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error deleting data");
        //    }
        //}
    }
}










