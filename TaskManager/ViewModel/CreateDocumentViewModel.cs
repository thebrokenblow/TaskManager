using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager.Models;

namespace TaskManager.ViewModel;

public class CreateDocumentViewModel
{
    public required Document Document { get; init; }
    public required SelectList Employees { get; init; }
}
