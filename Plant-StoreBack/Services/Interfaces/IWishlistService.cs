using Plant_StoreBack.Models;
using Plant_StoreBack.ViewModels.Product;
using Plant_StoreBack.ViewModels.Wishlist;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IWishlistService
    {
        int AddWishlist(int id, ProductVM product);
        int GetCount();
        Task<List<WishlistDetailVM>> GetWishlistDatasAsync();
        void DeleteItem(int id);
        List<WishlistVM> GetDatasFromCoockies();
        void SetDatasToCookies(List<WishlistVM> wishlist, Product dbProduct, WishlistVM existProduct);
        Task<Wishlist> GetByUserIdAsync(string userId);
        Task<List<WishlistProduct>> GetAllByWishlistIdAsync(int? wishlistId);
    }
}
