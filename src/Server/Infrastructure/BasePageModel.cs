using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Server.Infrastructure;

public abstract class BasePageModel : PageModel
{
	protected BasePageModel() : base()
	{
	}
}