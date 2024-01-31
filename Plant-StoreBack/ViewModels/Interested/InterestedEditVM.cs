namespace Plant_StoreBack.ViewModels.Interested
{
    public class InterestedEditVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
        public string Image { get; set; }
    }
}
