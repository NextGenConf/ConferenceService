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

        private string mongoUser;
        private string mongoPassword;
        private string mongoHostEnvironment;

        public string AuthString
        {
            get
            {
                if (mongoUser == null || mongoPassword == null)
                {
                    mongoUser = Environment.GetEnvironmentVariable(MongoDbUserEnvironmentVar);
                    mongoPassword = Environment.GetEnvironmentVariable(MongoDbPasswordEnvironmentVar);
                }

                return mongoUser != null && mongoPassword != null ? $"{mongoUser}:{mongoPassword}@" : "";
            }
        }

        public string ConnectionString
        { 
            get 
            {
                if (mongoHostEnvironment == null)
                {
                    mongoHostEnvironment = Environment.GetEnvironmentVariable(MongoDbHostEnvironmentVar);
                }

                return mongoHostEnvironment == null ? MongoDbHostDefault : mongoHostEnvironment;
            }
        }

        public readonly string ConferenceCollectionName = "Conferences";

        public readonly string DatabaseName = "ConferenceDb";
    }
}
