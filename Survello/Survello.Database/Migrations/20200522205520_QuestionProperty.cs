using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survello.Database.Migrations
{
    public partial class QuestionProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionNumber",
                table: "TextQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionNumber",
                table: "MultipleChoiceQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionNumber",
                table: "DocumentQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0989cb07-226e-430d-9173-87ee97472f6a"),
                column: "ConcurrencyStamp",
                value: "781eb484-cb76-4f0a-9335-d2415cf0271e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "7d32d456-c246-4efa-9b47-5725b5f91d35", new DateTime(2020, 5, 22, 20, 55, 19, 325, DateTimeKind.Utc).AddTicks(3737), "AQAAAAEAACcQAAAAEMEogKOisQIiiL880sXmCd9jhPtfcatph/74YLna3c0URLjHsCYWqi4AOcYaRSs24w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("52d02f62-14ac-4152-872c-08d7eb74f484"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "a3e83055-8b5b-440f-a904-9e5d47be9763", new DateTime(2020, 5, 22, 20, 55, 19, 296, DateTimeKind.Utc).AddTicks(5619), "AQAAAAEAACcQAAAAEC28sdn/lN4gef4Zxgxj6HBa/G1AM0fGdZFqHopz5JR2m7jyshv3LW9svLbNCbf/yQ==" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("1009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 22, 20, 55, 19, 288, DateTimeKind.Utc).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("2009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 22, 20, 55, 19, 288, DateTimeKind.Utc).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("3009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 22, 20, 55, 19, 288, DateTimeKind.Utc).AddTicks(7608));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("4009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 22, 20, 55, 19, 288, DateTimeKind.Utc).AddTicks(7620));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionNumber",
                table: "TextQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionNumber",
                table: "MultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionNumber",
                table: "DocumentQuestions");

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
    }
}
