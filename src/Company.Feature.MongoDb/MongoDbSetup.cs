using Company.Feature.UseCases.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Company.Feature.MongoDb;

public static class MongoDbSetup
{
  public static IServiceCollection AddMongoInfrastructure(this IServiceCollection services, string connectionString)
  {
    var client = new MongoClient(connectionString);
    var database = client.GetDatabase("FeatureDb");

    services.AddSingleton(database);
    services.AddScoped<IEntityNameRepository, MongoEntityNameRepository>();

    return services;
  }
}
