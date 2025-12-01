using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Model.Documents;
using TaskManager.Domain.Queries;
using TaskManager.Persistence.Data;

namespace TaskManager.Persistence.Queries;

public class DocumentQuery(TaskManagerDbContext context) : IDocumentQuery
{
    public async Task<(List<DocumentOverviewModel> documents, int countDocuments)> GetDocumentsAsync(int countSkip, int countTake)
    {
        var queryDocuments = context.Documents.Include(document => document.ResponsibleEmployeeInputDocument)
                                              .Where(document => document.IsCompleted == false && document.RemoveDateTime == null)
                                              .AsQueryable();

        var countDocuments = await queryDocuments.CountAsync();

        var documents = await queryDocuments.OrderBy(document => document.TaskDueDateInputDocument)
                                            .ThenBy(document => document.IsUnderControl)
                                            .Skip(countSkip)
                                            .Take(countTake)
                                            .Select(document => new DocumentOverviewModel
                                            {
                                                Id = document.Id,
                                                OutgoingDocumentNumberInputDocument = document.OutgoingDocumentNumberInputDocument,
                                                DocumentSummaryInputDocument = document.DocumentSummaryInputDocument,
                                                IncomingDocumentNumberInputDocument = document.IncomingDocumentNumberInputDocument,
                                                CustomerInputDocument = document.CustomerInputDocument,
                                                TaskDueDateInputDocument = document.TaskDueDateInputDocument,
                                                OutgoingDocumentNumberOutputDocument = document.OutgoingDocumentNumberOutputDocument,
                                                OutgoingDocumentDateOutputDocument = document.OutgoingDocumentDateOutputDocument,
                                                CreatedByEmployeeId = document.CreatedByEmployeeId,

                                                FullNameResponsibleEmployee =
                                                    document.ResponsibleEmployeeInputDocument != null
                                                    ? document.ResponsibleEmployeeInputDocument.FullName
                                                    : null,

                                                RemovedByEmployeeId = document.RemovedByEmployeeId,
                                                IsCompleted = document.IsCompleted,
                                                IsUnderControl = document.IsUnderControl,
                                            })
                                            .AsNoTracking()
                                            .ToListAsync();

        return (documents, countDocuments);
    }

    public async Task<(List<DocumentOverviewModel> documents, int countDocuments)> SearchDocumentsAsync(
        string inputSearch,
        int countSkip,
        int countTake)
    {
        var queryDocuments = context.Documents.Include(document => document.ResponsibleEmployeeInputDocument)
                                              .AsQueryable();

        if (!string.IsNullOrWhiteSpace(inputSearch))
        {
            queryDocuments = queryDocuments.Where(document =>
                                        (document.OutgoingDocumentNumberInputDocument != null && document.OutgoingDocumentNumberInputDocument.Contains(inputSearch)) ||
                                        (document.DocumentSummaryInputDocument != null && document.DocumentSummaryInputDocument.Contains(inputSearch)) ||
                                        (document.IncomingDocumentNumberInputDocument != null && document.IncomingDocumentNumberInputDocument.Contains(inputSearch)) ||
                                        (document.OutgoingDocumentNumberOutputDocument != null && document.OutgoingDocumentNumberOutputDocument.Contains(inputSearch)));
        }

        var countDocuments = await queryDocuments.CountAsync();

        var documents = await queryDocuments.OrderBy(document => document.TaskDueDateInputDocument)
                                            .ThenBy(document => document.IsUnderControl)
                                            .Select(document => new DocumentOverviewModel
                                            {
                                                Id = document.Id,
                                                OutgoingDocumentNumberInputDocument = document.OutgoingDocumentNumberInputDocument,
                                                DocumentSummaryInputDocument = document.DocumentSummaryInputDocument,
                                                IncomingDocumentNumberInputDocument = document.IncomingDocumentNumberInputDocument,
                                                CustomerInputDocument = document.CustomerInputDocument,
                                                TaskDueDateInputDocument = document.TaskDueDateInputDocument,
                                                OutgoingDocumentNumberOutputDocument = document.OutgoingDocumentNumberOutputDocument,
                                                OutgoingDocumentDateOutputDocument = document.OutgoingDocumentDateOutputDocument,
                                                CreatedByEmployeeId = document.CreatedByEmployeeId,

                                                FullNameResponsibleEmployee =
                                                    document.ResponsibleEmployeeInputDocument != null ? 
                                                    document.ResponsibleEmployeeInputDocument.FullName : 
                                                    null,

                                                RemovedByEmployeeId = document.RemovedByEmployeeId,
                                                IsCompleted = document.IsCompleted,
                                                IsUnderControl = document.IsUnderControl,
                                            })
                                            .AsNoTracking()
                                            .Skip(countSkip)
                                            .Take(countTake)
                                            .ToListAsync();

        return (documents, countDocuments);
    }

