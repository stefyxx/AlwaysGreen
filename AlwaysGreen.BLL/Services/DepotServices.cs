using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.BLL.Services
{
    public class DepotServices(IDepotRepository _depotRepository)
    {
        public Depot Add(Depot depot) { return _depotRepository.Add(depot); }
    }
}
