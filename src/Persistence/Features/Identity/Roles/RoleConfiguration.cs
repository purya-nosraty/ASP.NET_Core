using Microsoft.EntityFrameworkCore;
using Domain.Features.Identity.Roles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Features.Identity.Roles;

internal class RoleConfiguration() : IEntityTypeConfiguration<Role>
{
	public void Configure(EntityTypeBuilder<Role> builder)
	{
		#region Id
		builder
			.HasKey(x => x.Id)
			.IsClustered(clustered: false)
			;
		#endregion /Id

		//***********************************************

		#region Name
		builder
			.Property(x => x.Name)
			.IsRequired(required: true)
			.IsUnicode(unicode: false)
			.IsFixedLength(fixedLength: false)
			;

		builder
			.HasIndex(x => x.Name)
			.IsUnique(unique: true)
			;
		#endregion /Name

		//***********************************************

		#region Users
		builder
			.HasMany(x => x.Users)
			.WithOne(nameof(Role))
			.IsRequired(required: true)
			.HasForeignKey(x => x.RoleId)
			.OnDelete(DeleteBehavior.NoAction)
			;
		#endregion /Users

		//***********************************************
	}
}