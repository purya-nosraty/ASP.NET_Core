using System;
using Shared;
using Resources.Messages;
using Domain.Features.Identity.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Features.Identity.Users;

[Table(name: nameof(User), Schema = nameof(Identity))]
public class User
	(string username, string password) : Seedwork.Entity
{
	/// <summary>
	/// شناسه کاربری
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
	public string Username { get; set; } = username;

	//***********************************************

	/// <summary>
	/// کلمه عبور
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.StringLength))]
	[StringLength
		(maximumLength: Utility.Const.RoleNameMaxLength,
		MinimumLength = Utility.Const.RoleNameMinLength,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.StringLength))]
	public string Password { get; set; } = password;

	//***********************************************

	/// <summary>
	/// سن
	/// </summary>
	[Range
		(minimum: Utility.Const.AgeMinLength,
		maximum: Utility.Const.AgeMaxLength)]
	public byte Age { get; set; }

	//***********************************************

	/// <summary>
	/// نام و نام خانوادگی
	/// </summary>
	[Display(Name = nameof(Resources.DataDictionary.FullName))]
	[StringLength
		(maximumLength: Utility.Const.FullNameMaxLength,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.StringLength))]
	public string? FullName { get; set; }

	//***********************************************

	/// <summary>
	/// توضیحات
	/// </summary>
	[MaxLength
		(length: Utility.Const.DescriptionMaxLength,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.MaxLength))]
	public string? Description { get; set; }

	//***********************************************

	/// <summary>
	/// وضعیت فعال بودن
	/// </summary>
	[Display(Name = nameof(Resources.DataDictionary.IsActive))]
	public bool IsActive { get; set; }

	//***********************************************

	/// <summary>
	/// شناسه نقش
	/// </summary>
	[Required
		(ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	public Guid RoleId { get; set; }
	public virtual Role? Role { get; set; }

	//***********************************************

	/// <summary>
	/// مرتبه
	/// </summary>
	//[Column(Order = 100_000)]
	[Range(minimum: 0, maximum: 100_000)]
	public int Ordering { get; set; }

	//***********************************************
}