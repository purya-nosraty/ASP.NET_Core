using Microsoft.EntityFrameworkCore;
using Domain.Features.Identity.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
		#endregion /Id

		//***********************************************

		#region Username
		builder
			.Property(current => current.Username)
			.IsRequired(required: true)
			.IsUnicode(unicode: false)
			.IsFixedLength(fixedLength: false)
			.HasMaxLength(maxLength: Shared.Utility.Const.UsernameMaxLength)
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
			.IsFixedLength(fixedLength: false)
			.HasMaxLength(maxLength: Shared.Utility.Const.PasswordMaxLength)
			;
		#endregion /Password

		//***********************************************

		#region Age
		builder
			.Property(current => current.Age)
			.HasMaxLength(maxLength: Shared.Utility.Const.AgeMaxLength)
			;
		#endregion /Age

		//***********************************************

		#region FullName
		builder
			.Property(current => current.FullName)
			.IsRequired(required: false)
			.IsUnicode(unicode: true)
			.IsFixedLength(fixedLength: false)
			.HasMaxLength(maxLength: Shared.Utility.Const.FullNameMaxLength)
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
			.HasColumnName(name: nameof(Resources.DataDictionary.IsActive))
			;
		#endregion /IsActive

		//***********************************************

		builder
			.Property(current => current.Ordering)
			.HasMaxLength(maxLength: 100_000)
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