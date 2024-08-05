using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Model
{
    public class ShoppingCartModel
    {
        public CartOrder CartOrder { get; set; }

        [Required]
        public string UserId { get; set; }


    }
}
