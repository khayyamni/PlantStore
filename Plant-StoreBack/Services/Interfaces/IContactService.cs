using Plant_StoreBack.ViewModels.Contact;
using Plant_StoreBack.ViewModels.ContactMessage;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IContactService
    {

        Task<ContactVM> GetData();
        Task<List<ContactMessageVM>> GetAllMessagesAsync();
        Task<ContactMessageVM> GetMessageByIdAsync(int id);

    }
}
