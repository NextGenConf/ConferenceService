namespace ConferenceService.Configuration
{
    /// <summary>
    /// The settings required to setup a successful connection
    /// to the mongo db instance.
    /// </summary>
    public class ConferenceDatabaseSettings
    {
        public string ConferenceCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
