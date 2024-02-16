using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;
using System.Transactions;

namespace AlwaysGreen.BLL.Services
{
    public class TransportServices(ITransportRepository _transportRepository, IEmptybottleRepository _emptybottleRepository)
    {
        public List<Transport> GetAll() { return _transportRepository.GetAll(); }

        public Transport Register(List<Emptybottle> emptybottles, int locationFromId, int locationToId, int courierId)
        {
            using TransactionScope scope = new TransactionScope();
            //per ogni emptybottle bisogna 
            //1- creare una Delivery con la quantity
            //2- modificare lo stock
            Transport transport = new Transport();
            transport.LocationFromId = locationFromId;
            transport.LocationsToId = locationToId;
            transport.CourierId = courierId;
            transport.Date = DateTime.UtcNow;
            // transport.Emptybottles = emptybottles;

            List<Emptybottle> allEmptybottleIntoBD = _emptybottleRepository.GetAll();
            transport.Deliveries = emptybottles.Select(
                e => {
                //function to find ID and prix for Emptybottle --> TypeName
                allEmptybottleIntoBD.ForEach(eDB =>
                {
                    if (eDB.TypeName == e.TypeName)
                    {
                        e.Id = eDB.Id;
                        e.Prix = eDB.Prix;
                    }
                });
                
                return new Delivery
                {
                    QuantityTransported = e.Quantity,
                    Prix = e.Prix,
                    EmptybottleId = e.Id
                };
                }).ToList();
            
            Transport transportCreated =  _transportRepository.Add(transport);
            //stock
            transportCreated.Emptybottles.ForEach(e =>
            {
                Emptybottle? eDBstocked = _emptybottleRepository.Find(e.Id);
                eDBstocked.Quantity = eDBstocked.Quantity + e.Quantity;
                _emptybottleRepository.Update(eDBstocked);
            });
            transportCreated = _transportRepository.Find(transportCreated.Id);
            scope.Complete();
            return transportCreated;
        }

    }
}
