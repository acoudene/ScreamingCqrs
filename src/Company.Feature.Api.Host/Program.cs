using Company.Feature.Application.UseCases;
using Company.Feature.MongoDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Infrastructure
builder.Services.AddMongoInfrastructure(builder.Configuration.GetConnectionString("MongoDb")!);

// Application
builder.Services.AddScoped<GetAllEntityNamesQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
