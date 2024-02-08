using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.Domain.Entities
{
    public class Transport
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        #region FK: Many to May
        //puo' essere = [] perché é relaz 0-N
        public List<Delivery> Deliveries { get; set; } = [];
        public List<Emptybottle> Emptybottles { get; set; } = [];

        #endregion

        #region FK

        [InverseProperty("TransportFrom")]
        public List<Location> LocationsFrom { get; set; } = [];

        [InverseProperty("TransportTo")]
        public List<Location> LocationsTo { get; set; } = [];


        public List<Courier> Courriers { get; set; } = [];
        #endregion

    }
}
