using Microsoft.EntityFrameworkCore;
using testcqrs.Domain.Entities;

namespace testcqrs.DataAccess;
public class DatabaseContext : DbContext
{
	public virtual DbSet<UserEntity> Users { get; set; }

	public DatabaseContext()
	{

	}

	public DatabaseContext(DbContextOptions options)
		: base(options)
	{

	}
}