namespace ConferenceService.Configuration
{
    using System;

    /// <summary>
    /// The settings required to setup a successful connection
    /// to the mongo db instance.
    /// </summary>
    public class ConferenceDatabaseSettings
    {
        private const string MongoDbHostDefault = "mongodb://localhost:27017";
        private const string MongoDbHostEnvironmentVar = "MongoDbHost";

        public string ConnectionString
        { 
            get 
            {
                var mongoDbHost = Environment.GetEnvironmentVariable(MongoDbHostEnvironmentVar);
                if (mongoDbHost != null)
                {
                    return mongoDbHost;
                }

                return MongoDbHostDefault;
            }
        }

        public readonly string ConferenceCollectionName = "Conferences";

        public readonly string DatabaseName = "ConferenceDb";
    }
}
