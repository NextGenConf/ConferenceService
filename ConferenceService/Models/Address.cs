namespace ConferenceService.Models
{
    using System;

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

        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   AddressLine == address.AddressLine &&
                   City == address.City &&
                   Country == address.Country &&
                   PostalCode == address.PostalCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AddressLine, City, Country, PostalCode);
        }
    }
}
