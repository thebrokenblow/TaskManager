using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager.Models;
using TaskManager.Queries.Interfaces;
using TaskManager.Repositories.Interfaces;
using TaskManager.ViewModel;

namespace TaskManager.Controllers;

public class DocumentController(
        IDocumentRepository documentRepository, 
        IDocumentQuery documentQuery,
        IEmployeeRepository employeeRepository) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var documents = await documentQuery.GetFilteredRangeAsync();
        var employees = await employeeRepository.GetAllAsync();

        var employeesForSelect = employees.Select(employee => new EmployeeForSelect
        {
            Id = employee.Id,
            FullNameAndDepartment = $"{employee.FullName} ({employee.Department})"
        });

        var selectListEmployees = new SelectList(
                                        employeesForSelect, 
                                        nameof(EmployeeForSelect.Id), 
                                        nameof(EmployeeForSelect.FullNameAndDepartment));

        var indexDocumentViewModel = new IndexDocumentViewModel
        {
            Documents = documents,
            Employees = selectListEmployees,
        };

        return View(indexDocumentViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Document document)
    {
        var t1 = document.SourceIsExternal;
        var t2 = document.IsUnderControl;

        await documentRepository.AddAsync(document);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var document = await documentRepository.GetByIdAsync(id);

        if (document == null)
        {
            return NotFound();
        }

        var employees = await employeeRepository.GetAllAsync();

        var employeesForSelect = employees.Select(employee => new EmployeeForSelect
        {
            Id = employee.Id,
            FullNameAndDepartment = $"{employee.FullName} ({employee.Department})"
        });

        var selectListEmployees = new SelectList(
                                        employeesForSelect,
                                        nameof(EmployeeForSelect.Id),
                                        nameof(EmployeeForSelect.FullNameAndDepartment));

        var editDocumentViewModel = new EditDocumentViewModel
        {
            Document = document,
            Employees = selectListEmployees
        };

        return View(editDocumentViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Document document)
    {
        await documentRepository.UpdateAsync(document);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var document = await documentRepository.GetByIdAsync(id);

        if (document == null)
        {
            return NotFound();
        }

        return View(document);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var document = await documentRepository.GetByIdAsync(id);

        if (document == null)
        {
            return NotFound();
        }

        await documentRepository.RemoveAsync(document);

        return RedirectToAction(nameof(Index));
    }
}