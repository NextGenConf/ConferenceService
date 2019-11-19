namespace ConferenceService.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using ConferenceService.Models;
    using ConferenceService.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        private readonly IConferenceService conferenceService;

        public ConferenceController(IConferenceService conferenceService)
        {
            this.conferenceService = conferenceService;
        }

        /// <summary>
        /// Retrieves all conferences in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Conference>> Get()
        {
            return conferenceService.GetAll().ToList();
        }
        
        /// <summary>
        /// Retrieves a conference by a specific id.
        /// </summary>
        /// <param name="id">The id of the conference to get.</param>
        /// <returns>The conference object.</returns>
        [HttpGet("{id}")]
        public ActionResult<Conference> Get(string id)
        {
            return conferenceService.GetById(id);
        }
    }
}
