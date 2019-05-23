using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using System;
using System.Diagnostics;
using ZXVentures.BackendChallenge.Domain;
using ZXVentures.BackendChallenge.Domain.People;

namespace ZxVentures.BackendChallenge.Infrastructure.Data
{
    public class DatabaseContext
    {
        readonly MongoClient mongoClient;

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

        public IMongoDatabase GetDatabase(string name)
        {
            return mongoClient.GetDatabase(name);
        }

        public static void Configure()
        {
            BsonSerializer.RegisterSerializer(typeof(DateTime), new DateTimeSerializer(DateTimeKind.Local));

            BsonClassMap.RegisterClassMap<PDV>();
            BsonClassMap.RegisterClassMap<NaturalPeople>();
            BsonClassMap.RegisterClassMap<LegalPeople>();
        }
    }
}
