using Microsoft.EntityFrameworkCore;
using Domain.Features.Identity.Users;

namespace Persistence;

public class ApplicationDatabaseContext : DbContext
{
	#region Constructor
	public ApplicationDatabaseContext() : base()
	{
		Database.EnsureDeleted();
		Database.EnsureCreated();
	}
	#endregion /Constructor

	#region Properties
	public DbSet<User> Users { get; set; }
	#endregion /Properties

	#region Methods
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var connectionString =
			"Server=.;User=sa;Password=123;Database=Project;MultipleActiveResultSets=true;TrustServerCertificate=True;";

		optionsBuilder.UseSqlServer
			(connectionString: connectionString);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly
			(assembly: typeof(ApplicationDatabaseContext).Assembly);
	}
	#endregion /Methods
}