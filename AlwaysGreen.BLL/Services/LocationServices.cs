using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.BLL.Services
{
    public class LocationServices (ILocationRepository _locationRepository)
    {
        public List<Location> GetAll()
        {
            return _locationRepository.GetAll();
        }
    }
}
