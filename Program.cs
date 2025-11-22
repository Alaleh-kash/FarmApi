
using FarmApi.Services;

var builder = WebApplication.CreateBuilder(args);

// ⭐ Add CORS so React can call API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        b => b.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// ⭐ Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ⭐ Register your FarmService
builder.Services.AddScoped<FarmService>();

// Build app
var app = builder.Build();

// ⭐ Enable CORS
app.UseCors("AllowReact");

// Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ⭐ Your API endpoint
app.MapGet("/farm/animals", (FarmService service) =>
{
    return service.GetFarmAnimals();
});

app.MapGet("/farm/foods", (FarmService service) =>
{
    return service.GetFoods();
});


app.Run();

