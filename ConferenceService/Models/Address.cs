namespace ConferenceService.Models
{
    /// <summary>
    /// Class representing an address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Free form address to describe the street/street number.
        /// </summary>
        public string AddressLine { get; set; }

        /// <summary>
        /// The city of the address.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The country of the address.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Address's postal code.
        /// </summary>
        public string PostalCode { get; set; }
    }
}