using webapi.Core.Extensions;
using webapi.Core.Interfaces;
using webapi.Infrastructure.Data.DbConnection;
using webapi.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
var corsPolicy = "CorsPolicy";

// Add services to the container.
builder.Services.ConfigureCors(corsPolicy);
builder.Services.AddControllers();
builder.Services.AddSingleton(_ => new DbConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

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

app.UseCors(corsPolicy);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
