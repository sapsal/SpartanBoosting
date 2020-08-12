using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpartanBoosting.Models.Data;
using SpartanBoosting.Models.Repositorys;
using SpartanBoosting.Utils;
using Stripe;

namespace SpartanBoosting
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews().AddRazorRuntimeCompilation();
			//services.AddApplicationInsightsTelemetry("385ae6ef-e3a5-43b5-84d8-820e4ac8b1e9");
			services.AddSingleton<IEmailSender, EmailSender>();
			services.Configure<SmtpSettings>(Configuration.GetSection("Smtp"));
			services.AddDbContextPool<AppDbContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped<IPurchaseOrderRepository, SqlPurchaseOrderRepository>();

			ObjectFactory.LoadPricing();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});

			app.UseForwardedHeaders(new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor |
		  ForwardedHeaders.XForwardedProto
			});

			StripeConfiguration.SetApiKey("sk_test_51GuKbWF9YOHhm6ddnekRwwVMKi5X5XxEj5RtIGmemedeWHdMzyczJGRon90eAoj3oVqKsyI1EjLxg77YqCteqIyM00LMyi7RQ1");
		}
	}
}
