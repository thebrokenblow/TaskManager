using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TaskManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор сотрудника")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false, comment: "Полное имя сотрудника (фамилия и инициалы)"),
                    department = table.Column<string>(type: "text", nullable: false, comment: "Подразделение или отдел, в котором работает сотрудник"),
                    login = table.Column<string>(type: "text", nullable: false, comment: "Логин сотрудника для входа в систему"),
                    password = table.Column<string>(type: "text", nullable: false, comment: "Пароль сотрудника для входа в систему"),
                    role = table.Column<int>(type: "integer", nullable: false, comment: "Тип сотрудника (роль в системе)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id);
                },
                comment: "Таблица для хранения данных сотрудников системы TaskManager");

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор документа.")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    outgoing_document_number_input_document = table.Column<string>(type: "text", nullable: true, comment: "Исходный номер документа. Входные данные документа. Заполняет хозяин записи (делопроизводитель)."),
                    source_document_date_input_document = table.Column<DateOnly>(type: "date", nullable: true, comment: "Дата исходного документа. Входные данные документа. Заполняет хозяин записи (делопроизводитель)."),
                    customer_input_document = table.Column<string>(type: "text", nullable: true, comment: "Заказчик. Входные данные документа. Заполняет хозяин записи (делопроизводитель)."),
                    document_summary_input_document = table.Column<string>(type: "text", nullable: true, comment: "Краткое содержание документа. Входные данные документа. Заполняет хозяин записи (делопроизводитель)."),
                    is_external_document_input_document = table.Column<bool>(type: "boolean", nullable: false, comment: "Признак внешнего документа. Входные данные документа. Заполняет хозяин записи (делопроизводитель)."),
                    incoming_document_number_input_document = table.Column<string>(type: "text", nullable: false, comment: "Входящий номер документа ВХ(46 ЦНИИ). Входные данные документа. Заполняет хозяин записи (делопроизводитель)."),
                    incoming_document_date_input_document = table.Column<DateOnly>(type: "date", nullable: false, comment: "Дата входящего документа. Входные данные документа. Заполняет хозяин записи (делопроизводитель)."),
                    responsible_departments_input_document = table.Column<string>(type: "text", nullable: true, comment: "Ответственные отделы. Входные данные документа. Заполняет хозяин записи (делопроизводитель)."),
                    task_due_date_input_document = table.Column<DateOnly>(type: "date", nullable: false, comment: "Срок выполнения задачи. Входные данные документа. Заполняет хозяин записи (делопроизводитель)."),
                    id_responsible_employee_input_document = table.Column<int>(type: "integer", nullable: true, comment: "Идентификатор ответственного сотрудника. Входные данные документа. Заполняет исполнитель."),
                    is_external_document_output_document = table.Column<bool>(type: "boolean", nullable: false, comment: "Признак внешнего документа. Выходные данные документа. Заполняет исполнитель."),
                    outgoing_document_number_output_document = table.Column<string>(type: "text", nullable: true, comment: "Исходящий номер документа Исх(46 ЦНИИ). Выходные данные документа. Заполняет исполнитель."),
                    outgoing_document_date_output_document = table.Column<DateOnly>(type: "date", nullable: true, comment: "Дата исходящего документа. Выходные данные документа. Заполняет исполнитель."),
                    recipient_output_document = table.Column<string>(type: "text", nullable: true, comment: "Получатель. Выходные данные документа. Заполняет исполнитель."),
                    document_summary_output_document = table.Column<string>(type: "text", nullable: true, comment: "Краткое содержание документа. Выходные данные документа. Заполняет исполнитель."),
                    is_under_control = table.Column<bool>(type: "boolean", nullable: false, comment: "Признак нахождения задачи на контроле. Выходные данные документа. Заполняет хозяин записи (делопроизводитель)."),
                    is_completed = table.Column<bool>(type: "boolean", nullable: false, comment: "Признак завершения задачи. Заполняет исполнитель."),
                    created_by_employee_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор сотрудника, который создал документ."),
                    last_edited_by_employee_id = table.Column<int>(type: "integer", nullable: true, comment: "Идентификатор сотрудника, который последним редактировал документ."),
                    last_edited_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата и время последнего редактирования документа."),
                    removed_by_employee_id = table.Column<int>(type: "integer", nullable: true, comment: "Идентификатор сотрудника, который удалил запись."),
                    remove_date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата удаления документа.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.id);
                    table.ForeignKey(
                        name: "FK_documents_employees_created_by_employee_id",
                        column: x => x.created_by_employee_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_documents_employees_id_responsible_employee_input_document",
                        column: x => x.id_responsible_employee_input_document,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_documents_employees_last_edited_by_employee_id",
                        column: x => x.last_edited_by_employee_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_documents_employees_removed_by_employee_id",
                        column: x => x.removed_by_employee_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Таблица для хранения документов системы TaskManager");

            migrationBuilder.CreateIndex(
                name: "IX_documents_created_by_employee_id",
                table: "documents",
                column: "created_by_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_id_responsible_employee_input_document",
                table: "documents",
                column: "id_responsible_employee_input_document");

            migrationBuilder.CreateIndex(
                name: "IX_documents_last_edited_by_employee_id",
                table: "documents",
                column: "last_edited_by_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_documents_removed_by_employee_id",
                table: "documents",
                column: "removed_by_employee_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documents");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
