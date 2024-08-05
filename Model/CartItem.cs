using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Model
{
    public class CartItem
    {
        public string Id { get; set; }
        public int Qty { get; set; }
        public string ProductId { get; set; }
        public string CartId { get; set; }
        public bool active { get; set; }

    }

    public class Item
    {
        public string cartId { get; set; }
        public int Qty { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductDescription { get; set; }
        public decimal? Price { get; set; }
    }

    public class Cart
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public bool active { get; set; }


    }

    public class CartOrder
    {
        public Cart Cart { get; set; }
        public List<CartItem> Items { get; set; }
    }

    public class CartItemRes
    {

        public User User { get; set; }
        public List<ItemResponse> CartOrderList { get; set; }

    }
    public class ItemResponse
    {
        public Cart Cart { get; set; }
        public List<Item> Items { get; set; }
    }
    public class ShoppingUserResponse
    {
        public User User { get; set; }
        public List<CartOrder> CartOrderList { get; set; }


    }

    public class AddItemReq
    {

        public int Qty { get; set; }
        public string ProductId { get; set; }

    }

    public class AddItemPayload
    {
        [Required]
        public string cartId { get; set; }
        [Required]
        public string userId { get; set; }
        public List<AddItemReq> itemlist { get; set; }
    }

    public class RemoveItemRes
    {
        [Required]
        public string userId { get; set; }
        [Required]
        public string cartId { get; set; }
        [Required]
        public string productId { get; set; }

    }

    public class CheckOutOrder : CheckOutOrderReq
    {
        public string Id { get; set; }
        public DateTime createdDate { get; set; }
        public bool active { get; set; }
    }

    public class CheckOutOrderReq
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string CartId { get; set; }
    }

}
