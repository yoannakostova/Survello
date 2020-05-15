﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Survello.Database;

namespace Survello.Database.Migrations
{
    [DbContext(typeof(SurvelloContext))]
    partial class SurvelloContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("52d02f62-14ac-4152-872c-08d7eb74f484"),
                            RoleId = new Guid("0989cb07-226e-430d-9173-87ee97472f6a")
                        },
                        new
                        {
                            UserId = new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70"),
                            RoleId = new Guid("0989cb07-226e-430d-9173-87ee97472f6a")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Survello.Models.Entites.DocumentAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CorelationToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DocumentQuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DocumentQuestionId");

                    b.ToTable("DocumentAnswers");
                });

            modelBuilder.Entity("Survello.Models.Entites.DocumentQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileSize")
                        .HasColumnType("int");

                    b.Property<Guid>("FormId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("DocumentQuestions");
                });

            modelBuilder.Entity("Survello.Models.Entites.Form", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfExpiration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfFilledForms")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Forms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1009cb07-226e-430d-9173-87ee97472f6a"),
                            CreatedOn = new DateTime(2020, 5, 15, 13, 25, 10, 119, DateTimeKind.Utc).AddTicks(8303),
                            Description = "Test description 1.",
                            IsDeleted = false,
                            NumberOfFilledForms = 0,
                            Title = "Test form 1",
                            UserId = new Guid("52d02f62-14ac-4152-872c-08d7eb74f484")
                        },
                        new
                        {
                            Id = new Guid("2009cb07-226e-430d-9173-87ee97472f6a"),
                            CreatedOn = new DateTime(2020, 5, 15, 13, 25, 10, 120, DateTimeKind.Utc).AddTicks(9921),
                            Description = "Test description 2.",
                            IsDeleted = false,
                            NumberOfFilledForms = 0,
                            Title = "Test form 2",
                            UserId = new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70")
                        },
                        new
                        {
                            Id = new Guid("3009cb07-226e-430d-9173-87ee97472f6a"),
                            CreatedOn = new DateTime(2020, 5, 15, 13, 25, 10, 121, DateTimeKind.Utc).AddTicks(242),
                            Description = "Test description 3.",
                            IsDeleted = false,
                            NumberOfFilledForms = 0,
                            Title = "Test form 3",
                            UserId = new Guid("52d02f62-14ac-4152-872c-08d7eb74f484")
                        },
                        new
                        {
                            Id = new Guid("4009cb07-226e-430d-9173-87ee97472f6a"),
                            CreatedOn = new DateTime(2020, 5, 15, 13, 25, 10, 121, DateTimeKind.Utc).AddTicks(265),
                            Description = "Test description 4",
                            IsDeleted = false,
                            NumberOfFilledForms = 0,
                            Title = "Test form 4",
                            UserId = new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70")
                        });
                });

            modelBuilder.Entity("Survello.Models.Entites.MultipleChoiceAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CorelationToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("MultipleChoiceOptionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MultipleChoiceOptionId");

                    b.ToTable("MultipleChoiceAnswers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1231cb07-226e-430d-9173-87ee97472f6a"),
                            CorelationToken = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = false,
                            MultipleChoiceOptionId = new Guid("1219cb07-226e-430d-9173-87ee97472f6a")
                        },
                        new
                        {
                            Id = new Guid("1233cb07-226e-430d-9173-87ee97472f6a"),
                            CorelationToken = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = false,
                            MultipleChoiceOptionId = new Guid("2222cb07-226e-430d-9173-87ee97472f6a")
                        },
                        new
                        {
                            Id = new Guid("1234cb07-226e-430d-9173-87ee97472f6a"),
                            CorelationToken = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = false,
                            MultipleChoiceOptionId = new Guid("2222cb07-226e-430d-9173-87ee97472122")
                        },
                        new
                        {
                            Id = new Guid("15734b07-226e-430d-9173-87e97472f6a1"),
                            CorelationToken = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = false,
                            MultipleChoiceOptionId = new Guid("3322cb07-226e-430d-9173-87ee97472122")
                        },
                        new
                        {
                            Id = new Guid("15094b07-226e-430d-9173-87ee927472f6"),
                            CorelationToken = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = false,
                            MultipleChoiceOptionId = new Guid("3422cb07-226e-430d-9173-87ee97472122")
                        },
                        new
                        {
                            Id = new Guid("19934cb7-226e-430d-9173-87ee974272fa"),
                            CorelationToken = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = false,
                            MultipleChoiceOptionId = new Guid("3332cb07-226e-430d-9173-87ee97472122")
                        });
                });

            modelBuilder.Entity("Survello.Models.Entites.MultipleChoiceOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("MultipleChouceQuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Option")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MultipleChouceQuestionId");

                    b.ToTable("MultipleChoiceOptions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1219cb07-226e-430d-9173-87ee97472f6a"),
                            IsDeleted = false,
                            MultipleChouceQuestionId = new Guid("2109cb07-226e-430d-9173-87ee97472f6a"),
                            Option = "Neither agree nor disagree"
                        },
                        new
                        {
                            Id = new Guid("1229cb07-226e-430d-9173-87ee97472f6a"),
                            IsDeleted = false,
                            MultipleChouceQuestionId = new Guid("2109cb07-226e-430d-9173-87ee97472f6a"),
                            Option = "Satisfied"
                        },
                        new
                        {
                            Id = new Guid("1239cb07-226e-430d-9173-87ee97472f6a"),
                            IsDeleted = false,
                            MultipleChouceQuestionId = new Guid("2109cb07-226e-430d-9173-87ee97472f6a"),
                            Option = "Dissatisfied"
                        },
                        new
                        {
                            Id = new Guid("2220cb07-226e-430d-9173-87ee97472f6a"),
                            IsDeleted = false,
                            MultipleChouceQuestionId = new Guid("2209cb07-226e-430d-9173-87ee97472f6a"),
                            Option = "Weekly"
                        },
                        new
                        {
                            Id = new Guid("2221cb07-226e-430d-9173-87ee97472f6a"),
                            IsDeleted = false,
                            MultipleChouceQuestionId = new Guid("2209cb07-226e-430d-9173-87ee97472f6a"),
                            Option = "Monthly"
                        },
                        new
                        {
                            Id = new Guid("2222cb07-226e-430d-9173-87ee97472f6a"),
                            IsDeleted = false,
                            MultipleChouceQuestionId = new Guid("2209cb07-226e-430d-9173-87ee97472f6a"),
                            Option = "Quarterly"
                        },
                        new
                        {
                            Id = new Guid("2222cb07-226e-430d-9173-87ee97472111"),
                            IsDeleted = false,
                            MultipleChouceQuestionId = new Guid("22000b07-226e-430d-9173-87ee97472f6a"),
                            Option = "Dog"
                        },
                        new
                        {
                            Id = new Guid("2222cb07-226e-430d-9173-87ee97471210"),
                            IsDeleted = false,
                            MultipleChouceQuestionId = new Guid("22000b07-226e-430d-9173-87ee97472f6a"),
                            Option = "Elephant"
                        },
                        new
                        {
                            Id = new Guid("2222cb07-226e-430d-9173-87ee97472122"),
                            IsDeleted = false,
                            MultipleChouceQuestionId = new Guid("22000b07-226e-430d-9173-87ee97472f6a"),
                            Option = "Cat"
                        },
                        new
                        {
                            Id = new Guid("3322cb07-226e-430d-9173-87ee97472122"),
                            IsDeleted = false,
                            MultipleChouceQuestionId = new Guid("22600b07-226e-430d-9173-87ee97472f6a"),
                            Option = "Traversing"
                        },
                        new
                        {
                            Id = new Guid("3422cb07-226e-430d-9173-87ee97472122"),
                            IsDeleted = false,
                            MultipleChouceQuestionId = new Guid("22600b07-226e-430d-9173-87ee97472f6a"),
                            Option = "Searching"
                        },
                        new
                        {
                            Id = new Guid("3332cb07-226e-430d-9173-87ee97472122"),
                            IsDeleted = false,
                            MultipleChouceQuestionId = new Guid("22600b07-226e-430d-9173-87ee97472f6a"),
                            Option = "Deleting"
                        });
                });

            modelBuilder.Entity("Survello.Models.Entites.MultipleChoiceQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FormId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("MultipleChoiceQuestions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2109cb07-226e-430d-9173-87ee97472f6a"),
                            Description = "How would you rate your experience with our product?",
                            FormId = new Guid("1009cb07-226e-430d-9173-87ee97472f6a"),
                            IsDeleted = false,
                            IsRequired = true
                        },
                        new
                        {
                            Id = new Guid("2209cb07-226e-430d-9173-87ee97472f6a"),
                            Description = "How often do you conduct surveys?",
                            FormId = new Guid("2009cb07-226e-430d-9173-87ee97472f6a"),
                            IsDeleted = false,
                            IsRequired = true
                        },
                        new
                        {
                            Id = new Guid("22000b07-226e-430d-9173-87ee97472f6a"),
                            Description = "What kind of animal is feline?",
                            FormId = new Guid("3009cb07-226e-430d-9173-87ee97472f6a"),
                            IsDeleted = false,
                            IsRequired = true
                        },
                        new
                        {
                            Id = new Guid("22600b07-226e-430d-9173-87ee97472f6a"),
                            Description = "Which operations can be performed on a data structure?",
                            FormId = new Guid("4009cb07-226e-430d-9173-87ee97472f6a"),
                            IsDeleted = false,
                            IsRequired = true
                        });
                });

            modelBuilder.Entity("Survello.Models.Entites.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0989cb07-226e-430d-9173-87ee97472f6a"),
                            ConcurrencyStamp = "dcd559b4-d87a-4fa6-bc0c-b763f219fe0a",
                            Name = "Member",
                            NormalizedName = "MEMBER"
                        });
                });

            modelBuilder.Entity("Survello.Models.Entites.TextAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CorelationToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("TextQuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TextQuestionId");

                    b.ToTable("TextAnswers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1119cb07-226e-430d-9173-87ee97472f6a"),
                            Answer = "I am 18 years old",
                            CorelationToken = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = false,
                            TextQuestionId = new Guid("1109cb07-226e-430d-9173-87ee97472f6a")
                        },
                        new
                        {
                            Id = new Guid("1111cb07-226e-430d-9173-87ee97472f6a"),
                            Answer = "I am from Bourgas",
                            CorelationToken = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = false,
                            TextQuestionId = new Guid("1209cb07-226e-430d-9173-87ee97472f6a")
                        },
                        new
                        {
                            Id = new Guid("11111b07-226e-430d-9173-87ee97472f6a"),
                            Answer = "Models of real world objects, have state and behaviour.",
                            CorelationToken = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = false,
                            TextQuestionId = new Guid("1309cb07-226e-430d-9173-87ee97472f6a")
                        },
                        new
                        {
                            Id = new Guid("11171b07-226e-430d-9173-87ee97472f6a"),
                            Answer = "An algorithm is a set of predifined steps used to solve a problem.",
                            CorelationToken = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = false,
                            TextQuestionId = new Guid("1409cb07-226e-430d-9173-87ee97472f6a")
                        });
                });

            modelBuilder.Entity("Survello.Models.Entites.TextQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FormId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLongAnswer")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("TextQuestions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1109cb07-226e-430d-9173-87ee97472f6a"),
                            Description = "How old are you?",
                            FormId = new Guid("1009cb07-226e-430d-9173-87ee97472f6a"),
                            IsDeleted = false,
                            IsLongAnswer = false,
                            IsRequired = true
                        },
                        new
                        {
                            Id = new Guid("1209cb07-226e-430d-9173-87ee97472f6a"),
                            Description = "Where are you from?",
                            FormId = new Guid("2009cb07-226e-430d-9173-87ee97472f6a"),
                            IsDeleted = false,
                            IsLongAnswer = false,
                            IsRequired = true
                        },
                        new
                        {
                            Id = new Guid("1309cb07-226e-430d-9173-87ee97472f6a"),
                            Description = "What is class?",
                            FormId = new Guid("3009cb07-226e-430d-9173-87ee97472f6a"),
                            IsDeleted = false,
                            IsLongAnswer = false,
                            IsRequired = true
                        },
                        new
                        {
                            Id = new Guid("1409cb07-226e-430d-9173-87ee97472f6a"),
                            Description = "What is algorithm?",
                            FormId = new Guid("4009cb07-226e-430d-9173-87ee97472f6a"),
                            IsDeleted = false,
                            IsLongAnswer = false,
                            IsRequired = true
                        });
                });

            modelBuilder.Entity("Survello.Models.Entites.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("52d02f62-14ac-4152-872c-08d7eb74f484"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "efce1025-be83-4d17-ba08-d6523bf32340",
                            CreatedOn = new DateTime(2020, 5, 15, 13, 25, 10, 133, DateTimeKind.Utc).AddTicks(3239),
                            Email = "nasko@survello.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "NASKO",
                            NormalizedUserName = "NASKO",
                            PasswordHash = "AQAAAAEAACcQAAAAEM2DJcYg5T0eP99mZ0rLJUvadfCL6FU6eBIE0WQTdtYFtg3hMTjZVo19aPg5gvkT3Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "321E275DD1E24957A7781D42BB68293B",
                            TwoFactorEnabled = false,
                            UserName = "nasko"
                        },
                        new
                        {
                            Id = new Guid("22a2d89d-ee6e-4c94-e490-08d7eb6bae70"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "802da9fc-ad65-44a7-a29f-d641de06664f",
                            CreatedOn = new DateTime(2020, 5, 15, 13, 25, 10, 264, DateTimeKind.Utc).AddTicks(9186),
                            Email = "yoanna@survello.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "YOANNA",
                            NormalizedUserName = "YOANNA",
                            PasswordHash = "AQAAAAEAACcQAAAAEIuUMvRzBHTCNQfZ+VgliVUOlqYOCdenFIdMpRUPtG+UiWBPBKXEqargYK4LJJlZzA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "431E275DD1E24957A7781D42BB68293B",
                            TwoFactorEnabled = false,
                            UserName = "yoanna"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Survello.Models.Entites.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Survello.Models.Entites.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Survello.Models.Entites.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Survello.Models.Entites.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Survello.Models.Entites.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Survello.Models.Entites.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survello.Models.Entites.DocumentAnswer", b =>
                {
                    b.HasOne("Survello.Models.Entites.DocumentQuestion", "DocumentQuestion")
                        .WithMany("Answers")
                        .HasForeignKey("DocumentQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survello.Models.Entites.DocumentQuestion", b =>
                {
                    b.HasOne("Survello.Models.Entites.Form", "Form")
                        .WithMany("DocumentQuestions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survello.Models.Entites.Form", b =>
                {
                    b.HasOne("Survello.Models.Entites.User", "User")
                        .WithMany("Forms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survello.Models.Entites.MultipleChoiceAnswer", b =>
                {
                    b.HasOne("Survello.Models.Entites.MultipleChoiceOption", "MultipleChoiceOption")
                        .WithMany("MultipleChoiceAnswers")
                        .HasForeignKey("MultipleChoiceOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survello.Models.Entites.MultipleChoiceOption", b =>
                {
                    b.HasOne("Survello.Models.Entites.MultipleChoiceQuestion", "MultipleChoiceQuestion")
                        .WithMany("Options")
                        .HasForeignKey("MultipleChouceQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survello.Models.Entites.MultipleChoiceQuestion", b =>
                {
                    b.HasOne("Survello.Models.Entites.Form", "Form")
                        .WithMany("MultipleChoiceQuestions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survello.Models.Entites.TextAnswer", b =>
                {
                    b.HasOne("Survello.Models.Entites.TextQuestion", "TextQuestion")
                        .WithMany("Answers")
                        .HasForeignKey("TextQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survello.Models.Entites.TextQuestion", b =>
                {
                    b.HasOne("Survello.Models.Entites.Form", "Form")
                        .WithMany("TextQuestions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
