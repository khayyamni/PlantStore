using Plant_StoreBack.Helpers.Responses;
using Plant_StoreBack.Models;
using Plant_StoreBack.ViewModels.Basket;
using Plant_StoreBack.ViewModels.Product;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IBasketService
    {
        void AddBasket(int id, ProductVM product);
        int GetCount();
        Task<List<BasketDetailVM>> GetBasketDatasAsync();
        Task<CountPlusAndMinus> PlusIcon(int id);
        Task<CountPlusAndMinus> MinusIcon(int id);
        Task<DeleteBasketItemResponse> DeleteItem(int id);
        List<BasketVM> GetDatasFromCoockies();
        Task<Basket> GetByUserIdAsync(string userId);
        Task<List<BasketProduct>> GetAllByBasketIdAsync(int? basketId);

    }
}
