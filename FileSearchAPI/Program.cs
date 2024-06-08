using Nest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new ConnectionSettings(new Uri("http://elasticsearch:9200")) // Use service name here
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

builder.WebHost.UseUrls("http://*:5000"); // Ensure only port 5000 is used

var app = builder.Build();

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
