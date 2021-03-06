using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>opt.UseInMemoryDatabase("AppDbInMem"));
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    // populate mock data
    PrepDb.PrepPopulation(app);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
