using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using marketplace_microservice_backend.Entity;

namespace marketplace_microservice_backend.DataAccess
{
    public class AllDbContext
    {
        MongoClient mongoClient;
        IMongoDatabase database;
        public AllDbContext()
        {
        }
        public AllDbContext(IConfiguration configuration) {
        
            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                mongoClient = new MongoClient(Environment.GetEnvironmentVariable("mongo_db"));
            }
            else
            {
                mongoClient = new MongoClient(configuration.GetSection("MongoDB:server").Value);
            }
            database = mongoClient.GetDatabase(configuration.GetSection("MongoDB:database").Value);
        }
         
        public IMongoCollection<EIntegration> Integrations => database.GetCollection<EIntegration>("Integration");
        public IMongoCollection<Issues> Issues => database.GetCollection<Issues>("Issues");
        public IMongoCollection<User> User => database.GetCollection<User>("User");
        public IMongoCollection<MyGitHub> MyGitHub => database.GetCollection<MyGitHub>("MyGitHub");
    }
}
