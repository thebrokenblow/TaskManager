using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Exceptions;
using TaskManager.Domain.Model.Documents;
using TaskManager.View.ViewModel.Documents;
using TaskManager.View.ViewModel.Employees;

namespace TaskManager.View.Controllers;

public class DocumentsController(
    IDocumentService documentService,
    IEmployeeService employeeService) : Controller
{
    private const int DefaultNumberPage = 1;
    private const int DefaultCountDocumentsOnPage = 50;

    private const int DefaultDueDateDaysOffset = 5;

    [HttpGet]
    public async Task<IActionResult> Index(
        string inputSearch,
        int page = DefaultNumberPage,
        int pageSize = DefaultCountDocumentsOnPage) 
    {
        var pagedDocuments = await documentService.GetPagedAsync(inputSearch, page, pageSize);

        var indexDocumentViewModel = new IndexDocumentViewModel
        {
            InputString = inputSearch,
            PagedDocuments = pagedDocuments
        };

        return View(indexDocumentViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var document = new Document
        {
            IsExternalDocumentInputDocument = true,
            IncomingDocumentNumberInputDocument = string.Empty,
            IncomingDocumentDateInputDocument = DateOnly.FromDateTime(DateTime.Today),
            TaskDueDateInputDocument = DateOnly.FromDateTime(DateTime.Today.AddDays(DefaultDueDateDaysOffset)),
            IsExternalDocumentOutputDocument = true,
            IsUnderControl = false,
            IsCompleted = false,
            CreatedByEmployeeId = default,
        };

        var responsibleEmployees = await employeeService.GetResponsibleEmployeesAsync();

        var responsibleEmployeesSelectList = new SelectList(
                                                    responsibleEmployees,
                                                    nameof(EmployeeForSelect.Id),
                                                    nameof(EmployeeForSelect.FullNameAndDepartment));

        var createDocumentViewModel = new CreateDocumentViewModel
        {
            Document = document,
            ResponsibleEmployees = responsibleEmployeesSelectList,
        };

        return View(createDocumentViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Document document)
    {
        await documentService.CreateAsync(document);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var document = await documentService.GetDocumentForEditAsync(id);

        if (document is null)
        {
            return NotFound();
        }

        var responsibleEmployees = await employeeService.GetResponsibleEmployeesAsync();


        var responsibleEmployeesSelectList = new SelectList(
                                                    responsibleEmployees,
                                                    nameof(EmployeeForSelect.Id),
                                                    nameof(EmployeeForSelect.FullNameAndDepartment));

        var editDocumentViewModel = new EditDocumentViewModel
        {
            Document = document,
            ResponsibleEmployees = responsibleEmployeesSelectList
        };

        return View(editDocumentViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Document document)
    {
        await documentService.EditAsync(document);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var document = await documentService.GetDocumentForDeleteAsync(id);

        if (document == null)
        {
            return NotFound();
        }

        return View(document);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await documentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch (NotFoundException)
        {
            return RedirectToAction(nameof(Index));
            //Показать страницу документ не найден в системе
        }
        catch
        {
            //Показать страницу ошибки
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    public async Task<IActionResult> RecoverDeleted(int id)
    {
        await documentService.RecoverDeletedAsync(id);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> ChangeStatus(int id)
    {
        await documentService.ChangeStatusAsync(id);

        return RedirectToAction(nameof(Index));
    }
}