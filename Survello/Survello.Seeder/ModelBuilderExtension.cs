using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Survello.Models.Entites;
using System;

namespace Survello.Seeder
{
    public static class ModelBuilderExtension
    {
        public static void Seeder(this ModelBuilder builder)
        {
            //Forms
            builder.Entity<Form>().HasData(
                new Form
                {
                    Id = Guid.Parse("1009cb07-226e-430d-9173-87ee97472f6a"),
                    Title = "Test form 1",
                    Description = "Test description 1.",
                    UserId = Guid.Parse("52D02F62-14AC-4152-872C-08D7EB74F484")
                },
                new Form
                {
                    Id = Guid.Parse("2009cb07-226e-430d-9173-87ee97472f6a"),
                    Title = "Test form 2",
                    Description = "Test description 2.",
                    UserId = Guid.Parse("22A2D89D-EE6E-4C94-E490-08D7EB6BAE70"),
                },
                new Form
                {
                    Id = Guid.Parse("3009cb07-226e-430d-9173-87ee97472f6a"),
                    Title = "Test form 3",
                    Description = "Test description 3.",
                    UserId = Guid.Parse("52D02F62-14AC-4152-872C-08D7EB74F484"),
                },
                new Form
                {
                    Id = Guid.Parse("4009cb07-226e-430d-9173-87ee97472f6a"),
                    Title = "Test form 4",
                    Description = "Test description 4",
                    UserId = Guid.Parse("22A2D89D-EE6E-4C94-E490-08D7EB6BAE70"),
                });

            //TextQuestions
            builder.Entity<TextQuestion>().HasData(
                new TextQuestion
                {
                    Id = Guid.Parse("1109cb07-226e-430d-9173-87ee97472f6a"),
                    Description = "How old are you?",
                    IsLongAnswer = false,
                    IsRequired = true,
                    FormId = Guid.Parse("1009cb07-226e-430d-9173-87ee97472f6a"),
                },
                  new TextQuestion
                  {
                      Id = Guid.Parse("1209cb07-226e-430d-9173-87ee97472f6a"),
                      Description = "Where are you from?",
                      IsLongAnswer = false,
                      IsRequired = true,
                      FormId = Guid.Parse("2009cb07-226e-430d-9173-87ee97472f6a"),
                  },
                  new TextQuestion
                  {
                      Id = Guid.Parse("1309cb07-226e-430d-9173-87ee97472f6a"),
                      Description = "What is class?",
                      IsLongAnswer = false,
                      IsRequired = true,
                      FormId = Guid.Parse("3009cb07-226e-430d-9173-87ee97472f6a"),
                  },
                  new TextQuestion
                  {
                      Id = Guid.Parse("1409cb07-226e-430d-9173-87ee97472f6a"),
                      Description = "What is algorithm?",
                      IsLongAnswer = false,
                      IsRequired = true,
                      FormId = Guid.Parse("4009cb07-226e-430d-9173-87ee97472f6a"),
                  });

            //TextAnswers
            builder.Entity<TextAnswer>().HasData(
                new TextAnswer
                {
                    Id = Guid.Parse("1119cb07-226e-430d-9173-87ee97472f6a"),
                    Answer = "I am 18 years old",
                    TextQuestionId = Guid.Parse("1109cb07-226e-430d-9173-87ee97472f6a"),
                },
                new TextAnswer
                {
                    Id = Guid.Parse("1111cb07-226e-430d-9173-87ee97472f6a"),
                    Answer = "I am from Bourgas",
                    TextQuestionId = Guid.Parse("1209cb07-226e-430d-9173-87ee97472f6a"),
                },
                new TextAnswer
                {
                    Id = Guid.Parse("11111b07-226e-430d-9173-87ee97472f6a"),
                    Answer = "Models of real world objects, have state and behaviour.",
                    TextQuestionId = Guid.Parse("1309cb07-226e-430d-9173-87ee97472f6a"),
                },
                 new TextAnswer
                 {
                     Id = Guid.Parse("11171b07-226e-430d-9173-87ee97472f6a"),
                     Answer = "An algorithm is a set of predifined steps used to solve a problem.",
                     TextQuestionId = Guid.Parse("1409cb07-226e-430d-9173-87ee97472f6a"),
                 });

            //MultipleChoiceQuestions
            builder.Entity<MultipleChoiceQuestion>().HasData(
                new MultipleChoiceQuestion
                {
                    Id = Guid.Parse("2109cb07-226e-430d-9173-87ee97472f6a"),
                    Description = "How would you rate your experience with our product?",
                    IsRequired = true,
                    FormId = Guid.Parse("1009cb07-226e-430d-9173-87ee97472f6a"),
                },
                new MultipleChoiceQuestion
                {
                    Id = Guid.Parse("2209cb07-226e-430d-9173-87ee97472f6a"),
                    Description = "How often do you conduct surveys?",
                    IsRequired = true,
                    FormId = Guid.Parse("2009cb07-226e-430d-9173-87ee97472f6a"),
                },
                new MultipleChoiceQuestion
                {
                    Id = Guid.Parse("22000b07-226e-430d-9173-87ee97472f6a"),
                    Description = "What kind of animal is feline?",
                    IsRequired = true,
                    FormId = Guid.Parse("3009cb07-226e-430d-9173-87ee97472f6a"),
                },
                new MultipleChoiceQuestion
                {
                    Id = Guid.Parse("22600b07-226e-430d-9173-87ee97472f6a"),
                    Description = "Which operations can be performed on a data structure?",
                    IsRequired = true,
                    FormId = Guid.Parse("4009cb07-226e-430d-9173-87ee97472f6a"),
                });

            //MultipleChoiceOptions
            builder.Entity<MultipleChoiceOption>().HasData(
                new MultipleChoiceOption
                {
                    Id = Guid.Parse("1219cb07-226e-430d-9173-87ee97472f6a"),
                    Option = "Neither agree nor disagree",
                    MultipleChoiceQuestionId = Guid.Parse("2109cb07-226e-430d-9173-87ee97472f6a"),
                },
                 new MultipleChoiceOption
                 {
                     Id = Guid.Parse("1229cb07-226e-430d-9173-87ee97472f6a"),
                     Option = "Satisfied",
                     MultipleChoiceQuestionId = Guid.Parse("2109cb07-226e-430d-9173-87ee97472f6a"),
                 },
                 new MultipleChoiceOption
                 {
                     Id = Guid.Parse("1239cb07-226e-430d-9173-87ee97472f6a"),
                     Option = "Dissatisfied",
                     MultipleChoiceQuestionId = Guid.Parse("2109cb07-226e-430d-9173-87ee97472f6a"),
                 },
                 new MultipleChoiceOption
                 {
                     Id = Guid.Parse("2220cb07-226e-430d-9173-87ee97472f6a"),
                     Option = "Weekly",
                     MultipleChoiceQuestionId = Guid.Parse("2209cb07-226e-430d-9173-87ee97472f6a"),
                 },
                 new MultipleChoiceOption
                 {
                     Id = Guid.Parse("2221cb07-226e-430d-9173-87ee97472f6a"),
                     Option = "Monthly",
                     MultipleChoiceQuestionId = Guid.Parse("2209cb07-226e-430d-9173-87ee97472f6a"),
                 },
                  new MultipleChoiceOption
                  {
                      Id = Guid.Parse("2222cb07-226e-430d-9173-87ee97472f6a"),
                      Option = "Quarterly",
                      MultipleChoiceQuestionId = Guid.Parse("2209cb07-226e-430d-9173-87ee97472f6a"),
                  },
                  new MultipleChoiceOption
                  {
                      Id = Guid.Parse("2222cb07-226e-430d-9173-87ee97472111"),
                      Option = "Dog",
                      MultipleChoiceQuestionId = Guid.Parse("22000b07-226e-430d-9173-87ee97472f6a"),
                  },
                  new MultipleChoiceOption
                  {
                      Id = Guid.Parse("2222cb07-226e-430d-9173-87ee97471210"),
                      Option = "Elephant",
                      MultipleChoiceQuestionId = Guid.Parse("22000b07-226e-430d-9173-87ee97472f6a"),
                  },
                  new MultipleChoiceOption
                  {
                      Id = Guid.Parse("2222cb07-226e-430d-9173-87ee97472122"),
                      Option = "Cat",
                      MultipleChoiceQuestionId = Guid.Parse("22000b07-226e-430d-9173-87ee97472f6a"),
                  },
                  new MultipleChoiceOption
                  {
                      Id = Guid.Parse("3322cb07-226e-430d-9173-87ee97472122"),
                      Option = "Traversing",
                      MultipleChoiceQuestionId = Guid.Parse("22600b07-226e-430d-9173-87ee97472f6a"),
                  },
                  new MultipleChoiceOption
                  {
                      Id = Guid.Parse("3422cb07-226e-430d-9173-87ee97472122"),
                      Option = "Searching",
                      MultipleChoiceQuestionId = Guid.Parse("22600b07-226e-430d-9173-87ee97472f6a"),
                  },
                  new MultipleChoiceOption
                  {
                      Id = Guid.Parse("3332cb07-226e-430d-9173-87ee97472122"),
                      Option = "Deleting",
                      MultipleChoiceQuestionId = Guid.Parse("22600b07-226e-430d-9173-87ee97472f6a"),
                  });

            //MultipleChoiceAnswers
            builder.Entity<MultipleChoiceAnswer>().HasData(
                new MultipleChoiceAnswer
                {
                    Id = Guid.Parse("1231cb07-226e-430d-9173-87ee97472f6a"),
                    MultipleChoiceOptionId = Guid.Parse("1219cb07-226e-430d-9173-87ee97472f6a"),

                },
                new MultipleChoiceAnswer
                {
                    Id = Guid.Parse("1233cb07-226e-430d-9173-87ee97472f6a"),
                    MultipleChoiceOptionId = Guid.Parse("2222cb07-226e-430d-9173-87ee97472f6a"),


                },
                new MultipleChoiceAnswer
                {
                    Id = Guid.Parse("1234cb07-226e-430d-9173-87ee97472f6a"),
                    MultipleChoiceOptionId = Guid.Parse("2222cb07-226e-430d-9173-87ee97472122"),

                },
                new MultipleChoiceAnswer
                {
                    Id = Guid.Parse("15734b07-226e-430d-9173-87e97472f6a1"),
                    MultipleChoiceOptionId = Guid.Parse("3322cb07-226e-430d-9173-87ee97472122"),

                },
                new MultipleChoiceAnswer
                {
                    Id = Guid.Parse("15094b07-226e-430d-9173-87ee927472f6"),
                    MultipleChoiceOptionId = Guid.Parse("3422cb07-226e-430d-9173-87ee97472122"),

                },
                new MultipleChoiceAnswer
                {
                    Id = Guid.Parse("19934cb7-226e-430d-9173-87ee974272fa"),
                    MultipleChoiceOptionId = Guid.Parse("3332cb07-226e-430d-9173-87ee97472122"),

                });

            //Role
            builder.Entity<Role>().HasData(
                new Role
                {
                    Id = Guid.Parse("0989cb07-226e-430d-9173-87ee97472f6a"),
                    Name = "Member",
                    NormalizedName = "MEMBER"
                });

            //Users
            var hasher = new PasswordHasher<User>();

            User user1 = new User
            {
                Id = Guid.Parse("52D02F62-14AC-4152-872C-08D7EB74F484"),
                UserName = "nasko",
                Email = "nasko@survello.com",
                CreatedOn = DateTime.UtcNow,
                SecurityStamp = "321E275DD1E24957A7781D42BB68293B"
            };
            user1.NormalizedUserName = user1.UserName.ToUpper();
            user1.NormalizedEmail = user1.UserName.ToUpper();
            user1.PasswordHash = hasher.HashPassword(user1, "nasko1");

            User user2 = new User
            {
                Id = Guid.Parse("22A2D89D-EE6E-4C94-E490-08D7EB6BAE70"),
                UserName = "yoanna",
                Email = "yoanna@survello.com",
                CreatedOn = DateTime.UtcNow,
                SecurityStamp = "431E275DD1E24957A7781D42BB68293B"
            };
            user2.NormalizedUserName = user2.UserName.ToUpper();
            user2.NormalizedEmail = user2.UserName.ToUpper();
            user2.PasswordHash = hasher.HashPassword(user2, "yoanna1");

            builder.Entity<User>().HasData(user1, user2);

            builder.Entity<IdentityUserRole<Guid>>().HasData(
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("0989cb07-226e-430d-9173-87ee97472f6a"),
                UserId = user1.Id
            },
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("0989cb07-226e-430d-9173-87ee97472f6a"),
                UserId = user2.Id
            });
        }
    }
}
