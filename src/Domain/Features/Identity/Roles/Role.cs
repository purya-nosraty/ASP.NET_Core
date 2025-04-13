using Shared;
using Resources.Messages;
using System.Collections.Generic;
using Domain.Features.Identity.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Features.Identity.Roles;

[Table(name: nameof(Role), Schema = nameof(Identity))]
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
		(maximumLength: Utility.Const.RoleNameMaxLength,
		MinimumLength = Utility.Const.RoleNameMinLength,
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