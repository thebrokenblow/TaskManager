using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager.Domain.Model.Documents;

namespace TaskManager.View.ViewModel.Documents;

public class EditDocumentViewModel
{
    public required DocumentForEdit Document { get; init; }
    public required SelectList ResponsibleEmployees { get; init; }
}