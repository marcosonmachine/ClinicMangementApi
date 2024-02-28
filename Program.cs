using ApiProject.Data;
using ApiProject.Services.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using ApiProject.Filters;
using ApiProject.Mapper;
using ApiProject.Services;
using System.ComponentModel.Design;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("mssql_connection"));
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.EnableAnnotations();
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "MIS.Backend", Version = "v1" });
    option.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });

    var filePath = Path.Combine(AppContext.BaseDirectory, "ApiProject.xml");
    option.IncludeXmlComments(filePath);

    option.OperationFilter<AuthResponsesOperationFilter>();
});

builder.Services.AddProblemDetails();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Support string to enum conversions
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// These will eventually be moved to a secrets file, but for alpha development appsettings is fine
var validIssuer = builder.Configuration.GetValue<string>("JwtTokenSettings:ValidIssuer");
var validAudience = builder.Configuration.GetValue<string>("JwtTokenSettings:ValidAudience");
var symmetricSecurityKey = builder.Configuration.GetValue<string>("JwtTokenSettings:SymmetricSecurityKey");

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.IncludeErrorDetails = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            // TODO: Later change it
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = validIssuer,
            ValidAudience = validAudience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(symmetricSecurityKey)
            ),
        };
    });

builder.Services.AddAuthorization(
    options =>
    {
        // options.AddPolicy("Admin",policy => policy.RequireClaim("Role", "Admin"));
    }
);

builder.Services.AddHttpContextAccessor();

//JWT blacklist
builder.Services.AddSingleton<IBlackListService, InMemoryBlacklistService>();
// Register Token Service Dependency
builder.Services.AddScoped<ITokenService, TokenService>();
// Data Services 
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IDictionaryApiService, DictionaryApiService>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<InspectionService>();
builder.Services.AddScoped<ConsultationService>();

// Database resetu

// Build the app
var app = builder.Build();


// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        // _context.Database.EnsureDeleted();
        // _context.Database.EnsureCreated();
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStatusCodePages();


//Auth
app.UseAuthentication();
app.UseMiddleware<BlacklistMiddleware>();
app.UseAuthorization();


app.MapControllers();
app.Run();