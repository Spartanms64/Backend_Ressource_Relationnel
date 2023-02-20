using Backend_Ressource_Relationnel.Controllers;
using Backend_Ressource_Relationnel.Models;



namespace Backend_Ressource_Relationnel
{
    public class Program
    {
        public static void Main(string[] args)
        {

            /***************** Serveur **************************/

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Test API
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            /****************************************************/












        }
    }
}