using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.Domain.Entities
{
    public class Emptybottle
    {
        [Key]
        public int Id { get; set; }

        //TODO --> enum CategoryEmptybottle
        public string TypeName { get; set; } = null!;

        public int Quantity { get; set; } = 0;

        public float? Prix { get; set; }

        #region FK
        public List<Delivery> Deliveries { get; set; } = [];
        public List<Transport> Transports { get; set; } = [];
        #endregion
    }
}
