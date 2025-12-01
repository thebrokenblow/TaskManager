using TaskManager.Application.Common;
using TaskManager.Domain.Model.Documents;

namespace TaskManager.View.ViewModel.Employees;

public class IndexDocumentViewModel
{
    public required string InputString { get; init; }
    public required PagedResult<DocumentOverviewModel> PagedDocuments { get; init; }
}