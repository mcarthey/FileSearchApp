using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nest;
using System;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = AppContext.BaseDirectory,
    WebRootPath = "wwwroot",
    ApplicationName = "FileSearchAPI"
});

// Add services to the container.
var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
    .DefaultIndex("files");

var client = new ElasticClient(settings);

builder.Services.AddSingleton(client);
builder.Services.AddScoped<FileIndexer>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseStaticFiles(); // Ensure static files are served

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("index.html"); // Ensure fallback to index.html
});

app.Run("http://*:80");  // Set the application to listen on port 80
