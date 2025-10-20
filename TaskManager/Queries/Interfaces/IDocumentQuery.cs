using TaskManager.Models;

namespace TaskManager.Queries.Interfaces;

public interface IDocumentQuery
{
    Task<List<FilteredRangeDocument>> GetFilteredRangeAsync();
}
