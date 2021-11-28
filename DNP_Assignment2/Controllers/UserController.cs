using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNP_Assignment2.Models;
using DNP_Assignment2.Services;
using Microsoft.AspNetCore.Mvc;

namespace DNP_Assignment2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class UserController : Controller
    {
        //UserServices _userServices = new();
        
        private readonly UserDBServices _userServices;
        public UserController(UserDBServices _userServices) => this._userServices = _userServices;

        [HttpGet ("{username},{password}")]
        public async Task<ActionResult<User>> Get(string username, string password)
        {
            try
            {
                User user = _userServices.ValidateUser(username,password);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            try
            {
                _userServices.AddUser(user);
                return Created($"/{user}", user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}