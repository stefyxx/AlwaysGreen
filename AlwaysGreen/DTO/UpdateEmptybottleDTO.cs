using AlwaysGreen.Domain.Entities;

namespace AlwaysGreen.DTO
{
    public class UpdateEmptybottleDTO
    {
        public required string TypeName { get; set; } = null!;

        public required int Quantity { get; set; } = 0;

        public float? Prix { get; set; }

    }
}
