using Resources;
using Microsoft.EntityFrameworkCore;
using Domain.Features.Identity.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Features.Identity.Roles;

namespace Persistence.Features.Identity.Users;

internal class UserConfiguration() : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		#region Id
		builder
			.HasKey(current => current.Id)
			.IsClustered(clustered: false)
			;

		builder
			.Property(current => current.Id)
			.IsRequired(required: true)
			;

		builder
			.HasIndex(current => current.Id)
			.IsUnique(unique: true)
			.IsClustered(clustered: false)
			;
		#endregion /Id

		//***********************************************

		#region Username
		builder
			.Property(current => current.Username)
			.IsRequired(required: true)
			.IsUnicode(unicode: false)
			.HasMaxLength(maxLength: Shared.Utility.UsernameMaxLength)
			;

		builder
			.HasIndex(current => current.Username)
			.IsUnique(unique: true)
			;
		#endregion /Username

		//***********************************************

		#region Password
		builder
			.Property(current => current.Password)
			.IsRequired(required: true)
			.IsUnicode(unicode: false)
			.HasMaxLength(maxLength: Shared.Utility.PasswordMaxLength)
			;
		#endregion /Password

		//***********************************************

		#region RoleId
		builder
			.Property(current => current.RoleId)
			.IsRequired(required: true)
			;
		#endregion /RoleId

		//***********************************************

		#region Age
		builder
			.Property(current => current.Age)
			;
		#endregion /Age

		//***********************************************

		#region FullName
		builder
			.Property(current => current.FullName)
			.HasMaxLength(maxLength: Shared.Utility.UsernameMaxLength)
			;

		builder
			.HasIndex(current => current.FullName)
			.IsUnique(unique: false)
			;
		#endregion /FullName

		//***********************************************

		#region Active
		builder
			.Property(current => current.IsActive)
			;
		#endregion /IsActive

		//***********************************************

		builder
			.Property(current => current.Ordering)
			;

		//***********************************************

		#region SeedData
		//var role =
		//	new Role(name: nameof(DataDictionary.Admin));

		//builder
		//	.HasData(data: role);

		//var user =
		//	new User
		//		(username: "Puria",
		//		password: "12345678")
		//	{
		//		Age = 28,
		//		IsActive = true,
		//		RoleId = role.Id,
		//		Description = null,
		//		FullName = DataDictionary.AuthorName,
		//	};

		//builder
		//	.HasData(data: user);
		#endregion /SeedData

		//***********************************************
	}
}