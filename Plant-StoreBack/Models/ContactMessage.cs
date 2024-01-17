namespace Plant_StoreBack.Models
{
    public class ContactMessage:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
