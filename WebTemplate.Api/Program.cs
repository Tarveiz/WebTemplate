using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using WebTemplate.DAL;
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
        logger.Info("init main");

        try
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddScoped<ITestService, TestService>();

            #region SwaggerMiddleware
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            builder.Services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DataContext")));

            #region Nlog
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                #region Swagger
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
                #endregion
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePages();
                //app.UseResponseCompression();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllers();

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
