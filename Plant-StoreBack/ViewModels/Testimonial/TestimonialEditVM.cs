namespace Plant_StoreBack.ViewModels.Testimonial
{
    public class TestimonialEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public IFormFile Photo { get; set; }
        public string Image { get; set; }
    }
}
