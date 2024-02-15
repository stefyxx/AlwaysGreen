namespace AlwaysGreen.DTO
{
    public class AddressCreateDTO
    {
        public required string StreetName { get; set; }
        public required string StreetNumber { get; set; }

        #region nb:
        //a volte hai Apartment --> corrisp a 13A
        //altre hai unit + unitnb --> ipercondomini
        public string? Apartment { get; set; }
        public string? Unit { get; set; }
        public string? UnitNumber { get; set; }
        #endregion

        public required string City { get; set; }
        public required string ZipCode { get; set; }
        public required string Country { get; set; }
    }
}
