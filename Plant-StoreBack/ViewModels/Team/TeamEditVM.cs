namespace Plant_StoreBack.ViewModels.Team
{
    public class TeamEditVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public IFormFile Photo { get; set; }
        public string Image { get; set; }
    }
}
