using TaskManager.Domain.Model.Employees;

namespace TaskManager.Domain.Services;

public interface IAuthService
{
    bool IsAuthenticated { get; }
    bool IsAdmin { get; }
    string? FullName { get; }
    int? IdCurrentUser { get; }
    int IdAdmin { get; }

    Task<bool> LoginAsync(EmployeeLoginModel employeeLoginModel);
    Task LogoutAsync();
}