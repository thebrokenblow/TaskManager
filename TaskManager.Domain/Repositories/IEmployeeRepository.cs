using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Repositories;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task<Employee?> GetByLoginAsync(string login);
    Task<bool> IsLoginExistAsync(string login, int? excludeEmployeeId = null);
    Task AddAsync(Employee employee);
    Task UpdateAsync(Employee employee);
}