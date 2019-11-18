namespace ConferenceService.Models
{
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
    }
}