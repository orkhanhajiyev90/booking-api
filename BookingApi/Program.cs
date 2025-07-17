using BookingApi.Business.Abstract;
using BookingApi.Business.Concrete;
using BookingApi.Business.FluentValidation;
using BookingApi.Core.Repository.Concrete;
using BookingApi.DataAccess.Repositories.Abstract;
using BookingApi.Exception;
using BookingApi.Infrastructure.Serialization;
using FluentValidation.AspNetCore;
using FluentValidation;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonDateOnlyConverter());
    });

builder.Services.AddValidatorsFromAssemblyContaining<DateRangeRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Logging.ClearProviders();

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));


var app = builder.Build();

app.UseGlobalExceptionMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
