using Microsoft.Extensions.DependencyInjection;
using testcqrs.ModuleName.Contracts.Data;

namespace testcqrs.ModuleName.Data;

public class UnitOfWork(IServiceProvider serviceProvider, DatabaseContext context) : IUnitOfWork
{
	private readonly IServiceProvider _serviceProvider = serviceProvider;
	private readonly DatabaseContext _context = context;

	public T Repository<T>() where T : notnull =>
		_serviceProvider.GetService<T>() ??
			throw new Exception($"UnitOfWork does not contain repository {typeof(T).Name}");

	public void Commit() => _context.SaveChanges();

	public Task CommitAsync() => _context.SaveChangesAsync();
}
