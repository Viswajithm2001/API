using MoviesAPI.Services;
using MoviesAPI.Filters;
using Microsoft.AspNetCore.Builder;
using MoviesAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(MyExceptionFilters));
}).AddXmlSerializerFormatters();
builder.Services.AddSingleton<IRepository,InMemoryRepository>();
builder.Services.AddTransient<MyActionFilter>();
builder.Services.AddTransient<IHostedService,WriteToFileHosterServices>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
