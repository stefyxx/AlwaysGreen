using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.Domain.Entities
{
    //tab intermediaria Many to many con properties in più: tra Transport e Emptybottle
    
    public class Delivery
    {
        //la data é nel Transport
        #region FK
        public int TransportId { get; set; }
        public Transport Transport { get; set; } = null!;

        public int EmptybottleId { get; set; }
        public Emptybottle Emptybottle { get; set; } = null!;

        #endregion

        public int QuantityTransported { get; set; } = 0;

        public float? Prix { get; set; }

        //https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many
    }
}
