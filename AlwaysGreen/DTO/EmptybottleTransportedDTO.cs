namespace AlwaysGreen.DTO
{
    public class EmptybottleTransportedDTO
    {
        //in realtà io recupero l'id anche
        public required string TypeName { get; set; } = null!;

        public required int Quantity { get; set; } = 0;
    }
}
