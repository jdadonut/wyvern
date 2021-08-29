using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Wyvern.Database;
using Microsoft.AspNetCore;
using System.Threading;
namespace Wyvern
{
  private WyvernDatabase db;
  public class Wyvern
  {
    Thread asp;
    public Wyvern()
    {
      BootstrapAspNet();
    }
    public void BootstrapAspNet()
    {
      this.asp = new Thread(() =>
      {
        WebHostBuilder app = new WebHostBuilder()
        .UseKestrel()
        .UseStartup<WyvernWebStartup>()
        app.UseDeveloperExceptionPage();
        Configure(app)
        app.Build().Run();
      });
    }
    public void Configure(IApplicationBuilder app)
    {
      app.UseStaticFiles();
      app.UseRouting();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapGet("/", async context =>
        {
          await context.Response.WriteAsync("Hello World!");
        });
      });
    }

    public Wyvern WithDatabase(WyvernDatabase database)
    {
      this.db = database;
    }
    public void Start()
    {
      BuildDepencies();
      this.asp.Start();
    }
    public void BuildDepencies()
    {
      return;
      if (this.db == null)
      {
        throw new Exception("Wyvern requires a database to be set");
      }

    }



  }
}