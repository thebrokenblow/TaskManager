namespace TaskManager.Models;

/// <summary>
/// Представляет документ в системе документооборота
/// Содержит исходные данные документа и выходные данные обработки.
/// </summary>
public class Document
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
    /// Дата исходящего документа из исходных данных.
    /// Необязательное свойство.
    /// </summary>
    public DateOnly? SourceOutgoingDocumentDate { get; set; }

    /// <summary>
    /// Заказчик из исходных данных.
    /// Необязательное свойство.
    /// </summary>
    public string? SourceCustomer { get; set; }

    /// <summary>
    /// Текст задачи из исходных данных.
    /// Необязательное свойство.
    /// </summary>
    public string? SourceTaskText { get; set; }

    /// <summary>
    /// Признак внешнего документа из исходных данных.
    /// Обязательное свойство.
    /// </summary>
    public required bool SourceIsExternal { get; set; }

    /// <summary>
    /// Номер выходящего документа из исходных данных.
    /// Обязательное свойство.
    /// </summary>
    public required string SourceOutputDocumentNumber { get; set; }

    /// <summary>
    /// Дата входящего документа из исходных данных.
    /// Обязательное свойство.
    /// </summary>
    public required DateOnly SourceOutputDocumentDate { get; set; }

    /// <summary>
    /// Срок выполнения из исходных данных.
    /// Обязательное свойство.
    /// </summary>
    public required DateOnly SourceDueDate { get; set; }

    /// <summary>
    /// Отвественный (-ые) отдел (-ы) из исходный данных.
    /// Необязательное свойство.
    /// </summary>
    public string? SourseResponsibleDepartment { get; set; }

    /// <summary>
    /// Идентификатор пользователя, который создал запись.
    /// Необязательное свойство.
    /// </summary>
    public int? IdAuthorCreateDocument { get; set; }

    /// <summary>
    /// Навигационное свойство пользователя, который создал запись 
    /// Необязательное свойство.
    /// </summary>
    public Employee? AuthorCreateDocument { get; set; }

    // Выходные данные документа

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
    /// Получатель документа из выходных данных (кому отправлен).
    /// Необязательное свойство.
    /// </summary>
    public string? OutputSentTo { get; set; }

    /// <summary>
    /// Содержание ответа из выходных данных.
    /// Необязательное свойство.
    /// </summary>
    public string? OutputContentAnswer { get; set; }

    /// <summary>
    /// Признак нахождения задачи на контроле.
    /// Обязательное свойство.
    /// </summary>
    public required bool IsUnderControl { get; set; }

    /// <summary>
    /// Признак завершения задачи.
    /// Обязательное свойство.
    /// </summary>
    public required bool IsCompleted { get; set; }

    /// <summary>
    /// Идентификатор пользователя, который удалил запись.
    /// Необязательное свойство.
    /// </summary>
    public int? IdAuthorRemoveDocument { get; set; }

    /// <summary>
    /// Навигационное свойство пользователя, который удалил запись.
    /// Необязательное свойство.
    /// </summary>
    public Employee? AuthorRemoveDocument { get; set; }

    /// <summary>
    /// Полное имя сотрудника, который последним редактировал документ.
    /// Необязательное свойство.
    /// </summary>
    public string? LastModifiedByEmployee { get; set; }

    /// <summary>
    /// Дата и время последнего редактирования документа.
    /// Необязательное свойство.
    /// </summary>
    public DateTime? LastModifiedDate { get; set; }

    /// <summary>
    /// Дата удаления документа.
    /// Необязательное свойство.
    /// </summary>
    public DateTime? DateRemove { get; set; }
}