using Dapper;
using ShoppingCart.Model;
using ShoppingCartProject.Model;
using System.Data;

namespace ShoppingCartProject.Repository
{
    public class ShoppingCartRepository
    {

        SqlConnectionFactory connection = new SqlConnectionFactory();

        public async Task<CartItemRes> RetrieveUserShoppingCart(string userId)
        {
            CartItemRes response = new CartItemRes();

            List<Cart> CartList = new List<Cart>();

            List<Item> itemList = new List<Item>();
            try
            {
                using (IDbConnection conn = connection.CreateConnection())
                {
                    using (var multi = await conn.QueryMultipleAsync("spSelectUserShoppingCart2",
                    new
                    {
                        userId = userId
                    },
                    commandType: CommandType.StoredProcedure))
                    {
                        response.User = multi.Read<User>().FirstOrDefault();
                        CartList = multi.Read<Cart>().ToList();
                        itemList = multi.Read<Item>().ToList();


                        foreach (var header in CartList)
                        {
                            var detailsItems = itemList.Where(detail => detail.cartId == header.Id).ToList();
                            response.CartOrderList = new List<ItemResponse>();
                            response.CartOrderList.Add(new ItemResponse
                            {
                                Cart = header,
                                Items = detailsItems
                            });
                        }







                    }
                }

            }


            catch (Exception ex) { }
            return response;
        }
        public async Task<CodeMessage> CreateNewShoppingCart(Cart shopingCartInfo)
        {
            try
            {
                TypeTableInsertingHelper tb = new();
                var typeCart = tb.ConvertToDataTable(shopingCartInfo, "typeCart");

                using (IDbConnection conn = connection.CreateConnection())
                {

                    CodeMessage responseData = (await conn.QueryAsync<CodeMessage>("spCreateNewShoppingCart",
                        new
                        {
                            @cart = typeCart
                        },
                        commandType: CommandType.StoredProcedure, commandTimeout: 0)).FirstOrDefault();
                    return responseData;
                }
            }
            catch (Exception ex)
            {
                throw;
            }



        }

        public async Task<CodeMessage> AddItemToShoppingCart(ShoppingCartModel shopingCartInfo)
        {
            try
            {
                TypeTableInsertingHelper tb = new();
                var typeCartItem = tb.ConvertToDataTable(shopingCartInfo.CartOrder.Items, "typeCartItem");

                using (IDbConnection conn = connection.CreateConnection())
                {

                    CodeMessage responseData = (await conn.QueryAsync<CodeMessage>("spUpdateShoppingCart",
                        new
                        {

                            @cartItem = typeCartItem
                        },
                        commandType: CommandType.StoredProcedure, commandTimeout: 0)).FirstOrDefault();
                    return responseData;
                }
            }
            catch (Exception ex)
            {
                throw;
            }



        }

        public async Task<CodeMessage> RemoveItemFromShoppingCart(RemoveItemRes req)
        {
            try
            {
                TypeTableInsertingHelper tb = new();

                using (IDbConnection conn = connection.CreateConnection())
                {

                    CodeMessage responseData = (await conn.QueryAsync<CodeMessage>("spRemoveItem",
                        new
                        {
                            @userId = req.userId,
                            @cartId = req.cartId,
                            @productId = req.productId
                        },
                        commandType: CommandType.StoredProcedure, commandTimeout: 0)).FirstOrDefault();
                    return responseData;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<CodeMessage> CheckingOutOrder(CheckOutOrder order)
        {
            string query = "INSERT INTO [dbo].[ShoppingOrder] ([Id],[UserId],[CartId],[createdDate],[active]) VALUES(@Id,@UserId,@CartId,@createdDate,1)";
            try
            {
                using (IDbConnection conn = connection.CreateConnection())
                {
                    CodeMessage responseData = (await conn.QueryAsync<CodeMessage>(query, new
                    {
                        Id = order.Id,
                        UserId = order.UserId,
                        CartId = order.CartId,
                        createdDate = order.createdDate

                    })).FirstOrDefault();
                    responseData = new CodeMessage();
                    responseData.code = "001";
                    responseData.Message = "Success";
                    return responseData;
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
