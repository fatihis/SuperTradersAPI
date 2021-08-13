using Microsoft.AspNetCore.Mvc;
using SuperTradersAPI.Models;
using SuperTradersAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperTradersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet("/getAllUsers")]
        public List<User> getAllUsers()
        {
            CRUDOperations context = HttpContext.RequestServices.GetService(typeof(CRUDOperations)) as CRUDOperations;
            return context.GetAllUsers();
        }[HttpGet("/getUser/{userId}")]
        public User getUser(int userId)
        {
            CRUDOperations context = HttpContext.RequestServices.GetService(typeof(CRUDOperations)) as CRUDOperations;
            return context.GetUser(userId);
        }
        [HttpPut("/updateUser")]
        public IActionResult updateUser(User UpdateData)
        {
            CRUDOperations context = HttpContext.RequestServices.GetService(typeof(CRUDOperations)) as CRUDOperations;
            try
            {
                context.UpdateUser(UpdateData);
                return StatusCode(200);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("error: " + e);
                return StatusCode(400);
            }
        }
        [HttpPost("/addUser")]
        public IActionResult addUser(User UserData)
        {
            CRUDOperations context = HttpContext.RequestServices.GetService(typeof(CRUDOperations)) as CRUDOperations;
            try
            {
                context.AddUser(UserData);
                return StatusCode(200);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("error: " + e);
                return StatusCode(400);
            }
        }
        [HttpPost("/deleteUser/{userId}")]
        public IActionResult deleteUser(int userId)
        {
            CRUDOperations context = HttpContext.RequestServices.GetService(typeof(CRUDOperations)) as CRUDOperations;
            try
            {
                context.deleteUser(userId);
                return StatusCode(200);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("error: " + e);
                return StatusCode(400);
            }
        }
        [HttpPost("/addWallet/")]
        public IActionResult addWallet(int id)
        {
            CRUDOperations context = HttpContext.RequestServices.GetService(typeof(CRUDOperations)) as CRUDOperations;
            try
            {
                context.AddWallet(new Wallet{walletId= id, walletSharesId = id });
                return StatusCode(200);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("error: " + e);
                return StatusCode(400);
            }
        }
        [HttpGet("/getAllLogs/")]
        public List<Log> getAllLogs()
        {
            CRUDOperations context = HttpContext.RequestServices.GetService(typeof(CRUDOperations)) as CRUDOperations;

            return context.GetAllLogs();
        }
        [HttpGet("/getUserLogs/{id}")]
        public List<Log> getUserLogs(int id)
        {
            CRUDOperations context = HttpContext.RequestServices.GetService(typeof(CRUDOperations)) as CRUDOperations;
            return context.GetLogByUserId(id);
        }
    }
}
