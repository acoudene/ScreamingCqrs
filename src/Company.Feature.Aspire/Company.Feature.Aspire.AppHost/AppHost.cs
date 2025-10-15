var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Company_Feature_ApiApp>("company-feature-apiapp");

builder.AddProject<Projects.Company_Feature_BlazorApp>("company-feature-blazorapp");

builder.Build().Run();
