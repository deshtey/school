var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.schoolapp_webapi>("schoolapp-webapi");

builder.Build().Run();
