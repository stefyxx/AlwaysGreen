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
        public int? LocationFromId { get; set; }
        [ForeignKey("LocationFromId")]
        public Location? LocationFrom { get; set; }
        public int? LocationsToId { get; set; }
        [ForeignKey("LocationsToId")]
        public Location? LocationTo { get; set; }

        //puo' essere = ? perché é relaz 0-N
        public int? CourierId { get; set; }
        [ForeignKey("CourierId")]
        public Courier? Courier { get; set; }

        #endregion

    }
}
