using Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Mongo
{
    public static class MongoRegistration
    {
        public static IServiceCollection AddMongoInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["Mongo:ConnectionString"];
            var dbName = configuration["Mongo:Database"];

            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);

            services.AddSingleton<IMongoDatabase>(db);
            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
