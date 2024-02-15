using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.DTO
{
    public class TransportResultDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        #region FK: Many to May
        //recuperato da DELIVERY !!!!!
        public List<EmptybottleTransportedDTO> Emptybottles { get; set; }
        #endregion

        #region FK
        public LocationResultDTO LocationFrom { get; set; }
        public LocationResultDTO LocationTo { get; set; }
        public CourierResultDTO Courier { get; set; }
        #endregion
    }
}
