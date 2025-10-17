var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Company_Feature_Api_AppHost>("company-feature-api-apphost");

builder.AddProject<Projects.Company_Feature_Blazor_AppHost>("company-feature-blazor-apphost");

builder.Build().Run();
