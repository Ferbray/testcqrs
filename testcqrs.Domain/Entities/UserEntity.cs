namespace testcqrs.ModuleName.Entities;

public class UserEntity : BaseEntity
{
	public string Login { get; set; } = null!;
	public string Password { get; set; } = null!;
}