using Backend_Ressource_Relationnel;
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
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 6, 11)))
                );

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
