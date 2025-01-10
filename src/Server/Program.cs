using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Server.Infrastructue.Settings;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Server.Infrastructure.Middlewares;

namespace Server;

internal static class Program
{
	static Program()
	{
	}

	private static async Task Main()
	{
		var webApplication = new WebApplicationOptions
		{
			EnvironmentName = Environments.Development
			//EnvironmentName = Environments.Production
		};

		var builder = WebApplication.CreateBuilder(options: webApplication);

		//**************************************************************

#pragma warning disable S125
		//var email =
		//	builder.Configuration.GetSection(key: "EmailAddress").Value;

		//var age =
		//	builder.Configuration.GetSection(key: "AdminSettings:Age").Value;

		//var a = builder.Configuration.GetSection("AdminSettings").GetSection("Age").Value;
#pragma warning restore S125

		builder.Services
			.Configure<AdminSettings>
				(builder.Configuration.GetSection(key: nameof(AdminSettings)));

		//**************************************************************
		builder.Services.AddRazorPages();

		builder.Services.Configure
			<RequestLocalizationOptions>(option =>
		{
			var supportedCultures = new[]
			{
				new CultureInfo(name: "fa-IR"),
				new CultureInfo(name: "en-US"),
			};

			option.SupportedCultures = supportedCultures;
			option.SupportedUICultures = supportedCultures;

			option.DefaultRequestCulture =
				new RequestCulture(culture: "en-US", uiCulture: "en-US");
		});

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}
		else
		{
			app.UseExceptionHandler("/Errors/Error");
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();
		app.UseRouting();
		app.UseAuthentication();
		app.UseAuthorization();

#pragma warning disable S125
		//app.UseMiddleware<Infrastructue.Middlewares.CultureCookieHandlingMiddleware>();
		app.UseCultureCookie();
#pragma warning restore S125

		app.UseGlobalException();
		app.MapRazorPages();

		await app.RunAsync();
	}
}