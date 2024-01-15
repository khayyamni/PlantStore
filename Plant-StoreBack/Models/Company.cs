namespace Plant_StoreBack.Models
{
    public class Company : BaseEntity
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        public string DescLeft { get; set; }
        public string DescRight { get; set; }
    }
}
