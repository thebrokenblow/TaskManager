using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Model.Employees;
using TaskManager.Domain.Queries;
using TaskManager.Persistence.Data;

namespace TaskManager.Persistence.Queries;

public class EmployeeQuery(TaskManagerDbContext context) : IEmployeeQuery
{
    public async Task<List<EmployeeSelectModel>> GetResponsibleEmployeesAsync()
    {
        var employees = await context.Employees.Select(employee => new EmployeeSelectModel  
                                                { 
                                                    Id = employee.Id,
                                                    FullNameAndDepartment = $"{employee.FullName} ({employee.Department})"
                                                })
                                                .ToListAsync();

        return employees;
    }
}