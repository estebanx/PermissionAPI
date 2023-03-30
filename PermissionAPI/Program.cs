using FluentValidation.AspNetCore;
using Permission.Services.IoC;
using Permission.Services.Validators;
using Permission.Models.IoC;
using Permission.Models.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    options.EnableEndpointRouting = false;
}).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PermissionTypeValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("allowall", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddModelRegistry();
builder.Services.AddServicesRegistry();

builder.Services.AddDbContext<PermissionDataContext>(op => op.UseInMemoryDatabase("PermissionsDb"));

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseCors("allowall");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
