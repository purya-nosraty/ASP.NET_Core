using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder =
	Microsoft.AspNetCore.Builder
	.WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
