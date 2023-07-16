using FluentValidation;
using MentorMate.Zoo.API.Extensions;
using MentorMate.Zoo.Business.Factories;
using MentorMate.Zoo.Business.Helpers.Mapper;
using MentorMate.Zoo.Business.Services;
using MentorMate.Zoo.Business.Strategy;
using MentorMate.Zoo.Business.Validators;
using MentorMate.Zoo.Data;
using MentorMate.Zoo.Data.Constants;
using MentorMate.Zoo.Data.Repositories;
using MentorMate.Zoo.Data.Seed;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }); ;

builder.Services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(builder.Configuration
                .GetConnectionString(DatabaseConfiguration.ConnectionStringName))
);

builder.Services.AddScoped<IFoodFactory, FoodFactory>();
builder.Services.AddScoped<IFoodStrategy, FoodStrategy>();
builder.Services.AddScoped<IResultFactory, ResultFactory>();
builder.Services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddAutoMapper(typeof(AnimalProfile));
builder.Services.AddValidatorsFromAssemblyContaining<AnimalDTOValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await app.InitializeDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
