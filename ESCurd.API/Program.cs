using ESCurd.API.Model;
using ESCurd.API.Sevices;
using Nest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var settings = new ConnectionSettings(new Uri("http://localhost:9200/")).DefaultIndex("esdemo");
var client = new ElasticClient(settings);

builder.Services.AddSingleton(client);

builder.Services.AddScoped<IElasticsearchService<MyDocument>, ElasticsearchService<MyDocument>>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
