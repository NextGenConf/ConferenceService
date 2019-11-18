namespace ConferenceService.Models
{
    /// <summary>
    /// Class representing an address.
    /// </summary>
    public class Address
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
