using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.BLL.Interfaces
{
    public interface ITransportRepository
    {
        public List<Transport> GetAll();
        public Transport? Find(params object[] id);
        public Transport Add(Transport transport);
         public void Delete(Transport transport);
        public void Update(Transport transport);
        Transport? FindIsExisting(Transport transport);
    }
}
