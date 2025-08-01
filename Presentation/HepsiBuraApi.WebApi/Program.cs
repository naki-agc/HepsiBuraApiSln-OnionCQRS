using HepsiBuraApi.Persistence;
using HepsiBuraApi.Application;
using HepsiBuraApi.Infrastructure;
using HepsiBuraApi.Mapper;
using HepsiBuraApi.Application.Exceptions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var environment = builder.Environment;

builder.Configuration
    .SetBasePath(environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(); // IServceCollection gibi �al���r ve Application katman�ndaki servisleri ekler.Referans vermeye gerek yoktur.
builder.Services.AddCustomMapper(); // AutoMapper i�in gerekli olan servisleri ekler. Referans vermeye gerek yoktur.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HepsiBurada Api", Version = "v1", Description = "Hepsiburada Api Swagger Client" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In =ParameterLocation.Header,
        Description = "'Bearer yaz�p bo�luk burakt�ktan sonra token� girebilirsiniz'"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {

        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }

    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandlingMiddleware(); // �zel hata i�leme ara katman�n� ekler. Bu, uygulama genelinde hata y�netimini sa�lar.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();