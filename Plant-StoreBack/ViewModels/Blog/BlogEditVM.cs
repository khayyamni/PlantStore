namespace Plant_StoreBack.ViewModels.Blog
{
    public class BlogEditVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
        public string Image { get; set; }
    }
}
