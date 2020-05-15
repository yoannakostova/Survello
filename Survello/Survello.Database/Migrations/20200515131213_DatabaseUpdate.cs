using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survello.Database.Migrations
{
    public partial class DatabaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentAnswer_DocumentQuestion_DocumentQuestionId",
                table: "DocumentAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentQuestion_Forms_FormId",
                table: "DocumentQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentQuestion",
                table: "DocumentQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentAnswer",
                table: "DocumentAnswer");

            migrationBuilder.RenameTable(
                name: "DocumentQuestion",
                newName: "DocumentQuestions");

            migrationBuilder.RenameTable(
                name: "DocumentAnswer",
                newName: "DocumentAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentQuestion_FormId",
                table: "DocumentQuestions",
                newName: "IX_DocumentQuestions_FormId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentAnswer_DocumentQuestionId",
                table: "DocumentAnswers",
                newName: "IX_DocumentAnswers_DocumentQuestionId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DocumentQuestions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "DocumentAnswers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentQuestions",
                table: "DocumentQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentAnswers",
                table: "DocumentAnswers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0989cb07-226e-430d-9173-87ee97472f6a"),
                column: "ConcurrencyStamp",
                value: "327ba0eb-8496-4c11-bff8-44f8ca46c5f6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "f0427527-6f65-4e91-a28f-986921380a85", new DateTime(2020, 5, 15, 13, 12, 10, 630, DateTimeKind.Utc).AddTicks(9071), "AQAAAAEAACcQAAAAECGx1tLT4ealzN/jl5MeJiTVQk+iP+izfwj7CZWvRz65bG7zBZAa2OUbLTmfhRWFOQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("52d02f62-14ac-4152-872c-08d7eb74f484"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "1f306fcb-3845-4257-a12d-0191b121dc5a", new DateTime(2020, 5, 15, 13, 12, 10, 482, DateTimeKind.Utc).AddTicks(5202), "AQAAAAEAACcQAAAAEELA+O/qGFW1qAmTZCLc+HBkB4s4yWRkkKLwCNEST9XYTkCeUbUA2TwgVzUwlIhuzQ==" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("1009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 15, 13, 12, 10, 467, DateTimeKind.Utc).AddTicks(7255));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("2009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 15, 13, 12, 10, 468, DateTimeKind.Utc).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("3009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 15, 13, 12, 10, 468, DateTimeKind.Utc).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("4009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 15, 13, 12, 10, 468, DateTimeKind.Utc).AddTicks(4376));

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentAnswers_DocumentQuestions_DocumentQuestionId",
                table: "DocumentAnswers",
                column: "DocumentQuestionId",
                principalTable: "DocumentQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentQuestions_Forms_FormId",
                table: "DocumentQuestions",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentAnswers_DocumentQuestions_DocumentQuestionId",
                table: "DocumentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentQuestions_Forms_FormId",
                table: "DocumentQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentQuestions",
                table: "DocumentQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentAnswers",
                table: "DocumentAnswers");

            migrationBuilder.RenameTable(
                name: "DocumentQuestions",
                newName: "DocumentQuestion");

            migrationBuilder.RenameTable(
                name: "DocumentAnswers",
                newName: "DocumentAnswer");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentQuestions_FormId",
                table: "DocumentQuestion",
                newName: "IX_DocumentQuestion_FormId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentAnswers_DocumentQuestionId",
                table: "DocumentAnswer",
                newName: "IX_DocumentAnswer_DocumentQuestionId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DocumentQuestion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "DocumentAnswer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentQuestion",
                table: "DocumentQuestion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentAnswer",
                table: "DocumentAnswer",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0989cb07-226e-430d-9173-87ee97472f6a"),
                column: "ConcurrencyStamp",
                value: "e3815dba-c7e2-472f-8e60-8c73fb31d6fc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "c654bbfd-6300-4dd4-91ff-19948560842f", new DateTime(2020, 5, 15, 13, 0, 40, 330, DateTimeKind.Utc).AddTicks(5862), "AQAAAAEAACcQAAAAEHMdx7DIThDQ9OoJFtoaV4MmXxf1mCKUBLAJmUas5x9Y27Sj6/me2WIuCBr2M2gzzw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("52d02f62-14ac-4152-872c-08d7eb74f484"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "26d2cae9-4e2d-4b08-8c66-9ff25718deb8", new DateTime(2020, 5, 15, 13, 0, 40, 85, DateTimeKind.Utc).AddTicks(3469), "AQAAAAEAACcQAAAAEPbyqOmHjtkixm+RyZMntPxmjB4F8aQYl7XlIWetePRwWP/czPopBONyXfbvBooHew==" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("1009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 15, 13, 0, 40, 76, DateTimeKind.Utc).AddTicks(5444));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("2009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 15, 13, 0, 40, 77, DateTimeKind.Utc).AddTicks(396));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("3009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 15, 13, 0, 40, 77, DateTimeKind.Utc).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("4009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 15, 13, 0, 40, 77, DateTimeKind.Utc).AddTicks(503));

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentAnswer_DocumentQuestion_DocumentQuestionId",
                table: "DocumentAnswer",
                column: "DocumentQuestionId",
                principalTable: "DocumentQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentQuestion_Forms_FormId",
                table: "DocumentQuestion",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
