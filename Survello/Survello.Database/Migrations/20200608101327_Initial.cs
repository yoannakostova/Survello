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
                    CorelationToken = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(nullable: false),
                    DocumentQuestionId = table.Column<Guid>(nullable: false)
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
                values: new object[] { new Guid("0989cb07-226e-430d-9173-87ee97472f6a"), "53a68973-89f5-40b4-a2e1-8efffbecc478", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("52d02f62-14ac-4152-872c-08d7eb74f484"), 0, "293bbe7a-2f81-40ac-9791-2549dae190f1", new DateTime(2020, 6, 8, 10, 13, 24, 641, DateTimeKind.Utc).AddTicks(1644), "nasko@survello.com", false, false, false, null, "NASKO", "NASKO", "AQAAAAEAACcQAAAAECZ1NjkrxNVXZh2QqNXalEaeTB65ALdZrS2xlANQtkiIuqVOneRu60eXk2bEsBhxWA==", null, false, "321E275DD1E24957A7781D42BB68293B", false, "nasko" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70"), 0, "7e7749ea-d920-4a49-864f-668c7f0ff4c9", new DateTime(2020, 6, 8, 10, 13, 24, 712, DateTimeKind.Utc).AddTicks(4354), "yoanna@survello.com", false, false, false, null, "YOANNA", "YOANNA", "AQAAAAEAACcQAAAAEMWjgaTccMipRBXVOqBkDDDd+HYuHvZkmoHntw2ye2WxTswYnNoDE3uhm0LEyR3dNQ==", null, false, "431E275DD1E24957A7781D42BB68293B", false, "yoanna" });

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
                    { new Guid("433ae596-a2d7-4edd-9ca6-725e38d81d20"), new DateTime(2020, 6, 8, 13, 13, 24, 588, DateTimeKind.Local).AddTicks(9860), null, "In this form you will find basic questions about c#.", false, 0, "Basic .Net questions", new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70") },
                    { new Guid("52810e25-ff5a-4a0b-a3bb-149966936603"), new DateTime(2020, 6, 8, 13, 13, 24, 605, DateTimeKind.Local).AddTicks(3798), null, "This quiz will walk you through some of the most common questions asked about c# during interviews.", false, 0, "Quiz of commonly asked questions", new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70") },
                    { new Guid("54e3ce66-3f54-4887-a824-a8b5f3e2753d"), new DateTime(2020, 6, 8, 13, 13, 24, 605, DateTimeKind.Local).AddTicks(4270), null, "This quiz will walk you through some of the most common questions asked about c# during interviews.", false, 0, ".Net Interview questions", new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70") },
                    { new Guid("03270740-b76c-4947-a9f6-8505c59a6af3"), new DateTime(2020, 6, 8, 13, 13, 24, 605, DateTimeKind.Local).AddTicks(4362), null, "A selection of commonly asked questions during interviews.", false, 0, ".Net Advanced questions", new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70") },
                    { new Guid("19fe0d98-01a7-4f43-8fd5-c83e22660394"), new DateTime(2020, 6, 8, 13, 13, 24, 605, DateTimeKind.Local).AddTicks(4422), null, "Questions frequently asked during interviews for junior developer", false, 0, "Junior dev interview questions", new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70") },
                    { new Guid("ec3164af-7883-4df8-8db9-ebaf35160a52"), new DateTime(2020, 6, 8, 13, 13, 24, 605, DateTimeKind.Local).AddTicks(4510), null, "A collection of advanced questions", false, 0, "A collection of advanced questions", new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70") }
                });

            migrationBuilder.InsertData(
                table: "DocumentQuestions",
                columns: new[] { "Id", "Description", "FileNumberLimit", "FileSize", "FormId", "IsDeleted", "IsRequired", "QuestionNumber" },
                values: new object[,]
                {
                    { new Guid("078b4521-5443-4731-97f5-3782a007d19b"), "Write a C# method to total all the even numbers in an array of ints.", 2, 1, new Guid("433ae596-a2d7-4edd-9ca6-725e38d81d20"), false, true, 3 },
                    { new Guid("9da82655-2106-4e77-a42a-97c64bbe07ae"), "Write a C# method to total all the even numbers in an array of ints.", 5, 1, new Guid("19fe0d98-01a7-4f43-8fd5-c83e22660394"), false, true, 1 },
                    { new Guid("1ff9a8cf-4c6e-4ad3-ba1f-ea5d9f03e6dd"), "Write a C# method to total all the even numbers in an array of ints.", 4, 1, new Guid("03270740-b76c-4947-a9f6-8505c59a6af3"), false, true, 4 },
                    { new Guid("c576c898-95b8-4758-a7ef-11533c8cca48"), "Write a C# method to total all the even numbers in an array of ints.", 7, 1, new Guid("ec3164af-7883-4df8-8db9-ebaf35160a52"), false, true, 3 },
                    { new Guid("29317811-fc8b-4023-b7ba-6ec36b0493cb"), "Write a C# method to total all the even numbers in an array of ints.", 1, 1, new Guid("54e3ce66-3f54-4887-a824-a8b5f3e2753d"), false, true, 3 },
                    { new Guid("45a5dd1e-a553-4181-b121-0b05ad3d2f0c"), "Write a C# method to total all the even numbers in an array of ints.", 3, 1, new Guid("52810e25-ff5a-4a0b-a3bb-149966936603"), false, true, 2 }
                });

            migrationBuilder.InsertData(
                table: "MultipleChoiceQuestions",
                columns: new[] { "Id", "Description", "FormId", "IsDeleted", "IsMultipleAnswer", "IsRequired", "QuestionNumber" },
                values: new object[,]
                {
                    { new Guid("9c66a8bd-de6f-47fb-a747-95b9b42c2055"), "Which of the following are the correct statements about delegates?", new Guid("19fe0d98-01a7-4f43-8fd5-c83e22660394"), false, false, false, 2 },
                    { new Guid("18db6f90-753e-4d55-aa6e-69db9cbb12eb"), "Which is the String method used to compare two strings with each other ?", new Guid("03270740-b76c-4947-a9f6-8505c59a6af3"), false, false, false, 3 },
                    { new Guid("30331739-eb68-451c-8b0a-ed5ac05e8227"), "Which of these keywords is not a part of exception handling?", new Guid("54e3ce66-3f54-4887-a824-a8b5f3e2753d"), false, false, true, 2 },
                    { new Guid("0f94f73d-67dc-4c79-b09c-89af701ffeda"), "Correct way to define operator method or to perform operator overloading is?", new Guid("52810e25-ff5a-4a0b-a3bb-149966936603"), false, false, true, 3 },
                    { new Guid("dcec67bf-4aef-4676-b8b2-498380a4efa7"), "Which of these keywords must be used to monitor exceptions?", new Guid("54e3ce66-3f54-4887-a824-a8b5f3e2753d"), false, false, false, 4 },
                    { new Guid("1f56e1ac-1bb7-4770-bab3-fb532b52e7cb"), "Which of the following is an incorrect statement about delegate?", new Guid("ec3164af-7883-4df8-8db9-ebaf35160a52"), false, false, false, 2 },
                    { new Guid("e8e5a052-e9a9-4093-8b70-282016042413"), "Which keyword is used to refer baseclass constructor to subclass constructor?", new Guid("433ae596-a2d7-4edd-9ca6-725e38d81d20"), false, false, true, 2 },
                    { new Guid("ae0d5c2a-8f4e-4827-bf5a-c0207058f073"), "In Inheritance concept, which of the following members of base class are accessible to derived class members?", new Guid("433ae596-a2d7-4edd-9ca6-725e38d81d20"), false, false, true, 5 },
                    { new Guid("3b4f9812-6117-4e58-903f-490991e680b2"), "Which keyword is used for correct implementation of an interface in C#.NET?", new Guid("52810e25-ff5a-4a0b-a3bb-149966936603"), false, false, false, 1 }
                });

            migrationBuilder.InsertData(
                table: "TextQuestions",
                columns: new[] { "Id", "DeletedOn", "Description", "FormId", "IsDeleted", "IsLongAnswer", "IsRequired", "QuestionNumber" },
                values: new object[,]
                {
                    { new Guid("aab30de9-d16d-45a2-9012-dd122b6b1dfa"), null, "What is a garbage collector?", new Guid("19fe0d98-01a7-4f43-8fd5-c83e22660394"), false, false, false, 4 },
                    { new Guid("ef6ce506-b780-4d36-8043-03924225556c"), null, "What is caching?", new Guid("19fe0d98-01a7-4f43-8fd5-c83e22660394"), false, true, true, 3 },
                    { new Guid("0d7be58a-bd72-459b-9322-d4c86b631a87"), null, "What are the different types of constructors in c#?", new Guid("03270740-b76c-4947-a9f6-8505c59a6af3"), false, true, false, 7 },
                    { new Guid("ce852ae2-426e-43b9-afa1-670d6d80ef0e"), null, "What do you know about JIT?", new Guid("03270740-b76c-4947-a9f6-8505c59a6af3"), false, true, false, 6 },
                    { new Guid("786a9b6d-94d5-4afd-bb68-1d729a7ae817"), null, "What is CLR?", new Guid("03270740-b76c-4947-a9f6-8505c59a6af3"), false, true, true, 5 },
                    { new Guid("f840155f-5c38-47e8-b954-d71429f5ae72"), null, "What is the .NET framework?", new Guid("03270740-b76c-4947-a9f6-8505c59a6af3"), false, false, false, 2 },
                    { new Guid("2ffda5f1-1e63-42e6-b560-394a92968ad9"), null, "Describe the accessibility modifier \"protected internal\".", new Guid("03270740-b76c-4947-a9f6-8505c59a6af3"), false, true, false, 1 },
                    { new Guid("4d8e3c85-ef71-472d-8444-a0af982736fd"), null, "What is C#?", new Guid("433ae596-a2d7-4edd-9ca6-725e38d81d20"), false, true, false, 1 },
                    { new Guid("828631cf-db6e-41a6-a81a-46c46f59b581"), null, "Explain types of comment in C# with examples", new Guid("433ae596-a2d7-4edd-9ca6-725e38d81d20"), false, true, false, 2 },
                    { new Guid("e1629f86-fc5a-4eb0-b670-dc6af6dee40e"), null, "�Can a private virtual method can be overridden?", new Guid("54e3ce66-3f54-4887-a824-a8b5f3e2753d"), false, false, false, 8 },
                    { new Guid("3c03d298-d567-4ee8-91ea-2b1ed6cda9c9"), null, "What are sealed classes in C#?", new Guid("54e3ce66-3f54-4887-a824-a8b5f3e2753d"), false, true, false, 6 },
                    { new Guid("a488d39b-ff77-4872-b00a-3c32a53f3e09"), null, "What are value types and reference types?", new Guid("54e3ce66-3f54-4887-a824-a8b5f3e2753d"), false, false, false, 5 },
                    { new Guid("9438bc0d-2c47-409f-a3f7-0334d0240f2e"), null, "What is an interface class? Give one example of it", new Guid("54e3ce66-3f54-4887-a824-a8b5f3e2753d"), false, true, false, 1 },
                    { new Guid("0fe8bf2a-b48f-480b-8ad5-c054c29b4566"), null, "Can multiple catch blocks be executed?", new Guid("433ae596-a2d7-4edd-9ca6-725e38d81d20"), false, false, false, 4 },
                    { new Guid("0b447bc0-a9e0-4a51-bd34-781ac9478091"), null, "What is the difference between public, static, and void?", new Guid("433ae596-a2d7-4edd-9ca6-725e38d81d20"), false, true, true, 6 },
                    { new Guid("29642fa8-57ab-4b35-9284-d556a81e6649"), null, "What is an object?", new Guid("433ae596-a2d7-4edd-9ca6-725e38d81d20"), false, true, true, 7 },
                    { new Guid("cc58d266-38c1-4634-829c-2800ad28d8b9"), null, "What is the difference between constants and read-only?", new Guid("52810e25-ff5a-4a0b-a3bb-149966936603"), false, true, false, 8 },
                    { new Guid("81f10c0a-62d5-4921-8882-9e82c573aa87"), null, "Can we use \"this\" command within a static method?", new Guid("52810e25-ff5a-4a0b-a3bb-149966936603"), false, false, false, 7 },
                    { new Guid("f474eb25-71f4-44bc-a9e2-798b0075858d"), null, "What is the use of 'using' statement in C#?", new Guid("52810e25-ff5a-4a0b-a3bb-149966936603"), false, false, true, 6 },
                    { new Guid("265bf076-045b-4125-a601-d021802d36f0"), null, "What is Jagged Arrays?", new Guid("52810e25-ff5a-4a0b-a3bb-149966936603"), false, false, true, 5 },
                    { new Guid("adc438b9-6789-4ea0-a689-88a5130b3a1c"), null, "What is method overloading?", new Guid("54e3ce66-3f54-4887-a824-a8b5f3e2753d"), false, true, true, 7 },
                    { new Guid("0758f4a1-a33a-4d9b-b83c-52420f32f3a9"), null, "Define Constructors", new Guid("52810e25-ff5a-4a0b-a3bb-149966936603"), false, true, true, 4 }
                });

            migrationBuilder.InsertData(
                table: "MultipleChoiceOptions",
                columns: new[] { "Id", "MultipleChoiceQuestionId", "Option" },
                values: new object[,]
                {
                    { new Guid("74277088-7d1b-4429-98f8-39fe98815267"), new Guid("e8e5a052-e9a9-4093-8b70-282016042413"), "This" },
                    { new Guid("b20ee0b4-dcde-4f9e-bbf8-ef9617eed909"), new Guid("dcec67bf-4aef-4676-b8b2-498380a4efa7"), "try" },
                    { new Guid("e2606baf-96f6-4ddf-bf4d-6be5023cdb34"), new Guid("dcec67bf-4aef-4676-b8b2-498380a4efa7"), "finally" },
                    { new Guid("e70545cb-50a9-44e6-b413-c804af770a20"), new Guid("dcec67bf-4aef-4676-b8b2-498380a4efa7"), "throw" },
                    { new Guid("27a9da42-4aed-45bd-a64c-177ea6241802"), new Guid("dcec67bf-4aef-4676-b8b2-498380a4efa7"), "catch" },
                    { new Guid("7a3b0334-e88d-4dd7-be89-8e582c52d48d"), new Guid("18db6f90-753e-4d55-aa6e-69db9cbb12eb"), "Compare To()" },
                    { new Guid("9c7923c3-3383-451e-9990-ec15d652aa04"), new Guid("18db6f90-753e-4d55-aa6e-69db9cbb12eb"), "Compare()" },
                    { new Guid("b6d60eab-4820-42be-8f33-4155af131ad3"), new Guid("30331739-eb68-451c-8b0a-ed5ac05e8227"), "catch" },
                    { new Guid("a35a133a-19a3-4574-89ec-7e44fa97fe34"), new Guid("18db6f90-753e-4d55-aa6e-69db9cbb12eb"), "Copy()" },
                    { new Guid("149d9a84-62a2-4dd9-b23e-d68d42618ff1"), new Guid("9c66a8bd-de6f-47fb-a747-95b9b42c2055"), "Delegates can be used to implement callback notification" },
                    { new Guid("f15e89b5-60e2-4457-bdc3-d4bb483834a2"), new Guid("9c66a8bd-de6f-47fb-a747-95b9b42c2055"), "Delegates permit execution of a method on a secondary thread in an asynchronous manner" },
                    { new Guid("3d0cfcaa-5ec7-4efc-8f27-261ea1bc9f87"), new Guid("9c66a8bd-de6f-47fb-a747-95b9b42c2055"), "Delegate is a user defined type" },
                    { new Guid("2df4a514-8123-4b39-96c0-21b9d362ce30"), new Guid("9c66a8bd-de6f-47fb-a747-95b9b42c2055"), "All of the mentioned" },
                    { new Guid("32eff30e-84a8-4f39-98ad-9299673dd821"), new Guid("1f56e1ac-1bb7-4770-bab3-fb532b52e7cb"), "A single delegate can invoke more than one method" },
                    { new Guid("a04723a5-d772-4c4d-83c1-afade549cf91"), new Guid("1f56e1ac-1bb7-4770-bab3-fb532b52e7cb"), "Delegates could be shared" },
                    { new Guid("c9aa4c04-1923-4a23-bff7-abdb9eba037c"), new Guid("18db6f90-753e-4d55-aa6e-69db9cbb12eb"), "Concat()" },
                    { new Guid("4c9faca3-d8db-48b7-90b8-04f327507e97"), new Guid("30331739-eb68-451c-8b0a-ed5ac05e8227"), "thrown" },
                    { new Guid("b02fe2be-d595-4f7c-823d-3847ce7ffd19"), new Guid("30331739-eb68-451c-8b0a-ed5ac05e8227"), "finally" },
                    { new Guid("54bd185e-d4a5-4111-b8cd-d0f673888e36"), new Guid("30331739-eb68-451c-8b0a-ed5ac05e8227"), "try" },
                    { new Guid("c193852b-b991-4f5a-9714-4ac795e1d9c6"), new Guid("e8e5a052-e9a9-4093-8b70-282016042413"), "static" },
                    { new Guid("e55253da-c62a-42a0-9376-6f94b6022961"), new Guid("e8e5a052-e9a9-4093-8b70-282016042413"), "extend" },
                    { new Guid("f4945cd1-77f2-45c2-b2d4-05a5ca211a77"), new Guid("e8e5a052-e9a9-4093-8b70-282016042413"), "base" },
                    { new Guid("01ae9bc9-a4b6-4e1e-98a8-f1c0c9b83f81"), new Guid("ae0d5c2a-8f4e-4827-bf5a-c0207058f073"), "static" },
                    { new Guid("ef72106e-1caf-4f12-b52d-7398fcb4173c"), new Guid("ae0d5c2a-8f4e-4827-bf5a-c0207058f073"), "protected" },
                    { new Guid("4830247a-7b4a-4a80-8bdb-86f821997b67"), new Guid("ae0d5c2a-8f4e-4827-bf5a-c0207058f073"), "private" },
                    { new Guid("89054196-2c4a-4f85-a1cd-6a56476078bb"), new Guid("ae0d5c2a-8f4e-4827-bf5a-c0207058f073"), "shared" },
                    { new Guid("db3fda74-04f4-4a37-afd1-364dfe8d9543"), new Guid("3b4f9812-6117-4e58-903f-490991e680b2"), "interface" },
                    { new Guid("cd3898da-94de-4d93-a573-213768940188"), new Guid("3b4f9812-6117-4e58-903f-490991e680b2"), "Interface" },
                    { new Guid("df4405a4-febe-4944-ac56-2aa7a542795b"), new Guid("3b4f9812-6117-4e58-903f-490991e680b2"), "intf" },
                    { new Guid("8fd76353-a1a1-4f93-ad4b-1ca98a1b85b2"), new Guid("3b4f9812-6117-4e58-903f-490991e680b2"), "Intf" },
                    { new Guid("3f6d4ee6-92de-488c-aa64-faa6e4603e6e"), new Guid("0f94f73d-67dc-4c79-b09c-89af701ffeda"), "public static op(arglist) { }" },
                    { new Guid("afe90d07-58bd-4e1b-b26f-5d9f0ce383e9"), new Guid("0f94f73d-67dc-4c79-b09c-89af701ffeda"), "public static retval op(arglist) { }" },
                    { new Guid("6a1b83e6-ab90-482f-90d2-643443d3b3d6"), new Guid("0f94f73d-67dc-4c79-b09c-89af701ffeda"), "public static retval operator op(arglist) { }" },
                    { new Guid("016951d6-ce70-490d-b970-dda0bfaeba94"), new Guid("0f94f73d-67dc-4c79-b09c-89af701ffeda"), "All of the mentioned" },
                    { new Guid("11551fa3-ef2f-4ade-bd5e-d3efdcd5a3e2"), new Guid("1f56e1ac-1bb7-4770-bab3-fb532b52e7cb"), "The del class will contain a one argument constructor and an invoke() method" },
                    { new Guid("5e985fb6-b616-4f6e-9599-fe4d6448dbc7"), new Guid("1f56e1ac-1bb7-4770-bab3-fb532b52e7cb"), "All of the mentioned" }
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
