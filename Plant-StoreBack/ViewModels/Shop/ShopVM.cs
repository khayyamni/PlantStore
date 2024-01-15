using Plant_StoreBack.ViewModels.Category;
using Plant_StoreBack.ViewModels.Product;

namespace Plant_StoreBack.ViewModels.Shop
{
    public class ShopVM
    {
        public List<ProductVM> Product { get; set; }
        public CategoryVM Category { get; set; }
    }
}
