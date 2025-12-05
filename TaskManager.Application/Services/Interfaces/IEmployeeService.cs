using TaskManager.Domain.Entities;
using TaskManager.Domain.Model.Employees;

namespace TaskManager.Application.Services.Interfaces;

public interface IEmployeeService
{
    Task<List<Employee>> GetRegularEmployeesAsync();
    Task<List<EmployeeSelectModel>> GetResponsibleEmployeesAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task CreateAsync(Employee employee);
    Task EditAsync(Employee employee);
}