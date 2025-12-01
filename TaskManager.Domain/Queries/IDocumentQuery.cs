using TaskManager.Domain.Entities;
using TaskManager.Domain.Model.Documents;

namespace TaskManager.Domain.Queries;

public interface IDocumentQuery
{
    Task<(List<DocumentOverviewModel> documents, int countDocuments)> GetDocumentsAsync(
        int countSkip,
        int countTake);

    Task<(List<DocumentOverviewModel> documents, int countDocuments)> SearchDocumentsAsync(
        string searchTerm,
        int countSkip,
        int countTake);

    Task<DocumentForEdit?> GetDocumentForEditAsync(int id);

    Task<DocumentForDelete?> GetDocumentForDeleteAsync(int id);
}