using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survello.Database.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMultipleAnswer",
                table: "MultipleChoiceQuestions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0989cb07-226e-430d-9173-87ee97472f6a"),
                column: "ConcurrencyStamp",
                value: "7fc15ec6-d5b6-48f5-9670-ff8aaddcb267");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "671e8d9c-078c-43d6-bb5c-5c521ddbeeb5", new DateTime(2020, 5, 21, 16, 0, 13, 113, DateTimeKind.Utc).AddTicks(9866), "AQAAAAEAACcQAAAAEDIqV+HtI8XTHbuvpZ28jOgM0d+tBPj4qhwTNcv+iVyQKuU7DDmczXQSZY2ZB/ZPaA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("52d02f62-14ac-4152-872c-08d7eb74f484"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "1b868fa6-d0f2-46aa-9455-be5efaa79182", new DateTime(2020, 5, 21, 16, 0, 13, 66, DateTimeKind.Utc).AddTicks(9825), "AQAAAAEAACcQAAAAELoqeCgVdWULpzi13tlu4n5t6FQVrUKZpCOHwVQO7lALk3Mo/SEWOUonUHY7EWKs/Q==" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("1009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 21, 16, 0, 13, 62, DateTimeKind.Utc).AddTicks(3925));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("2009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 21, 16, 0, 13, 62, DateTimeKind.Utc).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("3009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 21, 16, 0, 13, 62, DateTimeKind.Utc).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("4009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 21, 16, 0, 13, 62, DateTimeKind.Utc).AddTicks(6606));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMultipleAnswer",
                table: "MultipleChoiceQuestions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0989cb07-226e-430d-9173-87ee97472f6a"),
                column: "ConcurrencyStamp",
                value: "446ee42e-0a67-434d-a034-e6bd81d63ef1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "9df1d912-45cc-4a46-a1b9-e0f851921b0a", new DateTime(2020, 5, 21, 12, 24, 18, 667, DateTimeKind.Utc).AddTicks(7270), "AQAAAAEAACcQAAAAEGGPN9e6K/PGBJIQkBmj7jM72xjRkbgfK+X9JLGtLyMJjStqk/pL2RCV3f56pRIVhA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("52d02f62-14ac-4152-872c-08d7eb74f484"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "80c76880-5feb-434e-9780-8376f6f3211e", new DateTime(2020, 5, 21, 12, 24, 18, 656, DateTimeKind.Utc).AddTicks(2969), "AQAAAAEAACcQAAAAEMnCWvPu/10nElv+IG/9mzRT+tHJt0AZAO0BgLr2N+wJ2a4gaQtRFXw7Pv68CWlY8w==" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("1009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 21, 12, 24, 18, 652, DateTimeKind.Utc).AddTicks(9531));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("2009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 21, 12, 24, 18, 653, DateTimeKind.Utc).AddTicks(1529));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("3009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 21, 12, 24, 18, 653, DateTimeKind.Utc).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("4009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 21, 12, 24, 18, 653, DateTimeKind.Utc).AddTicks(1574));
        }
    }
}
