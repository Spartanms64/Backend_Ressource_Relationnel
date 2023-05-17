using Backend_Ressource_Relationnel.Models;
using Jose;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Text;

namespace Backend_Ressource_Relationnel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Cette méthode est appelée pour ajouter des services.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuration Base de données MySQL avec connexion
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options =>
                options.UseMySql(connectionString, MariaDbServerVersion.AutoDetect(connectionString))
                );
            //services.AddDbContext<DataContext>(options => options.UseMemoryCache();

            //configuration FTP Serveur
            var ftpUrl = Configuration.GetSection("FtpSettings")["FtpServerURL"]; ;// Récupération de l'URL du serveur FTP depuis le fichier de configuration
            var ftpUsername = Configuration.GetSection("FtpSettings")["FtpUsername"]; // Récupération du nom d'utilisateur du serveur FTP depuis le fichier de configuration
            var ftpPassword = Configuration.GetSection("FtpSettings")["FtpPassword"]; // Récupération du mot de passe du serveur FTP depuis le fichier de configuration

            // Inscription d'un WebClient en tant que service injectable pour interagir avec le serveur FTP
            services.AddSingleton<WebClient>((provider) =>
            {
                var client = new WebClient();
                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                return client;
            });
            /******** TEST FTP **********/
            // Test de connexion en affichant la liste des fichiers du répertoire racine

            /*// Création d'un WebClient pour interagir avec le serveur FTP
        _webClient = new WebClient();
        _webClient.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

        // Test de connexion en affichant la liste des fichiers du répertoire racine
        var fileList = _webClient.DownloadString(ftpUrl);
        Console.WriteLine($"Liste des fichiers du répertoire racine du serveur FTP : {fileList}");*/

            /***********  Jwt  *************/

            // Configuration de JWT (JSON Web Token)
            /*var jwtSettings = Configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(jwtSettings);
            var jwtSettingsOptions = jwtSettings.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettingsOptions.SecretKey);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettingsOptions.ValidIssuer,
                    ValidAudience = jwtSettingsOptions.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });*/

            /*********************************************************/

            services.AddIdentity<User, Role>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

            services.AddControllers();
            //Ajout service Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger", Version = "test" });
            });
            // inscription du DbContext en tant que service injectable
            //services.AddDbContext<Backend_Ressource_Relationnel_V2.DataContext>();
            services.AddEndpointsApiExplorer();

            services.AddMvc();
        }

        //*********** Zone Swagger *************//
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
            }
            /*******************************************************/
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
             );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });*/
        }
    }
}

/*
var allowOrigins = Configuration.GetValue<string>("AllowOrigins");
services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins(allowOrigins)
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowCredentials();
    });
    options.AddPolicy("AllowHeaders", builder =>
    {
        builder.WithOrigins(allowOrigins)
        .WithHeaders(HeaderNames.ContentType, HeaderNames.Server, HeaderNames.AccessControlAllowHeaders, HeaderNames.AccessControlExposeHeaders, "x-custom-header", "x-path", "x-record-in-use", HeaderNames.ContentDisposition);
    });
});*/