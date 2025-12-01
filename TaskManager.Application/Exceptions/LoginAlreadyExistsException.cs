namespace TaskManager.Application.Exceptions;

public class LoginAlreadyExistsException(string login) : Exception($"Сотрудник с логином '{login}' уже есть в системе")
{
    public string Login { get; } = login;
}