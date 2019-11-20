namespace ConferenceService.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class representing a conference venue.
    /// </summary>
    public class Venue
    {
        /// <summary>
        /// The name of the Venue.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The specific address of the venue.
        /// </summary>
        public Address Address { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Venue venue &&
                   Name == venue.Name &&
                   EqualityComparer<Address>.Default.Equals(Address, venue.Address);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Address);
        }
    }
}
