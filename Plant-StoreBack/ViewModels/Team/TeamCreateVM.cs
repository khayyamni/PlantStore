namespace Plant_StoreBack.ViewModels.Team
{
    public class TeamCreateVM
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Position { get; set; }
        public IFormFile Photo { get; set; }
    }
}
