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
        private MongoClient client;
        private ConferenceDatabaseSettings mongoSettings;

        public ConferenceService(ConferenceDatabaseSettings settings)
        {
            client = new MongoClient($"mongodb://{settings.AuthString}{settings.Host}:{settings.Port}{settings.Parameters}");
            mongoSettings = settings;
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
            var db = client.GetDatabase(mongoSettings.DatabaseName);
            var conferences = db.GetCollection<Conference>(mongoSettings.ConferenceCollectionName);
            return conferences.Find(conference => conference.UniqueName == uniqueName).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves all conferences in the database.
        /// </summary>
        public IEnumerable<Conference> GetAll()
        {
            var db = client.GetDatabase(mongoSettings.DatabaseName);
            var conferences = db.GetCollection<Conference>(mongoSettings.ConferenceCollectionName);
            return conferences.Find(_ => true).Sort("{StartTime: 1}").ToList();
        }

        /// <summary>
        /// Adds a conference to the db.
        /// </summary>
        /// <param name="conference">The conference to add</param>
        /// <returns>The conference, with an updated id.</returns>
        public Conference Add(Conference conference)
        {
            var db = client.GetDatabase(mongoSettings.DatabaseName);
            var conferences = db.GetCollection<Conference>(mongoSettings.ConferenceCollectionName);
            conferences.InsertOne(conference);
            return conference;
        }
    }
}
