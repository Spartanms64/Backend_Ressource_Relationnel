using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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