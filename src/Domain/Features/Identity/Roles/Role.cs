using Shared;
using Resources.Messages;
using System.Collections.Generic;
using Domain.Features.Identity.Users;
using System.ComponentModel.DataAnnotations;

namespace Domain.Features.Identity.Roles;

public class Role(string name) : Seedwork.Entity
{
	/// <summary>
	/// نام نقش
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[StringLength
		(maximumLength: Utility.UsernameMaxLength,
		MinimumLength = Utility.UsernameMinLength,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.StringLength))]
	public string Name { get; set; } = name;


	//***********************************************


	/// <summary>
	/// کاربر
	/// </summary>
	public virtual IList<User> Users { get; } = [];


	//***********************************************
}