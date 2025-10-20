using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;
using TaskManager.Queries.Interfaces;

namespace TaskManager.Queries;

public class DocumentQuery(TaskManagerDbContext context) : IDocumentQuery
{
    public async Task<List<FilteredRangeDocument>> GetFilteredRangeAsync()
    {
        var documents = await context.Documents.Select(document => new FilteredRangeDocument
        {
            Id = document.Id,
            SourceOutgoingDocumentNumber = document.SourceOutgoingDocumentNumber,
            SourceTaskText = document.SourceTaskText,
            SourceOutputDocumentNumber = document.SourceOutputDocumentNumber,
            SourceDueDate = document.SourceDueDate,
            OutputOutgoingDate = document.OutputOutgoingDate,
            OutputOutgoingNumber = document.OutputOutgoingNumber,
            SourceResponsibleEmployeeId = document.SourceResponsibleEmployeeId,
            SourceResponsibleEmployee = document.SourceResponsibleEmployee!
        })
        .AsNoTracking()
        .ToListAsync();

        return documents;
    }
}