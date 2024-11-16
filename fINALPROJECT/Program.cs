using fINALPROJECTCORE.AppSettings;
using fINALPROJECTCORE.Country_Interface;
using fINALPROJECTCORE.Plant_Interface;
using fINALPROJECTCORE.Signup_Interface;
using fINALPROJECTCORE.Signup_Model;
using fINALPROJECTDATA.Country_Repository;
using fINALPROJECTDATA.Plant_Repository;
using fINALPROJECTDATA.Signup_Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Configuration.GetSection("ConnectionStrings").Bind(AppSettings.ConnnectionString);
builder.Services.AddScoped<ISignUpRepository, SignUpRepository>();
builder.Services.AddScoped<IPlantRepository, PlantRepository>();
builder.Services.AddScoped<ICountriyRepository, CountriyRepository>();
builder.Services.AddScoped<IStatesRepository, StatesRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<IEmailService, EmailService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5173")
// Update with your frontend origin
                          .AllowAnyHeader()
                          .AllowAnyMethod()) ;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
