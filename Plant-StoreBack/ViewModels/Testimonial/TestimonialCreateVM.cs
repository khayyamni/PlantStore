using System.ComponentModel.DataAnnotations;

namespace Plant_StoreBack.ViewModels.Testimonial
{
	public class TestimonialCreateVM
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }

		[Required]
		public string Position { get; set; }

		[Required]
		public IFormFile Photo { get; set; }
	}
}
