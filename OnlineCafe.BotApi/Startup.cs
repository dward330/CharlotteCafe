using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Connector;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineCafe.BotApi
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
            #region
            List<Assembly> allAssemblies = new List<Assembly>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (string dll in Directory.GetFiles(path, "*.dll").Where(x => !x.Contains("OnlineCafe.BotApi")))
                allAssemblies.Add(Assembly.LoadFile(dll));
            #endregion
        }

        public IConfiguration Configuration { get; }
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton(_ => Configuration);

      var credentialProvider = new StaticCredentialProvider(Configuration.GetSection(MicrosoftAppCredentials.MicrosoftAppIdKey)?.Value,
          Configuration.GetSection(MicrosoftAppCredentials.MicrosoftAppPasswordKey)?.Value);

      services.AddAuthentication(
              // This can be removed after https://github.com/aspnet/IISIntegration/issues/371
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

      //var builder = new ContainerBuilder();
      //var assemblyCollection = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name.Contains("Bot") ||
      //        !x.GetName().Name.Contains("Services")).Distinct().ToArray();
      //builder
      //.RegisterAssemblyTypes(assemblyCollection)
      //.AsImplementedInterfaces()
      //.InstancePerRequest();
      //builder.Populate(services);
      //var container = builder.Build();
      //return new AutofacServiceProvider(container);
    }


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseStaticFiles();

      app.UseAuthentication();

      app.UseMvc();
    }
  }
}
