using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        #region FK

        #region Many to May
        //puo' essere = [] perché é relaz 0-N
        public List<Delivery> Deliveries { get; set; } = [];
        public List<Emptybottle> Emptybottles { get; set; } = [];

        #endregion

        public List<Courier> Courriers { get; set; } = [];
        #endregion

    }
}
