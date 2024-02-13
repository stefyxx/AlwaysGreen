using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.BLL.Interfaces
{
    public interface ISiretRepository
    {
        List<Siret> GetAll();
        Siret? Find(params object[] id);
        Siret Add(Siret siret);
        void Update(Siret siret);
        void Delete(Siret siret);
        Siret? FindIsExisting(Siret siret);
    }
}
