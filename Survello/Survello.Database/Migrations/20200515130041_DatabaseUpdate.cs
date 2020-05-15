using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survello.Database.Migrations
{
    public partial class DatabaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DocumentAnswer",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DocumentAnswer");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0989cb07-226e-430d-9173-87ee97472f6a"),
                column: "ConcurrencyStamp",
                value: "e178c488-23cc-4a0c-a7ce-8026fdef1e4d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "5970dcdb-c4b1-466b-b341-3c2391b1fe73", new DateTime(2020, 5, 15, 12, 56, 51, 749, DateTimeKind.Utc).AddTicks(1432), "AQAAAAEAACcQAAAAEFRiYTnck/yy5TDTB1TQ/HJsHuf//uTEUjrZ39ZgLEUkHNklTvplay20U09Ec3chng==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("52d02f62-14ac-4152-872c-08d7eb74f484"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "9e701abd-2a19-48ae-8444-76de824f9846", new DateTime(2020, 5, 15, 12, 56, 51, 724, DateTimeKind.Utc).AddTicks(8332), "AQAAAAEAACcQAAAAEKPkkDhqnt5CM0jUzvYI9VDww4gkYORU0CagVkc9nc8C20P/4CFXPGb82MLSnGc05A==" });

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("1009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 15, 12, 56, 51, 717, DateTimeKind.Utc).AddTicks(4228));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("2009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 15, 12, 56, 51, 717, DateTimeKind.Utc).AddTicks(8735));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("3009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 15, 12, 56, 51, 717, DateTimeKind.Utc).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: new Guid("4009cb07-226e-430d-9173-87ee97472f6a"),
                column: "CreatedOn",
                value: new DateTime(2020, 5, 15, 12, 56, 51, 717, DateTimeKind.Utc).AddTicks(8822));
        }
    }
}
