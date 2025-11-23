
using FarmApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your service
builder.Services.AddSingleton<FarmService>();

// CORS for Render
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("AllowAll");

// RUN SWAGGER ALSO IN PRODUCTION (REQUIRED FOR RENDER)
app.UseSwagger();
app.UseSwaggerUI();

// REQUIRED FOR RENDER — dynamic port binding
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Urls.Add($"http://0.0.0.0:{port}");

app.MapControllers();

app.Run();
