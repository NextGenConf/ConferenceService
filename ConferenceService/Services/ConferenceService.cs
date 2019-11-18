using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceService.Models;
using MongoDB.Driver;

namespace ConferenceService.Services
{
    /// <summary>
    /// An implementation of IConferenceService.
    /// </summary>
    public class ConferenceService : IConferenceService
    {

        private readonly IMongoCollection<Conference> conferences;

        public ConferenceService(ConferenceDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
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
        /// <param name="id">The id to filter by</param>
        /// <returns>The retrieved conference.</returns>
        public Conference GetById(string id)
        {
            return conferences.Find(conference => conference.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves all conferences in the database.
        /// </summary>
        public IEnumerable<Conference> GetAll()
        {
            return conferences.Find(conference => true).ToList();
        }
    }
}
