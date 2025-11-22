namespace TaskManager.Models;

/// <summary>
/// Представляет документ в системе документооборота
/// Содержит исходные данные документа и выходные данные обработки.
/// </summary>
public class FilteredRangeDocument
{
    /// <summary>
    /// Уникальный идентификатор документа.
    /// </summary>
    public int Id { get; set; }

    // Исходные данные документа

    /// <summary>
    /// Номер исходящего документа из исходных данных.
    /// Необязательное свойство.
    /// </summary>
    public string? SourceOutgoingDocumentNumber { get; set; }

    /// <summary>
    /// Текст задачи из исходных данных.
    /// Обязательное свойство.
    /// </summary>
    public required string SourceTaskText { get; set; }

    /// <summary>
    /// Номер выходящего документа из исходных данных.
    /// Обязательное свойство.
    /// </summary>
    public required string SourceOutputDocumentNumber { get; set; }

    /// <summary>
    /// Срок выполнения из исходных данных.
    /// Обязательное свойство.
    /// </summary>
    public required DateOnly SourceDueDate { get; set; }

    /// <summary>
    /// Номер исходящего документа из выходных данных.
    /// Необязательное свойство.
    /// </summary>
    public string? OutputOutgoingNumber { get; set; }

    /// <summary>
    /// Дата исходящего документа из выходных данных.
    /// Необязательное свойство.
    /// </summary>
    public DateOnly? OutputOutgoingDate { get; set; }

    /// <summary>
    /// Признак нахождения задачи на контроле.
    /// Обязательное свойство.
    /// </summary>
    public bool IsUnderControl { get; set; }

    /// <summary>
    /// Идентификатор пользователя, который создал запись.
    /// Необязательное свойство.
    /// </summary>
    public int? IdAuthorCreateDocument { get; set; }

    /// <summary>
    /// Навигационное свойство пользователя, который создал запись.
    /// Необязательное свойство.
    /// </summary>
    public Employee? AuthorCreateDocument { get; set; }

    /// <summary>
    /// Признак завершения задачи.
    /// Обязательное свойство.
    /// </summary>
    public required bool IsCompleted { get; set; }

    /// <summary>
    /// Дата удаления документа.
    /// Необязательное свойство.
    /// </summary>
    public DateTime? DateRemove { get; set; }

    /// <summary>
    /// Идентификатор пользователя, который удалил запись.
    /// Необязательное свойство.
    /// </summary>
    public int? IdAuthorRemoveDocument { get; set; }
}