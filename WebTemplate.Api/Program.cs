using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using WebTemplate.DAL;
using WebTemplate.Info;
using WebTemplate.Services.Interfaces;
using WebTemplate.Services.Services;

public class Program
{
    public static void Main(string[] args)
    {
        Logger logger = LogManager
            .Setup()
            .LoadConfigurationFromAppSettings()
            .GetCurrentClassLogger();
        try
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<ITestService, TestService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DataContext")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }
            else
            {
                app.UseStatusCodePages();
                app.UseResponseCompression();
            }

            app.UseStaticFiles();
            app.UseHttpLogging();
            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapBuildInfoRoute();

            app.Run();
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Program stopped because of exception");
            throw;
        }
        finally
        {
            LogManager.Shutdown();
        }
    }
}
