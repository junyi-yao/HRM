using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IJobService, JobService>();
//Ninject and autofac to use other Dependency Injections
builder.Services.AddScoped<IJobRepository, JobRepository>();


var dockerConnectionString = Environment.GetEnvironmentVariable("MSSQLConnectionString");

//Inject our connectionstring into DbContext
//builder.Services.AddDbContext<RecruitingDbContext>(
//    options => options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDbConnection"))
//    );

builder.Services.AddDbContext<RecruitingDbContext>(options => options.UseSqlServer(dockerConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
