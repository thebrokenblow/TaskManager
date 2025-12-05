using TaskManager.Application.Exceptions;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using TaskManager.Domain.Model.Employees;
using TaskManager.Domain.Queries;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Services;

public class EmployeeService(
    IEmployeeQuery employeeQuery, 
    IEmployeeRepository employeeRepository) : IEmployeeService
{
    private const string DefaultPassword = "Qwerty123";

    public async Task<List<Employee>> GetRegularEmployeesAsync()
    {
        var employee = await employeeQuery.GetRegularEmployeesAsync();

        return employee;
    }

    public async Task<List<EmployeeSelectModel>> GetResponsibleEmployeesAsync()
    {
        var responsibleEmployees = await employeeQuery.GetResponsibleEmployeesAsync();

        return responsibleEmployees;
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        var employee = await employeeRepository.GetByIdAsync(id);

        return employee;
    }

    public async Task CreateAsync(Employee employee)
    {
        var loginExists = await employeeRepository.IsLoginExistAsync(employee.Login);

        if (loginExists)
        {
            throw new LoginAlreadyExistsException(employee.Login);
        }

        TrimEmployeeProperties(employee);

        employee.Password = DefaultPassword;
        employee.Role = RolesDictionary.Employee;

        await employeeRepository.AddAsync(employee);
    }

    public async Task EditAsync(Employee employee)
    {
        var loginExists = await employeeRepository.IsLoginExistAsync(employee.Login, employee.Id);

        if (loginExists)
        {
            throw new LoginAlreadyExistsException(employee.Login);
        }

        TrimEmployeeProperties(employee);
        await employeeRepository.UpdateAsync(employee);
    }

    private static void TrimEmployeeProperties(Employee employee)
    {
        if (employee.FullName is not null)
        {
            employee.FullName = employee.FullName.Trim();
        }

        if (employee.Department is not null)
        {
            employee.Department = employee.Department.Trim();
        }

        if (employee.Login is not null)
        {
            employee.Login = employee.Login.Trim();
        }

        if (employee.Password is not null)
        {
            employee.Password = employee.Password.Trim();
        }
    }
}