    public async Task<DocumentForEdit?> GetDocumentForEditAsync(int id)
    {
        var document = await context.Documents
                                    .Select(document => new DocumentForEdit
                                    {
                                        Id = document.Id,
                                        OutgoingDocumentNumberInputDocument = document.OutgoingDocumentNumberInputDocument,
                                        SourceDocumentDateInputDocument = document.SourceDocumentDateInputDocument,
                                        CustomerInputDocument = document.CustomerInputDocument,
                                        DocumentSummaryInputDocument = document.DocumentSummaryInputDocument,
                                        IsExternalDocumentInputDocument = document.IsExternalDocumentInputDocument,
                                        IncomingDocumentNumberInputDocument = document.IncomingDocumentNumberInputDocument,
                                        IncomingDocumentDateInputDocument = document.IncomingDocumentDateInputDocument,
                                        ResponsibleDepartmentsInputDocument = document.ResponsibleDepartmentsInputDocument,
                                        TaskDueDateInputDocument = document.TaskDueDateInputDocument,
                                        IdResponsibleEmployeeInputDocument = document.IdResponsibleEmployeeInputDocument,
                                        IsExternalDocumentOutputDocument = document.IsExternalDocumentOutputDocument,
                                        OutgoingDocumentNumberOutputDocument = document.OutgoingDocumentNumberOutputDocument,
                                        OutgoingDocumentDateOutputDocument = document.OutgoingDocumentDateOutputDocument,
                                        RecipientOutputDocument = document.RecipientOutputDocument,
                                        DocumentSummaryOutputDocument = document.DocumentSummaryOutputDocument,
                                        IsUnderControl = document.IsUnderControl,
                                        IsCompleted = document.IsCompleted,

                                        FullNameLastEditedEmployee =
                                                    document.LastEditedByEmployee != null ? 
                                                    document.LastEditedByEmployee.FullName : 
                                                    null,

                                        LastEditedDateTime = document.LastEditedDateTime,
                                        CreatedByEmployeeId = document.CreatedByEmployeeId,
                                    })
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(document => document.Id == id);

        return document;
    }

    public async Task<DocumentForDelete?> GetDocumentForDeleteAsync(int id)
    {
        var document = await context.Documents
                                    .Select(document => new DocumentForDelete
                                    {
                                        Id = document.Id,
                                        OutgoingDocumentNumberInputDocument = document.OutgoingDocumentNumberInputDocument,
                                        SourceDocumentDateInputDocument = document.SourceDocumentDateInputDocument,
                                        CustomerInputDocument = document.CustomerInputDocument,
                                        DocumentSummaryInputDocument = document.DocumentSummaryInputDocument,
                                        IsExternalDocumentInputDocument = document.IsExternalDocumentInputDocument,
                                        IncomingDocumentNumberInputDocument = document.IncomingDocumentNumberInputDocument,
                                        IncomingDocumentDateInputDocument = document.IncomingDocumentDateInputDocument,
                                        ResponsibleDepartmentsInputDocument = document.ResponsibleDepartmentsInputDocument,
                                        TaskDueDateInputDocument = document.TaskDueDateInputDocument,
                                        IdResponsibleEmployeeInputDocument = document.IdResponsibleEmployeeInputDocument,

                                        ResponsibleEmployeeFullName = 
                                                    document.ResponsibleEmployeeInputDocument != null ? 
                                                    document.ResponsibleEmployeeInputDocument.FullName : 
                                                    null,
                                        
                                        IsExternalDocumentOutputDocument = document.IsExternalDocumentOutputDocument,
                                        OutgoingDocumentNumberOutputDocument = document.OutgoingDocumentNumberOutputDocument,
                                        OutgoingDocumentDateOutputDocument = document.OutgoingDocumentDateOutputDocument,
                                        RecipientOutputDocument = document.RecipientOutputDocument,
                                        DocumentSummaryOutputDocument = document.DocumentSummaryOutputDocument,
                                        IsUnderControl = document.IsUnderControl,
                                        IsCompleted = document.IsCompleted
                                    })
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(document => document.Id == id);

        return document;
    }
}