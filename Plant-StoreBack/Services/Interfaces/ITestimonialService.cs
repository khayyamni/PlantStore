using Plant_StoreBack.ViewModels.Testimonial;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface ITestimonialService
    {
        Task<List<TestimonialVM>> GetAllAsync();

    }
}
