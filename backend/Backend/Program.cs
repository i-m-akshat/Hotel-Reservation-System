using Backend;
using Backend.DataAccessLayer.Context.DBContext;
using Backend.DataAccessLayer.Repository.Implementations;
using Backend.DataAccessLayer.Repository.Interfaces;
using Backend.Infrastructure.Repository.Implementations;
using Backend.Infrastructure.Repository.Interfaces;
using Backend.Services.Implementatios;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<BaseraHotelReservationSystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.Configure<Backend.Models.AppSettings_Domain.AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<ISecureService, SecureService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminRepo,AdminRepo>();
builder.Services.AddCors(options=>{
    options.AddPolicy("AllowSpecificOrigins",
    builder=>{
builder.WithOrigins("https://localhost:44395","https://localhost:44395/Common/Default.aspx").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
