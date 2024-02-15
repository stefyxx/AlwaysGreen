using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.BLL.Services
{
    public class TransportServices(ITransportRepository _transportRepository)
    {
        public List<Transport> GetAll() { return _transportRepository.GetAll(); }

        public Transport Register(List<Emptybottle> emptybottles, int locationFromId, int locationToId, int courierId)
        {

        }

    }
}
