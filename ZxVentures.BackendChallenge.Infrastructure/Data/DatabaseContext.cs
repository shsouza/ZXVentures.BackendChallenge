using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using System;
using System.Diagnostics;
using System.Linq;
using ZXVentures.BackendChallenge.Domain;
using ZXVentures.BackendChallenge.Domain.People;
using ZXVentures.BackendChallenge.Infrastructure.Migration;

namespace ZxVentures.BackendChallenge.Infrastructure.Data
{
    public class DatabaseContext
    {
        readonly MongoClient mongoClient;

        private const string DATABASE_NAME = "zxventures_pdv";

        public DatabaseContext()
        {
            this.mongoClient = new MongoClient(
                new MongoClientSettings
                {
                    Server = new MongoServerAddress("localhost", 27017),
                    ClusterConfigurator = cc =>
                    {
                        cc.Subscribe<CommandStartedEvent>(e =>
                        {
                            Debug.WriteLine($"{e.CommandName} - {e.Command.ToString()}");
                        }
                        );
                    }
                }
            );
        }

        public IMongoDatabase GetDatabase()
        {
            return mongoClient.GetDatabase(DATABASE_NAME);
        }

        public void Configure()
        {
            BsonSerializer.RegisterSerializer(typeof(DateTime), new DateTimeSerializer(DateTimeKind.Local));

            BsonClassMap.RegisterClassMap<PDV>();
            BsonClassMap.RegisterClassMap<NaturalPeople>();
            BsonClassMap.RegisterClassMap<LegalPeople>();

            if (!DataBaseExists())
            {
                DatabaseMigrator.Migrate(this);
            }
        }

        private bool DataBaseExists()
        {
            using (var cursor = mongoClient.ListDatabases())
            {
                var databaseDocuments = cursor.ToList();

                if (databaseDocuments.Any(d => d["name"] == DATABASE_NAME))
                    return true;
            }

            return false;
        }
    }
}
