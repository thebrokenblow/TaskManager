using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Models;

namespace TaskManager.Data.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.ToTable("documents",
            tableBuilder => 
                tableBuilder.HasComment("Таблица для хранения документов системы TaskManager"));

        builder.HasKey(document => document.Id);

        builder.Property(document => document.Id)
            .HasColumnName("id")
            .UseIdentityByDefaultColumn()
            .HasComment("Уникальный идентификатор документа.");

        builder.Property(document => document.SourceOutgoingDocumentNumber)
            .HasColumnName("source_outgoing_document_number")
            .HasComment("Номер исходящего документа из исходных данных.")
            .IsRequired(false);

        builder.Property(document => document.SourceOutgoingDocumentDate)
            .HasColumnName("source_outgoing_document_date")
            .HasComment("Дата исходящего документа из исходных данных.")
            .IsRequired(false);

        builder.Property(document => document.SourceCustomer)
            .HasColumnName("source_customer")
            .HasComment("Заказчик из исходных данных.")
            .IsRequired(false);

        builder.Property(document => document.SourceTaskText)
            .HasColumnName("source_task_text")
            .HasComment("Текст задачи из исходных данных.")
            .IsRequired(false);

        builder.Property(document => document.SourceIsExternal)
            .HasColumnName("source_is_external")
            .HasComment("Признак внешнего документа из исходных данных.")
            .IsRequired();

        builder.Property(document => document.SourceOutputDocumentNumber)
            .HasColumnName("source_output_document_number")
            .HasComment("Номер выходящего документа из исходных данных.")
            .IsRequired();

        builder.Property(document => document.SourceOutputDocumentDate)
            .HasColumnName("source_output_document_date")
            .HasColumnType("date")
            .HasComment("Дата входящего документа из исходных данных.")
            .IsRequired();

        builder.Property(document => document.SourceDueDate)
            .HasColumnName("source_due_date")
            .HasColumnType("date")
            .HasComment("Срок выполнения из исходных данных")
            .IsRequired();

        builder.Property(document => document.SourseResponsibleDepartment)
            .HasColumnName("sourse_responsible_department")
            .HasComment("Отвественный (-ые) отдел (-ы) из исходный данных")
            .IsRequired(false);

        builder.Property(document => document.IdAuthorCreateDocument)
            .HasColumnName("id_author_create_document")
            .HasComment("Идентификатор пользователя, который создал запись.")
            .IsRequired(false);

        builder.HasOne(document => document.AuthorCreateDocument)
            .WithMany()
            .HasForeignKey(document => document.IdAuthorCreateDocument)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

        builder.Property(document => document.OutputOutgoingNumber)
            .HasColumnName("output_outgoing_number")
            .HasComment("Номер исходящего документа из выходных данных")
            .IsRequired(false);

        builder.Property(document => document.OutputOutgoingDate)
            .HasColumnName("output_outgoing_date")
            .HasColumnType("date")
            .HasComment("Дата исходящего документа из выходных данных")
            .IsRequired(false);

        builder.Property(document => document.OutputSentTo)
            .HasColumnName("output_sent_to")
            .HasComment("Получатель документа из выходных данных (кому отправлен).")
            .IsRequired(false);

        builder.Property(document => document.OutputContentAnswer)
            .HasColumnName("output_content_answer")
            .HasComment("Содержание ответа из выходных данных.")
            .IsRequired(false);

        builder.Property(document => document.IsUnderControl)
            .HasColumnName("is_under_control")
            .HasComment("Признак нахождения задачи на контроле")
            .IsRequired();

        builder.Property(document => document.IsCompleted)
            .HasColumnName("is_completed")
            .HasComment("Признак завершения задачи")
            .IsRequired();

        builder.Property(document => document.IdAuthorRemoveDocument)
            .HasColumnName("id_author_remove_document")
            .HasComment("Идентификатор пользователя, который удалил запись")
            .IsRequired(false);

        builder.HasOne(document => document.AuthorRemoveDocument)
            .WithMany()
            .HasForeignKey(document => document.IdAuthorRemoveDocument)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

        builder.Property(document => document.LastModifiedByEmployee)
            .HasColumnName("last_modified_by_employee")
            .HasComment("Полное имя сотрудника, который последним редактировал документ.")
            .IsRequired(false);

        builder.Property(document => document.LastModifiedDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("last_modified_date")
            .HasComment("Дата и время последнего редактирования документа.")
            .IsRequired(false);

        builder.Property(document => document.DateRemove)
            .HasColumnName("date_remove")
            .HasComment("Дата удаления документа.")
            .IsRequired(false);
    }
}