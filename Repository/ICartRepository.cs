namespace DMobileSite.Repository
{
    public interface ICartRepository
    {
        Task<int> AddItem(int mobileId, int qnt);
        Task<int> RemoveItem(int mobileId);
        Task<ShoppingCart> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<ShoppingCart> GetCart(string userId);
        Task<bool> DoCheckout(CheckoutModel model);
    }
}
