using TaskManager.Application.Common;
using TaskManager.Application.Exceptions;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Model.Documents;
using TaskManager.Domain.Queries;
using TaskManager.Domain.Repositories;
using TaskManager.Domain.Services;

namespace TaskManager.Application.Services;

public class DocumentService(
    IDocumentQuery documentQuery, 
    IDocumentRepository documentRepository,
    IAuthService authService) : IDocumentService
{
    public async Task<PagedResult<DocumentOverviewModel>> GetPagedAsync(string inputSearch, int page, int pageSize)
    {
        int countDocuments;
        List<DocumentOverviewModel> documents;

        int countSkip = (page - 1) * pageSize;

        if (!string.IsNullOrEmpty(inputSearch))
        {
            (documents, countDocuments) = await documentQuery.SearchDocumentsAsync(inputSearch, countSkip, pageSize);
        }
        else
        {
            (documents, countDocuments) = await documentQuery.GetDocumentsAsync(countSkip, pageSize);
        }

        var pagedResult = new PagedResult<DocumentOverviewModel>(documents, countDocuments, page, pageSize);

        return pagedResult;
    }

    public async Task<DocumentForEdit?> GetDocumentForEditAsync(int id)
    {
        var document = await documentQuery.GetDocumentForEditAsync(id);

        return document;
    }

    public async Task<DocumentForDelete?> GetDocumentForDeleteAsync(int id)
    {
        var document = await documentQuery.GetDocumentForDeleteAsync(id);

        return document;
    }

    public async Task<Document?> GetByIdAsync(int id)
    {
        var document = await documentRepository.GetByIdAsync(id);

        return document;
    }

    public async Task ChangeStatusAsync(int id)
    {
        var document = await documentRepository.GetByIdAsync(id) ?? 
            throw new NotFoundException(nameof(Document), id);

        document.IsCompleted = !document.IsCompleted;

        await documentRepository.UpdateAsync(document);
    }

    public async Task CreateAsync(Document document)
    {
        TrimDocumentProperties(document);
        await documentRepository.AddAsync(document);
    }

    public async Task EditAsync(Document document)
    {
        TrimDocumentProperties(document);

        document.LastEditedDateTime = DateTime.Now;
        document.LastEditedByEmployeeId = authService.IdCurrentUser;

        await documentRepository.UpdateAsync(document);
    }

    public async Task RecoverDeletedAsync(int id)
    {
        var document = await documentRepository.GetByIdAsync(id) ??
                                throw new NotFoundException(nameof(Document), id);

        document.IdResponsibleEmployeeInputDocument = document.LastEditedByEmployeeId;
        document.LastEditedByEmployeeId = null;
        document.RemoveDateTime = null;

        await documentRepository.UpdateAsync(document);
    }

    public async Task DeleteAsync(int id)
    {
        if (!authService.IsAuthenticated || !authService.IdCurrentUser.HasValue)
        {
            throw new Exception();
        }

        if (authService.IsAdmin)
        {
            await documentRepository.RemoveHardAsync(id);
        }
        else
        {
            await documentRepository.RemoveSoftAsync(id, authService.IdCurrentUser.Value, authService.IdAdmin, DateTime.Now);
        }
    }

    private static void TrimDocumentProperties(Document document)
    {
        if (document.OutgoingDocumentNumberInputDocument is not null)
        {
            document.OutgoingDocumentNumberInputDocument = document.OutgoingDocumentNumberInputDocument.Trim();
        }

        if (document.CustomerInputDocument is not null)
        {
            document.CustomerInputDocument = document.CustomerInputDocument.Trim();
        }

        if (document.DocumentSummaryInputDocument is not null)
        {
            document.DocumentSummaryInputDocument = document.DocumentSummaryInputDocument.Trim();
        }

        if (document.IncomingDocumentNumberInputDocument is not null)
        {
            document.IncomingDocumentNumberInputDocument = document.IncomingDocumentNumberInputDocument.Trim();
        }

        if (document.ResponsibleDepartmentsInputDocument is not null)
        {
            document.ResponsibleDepartmentsInputDocument = document.ResponsibleDepartmentsInputDocument.Trim();
        }

        if (document.OutgoingDocumentNumberOutputDocument is not null)
        {
            document.OutgoingDocumentNumberOutputDocument = document.OutgoingDocumentNumberOutputDocument.Trim();
        }

        if (document.RecipientOutputDocument is not null)
        {
            document.RecipientOutputDocument = document.RecipientOutputDocument.Trim();
        }

        if (document.DocumentSummaryOutputDocument is not null)
        {
            document.DocumentSummaryOutputDocument = document.DocumentSummaryOutputDocument.Trim();
        }
    }
}