using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Manager;
using ShoppingCart.Model;
using ShoppingCartProject.Manager;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : ControllerBase
    {


        private readonly ILogger<ShoppingCartController> _logger;
        public readonly ShoppingCartManager _shoppingCartManager;
        public readonly WriteLoging log;

        public ShoppingCartController(ILogger<ShoppingCartController> logger)
        {
            _logger = logger;
            this._shoppingCartManager = new ShoppingCartManager();
            this.log = new WriteLoging();


        }

        [HttpPost("CreateNewShoppingCart")]
        public async Task<IActionResult> CreateNewShoppingCart(string userId)
        {
            this.log.WriteLog("CreateNewShoppingCart start : { UserId : " + userId + "}");
            var data = await this._shoppingCartManager.CreateNewShoppingCart(userId);
            if (data != null)
            {
                this.log.WriteLog("CheckingOutOrder End : { code : " + data.code + ", Message : " + data.Message + "}");
                return Ok(new { code = "001", message = "Success", data = data });

            }
            this.log.WriteLog("CheckingOutOrder End : { code : 002" + ", Message : Not Success" + "}");
            return Ok(new { code = "002", message = "Not Success", data = data });
        }



        [HttpPost("GetShoppingCartListByUser")]
        public Task<CartItemRes> GetShoppingCartListByUser(string userId)
        {
            this.log.WriteLog("GetShoppingCartListByUser start : { UserId : " + userId + "}");
            return this._shoppingCartManager.GetShoppingCartListByUser(userId);
        }


        [HttpPost("AddItemToShoppingCart")]
        public async Task<IActionResult> AddItemToShoppingCart([FromBody] AddItemPayload req)
        {
            this.log.WriteLog("AddItemToShoppingCart start : { UserId : " + req.userId + "}");
            var data = await this._shoppingCartManager.AddItemToShoppingCart(req);
            if (data != null)
            {
                this.log.WriteLog("AddItemToShoppingCart End : { code : " + data.code + ", Message : " + data.Message + "}");
                return Ok(new { code = "001", message = "Success", data = data });

            }
            this.log.WriteLog("AddItemToShoppingCart End : { code : 002" + ", Message : Not Success" + "}");
            return Ok(new { code = "002", message = "Not Success", data = data });
        }
        [HttpPost("RemoveItemFromShoppingCart")]
        public async Task<IActionResult> RemoveItemFromShoppingCart(RemoveItemRes req)
        {
            this.log.WriteLog("RemoveItemFromShoppingCart start : { UserId : " + req.userId + "}");
            var data = await this._shoppingCartManager.RemoveItemFromShoppingCart(req);
            if (data != null)
            {
                this.log.WriteLog("RemoveItemFromShoppingCart End : { code : " + data.code + ", Message : " + data.Message + "}");
                return Ok(new { code = "001", message = "Success", data = data });

            }
            this.log.WriteLog("RemoveItemFromShoppingCart End : { code : 002" + ", Message : Not Success" + "}");
            return Ok(new { code = "002", message = "Not Success", data = data });
        }

        [HttpPost("CheckingOutOrder")]
        public async Task<IActionResult> CheckingOutOrder([FromBody] CheckOutOrderReq req)
        {


            this.log.WriteLog("CheckingOutOrder start : { UserId : " + req.UserId + ", cartId : " + req.CartId + "}");

            var data = await this._shoppingCartManager.CheckingOutOrder(req);
            if (data != null)
            {
                this.log.WriteLog("CheckingOutOrder End : { code : " + data.code + ", Message : " + data.Message + "}");
                return Ok(new { code = "001", message = "Success", data = data });


            }
            this.log.WriteLog("CheckingOutOrder End : { code : 002" + ", Message : Not Success" + "}");
            return Ok(new { code = "002", message = "Not Success", data = data });
        }
    }
}