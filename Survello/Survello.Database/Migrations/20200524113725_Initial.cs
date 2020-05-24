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
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
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
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
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
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateOfExpiration = table.Column<DateTime>(nullable: true),
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
                    DeletedOn = table.Column<DateTime>(nullable: true),
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
                    DeletedOn = table.Column<DateTime>(nullable: true),
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
                    IsDeleted = table.Column<bool>(nullable: false),
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
                name: "MultipleChoiceOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Option = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MultipleChouceQuestionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceOptions_MultipleChoiceQuestions_MultipleChouceQuestionId",
                        column: x => x.MultipleChouceQuestionId,
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
                    IsDeleted = table.Column<bool>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "MultipleChoiceAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CorelationToken = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MultipleChoiceOptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceAnswers_MultipleChoiceOptions_MultipleChoiceOptionId",
                        column: x => x.MultipleChoiceOptionId,
                        principalTable: "MultipleChoiceOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("0989cb07-226e-430d-9173-87ee97472f6a"), "65a68a12-c66d-47a7-a77f-d40213bfea13", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LastModifiedOn", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("52d02f62-14ac-4152-872c-08d7eb74f484"), 0, "57057c91-2e9c-40be-abec-20eba3394d3a", new DateTime(2020, 5, 24, 11, 37, 24, 413, DateTimeKind.Utc).AddTicks(1843), null, "nasko@survello.com", false, false, null, false, null, "NASKO", "NASKO", "AQAAAAEAACcQAAAAEEhDST3DhWiZRkmCZGxmfBvTEsMTivp/MfrXURqFpXL4UNJ7i4me2GFNvXWWYyGblQ==", null, false, "321E275DD1E24957A7781D42BB68293B", false, "nasko" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LastModifiedOn", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70"), 0, "357eeda4-3d47-4ad2-91ba-19871c161955", new DateTime(2020, 5, 24, 11, 37, 24, 431, DateTimeKind.Utc).AddTicks(6538), null, "yoanna@survello.com", false, false, null, false, null, "YOANNA", "YOANNA", "AQAAAAEAACcQAAAAEGGK5BTXoJ4wHvqxLDVtb7mmsWItpBp7KIBL9uEcQSqwchnb9/3C6HM6qMDYJr7YdA==", null, false, "431E275DD1E24957A7781D42BB68293B", false, "yoanna" });

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
                columns: new[] { "Id", "CreatedOn", "DateOfExpiration", "DeletedOn", "Description", "IsDeleted", "LastModifiedOn", "NumberOfFilledForms", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("1009cb07-226e-430d-9173-87ee97472f6a"), new DateTime(2020, 5, 24, 11, 37, 24, 407, DateTimeKind.Utc).AddTicks(9202), null, null, "Test description 1.", false, null, 0, "Test form 1", new Guid("52d02f62-14ac-4152-872c-08d7eb74f484") },
                    { new Guid("3009cb07-226e-430d-9173-87ee97472f6a"), new DateTime(2020, 5, 24, 11, 37, 24, 408, DateTimeKind.Utc).AddTicks(2440), null, null, "Test description 3.", false, null, 0, "Test form 3", new Guid("52d02f62-14ac-4152-872c-08d7eb74f484") },
                    { new Guid("2009cb07-226e-430d-9173-87ee97472f6a"), new DateTime(2020, 5, 24, 11, 37, 24, 408, DateTimeKind.Utc).AddTicks(2379), null, null, "Test description 2.", false, null, 0, "Test form 2", new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70") },
                    { new Guid("4009cb07-226e-430d-9173-87ee97472f6a"), new DateTime(2020, 5, 24, 11, 37, 24, 408, DateTimeKind.Utc).AddTicks(2449), null, null, "Test description 4", false, null, 0, "Test form 4", new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70") }
                });

            migrationBuilder.InsertData(
                table: "MultipleChoiceQuestions",
                columns: new[] { "Id", "DeletedOn", "Description", "FormId", "IsDeleted", "IsMultipleAnswer", "IsRequired", "QuestionNumber" },
                values: new object[,]
                {
                    { new Guid("2109cb07-226e-430d-9173-87ee97472f6a"), null, "How would you rate your experience with our product?", new Guid("1009cb07-226e-430d-9173-87ee97472f6a"), false, false, true, 0 },
                    { new Guid("22000b07-226e-430d-9173-87ee97472f6a"), null, "What kind of animal is feline?", new Guid("3009cb07-226e-430d-9173-87ee97472f6a"), false, false, true, 0 },
                    { new Guid("2209cb07-226e-430d-9173-87ee97472f6a"), null, "How often do you conduct surveys?", new Guid("2009cb07-226e-430d-9173-87ee97472f6a"), false, false, true, 0 },
                    { new Guid("22600b07-226e-430d-9173-87ee97472f6a"), null, "Which operations can be performed on a data structure?", new Guid("4009cb07-226e-430d-9173-87ee97472f6a"), false, false, true, 0 }
                });

            migrationBuilder.InsertData(
                table: "TextQuestions",
                columns: new[] { "Id", "DeletedOn", "Description", "FormId", "IsDeleted", "IsLongAnswer", "IsRequired", "QuestionNumber" },
                values: new object[,]
                {
                    { new Guid("1109cb07-226e-430d-9173-87ee97472f6a"), null, "How old are you?", new Guid("1009cb07-226e-430d-9173-87ee97472f6a"), false, false, true, 0 },
                    { new Guid("1309cb07-226e-430d-9173-87ee97472f6a"), null, "What is class?", new Guid("3009cb07-226e-430d-9173-87ee97472f6a"), false, false, true, 0 },
                    { new Guid("1209cb07-226e-430d-9173-87ee97472f6a"), null, "Where are you from?", new Guid("2009cb07-226e-430d-9173-87ee97472f6a"), false, false, true, 0 },
                    { new Guid("1409cb07-226e-430d-9173-87ee97472f6a"), null, "What is algorithm?", new Guid("4009cb07-226e-430d-9173-87ee97472f6a"), false, false, true, 0 }
                });

            migrationBuilder.InsertData(
                table: "MultipleChoiceOptions",
                columns: new[] { "Id", "IsDeleted", "MultipleChouceQuestionId", "Option" },
                values: new object[,]
                {
                    { new Guid("1219cb07-226e-430d-9173-87ee97472f6a"), false, new Guid("2109cb07-226e-430d-9173-87ee97472f6a"), "Neither agree nor disagree" },
                    { new Guid("1229cb07-226e-430d-9173-87ee97472f6a"), false, new Guid("2109cb07-226e-430d-9173-87ee97472f6a"), "Satisfied" },
                    { new Guid("1239cb07-226e-430d-9173-87ee97472f6a"), false, new Guid("2109cb07-226e-430d-9173-87ee97472f6a"), "Dissatisfied" },
                    { new Guid("2222cb07-226e-430d-9173-87ee97472111"), false, new Guid("22000b07-226e-430d-9173-87ee97472f6a"), "Dog" },
                    { new Guid("2222cb07-226e-430d-9173-87ee97471210"), false, new Guid("22000b07-226e-430d-9173-87ee97472f6a"), "Elephant" },
                    { new Guid("2222cb07-226e-430d-9173-87ee97472122"), false, new Guid("22000b07-226e-430d-9173-87ee97472f6a"), "Cat" },
                    { new Guid("2220cb07-226e-430d-9173-87ee97472f6a"), false, new Guid("2209cb07-226e-430d-9173-87ee97472f6a"), "Weekly" },
                    { new Guid("2221cb07-226e-430d-9173-87ee97472f6a"), false, new Guid("2209cb07-226e-430d-9173-87ee97472f6a"), "Monthly" },
                    { new Guid("2222cb07-226e-430d-9173-87ee97472f6a"), false, new Guid("2209cb07-226e-430d-9173-87ee97472f6a"), "Quarterly" },
                    { new Guid("3322cb07-226e-430d-9173-87ee97472122"), false, new Guid("22600b07-226e-430d-9173-87ee97472f6a"), "Traversing" },
                    { new Guid("3422cb07-226e-430d-9173-87ee97472122"), false, new Guid("22600b07-226e-430d-9173-87ee97472f6a"), "Searching" },
                    { new Guid("3332cb07-226e-430d-9173-87ee97472122"), false, new Guid("22600b07-226e-430d-9173-87ee97472f6a"), "Deleting" }
                });

            migrationBuilder.InsertData(
                table: "TextAnswers",
                columns: new[] { "Id", "Answer", "CorelationToken", "IsDeleted", "TextQuestionId" },
                values: new object[,]
                {
                    { new Guid("1119cb07-226e-430d-9173-87ee97472f6a"), "I am 18 years old", new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("1109cb07-226e-430d-9173-87ee97472f6a") },
                    { new Guid("11111b07-226e-430d-9173-87ee97472f6a"), "Models of real world objects, have state and behaviour.", new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("1309cb07-226e-430d-9173-87ee97472f6a") },
                    { new Guid("1111cb07-226e-430d-9173-87ee97472f6a"), "I am from Bourgas", new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("1209cb07-226e-430d-9173-87ee97472f6a") },
                    { new Guid("11171b07-226e-430d-9173-87ee97472f6a"), "An algorithm is a set of predifined steps used to solve a problem.", new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("1409cb07-226e-430d-9173-87ee97472f6a") }
                });

            migrationBuilder.InsertData(
                table: "MultipleChoiceAnswers",
                columns: new[] { "Id", "CorelationToken", "IsDeleted", "MultipleChoiceOptionId" },
                values: new object[,]
                {
                    { new Guid("1231cb07-226e-430d-9173-87ee97472f6a"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("1219cb07-226e-430d-9173-87ee97472f6a") },
                    { new Guid("1234cb07-226e-430d-9173-87ee97472f6a"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("2222cb07-226e-430d-9173-87ee97472122") },
                    { new Guid("1233cb07-226e-430d-9173-87ee97472f6a"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("2222cb07-226e-430d-9173-87ee97472f6a") },
                    { new Guid("15734b07-226e-430d-9173-87e97472f6a1"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("3322cb07-226e-430d-9173-87ee97472122") },
                    { new Guid("15094b07-226e-430d-9173-87ee927472f6"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("3422cb07-226e-430d-9173-87ee97472122") },
                    { new Guid("19934cb7-226e-430d-9173-87ee974272fa"), new Guid("00000000-0000-0000-0000-000000000000"), false, new Guid("3332cb07-226e-430d-9173-87ee97472122") }
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
                name: "IX_MultipleChoiceAnswers_MultipleChoiceOptionId",
                table: "MultipleChoiceAnswers",
                column: "MultipleChoiceOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceOptions_MultipleChouceQuestionId",
                table: "MultipleChoiceOptions",
                column: "MultipleChouceQuestionId");

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
                name: "TextAnswers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DocumentQuestions");

            migrationBuilder.DropTable(
                name: "MultipleChoiceOptions");

            migrationBuilder.DropTable(
                name: "TextQuestions");

            migrationBuilder.DropTable(
                name: "MultipleChoiceQuestions");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
