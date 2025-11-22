namespace TaskManager.Domain.Entities;

/// <summary>
/// Представляет документ в системе документооборота
/// Содержит исходные данные документа и выходные данные обработки.
/// </summary>
public class Document
{
    //Входные данные документа

    /// <summary>
    /// Исходный номер документа. Входные данные документа. Заполняет хозяин записи (делопроизводитель).
    /// Необязательное свойство.
    /// </summary>
    public string? OutgoingDocumentNumberInputDocument { get; set; }

    /// <summary>
    /// Дата исходного документа. Входные данные документа. Заполняет хозяин записи (делопроизводитель).
    /// Необязательное свойство.
    /// </summary>
    public DateOnly? SourceDocumentDateInputDocument { get; set; }

    /// <summary>
    /// Заказчик. Входные данные документа. Заполняет хозяин записи (делопроизводитель).
    /// Необязательное свойство.
    /// </summary>
    public string? CustomerInputDocument { get; set; }

    /// <summary>
    /// Краткое содержание документа. Входные данные документа. Заполняет хозяин записи (делопроизводитель).
    /// Необязательное свойство.
    /// </summary>
    public string? DocumentSummaryInputDocument { get; set; }

    /// <summary>
    /// Признак внешнего документа. Входные данные документа. Заполняет хозяин записи (делопроизводитель).
    /// Обязательное свойство.
    /// </summary>
    public required bool IsExternalDocumentInputDocument { get; set; }

    /// <summary>
    /// Входящий номер документа ВХ(46 ЦНИИ). Входные данные документа. Заполняет хозяин записи (делопроизводитель).
    /// Обязательное свойство.
    /// </summary>
    public required string IncomingDocumentNumberInputDocument { get; set; }

    /// <summary>
    /// Дата входящего документа. Входные данные документа. Заполняет хозяин записи (делопроизводитель).
    /// Обязательное свойство.
    /// </summary>
    public required DateOnly IncomingDocumentDateInputDocument { get; set; }

    /// <summary>
    /// Ответственные отделы. Входные данные документа. Заполняет хозяин записи (делопроизводитель).
    /// Необязательное свойство.
    /// </summary>
    public string? ResponsibleDepartmentsInputDocument { get; set; }

    /// <summary>
    /// Срок выполнения задачи. Входные данные документа. Заполняет хозяин записи (делопроизводитель).
    /// Обязательное свойство.
    /// </summary>
    public required DateOnly TaskDueDateInputDocument { get; set; }

    /// <summary>
    /// Идентификатор ответственного сотрудника. Входные данные документа. Заполняет исполнитель.
    /// Необязательное свойство.
    /// </summary>
    public int? IdResponsibleEmployeeInputDocument { get; set; }

    /// <summary>
    /// Ответственный сотрудник. Входные данные документа. Заполняет исполнитель.
    /// Навигационное свойство.
    /// Необязательное свойство.
    /// </summary>
    public Employee? ResponsibleEmployeeInputDocument { get; set; }

    //Выходные данные документа

    /// <summary>
    /// Признак внешнего документа. Выходные данные документа. Заполняет исполнитель.
    /// Обязательное свойство.
    /// </summary>
    public required bool IsExternalDocumentOutputDocument { get; set; }

    /// <summary>
    /// Исходящий номер документа Исх(46 ЦНИИ). Выходные данные документа. Заполняет исполнитель.
    /// Необязательное свойство.
    /// </summary>
    public string? OutgoingDocumentNumberOutputDocument { get; set; }

    /// <summary>
    /// Дата исходящий документа. Выходные данные документа. Заполняет исполнитель.
    /// Необязательное свойство.
    /// </summary>
    public required DateOnly? OutgoingDocumentDateOutputDocument { get; set; }

    /// <summary>
    /// Получатель. Выходные данные документа. Заполняет исполнитель.
    /// Необязательное свойство.
    /// </summary>
    public string? RecipientOutputDocument { get; set; }

    /// <summary>
    /// Краткое содержание документа. Выходные данные документа. Заполняет исполнитель.
    /// Необязательное свойство.
    /// </summary>
    public string? DocumentSummaryOutputDocument { get; set; }

    /// <summary>
    /// Признак нахождения задачи на контроле. Выходные данные документа. Заполняет хозяин записи (делопроизводитель).
    /// Обязательное свойство.
    /// </summary>
    public required bool IsUnderControl { get; set; }

    /// <summary>
    /// Идентификатор сотрудника, который последним редактировал документ. Выходные данные документа.
    /// Необязательное свойство.
    /// </summary>
    public int? IdLastEditedEmployee { get; set; }

    /// <summary>
    /// Сотрудник, который последним редактировал документ. Выходные данные документа.
    /// Навигационное свойство.
    /// Необязательное свойство.
    /// </summary>
    public Employee? LastEditedEmployee { get; set; }
}