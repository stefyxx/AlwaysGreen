using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.BLL.Services
{
    public class TransportServices(ITransportRepository _transportRepository)
    {
        public List<Transport> GetAll() { return _transportRepository.GetAll(); }

        public Transport Register(List<Emptybottle> emptybottles, int locationFromId, int locationToId, int courierId)
        {
            //per ogni emptybottle bisogna 
            //1- creare una Delivery con la quantity
            //2- modificare lo stock
            Transport transport = new Transport();
            transport.LocationFromId = locationFromId;
            transport.LocationsToId = locationToId;
            transport.CourierId = courierId;
            transport.Emptybottles = emptybottles;


            return transport;
        }

    }
}
