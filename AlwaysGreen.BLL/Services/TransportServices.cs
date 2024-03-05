using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;
using System.Transactions;

namespace AlwaysGreen.BLL.Services
{
    public class TransportServices(ITransportRepository _transportRepository, IEmptybottleRepository _emptybottleRepository, ICourierRepository _courierRepository, ILocationRepository _locationRepository)
    {
        private readonly List<int> _AllCouriersId = _courierRepository.GetAll().Select(c => c.Id).ToList();
        private readonly List<int> _AllLocationsId = _locationRepository.GetAll().Select(l => l.Id).ToList();
        public List<Transport> GetAll() { return _transportRepository.GetAll(); }

        //[Authorize(Roles = "Depot")]
        public Transport Register(List<Emptybottle> emptybottles, int locationFromId, int locationToId, int courierId)
        {
            //Diversi appelli alla DB! Ottimizziamo con TransactionScope: sono sicura che alla fine o va o non va, chiude appello con DB e chiama garbage collector

            using TransactionScope scope = new TransactionScope();

            //per ogni emptybottle bisogna 
            //1- creare una Delivery con la quantity
            //2- modificare lo stock
            Transport transport = new Transport();

            if(!_AllLocationsId.Contains(locationFromId)) throw new Exception("This starting location does not registered");
            else transport.LocationFromId = locationFromId;
            if(!_AllLocationsId.Contains(locationToId)) throw new Exception("This ending location does not registered");
            else transport.LocationsToId = locationToId;
            
            if (!_AllCouriersId.Contains(courierId)) throw new Exception("Courier doesn't exist");
            else transport.CourierId = courierId;
            transport.Date = DateTime.UtcNow;

            List<Emptybottle> allEmptybottleIntoBD = _emptybottleRepository.GetAll();

            //MANY TO MANY --> riempio list di tab INTERMEDIARIA
            //transport.Emptybottles = emptybottles;
            transport.Deliveries = emptybottles.Select(
                e =>
                {
                    //function to find ID and prix for Emptybottle --> TypeName
                    allEmptybottleIntoBD.ForEach(eDB =>
                    {
                        if (eDB.TypeName == e.TypeName)
                        {
                            e.Id = eDB.Id;
                            e.Prix = eDB.Prix;
                        }
                    });
                    //I also put this control into Agular, but API isn't dependent to Front
                    if (e.Id > 0)
                    {
                        return new Delivery
                        {
                            QuantityTransported = e.Quantity,
                            Prix = e.Prix,
                            EmptybottleId = e.Id
                        };
                    }
                    else throw new Exception($"This empty bottle {e.TypeName} doesn't exist");

                }).ToList();

            Transport transportCreated = _transportRepository.Add(transport);

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
