using Plant_StoreBack.ViewModels.Contact;
using Plant_StoreBack.ViewModels.ContactMessage;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IContactService
    {

        ContactVM GetData();
        Task<List<ContactMessageVM>> GetAllMessagesAsync();
        Task<ContactMessageVM> GetMessageByIdAsync(int id);
        Task CreateAsync(ContactCreateMessageVM contact);
        Task DeleteAsync(int id);
    }
}
