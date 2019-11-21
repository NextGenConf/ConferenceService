namespace ConferenceService.Configuration
{
    using System;

    /// <summary>
    /// The settings required to setup a successful connection
    /// to the mongo db instance.
    /// </summary>
    public class ConferenceDatabaseSettings
    {
        private const string MongoDbHostDefault = "localhost";
        private const string MongoDbPortDefault = "27017";
        private const string MongoDbHostEnvironmentVar = "MONGO_DB_HOST";
        private const string MongoDbPasswordEnvironmentVar = "MONGO_DB_PASSWORD";
        private const string MongoDbUserEnvironmentVar = "MONGO_DB_USER";
        private const string MongoDbPortEnvironmentVar = "MONGO_DB_PORT";
        private const string MongoDbParametersEnvironmentVar = "MONGO_DB_PARAMETERS";

        private string mongoUser;
        private string mongoPassword;
        private string mongoHostEnvironment;
        private string mongoPort;
        private string mongoHost;
        private string mongoParameters;

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

        public string Port
        {
            get
            {
                if (mongoPort == null)
                {
                    mongoPort = Environment.GetEnvironmentVariable(MongoDbPortEnvironmentVar);
                }

                return mongoPort == null ? MongoDbPortDefault : mongoPort;
            }
        }

        public string Host
        { 
            get 
            {
                if (mongoHost == null) {
                    mongoHost = Environment.GetEnvironmentVariable(MongoDbHostEnvironmentVar);
                }

                return mongoHost == null ? MongoDbHostDefault : mongoHost;
            }
        }

        public string Parameters
        {
            get
            {
                if (mongoParameters == null) 
                {
                    mongoParameters = Environment.GetEnvironmentVariable(MongoDbParametersEnvironmentVar);
                }

                return mongoParameters == null ? "" : $"/?{mongoParameters}";
            }
        }

        public readonly string ConferenceCollectionName = "Conferences";

        public readonly string DatabaseName = "ConferenceDb";
    }
}
