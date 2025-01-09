using Shared;
using Domain.Features.Identity.Users.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Features.Identity.Users;

public class User
	(string username, string password, Role role) : Seedwork.Entity
{
	/// <summary>
	/// شناسه کاربری
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	[StringLength
		(maximumLength: Utility.UsernameMaxLength,
		MinimumLength = Utility.UsernameMinLength,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.StringLength))]
	public string Username { get; set; } = username;


	/// <summary>
	/// کلمه عبور
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.StringLength))]
	[StringLength
		(maximumLength: Utility.PasswordMinLength,
		MinimumLength = Utility.PasswordMinLength,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.StringLength))]
	public string Password { get; set; } = password;


	/// <summary>
	/// نقش
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public Role Role { get; set; } = role;


	/// <summary>
	/// سن
	/// </summary>
	[MaxLength
		(length: Utility.AgeMaxLength,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public byte Age { get; set; }


	/// <summary>
	/// نام و نام خانوادگی
	/// </summary>
	[StringLength
		(maximumLength: Utility.UsernameMinLength,
		MinimumLength = Utility.UsernameMinLength,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.StringLength))]
	public string? FullName { get; set; }


	/// <summary>
	/// توضیحات
	/// </summary>
	[MaxLength
		(length: Utility.DescriptionMaxLength,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? Description { get; set; }


	/// <summary>
	/// وضعیت فعال بودن
	/// </summary>
	public bool IsActive { get; set; }
}