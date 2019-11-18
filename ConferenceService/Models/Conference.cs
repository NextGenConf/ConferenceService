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
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Venue Venue { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Conference conference &&
                   Id == conference.Id &&
                   Name == conference.Name &&
                   StartDate == conference.StartDate &&
                   EndDate == conference.EndDate &&
                   EqualityComparer<Venue>.Default.Equals(Venue, conference.Venue);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, StartDate, EndDate, Venue);
        }
    }
}