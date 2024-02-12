using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.BLL.Interfaces
{
    public interface ILocationRepository
    {
        public List<Location> GetAll();
    }
}
