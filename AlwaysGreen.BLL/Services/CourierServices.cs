using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.BLL.Services
{
    public class CourierServices(ICourierRepository _courierRepository)
    {
        public List<Courier> GetAll() { return _courierRepository.GetAll();}

    }
}
