namespace ConferenceService.Configuration
{
    using System;

    /// <summary>
    /// The settings required to setup a successful connection
    /// to the mongo db instance.
    /// </summary>
    public class ConferenceDatabaseSettings
    {
        private const string MongoDbHostDefault = "localhost:27017";
        private const string MongoDbHostEnvironmentVar = "MONGO_DB_HOST";
        private const string MongoDbPasswordEnvironmentVar = "MONGO_DB_PASSWORD";
        private const string MongoDbUserEnvironmentVar = "MONGO_DB_USER";

        public string AuthString
        {
            get
            {
                var mongoDbUser = Environment.GetEnvironmentVariable(MongoDbUserEnvironmentVar);
                var mongoDbPassword = Environment.GetEnvironmentVariable(MongoDbPasswordEnvironmentVar);
                if (mongoDbUser != null && mongoDbPassword != null)
                {
                    return $"{mongoDbUser}:{mongoDbPassword}@";
                }

                return "";
            }
        }

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
