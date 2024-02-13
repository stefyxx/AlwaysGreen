using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.BLL.Services
{
    public class StoreServices(IStoreRepository _storeRepository)
    {
        public Store Add(Store s) { return _storeRepository.Add(s); }
    }
}
