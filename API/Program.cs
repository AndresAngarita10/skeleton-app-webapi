using iText.Kernel.XMP.Options;
using Persistencia;
using Microsoft.EntityFrameworkCore;
using API.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//---------------------------
//--------------------------------------
//-------------------------------------------------/////////////////
builder.Services.AddDbContext<SkeletonAppWebApiContext>(options =>
    {
        string connectionString = builder.Configuration.GetConnectionString("ConexMysql");   
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
);

builder.Services.ConfigureCors();
builder.Services.AddAplicacionServices();//-----------------
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly()); // ------------------

//_------------------------------------///////////////
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//---------------------------
//--------------------------------------
//------------------------------------------------

app.UseCors("CorsPolicy");

//----------------------------------------------///////////////////////
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
