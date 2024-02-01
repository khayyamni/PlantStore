
using Plant_StoreBack.ViewModels.Product;

namespace Plant_StoreBack.ViewModels.Category
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductVM> Products { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
