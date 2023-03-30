using MediatR;
using Microsoft.EntityFrameworkCore;
using MoneyMe.Api;
using MoneyMe.Api.Source.Infrastructure.DataProvider;
using MoneyMe.Api.Source.Infrastructure.DataProvider.EntityFramework;
using MoneyMe.Api.Source.Infrastructure.QuoteCalculator;
using MoneyMe.Api.Source.Infrastructure.RedirectUrlGenerator;
using System.Reflection;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => options
        .UseNpgsql(builder.Configuration.GetSection("AppSettings").Get<AppSettings>().ConnectionString));
builder.Services.Configure<AppSettings>(options => builder.Configuration
        .GetSection("AppSettings")
        .Bind(options));
builder.Services
        .AddLogging(configure => configure.AddConsole());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IDataProvider, EntityFrameworkDataProvider>();
builder.Services.AddSingleton<IRedirectUrlGenerator, Base64RedirectUrlGenerator>();
builder.Services.AddSingleton(new QuoteCalculatorFactory());

// Configure the HTTP request pipeline.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
app.ConfigureExceptionHandler(app.Logger);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
