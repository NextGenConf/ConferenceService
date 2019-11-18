using ConferenceService.Models;
using System.Collections.Generic;

namespace ConferenceService.Services
{
    /// <summary>
    /// An interface for interacting with the conference data model.
    /// </summary>
    public interface IConferenceService
    {
        /// <summary>
        /// Retrieves all the conference entries in the db.
        /// </summary>
        IEnumerable<Conference> GetAll();

        /// <summary>
        /// Retrieves the conference with a specific id.
        /// </summary>
        /// <param name="id">The id of the conference to retrieve</param>
        /// <returns>Conference</returns>
        Conference GetById(string id);
    }

}
