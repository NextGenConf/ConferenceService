namespace ConferenceService.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using ConferenceService.Models;
    using ConferenceService.Services;
    using Microsoft.AspNetCore.Mvc;
    using MongoDB.Bson.IO;

    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        private readonly IConferenceService conferenceService;

        public ConferenceController(IConferenceService conferenceService)
        {
            this.conferenceService = conferenceService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Conference>> GetAllConferences()
        {
            return conferenceService.GetAll().ToList();
        }
        
        // GET api/values/5
        [HttpGet("{uniqueName}")]
        public ActionResult<Conference> GetConferenceByUniqueName(string uniqueName)
        {
            return conferenceService.GetByUniqueName(uniqueName);
        }

        /// <summary>
        /// POST call to add a new conference.
        /// </summary>
        /// <param name="conference">The conference to add.</param>
        [HttpPost]
        public void Post([FromBody] Conference conference)
        {
            conferenceService.Add(conference);
        }
    }
}
