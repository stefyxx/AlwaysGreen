using AlwaysGreen.Domain.Enums;

namespace AlwaysGreen.DTO
{
    //creato solo x romprer il ciclo che avrei con Address, presente qui' e in Transport
    public class StoreDTO: LocationResultDTO
    {
        public string VATnumber { get; set; }
        public override RolesEnum[] Roles { get => [RolesEnum.Store]; }
        public bool IsPickUpPoint { get; set; }

        //é un pt dove spendere i buoni?
        public bool IsStorePoint { get; set; }
        
        public SiretDTO Siret { get; set; }
    }
}
