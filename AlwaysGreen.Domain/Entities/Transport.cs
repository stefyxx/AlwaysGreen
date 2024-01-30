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
        public List<Delivery> Deliveries { get; set; } = [];
        public List<Emptybottle> Emptybottles { get; set; } = [];
        #endregion

    }
}
