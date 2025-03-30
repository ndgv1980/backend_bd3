using BackendBDIII.Data;
using BackendBDIII.Data.Repositories;
using MySql.Data.MySqlClient;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using BackendBDIII.Data.MongoDBRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


#region Configurations

// Setup MySQL.
MySQLConfiguration mySQLConfiguration = new(builder.Configuration.GetConnectionString("MySQLConnection") ?? 
    throw new Exception("Configuration string not found!"));
builder.Services.AddSingleton(mySQLConfiguration);
builder.Services.AddSingleton(new MySqlConnection(mySQLConfiguration.ConnectionString));

// Setup MongoDB.
var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
if (connectionString == null)
{
    Console.WriteLine("You must set your 'MONGODB_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-connection-string");
    Environment.Exit(0);
}
builder.Services.AddSingleton(new MongoClient(connectionString));

// Setup repositories.
builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoDetallesRepository, ProductoDetallesRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IVentasRepository, VentasRepository>();
builder.Services.AddScoped<ISubventaRepository, SubventaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<ISalesHistoryRepository, SalesHistoryRepository>();
builder.Services.AddScoped<IProductsHistoryRepository, ProductHistoryRepository>();
builder.Services.AddScoped<IOperatorCommentsRepository, OperatorCommentsRepository>();

// Setup Swagger UI.
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddMvc();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    });
}

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseRouting();
    app.MapGet("/swagger", () => app.MapSwagger());
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
