using BloodTrack.Application;
using BloodTrack.Application.Services.ExternalServices;
using BloodTrack.Infrastructure;
using BloodTrack.Infrastructure.Persistence;
using BloodTrack.Infrastructure.Services;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient<ICepService, ViaCepService>();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();


var connectionString = builder.Configuration.GetConnectionString("BloodTrackCs");

builder.Services.AddDbContext<BloodTrackDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<BloodTrack.Api.Middlewares.ExceptionMiddleware>();

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
