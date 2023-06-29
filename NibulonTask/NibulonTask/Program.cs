using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NibulonBLL.Interfaces;
using NibulonBLL.MappingProfile;
using NibulonBLL.NibulonBLL;
using NibulonDAL.Data;
using NibulonDAL.Interfaces;
using NibulonDAL.Repositories;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc().AddCookieTempDataProvider();
builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDataProtection();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nibulon", Version = "v1" });

    c.UseInlineDefinitionsForEnums();
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IGrainElevatorArrivalsTableRepository, GrainElevatorArrivalsTableRepository>();
builder.Services.AddScoped< IGrainElevatorArrivalsTableService, GrainElevatorArrivalsTableService>();

builder.Services.AddScoped<IGroupedDataTableRepository, GroupedDataTableRepository>();
builder.Services.AddScoped<IGroupedDataTableService, GroupedDataTableService>();

builder.Services.AddScoped<IWeightedAverageTableRepository, WeightedAverageTableRepository>();
builder.Services.AddScoped<IWeightedAverageTableService, WeightedAverageTableService>();


builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
builder.Services.AddSingleton<ITempDataDictionaryFactory, TempDataDictionaryFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tables}/{action=GrainElevatorArrivalsTable}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
