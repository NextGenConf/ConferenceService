namespace ConferenceService.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using global::ConferenceService.Configuration;
    using Models;
    using MongoDB.Driver;
    
    /// <summary>
    /// An implementation of IConferenceService.
    /// </summary>
    public class ConferenceService : IConferenceService
    {
        private readonly IMongoCollection<Conference> conferences;

        public ConferenceService(ConferenceDatabaseSettings settings)
        {
            var client = new MongoClient($"mongodb://{settings.AuthString}{settings.ConnectionString}");
            var database = client.GetDatabase(settings.DatabaseName);

            conferences = database.GetCollection<Conference>(settings.ConferenceCollectionName);
        }

        /// <summary>
        /// Private default constructor to make sure it's never
        /// initialized this way.
        /// </summary>
        private ConferenceService() { } 

        /// <summary>
        /// Find a conference with the specific id.
        /// </summary>
        /// <param name="uniqueName">Unique name </param>
        /// <returns>The retrieved conference.</returns>
        public Conference GetByUniqueName(string uniqueName)
        {
            return conferences.Find(conference => conference.UniqueName == uniqueName).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves all conferences in the database.
        /// </summary>
        public IEnumerable<Conference> GetAll()
        {
            return conferences.Find(_ => true).Sort("{StartTime: 1}").ToList();
        }

        /// <summary>
        /// Adds a conference to the db.
        /// </summary>
        /// <param name="conference">The conference to add</param>
        /// <returns>The conference, with an updated id.</returns>
        public Conference Add(Conference conference)
        {
            conferences.InsertOne(conference);
            // Conference is now updated with the id used during insertion.
            return conference;
        }
    }
}
