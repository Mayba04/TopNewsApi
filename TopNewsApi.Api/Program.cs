using TopNewsApi.Core;
using TopNewsApi.Infrastructure;
using TopNewsApi.Infrastructure.Initializers;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("DefaulConnection");

//Databse context
builder.Services.AddDbCotext(connStr);


//Add repositories
builder.Services.AddRepositories();

//Add core services
builder.Services.AddCoreServices();

//Add Infrastructure
builder.Services.AddInfastructuresServices();

//Add mapping
builder.Services.AddMapping();


// Add services to the container.

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
