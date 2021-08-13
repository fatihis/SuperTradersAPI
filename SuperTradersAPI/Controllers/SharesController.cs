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
    public class SharesController : Controller
    {
        //returns shares amounts in order to share's symbol
        [HttpGet("/getShareAmounts/")]
        public IEnumerable<Share> getShareAmount()
        {
            CRUDOperations context = HttpContext.RequestServices.GetService(typeof(CRUDOperations)) as CRUDOperations;
            return context.GetAllShares();
        }
        //lets user buy shares. In case of insufficent amounts, returns bad request
        [HttpPost("/buyShares/{shareSymbol}")]
        public IActionResult buyShares(string shareSymbol, User user, int amount)
        {
            CRUDOperations context = HttpContext.RequestServices.GetService(typeof(CRUDOperations)) as CRUDOperations;
            return StatusCode(context.BuyShare(user.userId,shareSymbol,amount));
        }
        [HttpPost("/sellShares/{shareSymbol}")]
        public IActionResult sellShares(string shareSymbol, User user, int amount)
        {
            CRUDOperations context = HttpContext.RequestServices.GetService(typeof(CRUDOperations)) as CRUDOperations;
            return StatusCode(context.SellShare(user.userId,shareSymbol,amount));
        }
       
        [HttpPost("/addShare/")]
        public IActionResult addShare(Share share)
        {
           CRUDOperations context = HttpContext.RequestServices.GetService(typeof(CRUDOperations)) as CRUDOperations;
            try
            {
                context.AddShare(share);
                return StatusCode(200);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("error: " + e);
                return StatusCode(400);
            }
        }
    }
}
