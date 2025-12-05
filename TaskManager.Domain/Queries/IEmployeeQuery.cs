using TaskManager.Domain.Entities;
using TaskManager.Domain.Model.Employees;

namespace TaskManager.Domain.Queries;

public interface IEmployeeQuery
{
    Task<List<Employee>> GetRegularEmployeesAsync();
    Task<List<EmployeeSelectModel>> GetResponsibleEmployeesAsync();
}