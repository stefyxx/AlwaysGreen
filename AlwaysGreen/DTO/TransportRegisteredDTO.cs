using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.DTO
{
    public class TransportRegisteredDTO
    {
        //Date --> sarà DateTime.Now 

        //1- lista di bottiglie caricate nel trasporto
        public List<EmptybottleTransportedDTO> Emptybottles { get; set; }
        //2- Tabella intermediaria x legare a OGNI emptibottleId, questo TransportId

        //3- da dove li prendo , x ora Store IsPickUpPoint= true
        public int LocationFromId { get; set; }

        //4- dove li porto == a quale depot li porto
        public int LocationToId { get; set; }

        //5- corriere utilizzato --> se non c'é lo creo
        public int CourierId { get; set; }
    }
}
