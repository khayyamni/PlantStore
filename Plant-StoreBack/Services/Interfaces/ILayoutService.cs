using Plant_StoreBack.ViewModels;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface ILayoutService
    {
        HeaderVM GetHeaderDatas();
        FooterVM GetFooterDatas();

    }
}
