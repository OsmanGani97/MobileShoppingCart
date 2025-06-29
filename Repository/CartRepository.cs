using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace DMobileSite.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public CartRepository(ApplicationDbContext db,IHttpContextAccessor httpContextAccessor,UserManager<IdentityUser> userManager) 
        {
           _db = db;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public async Task<int> AddItem(int mobileId,int qnt)
        {
            string userId = GetUserId();
            using var transaction =_db.Database.BeginTransaction();
            try
            {
                
                if (string.IsNullOrEmpty(userId))
                    throw new UnauthorizedAccessException("user is not logged-in");

                var cart = await GetCart(userId);
                if (cart is null)
                {
                    cart = new ShoppingCart
                    {
                        UserId = userId
                    };
                    _db.ShoppingCarts.Add(cart);
                }
                _db.SaveChanges();
                //cart details section
            
                
                var cartItem=_db.CartDetails.FirstOrDefault(a=>a.ShoppingCartId==cart.Id && a.MobileId==mobileId);
                if (cartItem != null)
                {
                    cartItem.Quantity += qnt;
                }
                else
                {
                    var mobile = _db.Mobiles.Find(mobileId);
                    cartItem = new CartDetail
                    {
                        MobileId = mobileId,
                        ShoppingCartId = cart.Id,
                        Quantity= qnt,
                        UnitPrice=mobile.Price
                    };
                    _db.CartDetails.Add(cartItem);
                }
                _db.SaveChanges();
                transaction.Commit();
               


            }


            catch (Exception ex)
            {

            }
            var cartItemCount=await GetCartItemCount(userId);
            return cartItemCount;
        }

       
        public async Task<int> RemoveItem(int mobileId)
        {
            string userId = GetUserId();
            //using var transaction = _db.Database.BeginTransaction();
            try
            {
               
                if (string.IsNullOrEmpty(userId))
                    throw new UnauthorizedAccessException("user is not logged-in");

                var cart = await GetCart(userId);
                if (cart is null)
                {
                    throw new InvalidOperationException("Invalid cart");

                }
                _db.SaveChanges();
                //cart details section


                var cartItem = _db.CartDetails
                    .FirstOrDefault(a => a.ShoppingCartId == cart.Id && a.MobileId == mobileId);

                if (cartItem is null)
                {
                    throw new InvalidOperationException("Not items in cart");
                }
                 else if (cartItem.Quantity==1)

                {
                    _db.CartDetails.Remove(cartItem);
                }
                else
                {
                    cartItem.Quantity=cartItem.Quantity-1;
                }
                _db.SaveChanges();
                //transaction.Commit();
               


            }


            catch (Exception ex)
            {
               
            }
            var cartItemCount = await GetCartItemCount(userId);
            return cartItemCount;

        }
        public async Task<ShoppingCart> GetUserCart()
        {
            var userId = GetUserId();
            if (userId == null)
                throw new InvalidOperationException("Invalid userid");
            var shoppingCart = await _db.ShoppingCarts
                                   .Include(a => a.CartDetails)
                                  .ThenInclude(a => a.Mobile)
                                  .ThenInclude(a => a.Stock)
                                  .Include(a => a.CartDetails)
                                  .ThenInclude(a => a.Mobile)
                                  .ThenInclude(a => a.Brands)
                                  .Where(a => a.UserId == userId).FirstOrDefaultAsync();
            return shoppingCart;
        }


        public async Task< ShoppingCart> GetCart(string userId)
        {
            var cart= await _db.ShoppingCarts.FirstOrDefaultAsync(x => x.UserId == userId);
            return cart;
        }

        public async Task<int> GetCartItemCount(string userId="")
        {
            if (string.IsNullOrEmpty(userId))
            {
                userId = GetUserId();
            }
            var data = await (from cart in _db.ShoppingCarts
                            join CartDetail in _db.CartDetails
                            on cart.Id equals CartDetail.ShoppingCartId
                              where cart.UserId == userId
                              select new {CartDetail.Id}
                            ).ToListAsync();
            return data.Count;
        }

        public async Task<bool> DoCheckout(CheckoutModel model)
        {
            using var transaction=_db.Database.BeginTransaction();
            try
            {

                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                    throw new UnauthorizedAccessException("User is not logged-in");
                var cart = await GetCart(userId);
                if (cart is null)
                    throw new InvalidOperationException("Invalid cart");
                var cartDetail = _db.CartDetails
                                    .Where(a => a.ShoppingCartId == cart.Id).ToList();
                if (cartDetail.Count == 0)
                    throw new InvalidOperationException("Cart is empty");
                var pendingRecord = _db.OrderStatuss.FirstOrDefault(s => s.StatusName == "Pending");
                if (pendingRecord is null)
                    throw new InvalidOperationException("Order status does not have Pending status");

                var order = new Order
                {
                    UserId = userId,
                    CreateDate = DateTime.Now,
                    Name = model.Name,
                    Email = model.Email,
                    MobileNumber = model.MobileNumber,
                    PaymentMethod = model.PaymentMethod,
                    Address = model.Address,
                    IsPaid = false,
                    OrderStatusId = pendingRecord.Id
                };
                _db.Orders.Add(order);
                _db.SaveChanges();
                foreach (var item in cartDetail)
                {
                    var orderDetail = new OrderDetail
                    {
                        MobileId = item.MobileId,
                        OrderId = order.Id,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    };
                    _db.OrderDetails.Add(orderDetail);
                    // update stock here

                    var stock = await _db.Stocks.FirstOrDefaultAsync(a => a.MobileId == item.MobileId);
                    if (stock == null)
                    {
                        throw new InvalidOperationException("Stock is null");
                    }

                    if (item.Quantity > stock.Quantity)
                    {
                        throw new InvalidOperationException($"Only {stock.Quantity} items(s) are available in the stock");
                    }
                    // decrease the number of quantity from the stock table
                    stock.Quantity -= item.Quantity;
                }

                // removing the cartdetails
                _db.CartDetails.RemoveRange(cartDetail);
                _db.SaveChanges();
                transaction.Commit();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId=_userManager.GetUserId(principal);
            return userId;
        }
    }
}
