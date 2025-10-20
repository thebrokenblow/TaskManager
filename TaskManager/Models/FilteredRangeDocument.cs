namespace TaskManager.Models;

public class FilteredRangeDocument
{
    /// <summary>
    /// Уникальный идентификатор документа
    /// </summary>
    public required int Id { get; set; }

    // Исходные данные документа

    /// <summary>
    /// Номер исходящего документа (outgoing) из исходных данных
    /// Обязательное поле
    /// </summary>
    public required string SourceOutgoingDocumentNumber { get; set; }

    /// <summary>
    /// Текст задачи из исходных данных
    /// Обязательное поле
    /// </summary>
    public required string SourceTaskText { get; set; }

    /// <summary>
    /// Номер выходящего документа (output) из исходных данных
    /// Обязательное поле
    /// </summary>
    public required string SourceOutputDocumentNumber { get; set; }

    /// <summary>
    /// Срок выполнения из исходных данных
    /// Обязательное поле
    /// </summary>
    public required DateOnly SourceDueDate { get; set; }

    /// <summary>
    /// Идентификатор ответственного сотрудника из исходных данных
    /// Обязательное поле
    /// </summary>
    public required int SourceResponsibleEmployeeId { get; set; }

    /// <summary>
    /// Ответственный сотрудник из исходных данных
    /// </summary>
    public required Employee SourceResponsibleEmployee { get; set; }

    // Выходные данные документа

    /// <summary>
    /// Номер исходящего документа из выходных данных
    /// </summary>
    public required string? OutputOutgoingNumber { get; set; }

    /// <summary>
    /// Дата исходящего документа из выходных данных
    /// </summary>
    public required DateOnly? OutputOutgoingDate { get; set; }
}