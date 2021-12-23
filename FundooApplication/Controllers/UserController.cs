using BusinessLayer.Interfaces;
using CommonLayer.Model;
using CommonLayer.Model.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FundooApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }


        [HttpPost]
        public IActionResult UserRegistration(UserRegistarion user)
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
        [HttpPost("Login")]
        public IActionResult GetLogin(UserLogin user1)
        {
            try
            {
                LoginResponse result = this.userBL.GetLogin(user1);
                if (result.EmailId == null)
                {
                    return BadRequest(new { Success = false, message = "Email or Password Not Found" });
                }
                return Ok(new { Success = true, message = "Login Successful" , data = result });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }
    }
}
