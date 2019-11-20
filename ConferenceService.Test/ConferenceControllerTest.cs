using ConferenceService.Controllers;
using ConferenceService.Models;
using ConferenceService.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ConferenceService.Test
{
    [TestClass]
    public class ConferenceControllerTest
    {
        /// <summary>
        /// Checks so that the GetAll retrieves all the conferences that 
        /// the data model contains.
        /// </summary>
        [TestMethod]
        public void GetAll_RetrieveAllConferencesInDb_AllConferences()
        {
            var conferences = new List<Conference>()
            {
                new Conference()
                {
                    DisplayName = "Eva's conference",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow
                },
                new Conference()
                {
                    DisplayName = "Grant's conference",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow,
                }
            };

            var mockConferenceService = new Mock<IConferenceService>();
            mockConferenceService.Setup(m => m.GetAll()).Returns(conferences);

            var conferenceController = new ConferenceController(mockConferenceService.Object);
            var result = conferenceController.GetAllConferences().Value;
            Assert.AreEqual(conferences.Count, result.Count());

            foreach (var conf in conferences)
            {
                Assert.IsTrue(result.Contains(conf));
            }

            mockConferenceService.Verify(cs => cs.GetAll(), Times.Once());
        }

        /// <summary>
        /// Checks so that we handle the case of no entries in the db.
        /// </summary>
        [TestMethod]
        public void GetAll_NothingInDb_EmptyResult()
        {
            var mockConferenceService = new Mock<IConferenceService>();
            mockConferenceService.Setup(c => c.GetAll()).Returns(new List<Conference>());
            var conferenceController = new ConferenceController(mockConferenceService.Object);
            var result = conferenceController.GetAllConferences().Value;

            Assert.AreEqual(0, result.Count());
            mockConferenceService.Verify(cs => cs.GetAll(), Times.Once());
        }

        /// <summary>
        /// Checks whether a conference with a valid id can be retrieved.
        /// </summary>
        [TestMethod]
        public void GetById_ValidId_CorrectConference()
        {
            var mockConferenceService = new Mock<IConferenceService>();
            var conference = new Conference()
            {
                DisplayName = "Oliver Wheeler's Conference",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                UniqueName = "5dd2b0c4a3a3e850dc1b9c55",
            };
            mockConferenceService.Setup(c => c.GetByUniqueName(It.IsAny<string>())).Returns(conference);

            var conferenceController = new ConferenceController(mockConferenceService.Object);
            var result = conferenceController.GetConferenceByUniqueName("5dd2b0c4a3a3e850dc1b9c55").Value;
            Assert.AreEqual(conference, result);
        }

        /// <summary>
        /// Checks whether a null conference is handled correctly, and that the method is
        /// data model is queried with the correct id.
        /// </summary>
        [TestMethod]
        public void GetById_WrongId_Null()
        {
            var mockConferenceService = new Mock<IConferenceService>();
            mockConferenceService.Setup(c => c.GetByUniqueName(It.IsAny<string>())).Returns((Conference)null);

            var conferenceController = new ConferenceController(mockConferenceService.Object);
            var result = conferenceController.GetConferenceByUniqueName("6aa2b0c4a3a3e850dc1b9a62").Value;
            mockConferenceService.Verify(
                c => c.GetByUniqueName(It.Is<string>(id => id == "6aa2b0c4a3a3e850dc1b9a62")),
                Times.Once());
            Assert.IsNull(result);
        }

        /// <summary>
        /// Verifies that the exact same conference that's provided in the 
        /// http request is used for the store call.
        /// </summary>
        [TestMethod]
        public void Add_FullConference_CallToConferencService()
        {
            var mockConferenceService = new Mock<IConferenceService>();
            mockConferenceService.Setup(c => c.Add(It.IsAny<Conference>()));

            var conferenceController = new ConferenceController(mockConferenceService.Object);
            var conferenceToAdd = new Conference()
            {
                DisplayName = "Eva's Conference",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow
            };

            conferenceController.Post(conferenceToAdd);
            mockConferenceService.Verify(
                c => c.Add(It.Is<Conference>(conf => conf == conferenceToAdd)),
                Times.Once());
        }
    }
}
