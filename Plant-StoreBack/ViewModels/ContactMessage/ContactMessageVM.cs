﻿namespace Plant_StoreBack.ViewModels.ContactMessage
{
    public class ContactMessageVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
