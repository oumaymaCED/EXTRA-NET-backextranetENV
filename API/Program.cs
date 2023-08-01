using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using API.Controllers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

using DataAccess.Layer.DataContext;
using DataAccess.Layer.Repositories;
using DataAccess.Layer.Repositories.Contracts;
using Business.Layer.Services;
using Business.Layer.Services.Contracts;
using Microsoft.Extensions.Options;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using MongoDB.Driver.Core.Configuration;
using Business.Layer.DependencyInjenction;
using Microsoft.AspNetCore.Hosting;
using SolrNet;

using DataAccess.Layer.Models;

//using Cqrs.Hosts;
//using ikvm.runtime; 


var builder = WebApplication.CreateBuilder(args);

DependencyInjection.RegisterServices(builder.Services);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(Business.Layer.AutoMapper.AutoMapper));
builder.Services.AddAutoMapper(typeof(Startup));

builder.Services.AddDbContext<NewRepairDbQaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerConnStr"));
});
builder.Services.AddDbContext<NewRepairDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerConnStr"));
});

builder.Services.AddCors(options => options.AddPolicy(name: "dossier",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

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
app.UseCors("dossier");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 

app.Run();
