using TaskManager.Application.Common;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Model.Documents;

namespace TaskManager.Application.Services.Interfaces;

public interface IDocumentService
{
    Task<PagedResult<DocumentOverviewModel>> GetPagedAsync(string inputSearch, int page, int pageSize);
    Task<Document?> GetByIdAsync(int id);

    Task<DocumentForEdit?> GetDocumentForEditAsync(int id);

    Task<DocumentForDelete?> GetDocumentForDeleteAsync(int id);
    Task CreateAsync(Document document);
    Task EditAsync(Document document);
    Task DeleteAsync(int id);
    Task RecoverDeletedAsync(int id);
    Task ChangeStatusAsync(int id);
}