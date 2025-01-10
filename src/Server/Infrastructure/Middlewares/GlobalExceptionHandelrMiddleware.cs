using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Server.Infrastructure.Middlewares;
public class GlobalExceptionHandelrMiddleware(RequestDelegate next)
{
	private RequestDelegate Next { get; } = next;

	public async Task InvokeAsync(HttpContext httpContext)
	{
		try
		{
			await Next(httpContext);
		}
		catch (Exception)
		{
			httpContext.Response.Redirect
				(location: "/Errors/Error", permanent: false);
		}
	}
}