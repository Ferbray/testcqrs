using Microsoft.EntityFrameworkCore;
using testcqrs.ModuleName.Entities;

namespace testcqrs.ModuleName.Data;

public class DatabaseContext : DbContext
{
	public virtual DbSet<UserEntity> Users { get; set; }

	public DatabaseContext()
	{
	}

	public DatabaseContext(DbContextOptions options) : base(options)
	{
	}
}