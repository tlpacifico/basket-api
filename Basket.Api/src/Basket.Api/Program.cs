using Basket.Api.Integration;
using Basket.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICatalogRepository, CatalogRepository>();

builder.Services.AddHttpClient<ICatalogIntegration, CatalogIntegration>((_, client) =>
{                  
    client.BaseAddress = new Uri("https://azfun-impact-code-challenge-api.azurewebsites.net/api/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
}).AddHttpMessageHandler<ProtectedApiBearerTokenHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();