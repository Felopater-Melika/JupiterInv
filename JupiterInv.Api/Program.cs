using System.Data;
using System.Text;
using JupiterInv.Api.Configurations;
using JupiterInv.Core.Entities;
using JupiterInv.Infrastructure.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);

ConfigureLogger(builder);
ConfigureServices(builder);
ConfigureAuthentication(builder);
ConfigureAutoMapper(builder);
// ConfigureFluentValidation(builder);
ConfigureDatabase(builder);
ConfigureGraphQL(builder);
ConfigureIdentity(builder);

var app = builder.Build();


ConfigureMiddleware(app);

app.Run();

void ConfigureLogger(WebApplicationBuilder loggerBuilder)
{
    var serilogConfig = new LoggerConfiguration()
        .MinimumLevel.Information()
        .WriteTo.Console(theme: AnsiConsoleTheme.Code)
        .Enrich.FromLogContext()
        .CreateLogger();

    Log.Logger = serilogConfig;
    loggerBuilder.Host.UseSerilog();
}

void ConfigureServices(WebApplicationBuilder servicesBuilder)
{
    servicesBuilder.Services.AddControllers();
    servicesBuilder.Services.AddEndpointsApiExplorer();
    servicesBuilder.Services.AddSwaggerGen();
}

void ConfigureDatabase(WebApplicationBuilder servicesBuilder)
{
 

    servicesBuilder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    servicesBuilder.Services.AddIdentity<User, Role>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();
}

void ConfigureAutoMapper(WebApplicationBuilder servicesBuilder)
{
    servicesBuilder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}

// void ConfigureFluentValidation(WebApplicationBuilder servicesBuilder)
// {
//     servicesBuilder.Services.AddControllers().AddFluentValidation(fv =>
//     {
//         fv.RegisterValidatorsFromAssemblyContaining<Startup>();
//         // Any other FluentValidation configuration you might want
//     });
// }

void ConfigureGraphQL(WebApplicationBuilder servicesBuilder)
{
    servicesBuilder.Services.AddGraphQLServer();
}

void ConfigureIdentity(WebApplicationBuilder servicesBuilder)
{
    servicesBuilder.Services.AddIdentity<User, Role>().AddDefaultTokenProviders();
}

void ConfigureAuthentication(WebApplicationBuilder authenticationBuilder)
{
    var jwtSettings = authenticationBuilder.Configuration.GetSection("Jwt").Get<JwtSettings>();

    authenticationBuilder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            if (jwtSettings != null)
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer ?? throw new InvalidOperationException("Issuer not found in Jwt settings."),
                    ValidAudience = jwtSettings.Audience ?? throw new InvalidOperationException("Audience not found in Jwt settings."),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key ?? throw new InvalidOperationException("Key not found in Jwt settings.")))
                };
            }
        });
}

void ConfigureMiddleware(WebApplication application)
{
    if (application.Environment.IsDevelopment())
    {
        application.UseSwagger();
        application.UseSwaggerUI();
    }

    application.UseHttpsRedirection();
    application.UseRouting();
    application.UseAuthentication();
    application.UseAuthorization();
    application.MapControllers();
    application.MapGraphQL();
}
