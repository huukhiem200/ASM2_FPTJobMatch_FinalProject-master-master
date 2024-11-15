using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM2_FPTJobMatch.Migrations
{
    /// <inheritdoc />
    public partial class AddJobStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePost",
                table: "JobModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "JobModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "JobModel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatePost", "Status" },
                values: new object[] { new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc), 0 });

            migrationBuilder.UpdateData(
                table: "JobModel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DatePost", "Status" },
                values: new object[] { new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc), 0 });

            migrationBuilder.UpdateData(
                table: "JobModel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DatePost", "Status" },
                values: new object[] { new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc), 0 });

            migrationBuilder.UpdateData(
                table: "JobModel",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DatePost", "Status" },
                values: new object[] { new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc), 0 });

            migrationBuilder.UpdateData(
                table: "JobModel",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DatePost", "Status" },
                values: new object[] { new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "JobModel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePost",
                table: "JobModel",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "JobModel",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatePost",
                value: new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "JobModel",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatePost",
                value: new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "JobModel",
                keyColumn: "Id",
                keyValue: 3,
                column: "DatePost",
                value: new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "JobModel",
                keyColumn: "Id",
                keyValue: 4,
                column: "DatePost",
                value: new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "JobModel",
                keyColumn: "Id",
                keyValue: 5,
                column: "DatePost",
                value: new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc));
        }
    }
}
