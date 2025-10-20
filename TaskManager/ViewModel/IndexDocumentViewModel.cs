using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager.Models;

namespace TaskManager.ViewModel;

public class IndexDocumentViewModel
{
    public required List<FilteredRangeDocument> Documents { get; init; }
    public required SelectList Employees { get; init; }
}