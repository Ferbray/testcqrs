namespace testcqrs.Domain.Requests;

public class UserRequest
{
    public Guid Id { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
}