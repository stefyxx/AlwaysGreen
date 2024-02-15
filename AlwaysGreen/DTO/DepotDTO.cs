using AlwaysGreen.Domain.Enums;

namespace AlwaysGreen.DTO
{
    //creata solo x rompere il ciclo che avrei con Address (v the same into StoreDTO)
    public class DepotDTO: LocationResultDTO
    {
        public override RolesEnum[] Roles { get => [RolesEnum.Depot]; }
    }
}
