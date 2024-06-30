using Microsoft.AspNetCore.OpenApi;
using TodoApi.controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Rabbit MQ
builder.Services.AddRabbitMQService();

var app = builder.Build();

app.AddApiEndPoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
