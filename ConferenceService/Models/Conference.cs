namespace ConferenceService.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Data model representing a conference.
    /// </summary>
    public class Conference
    {
        /// <summary>
        /// A unique ID for each conference.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// The name of the conference.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A unique name identifying the conference.
        /// </summary>
        public string UniqueName { get; set; }

        /// <summary>
        /// Location of the conference icon
        /// </summary>
        public string IconUri { get; set; }

        /// <summary>
        /// The description of the conference.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The Conference subtitle.
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// Conference start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Conference end date.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// The venue that holds the conference.
        /// </summary>
        public Venue Venue { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Conference conference &&
                   Id == conference.Id &&
                   DisplayName == conference.DisplayName &&
                   StartDate == conference.StartDate &&
                   EndDate == conference.EndDate &&
                   EqualityComparer<Venue>.Default.Equals(Venue, conference.Venue);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, DisplayName, StartDate, EndDate, Venue);
        }
    }
}
