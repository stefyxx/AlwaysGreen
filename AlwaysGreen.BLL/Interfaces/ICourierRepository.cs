using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.BLL.Interfaces
{
    public interface ICourierRepository
    {
        List<Courier> GetAll();
        Courier? Find(params object[] id);
        Courier Add(Courier e);
        void Update(Courier e);
        void Delete(Courier e);
        Courier? FindIsExisting(Courier e);
    }
}
