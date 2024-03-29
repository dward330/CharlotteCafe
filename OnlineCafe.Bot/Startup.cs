using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Connector;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineCafe.Bot
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfiguration Configuration { get; }
    //This method gets called by the runtime.Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton(_ => Configuration);

      var credentialProvider = new StaticCredentialProvider(Configuration.GetSection(MicrosoftAppCredentials.MicrosoftAppIdKey)?.Value,
          Configuration.GetSection(MicrosoftAppCredentials.MicrosoftAppPasswordKey)?.Value);

      services.AddAuthentication(
               //This can be removed after https://github.com/aspnet/IISIntegration/issues/371
              options =>
              {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              }
          )
          .AddBotAuthentication(credentialProvider);

      services.AddSingleton(typeof(ICredentialProvider), credentialProvider);

      services.AddMvc(options =>
      {
        options.Filters.Add(typeof(TrustServiceUrlAttribute));
      });
    }


    //This method gets called by the runtime.Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseStaticFiles();

      app.UseAuthentication();

      app.UseMvc();
    }
  }
}
