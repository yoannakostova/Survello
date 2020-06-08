using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survello.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    NumberOfFilledForms = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    FileNumberLimit = table.Column<int>(nullable: false),
                    FileSize = table.Column<int>(nullable: false),
                    FormId = table.Column<Guid>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    QuestionNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentQuestions_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    IsMultipleAnswer = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FormId = table.Column<Guid>(nullable: false),
                    QuestionNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuestions_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsLongAnswer = table.Column<bool>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    FormId = table.Column<Guid>(nullable: false),
                    QuestionNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextQuestions_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(nullable: false),
                    DocumentQuestionId = table.Column<Guid>(nullable: false),
                    CorelationToken = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentAnswers_DocumentQuestions_DocumentQuestionId",
                        column: x => x.DocumentQuestionId,
                        principalTable: "DocumentQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CorelationToken = table.Column<Guid>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    MultipleChoiceQuestionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceAnswers_MultipleChoiceQuestions_MultipleChoiceQuestionId",
                        column: x => x.MultipleChoiceQuestionId,
                        principalTable: "MultipleChoiceQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Option = table.Column<string>(nullable: false),
                    MultipleChoiceQuestionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceOptions_MultipleChoiceQuestions_MultipleChoiceQuestionId",
                        column: x => x.MultipleChoiceQuestionId,
                        principalTable: "MultipleChoiceQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CorelationToken = table.Column<Guid>(nullable: false),
                    Answer = table.Column<string>(nullable: false),
                    TextQuestionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextAnswers_TextQuestions_TextQuestionId",
                        column: x => x.TextQuestionId,
                        principalTable: "TextQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("0989cb07-226e-430d-9173-87ee97472f6a"), "001a076e-ef72-43ab-94d7-36af9e9a1ca0", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("52d02f62-14ac-4152-872c-08d7eb74f484"), 0, "a0af1e5d-fe63-423a-b429-66510e26a244", new DateTime(2020, 6, 8, 9, 26, 40, 29, DateTimeKind.Utc).AddTicks(8328), "nasko@survello.com", false, false, false, null, "NASKO", "NASKO", "AQAAAAEAACcQAAAAEKpCBvZGu0QVaTgQUzo0taoqNBk2Q8GSD9LMsjjHxnaDDKf5i5yBCPJwssWMl+1DgA==", null, false, "321E275DD1E24957A7781D42BB68293B", false, "nasko" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70"), 0, "7708edea-1579-43a3-85ed-6321c7440e46", new DateTime(2020, 6, 8, 9, 26, 40, 44, DateTimeKind.Utc).AddTicks(8624), "yoanna@survello.com", false, false, false, null, "YOANNA", "YOANNA", "AQAAAAEAACcQAAAAEHWuWhGpzpV1vdef3FgC0z0wWOtjhSSSK9s8ADOdOOKV5BHLeSnbTuxDoA2UaxKvHQ==", null, false, "431E275DD1E24957A7781D42BB68293B", false, "yoanna" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("52d02f62-14ac-4152-872c-08d7eb74f484"), new Guid("0989cb07-226e-430d-9173-87ee97472f6a") },
                    { new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70"), new Guid("0989cb07-226e-430d-9173-87ee97472f6a") }
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsDeleted", "NumberOfFilledForms", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("f0d58731-55c4-4d3f-8528-4efe1e2c2bf8"), new DateTime(2020, 6, 8, 12, 26, 40, 21, DateTimeKind.Local).AddTicks(3412), null, "In this form you will find basic questions about c#.", false, 0, "Basic .Net questions", new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70") },
                    { new Guid("ab7411e3-3188-4de0-9bae-c3292a0ccbaa"), new DateTime(2020, 6, 8, 12, 26, 40, 24, DateTimeKind.Local).AddTicks(1928), null, "This quiz will walk you through some of the most common questions asked about c# during interviews.", false, 0, "Quiz of commonly asked questions", new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70") },
                    { new Guid("1f1da997-9be3-49f8-bbe3-822f14a80555"), new DateTime(2020, 6, 8, 12, 26, 40, 24, DateTimeKind.Local).AddTicks(2030), null, "This quiz will walk you through some of the most common questions asked about c# during interviews.", false, 0, ".Net Interview questions", new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70") },
                    { new Guid("1e3c4445-f658-4321-9486-385273e131fd"), new DateTime(2020, 6, 8, 12, 26, 40, 24, DateTimeKind.Local).AddTicks(2047), null, "A selection of commonly asked questions during interviews.", false, 0, ".Net Advanced questions", new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70") },
                    { new Guid("a7712d14-552f-4f3f-8758-f1d640e1fe8d"), new DateTime(2020, 6, 8, 12, 26, 40, 24, DateTimeKind.Local).AddTicks(2060), null, "Questions frequently asked during interviews for junior developer", false, 0, "Junior dev interview questions", new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70") },
                    { new Guid("1ea70a30-5eed-4cbb-bbf2-71c6b6cd1cda"), new DateTime(2020, 6, 8, 12, 26, 40, 24, DateTimeKind.Local).AddTicks(2075), null, "A collection of advanced questions", false, 0, "A collection of advanced questions", new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70") }
                });

            migrationBuilder.InsertData(
                table: "DocumentQuestions",
                columns: new[] { "Id", "Description", "FileNumberLimit", "FileSize", "FormId", "IsDeleted", "IsRequired", "QuestionNumber" },
                values: new object[,]
                {
                    { new Guid("390c1883-9d80-4ba6-8ca5-8ca64b7742ff"), "Write a C# method to total all the even numbers in an array of ints.", 2, 1, new Guid("f0d58731-55c4-4d3f-8528-4efe1e2c2bf8"), false, true, 3 },
                    { new Guid("d005dd49-0bcc-482e-b76c-124cc6b2a595"), "Write a C# method to total all the even numbers in an array of ints.", 5, 1, new Guid("a7712d14-552f-4f3f-8758-f1d640e1fe8d"), false, true, 1 },
                    { new Guid("f630607b-28b9-4fe6-ad5f-e297980e8fb2"), "Write a C# method to total all the even numbers in an array of ints.", 4, 1, new Guid("1e3c4445-f658-4321-9486-385273e131fd"), false, true, 4 },
                    { new Guid("3427db1a-57ca-4d6b-9bdc-4ffd2de41e8a"), "Write a C# method to total all the even numbers in an array of ints.", 7, 1, new Guid("1ea70a30-5eed-4cbb-bbf2-71c6b6cd1cda"), false, true, 3 },
                    { new Guid("241056cb-9a29-49f3-82d3-937c9c3cd07a"), "Write a C# method to total all the even numbers in an array of ints.", 1, 1, new Guid("1f1da997-9be3-49f8-bbe3-822f14a80555"), false, true, 3 },
                    { new Guid("2b433b42-a90b-4bc5-9839-f497c9640344"), "Write a C# method to total all the even numbers in an array of ints.", 3, 1, new Guid("ab7411e3-3188-4de0-9bae-c3292a0ccbaa"), false, true, 2 }
                });

            migrationBuilder.InsertData(
                table: "MultipleChoiceQuestions",
                columns: new[] { "Id", "Description", "FormId", "IsDeleted", "IsMultipleAnswer", "IsRequired", "QuestionNumber" },
                values: new object[,]
                {
                    { new Guid("afacb607-88c4-410b-b32b-fecbff3c20eb"), "Which of the following are the correct statements about delegates?", new Guid("a7712d14-552f-4f3f-8758-f1d640e1fe8d"), false, false, false, 2 },
                    { new Guid("38ea6935-bdd1-48b4-8ed5-c918658a05f1"), "Which is the String method used to compare two strings with each other ?", new Guid("1e3c4445-f658-4321-9486-385273e131fd"), false, false, false, 3 },
                    { new Guid("3dd27c6d-0283-48a4-b59b-e390204c32cc"), "�Which of these keywords is not a part of exception handling?", new Guid("1f1da997-9be3-49f8-bbe3-822f14a80555"), false, false, true, 2 },
                    { new Guid("ab1b1b5f-389e-4d1c-ad3d-0d56235433fa"), "�Correct way to define operator method or to perform operator overloading is?", new Guid("ab7411e3-3188-4de0-9bae-c3292a0ccbaa"), false, false, true, 3 },
                    { new Guid("872255df-ab9b-4622-8cc4-48306bde6d77"), "Which of these keywords must be used to monitor exceptions?", new Guid("1f1da997-9be3-49f8-bbe3-822f14a80555"), false, false, false, 4 },
                    { new Guid("a8cfc13d-fd75-45c1-ab3f-19809f54d01e"), "Which of the following is an incorrect statement about delegate?", new Guid("1ea70a30-5eed-4cbb-bbf2-71c6b6cd1cda"), false, false, false, 2 },
                    { new Guid("aa77eae5-3c01-47dc-bbb9-b8fb2ed83486"), "Which keyword is used to refer baseclass constructor to subclass constructor?", new Guid("f0d58731-55c4-4d3f-8528-4efe1e2c2bf8"), false, false, true, 2 },
                    { new Guid("e6ba6640-f27b-4e29-b310-3f98a776e244"), "�In Inheritance concept, which of the following members of base class are accessible to derived class members?", new Guid("f0d58731-55c4-4d3f-8528-4efe1e2c2bf8"), false, false, true, 5 },
                    { new Guid("a2cfb6b2-2e92-4329-ad0f-497d9ffc0f76"), "Which keyword is used for correct implementation of an interface in C#.NET?", new Guid("ab7411e3-3188-4de0-9bae-c3292a0ccbaa"), false, false, false, 1 }
                });

            migrationBuilder.InsertData(
                table: "TextQuestions",
                columns: new[] { "Id", "DeletedOn", "Description", "FormId", "IsDeleted", "IsLongAnswer", "IsRequired", "QuestionNumber" },
                values: new object[,]
                {
                    { new Guid("7b6e3b53-a872-4756-9014-e393a51e77c6"), null, "What is a garbage collector?", new Guid("a7712d14-552f-4f3f-8758-f1d640e1fe8d"), false, false, false, 4 },
                    { new Guid("9e710922-1ddc-4bcb-b808-a2ae9b709b8d"), null, "What is caching?", new Guid("a7712d14-552f-4f3f-8758-f1d640e1fe8d"), false, true, true, 3 },
                    { new Guid("d601ece8-c046-4be2-9dcb-750a8c2ed069"), null, "What are the different types of constructors in c#?", new Guid("1e3c4445-f658-4321-9486-385273e131fd"), false, true, false, 7 },
                    { new Guid("b18f1886-5792-4e8d-9c88-59254178e90e"), null, "What do you know about JIT?", new Guid("1e3c4445-f658-4321-9486-385273e131fd"), false, true, false, 6 },
                    { new Guid("4148b1fb-d9bb-4a94-bf23-d01c22ffa3b7"), null, "What is CLR?", new Guid("1e3c4445-f658-4321-9486-385273e131fd"), false, true, true, 5 },
                    { new Guid("ad356be6-3df4-41d9-9117-d2dc365789a4"), null, "What is the .NET framework?", new Guid("1e3c4445-f658-4321-9486-385273e131fd"), false, false, false, 2 },
                    { new Guid("1c4dd546-a0fb-4f1d-9914-14dfcddef1cb"), null, "Describe the accessibility modifier \"protected internal\".", new Guid("1e3c4445-f658-4321-9486-385273e131fd"), false, true, false, 1 },
                    { new Guid("d3d0758f-fce5-4920-a9c9-880be810c4e2"), null, "What is C#?", new Guid("f0d58731-55c4-4d3f-8528-4efe1e2c2bf8"), false, true, false, 1 },
                    { new Guid("2fd754ec-80b1-4384-965a-c9bd1f838566"), null, "Explain types of comment in C# with examples", new Guid("f0d58731-55c4-4d3f-8528-4efe1e2c2bf8"), false, true, false, 2 },
                    { new Guid("9d5b6e05-3a0d-4fe6-82c3-9b6d3d8f4050"), null, "�Can a private virtual method can be overridden?", new Guid("1f1da997-9be3-49f8-bbe3-822f14a80555"), false, false, false, 8 },
                    { new Guid("86cd11e3-938a-4cbe-8bb0-df52d57275bb"), null, "What are sealed classes in C#?", new Guid("1f1da997-9be3-49f8-bbe3-822f14a80555"), false, true, false, 6 },
                    { new Guid("451cc22f-2805-4d0b-9217-79e01bf19915"), null, "What are value types and reference types?", new Guid("1f1da997-9be3-49f8-bbe3-822f14a80555"), false, false, false, 5 },
                    { new Guid("80f17d1a-525b-48cd-be01-83910e56705b"), null, "What is an interface class? Give one example of it", new Guid("1f1da997-9be3-49f8-bbe3-822f14a80555"), false, true, false, 1 },
                    { new Guid("632a1e5f-1eea-4811-99c3-0f42b09f9e86"), null, "Can multiple catch blocks be executed?", new Guid("f0d58731-55c4-4d3f-8528-4efe1e2c2bf8"), false, false, false, 4 },
                    { new Guid("2d1a1e65-93ed-40c7-ad52-ceed884c0cf0"), null, "What is the difference between public, static, and void?", new Guid("f0d58731-55c4-4d3f-8528-4efe1e2c2bf8"), false, true, true, 6 },
                    { new Guid("891b055f-8238-4cca-bf29-ceed6f324717"), null, "What is an object?", new Guid("f0d58731-55c4-4d3f-8528-4efe1e2c2bf8"), false, true, true, 7 },
                    { new Guid("36c0dfce-32a2-4ddc-acbe-d94b198fdbc2"), null, "What is the difference between constants and read-only?", new Guid("ab7411e3-3188-4de0-9bae-c3292a0ccbaa"), false, true, false, 8 },
                    { new Guid("ec4a44b0-eae7-40a2-b5c2-981d9c94b897"), null, "Can we use \"this\" command within a static method?", new Guid("ab7411e3-3188-4de0-9bae-c3292a0ccbaa"), false, false, false, 7 },
                    { new Guid("7b568f9c-147e-4fe1-ab05-118d2a82ecad"), null, "What is the use of 'using' statement in C#?", new Guid("ab7411e3-3188-4de0-9bae-c3292a0ccbaa"), false, false, true, 6 },
                    { new Guid("c50ce009-ed7f-44da-b24f-dec75472dbb1"), null, "What is Jagged Arrays?", new Guid("ab7411e3-3188-4de0-9bae-c3292a0ccbaa"), false, false, true, 5 },
                    { new Guid("d544ea9f-e4fd-454e-a007-a01453cb58dd"), null, "What is method overloading?", new Guid("1f1da997-9be3-49f8-bbe3-822f14a80555"), false, true, true, 7 },
                    { new Guid("bd1fe1b5-0ab3-4639-acb5-e40bc5b9f927"), null, "Define Constructors", new Guid("ab7411e3-3188-4de0-9bae-c3292a0ccbaa"), false, true, true, 4 }
                });

            migrationBuilder.InsertData(
                table: "MultipleChoiceOptions",
                columns: new[] { "Id", "MultipleChoiceQuestionId", "Option" },
                values: new object[,]
                {
                    { new Guid("30a61e1f-a969-44c9-ad12-27677b0cf442"), new Guid("aa77eae5-3c01-47dc-bbb9-b8fb2ed83486"), "This" },
                    { new Guid("bdece55d-74ea-4457-8299-ec040acad325"), new Guid("872255df-ab9b-4622-8cc4-48306bde6d77"), "�try" },
                    { new Guid("66733d79-9886-49e2-88fb-0da0fe989c83"), new Guid("872255df-ab9b-4622-8cc4-48306bde6d77"), "finally" },
                    { new Guid("9b4d575b-794e-471f-9eeb-7a2ccf5a8ac8"), new Guid("872255df-ab9b-4622-8cc4-48306bde6d77"), "throw" },
                    { new Guid("f9737817-fc77-4624-b1b7-ab1945d60900"), new Guid("872255df-ab9b-4622-8cc4-48306bde6d77"), "catch" },
                    { new Guid("29950c72-bca5-4c8a-98c4-7f7c439a67ed"), new Guid("38ea6935-bdd1-48b4-8ed5-c918658a05f1"), "�Compare To()" },
                    { new Guid("188694a5-b5c8-49ca-8312-d4c8a47fe237"), new Guid("38ea6935-bdd1-48b4-8ed5-c918658a05f1"), "Compare()" },
                    { new Guid("34872bc9-82dd-4212-92f7-402868c4aa3a"), new Guid("3dd27c6d-0283-48a4-b59b-e390204c32cc"), "catch" },
                    { new Guid("59387642-1749-445e-930d-d8d7097d7283"), new Guid("38ea6935-bdd1-48b4-8ed5-c918658a05f1"), "Copy()" },
                    { new Guid("c939e1bc-0fef-48a4-a6e4-8454a859a3b3"), new Guid("afacb607-88c4-410b-b32b-fecbff3c20eb"), "Delegates can be used to implement callback notification" },
                    { new Guid("05db646b-3697-4f3d-bd54-575b25238bae"), new Guid("afacb607-88c4-410b-b32b-fecbff3c20eb"), "Delegates permit execution of a method on a secondary thread in an asynchronous manner" },
                    { new Guid("b90cb79c-7bcb-4902-ad65-3cf16974db42"), new Guid("afacb607-88c4-410b-b32b-fecbff3c20eb"), "Delegate is a user defined type" },
                    { new Guid("071fc262-239b-478e-a68d-7fd4e35ee2a1"), new Guid("afacb607-88c4-410b-b32b-fecbff3c20eb"), "All of the mentioned" },
                    { new Guid("b2f10545-cc02-4524-b497-a72bf93a8209"), new Guid("a8cfc13d-fd75-45c1-ab3f-19809f54d01e"), "A single delegate can invoke more than one method" },
                    { new Guid("43b1c3e0-9403-4f12-8cec-d50a6a0a27e5"), new Guid("a8cfc13d-fd75-45c1-ab3f-19809f54d01e"), "Delegates could be shared" },
                    { new Guid("ecafd3d4-2508-4046-8f06-09395e76864a"), new Guid("38ea6935-bdd1-48b4-8ed5-c918658a05f1"), "ConCat()" },
                    { new Guid("c0a57b70-70ec-4cd1-a709-11d3e3c2eebe"), new Guid("3dd27c6d-0283-48a4-b59b-e390204c32cc"), "thrown" },
                    { new Guid("1e9729cb-4952-4fd8-93fb-b982535b2558"), new Guid("3dd27c6d-0283-48a4-b59b-e390204c32cc"), "finally" },
                    { new Guid("497fe24c-4ffd-4897-8766-77bbe971cddd"), new Guid("3dd27c6d-0283-48a4-b59b-e390204c32cc"), "try" },
                    { new Guid("a4ff7082-a7f1-4f65-88e2-19d7cde8c07f"), new Guid("aa77eae5-3c01-47dc-bbb9-b8fb2ed83486"), "static" },
                    { new Guid("0c4ef4e0-0bd2-42fd-b971-e220dfd45c86"), new Guid("aa77eae5-3c01-47dc-bbb9-b8fb2ed83486"), "�extend" },
                    { new Guid("72294a58-3b27-4e3a-a21c-3d48f99bd0f9"), new Guid("aa77eae5-3c01-47dc-bbb9-b8fb2ed83486"), "base" },
                    { new Guid("4bfd92a7-ca4f-48f5-bb4b-68a5c4cb2db9"), new Guid("e6ba6640-f27b-4e29-b310-3f98a776e244"), "�static" },
                    { new Guid("1a18e769-8e32-4d1d-b2d4-f605896b3bf0"), new Guid("e6ba6640-f27b-4e29-b310-3f98a776e244"), "protected" },
                    { new Guid("c9317342-1232-4457-93d6-78b3e7389997"), new Guid("e6ba6640-f27b-4e29-b310-3f98a776e244"), "private" },
                    { new Guid("d89950e4-b55a-4bf0-9cfb-71b66b87f70e"), new Guid("e6ba6640-f27b-4e29-b310-3f98a776e244"), "shared" },
                    { new Guid("d3fa3e69-6b09-46bd-87d7-dbb83c82e23b"), new Guid("a2cfb6b2-2e92-4329-ad0f-497d9ffc0f76"), "interface" },
                    { new Guid("67e08c49-4062-453f-986e-4370c9e7a5ce"), new Guid("a2cfb6b2-2e92-4329-ad0f-497d9ffc0f76"), "Interface" },
                    { new Guid("0e77ad99-4f7e-432c-8e16-6d496946e63d"), new Guid("a2cfb6b2-2e92-4329-ad0f-497d9ffc0f76"), "intf" },
                    { new Guid("dc90d6f5-02ce-47a7-bd62-ccf42153b502"), new Guid("a2cfb6b2-2e92-4329-ad0f-497d9ffc0f76"), "Intf" },
                    { new Guid("7c82bb4a-2fd8-456e-908a-edbb4f8e61c5"), new Guid("ab1b1b5f-389e-4d1c-ad3d-0d56235433fa"), "public static op(arglist) { }" },
                    { new Guid("8907f9bd-ad34-4f70-8afc-b3ba1077a224"), new Guid("ab1b1b5f-389e-4d1c-ad3d-0d56235433fa"), "public static retval op(arglist) { }" },
                    { new Guid("eb2d9451-c2c2-4420-a887-7392781a925b"), new Guid("ab1b1b5f-389e-4d1c-ad3d-0d56235433fa"), "public static retval operator op(arglist) { }" },
                    { new Guid("b5976591-55e4-4a7f-9143-149abbcc6a6c"), new Guid("ab1b1b5f-389e-4d1c-ad3d-0d56235433fa"), "All of the mentioned" },
                    { new Guid("8bfe0ef8-dfe8-4fa4-a429-2b6fc6d3b93d"), new Guid("a8cfc13d-fd75-45c1-ab3f-19809f54d01e"), "The del class will contain a one argument constructor and an invoke() method" },
                    { new Guid("3e89a083-c7bf-40f4-9cef-0745796873b2"), new Guid("a8cfc13d-fd75-45c1-ab3f-19809f54d01e"), "All of the mentioned" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAnswers_DocumentQuestionId",
                table: "DocumentAnswers",
                column: "DocumentQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentQuestions_FormId",
                table: "DocumentQuestions",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_UserId",
                table: "Forms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceAnswers_MultipleChoiceQuestionId",
                table: "MultipleChoiceAnswers",
                column: "MultipleChoiceQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceOptions_MultipleChoiceQuestionId",
                table: "MultipleChoiceOptions",
                column: "MultipleChoiceQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceQuestions_FormId",
                table: "MultipleChoiceQuestions",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_TextAnswers_TextQuestionId",
                table: "TextAnswers",
                column: "TextQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TextQuestions_FormId",
                table: "TextQuestions",
                column: "FormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DocumentAnswers");

            migrationBuilder.DropTable(
                name: "MultipleChoiceAnswers");

            migrationBuilder.DropTable(
                name: "MultipleChoiceOptions");

            migrationBuilder.DropTable(
                name: "TextAnswers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DocumentQuestions");

            migrationBuilder.DropTable(
                name: "MultipleChoiceQuestions");

            migrationBuilder.DropTable(
                name: "TextQuestions");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
