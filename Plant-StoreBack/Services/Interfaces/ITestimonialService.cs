using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Testimonial;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface ITestimonialService
    {
        Task<List<TestimonialVM>> GetAllAsync();
		Task<TestimonialVM> GetDataIdAsync(int id);
		Task CreateAsync(TestimonialCreateVM request);
		Task DeleteAsync(int id);
        Task EditAsync(TestimonialEditVM request);


    }
}
