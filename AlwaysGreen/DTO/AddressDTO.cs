using System.ComponentModel.DataAnnotations.Schema;

namespace AlwaysGreen.DTO
{
    public class AddressDTO : AddressCreateDTO
    {
        public int Id { get; set; }
    }
}
