namespace Plant_StoreBack.ViewModels.Banner
{
    public class BannerEditVM
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Desc { get; set; }
		public IFormFile Photo { get; set; }
		public string Image { get; set; }
	}
}
