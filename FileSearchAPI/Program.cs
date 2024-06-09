using Nest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new ConnectionSettings(new Uri("http://elasticsearch:9200"))
    .DefaultIndex("files");

var client = new ElasticClient(settings);

builder.Services.AddSingleton<IElasticClient>(client);
builder.Services.AddScoped<FileIndexer>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

// Configure Kestrel to listen on port 5000
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5000);
});

var app = builder.Build();

// Log configuration values
app.Logger.LogInformation("ASPNETCORE_ENVIRONMENT: " + builder.Environment.EnvironmentName);
app.Logger.LogInformation("ASPNETCORE_URLS: " + Environment.GetEnvironmentVariable("ASPNETCORE_URLS"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseCors("AllowAll");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
