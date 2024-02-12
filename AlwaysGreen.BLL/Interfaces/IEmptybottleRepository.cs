using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.BLL.Interfaces
{
    public interface IEmptybottleRepository
    {
        List<Emptybottle> GetAll();
        Emptybottle? Find(params object[] id);
        Emptybottle Add(Emptybottle e);
        void Update(Emptybottle e);
        void Delete(Emptybottle e);
        Emptybottle? FindIsExisting(Emptybottle e);
    }
}
