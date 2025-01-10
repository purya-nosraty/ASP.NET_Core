using System.Linq;
using Persistence;
using Domain.Features.Identity.Users;
using Domain.Features.Identity.Roles;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages;

public class IndexModel : Infrastructure.BasePageModel
{
	public IndexModel() : base()
	{
	}

	public async Task OnGet()
	{
		using var databaseContext = new ApplicationDatabaseContext();

		var userExist =
			await
			databaseContext.Users.AnyAsync();

		string? username;

		if (userExist)
		{
			username =
				await
				databaseContext.Users
					.Select(current => current.Username)
					.FirstOrDefaultAsync();
		}
		else
		{
			var role =
				new Role(name: Resources.DataDictionary.Admin);

			databaseContext.Roles.Add(entity: role);
			await
				databaseContext.SaveChangesAsync();

			var user =
				new User
					(username: Resources.DataDictionary.AuthorName,
					password: "12345678")
				{
					Age = 28,
					IsActive = true,
					RoleId = role.Id,
					FullName = "popo",
				};

			username = user.Username;

			databaseContext.Users.Add(entity: user);
			await
				databaseContext.SaveChangesAsync();
		}

		ViewData["FullName"] = username;
		ViewData["PageTitle"] = Resources.PageTitles.Index;
	}
}