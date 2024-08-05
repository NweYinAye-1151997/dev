using ShoppingCart.Model;
using ShoppingCartProject.Model;
using ShoppingCartProject.Repository;

namespace ShoppingCart.Manager
{
    public class ShoppingCartManager
    {
        ShoppingCartRepository shoppingCartRepository;
        public ShoppingCartManager()
        {
            this.shoppingCartRepository = new ShoppingCartRepository();
        }

        public Task<CartItemRes> GetShoppingCartListByUser(string userId)
        {
            return this.shoppingCartRepository.RetrieveUserShoppingCart(userId);
        }

        public Task<CodeMessage> AddItemToShoppingCart(AddItemPayload req)
        {

            ShoppingCartModel shopingCartInfo = new ShoppingCartModel();
            foreach (var item in req.itemlist)
            {


                CartItem cartitem = new CartItem();
                cartitem.Id = Guid.NewGuid().ToString().ToLower();
                cartitem.Qty = item.Qty;
                cartitem.ProductId = item.ProductId;
                cartitem.CartId = req.cartId;
                cartitem.active = true;

                shopingCartInfo.CartOrder = new CartOrder();
                shopingCartInfo.CartOrder.Items = new List<CartItem>();
                shopingCartInfo.CartOrder.Cart = new Cart();

                shopingCartInfo.CartOrder.Items.Add(cartitem);




            }

            return this.shoppingCartRepository.AddItemToShoppingCart(shopingCartInfo);


        }

        public Task<CodeMessage> CreateNewShoppingCart(string userId)
        {
            Cart shopingCartInfo = new Cart();
            shopingCartInfo.Id = Guid.NewGuid().ToString().ToLower();
            shopingCartInfo.UserId = userId;
            shopingCartInfo.active = true;


            return this.shoppingCartRepository.CreateNewShoppingCart(shopingCartInfo);


        }
        public Task<CodeMessage> RemoveItemFromShoppingCart(RemoveItemRes req)
        {
            return this.shoppingCartRepository.RemoveItemFromShoppingCart(req);
        }

        public Task<CodeMessage> CheckingOutOrder(CheckOutOrderReq order)
        {
            CheckOutOrder orderInfo = new CheckOutOrder();
            orderInfo.Id = Guid.NewGuid().ToString().ToLower();
            orderInfo.UserId = order.UserId;
            orderInfo.CartId = order.CartId;
            orderInfo.active = true;
            orderInfo.createdDate = DateTime.Now;
            return this.shoppingCartRepository.CheckingOutOrder(orderInfo);
        }

    }
}
