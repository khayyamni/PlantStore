namespace Plant_StoreBack.ViewModels.Company
{
    public class CompanyEditVM
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        public IFormFile Photo { get; set; }

        public string DescLeft { get; set; }
        public string DescRight { get; set; }
    }
}
