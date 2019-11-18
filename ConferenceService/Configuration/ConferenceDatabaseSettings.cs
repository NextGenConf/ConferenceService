namespace ConferenceService.Services
{
    public class ConferenceDatabaseSettings : IConferenceDatabaseSettings
    {
        public string ConferenceCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
