namespace AlwaysGreen.DTO
{
    public class AddressCreateDTO
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }

        #region nb:
        //a volte hai Apartment --> corrisp a 13A
        //altre hai unit + unitnb --> ipercondomini
        public string? Apartment { get; set; }
        public string? Unit { get; set; }
        public string? UnitNumber { get; set; }
        #endregion

        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
