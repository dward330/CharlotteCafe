using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Connector;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnlineCafe.Interfaces;
using OnlineCafe.Interfaces.Repository;
using OnlineCafe.Interfaces.Services.Lineitem;
using OnlineCafe.Interfaces.Services.Menu;
using OnlineCafe.Interfaces.Services.Order;
using OnlineCafe.Interfaces.Services.User;
using OnlineCafe.Repository.Menu;
using OnlineCafe.Repository.MenuItem;
using OnlineCafe.Repository.Order;
using OnlineCafe.Repository.User;
using OnlineCafe.Services;
using OnlineCafe.Services.Menu;
using OnlineCafe.Services.Order;
using OnlineCafe.Services.User;
using OnlineCafe.Unity;
using Unity;
using Unity.Lifetime;
using Unity.RegistrationByConvention;

namespace OnlineCafe.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;

      #region
      List<Assembly> allAssemblies = new List<Assembly>();
      string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

      foreach (string dll in Directory.GetFiles(path, "*.dll").Where(x => !x.Contains("Document")))
        allAssemblies.Add(Assembly.LoadFile(dll));
#endregion
    }

    
    public void ConfigureContainer(IUnityContainer container)
    {

      var dependencyResolver = new UnityDependencyResolver();
      var assemblyCollection = AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.GetName().Name.Contains("Bot") &&
                         !x.GetName().Name.Contains("Unity") && x.GetName().Name.Contains("OnlineCafe")).Distinct().ToList();
      var assemblyTypes = assemblyCollection.SelectMany(x => x.GetTypes()).Distinct().ToList();
      container.RegisterTypes(assemblyTypes,
            WithMappings.FromAllInterfaces,
            WithName.Default,
            WithLifetime.ContainerControlled, overwriteExistingMappings: true);

      container.RegisterType<INewService, NewService>();
      container.RegisterType<IValueService, ValueService>();
      container.RegisterType<IOnlineCafeDataProvider, OnlineCafeDataProviderDatabase>();
      container.RegisterType<IMenuDataProvider, MenuDataProviderDatabase>();
      container.RegisterType<IMenuItemDataProvider, MenuItemDataProviderDatabase>();
      container.RegisterType<ILineItemDataProvider, LineItemDataProviderDatabase>();
      container.RegisterType<IOrderDataProvider, OrderDataProviderDatabase>();
      container.RegisterType<IMenuService, MenuService>();
      container.RegisterType<IMenuItemService, MenuItemService>();
      container.RegisterType<ILineItemService, LineItemService>();      
      container.RegisterType<IOrderService, OrderService>();
      container.RegisterType<IUserService, UserService>();
      container.RegisterType<IUserDataProvider, UserDataProviderFile>();
      
    }
    
    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton(_ => Configuration);

      var msAppIdKey = Configuration.GetSection(MicrosoftAppCredentials.MicrosoftAppIdKey)?.Value;
      var msAppPwdKey = Configuration.GetSection(MicrosoftAppCredentials.MicrosoftAppPasswordKey)?.Value;

      services.AddAuthentication(o =>
      {
        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
          .AddBotAuthentication(msAppIdKey, msAppPwdKey);

      services.AddMvc(o =>
      {
        o.Filters.Add(typeof(TrustServiceUrlAttribute));
      });

      
      services.AddDbContext<OnlineCafeDataProviderDatabase>(options =>
      {
        var connectionString = "Server=tcp:onlinecafesql-ip.database.windows.net;Database=onlineCafeDb;User ID=cafeadmin;Password=Charlottecafe1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //var connectionString = "Server=CSWING-SURFACE\\SQLEXPRESS;Database=OnlineCafe;Trusted_Connection=True;";
        options.UseSqlServer(connectionString);
      });
      

      services.AddCors(options =>
      {
        options.AddPolicy("onlineCafe",
            policy => {
              policy.AllowAnyOrigin();
              policy.AllowAnyHeader();
              policy.AllowAnyMethod();
            });
      });
      services.AddMvc();      
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseStaticFiles();
      }
      app.UseAuthentication();
      app.UseCors("onlineCafe");

      app.UseMvc();
    }
  }
}
