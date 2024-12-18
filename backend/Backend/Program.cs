using Backend;
using Backend.DataAccessLayer.Context.DBContext;
using Backend.DataAccessLayer.Repository.Implementations;
using Backend.DataAccessLayer.Repository.Interfaces;
using Backend.Infrastructure.Repository.Implementations;
using Backend.Infrastructure.Repository.Interfaces;
using Backend.Models.Mail_Domain;
using Backend.Services.Implementatios;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


// builder.WebHost.ConfigureKestrel(options=>{
//    options.Listen(System.Net.IPAddress.Any, 69696);
// });


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<BaseraHotelReservationSystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#region Application Settings part here



builder.Services.Configure<Backend.Models.AppSettings_Domain.AppSettings>(builder.Configuration.GetSection("AppSettings"));



#endregion
#region EmailConfiguration Part here 



var emailConfig = builder.Configuration.GetSection("MailSettings").Get<MailSettings>();
builder.Services.AddSingleton(emailConfig);



#endregion

#region Scoped Services here 



builder.Services.AddScoped<ISecureService, SecureService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminRepo,AdminRepo>();
builder.Services.AddScoped<ICountryRepo, CountryRepo>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IStateRepo, StateRepo>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<ICityRepo, CityRepo>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IRoleRepo, RoleRepo>();  
builder.Services.AddScoped<IAccessRepo, AccessRepo>();  
builder.Services.AddScoped<IAccessService,AccessService>();
builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IHotelRepo, HotelRepo>();
builder.Services.AddScoped<IHotelService, HotelServices>();



#endregion

#region Cross-Origin Resource Sharing-- Allowing the access to request coming from  https://localhost:44395 or https://localhost:44395/Common/Default.aspx , blocking other requests


builder.Services.AddCors(options=>{
    options.AddPolicy("AllowSpecificOrigins",
    builder=>{
builder.WithOrigins("https://localhost:44395","https://localhost:44395/Common/Default.aspx").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});


#endregion


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
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
