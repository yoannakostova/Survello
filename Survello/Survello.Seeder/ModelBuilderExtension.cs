using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Survello.Models.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;

namespace Survello.Seeder
{
    public static class ModelBuilderExtension
    {
        public const string SEED_DATA_FORMS = @"C:\ALL CODE\4. GIT Folders\negometrix-project\Survello\Survello.Seeder\SeedFiles\forms.csv";
        public const string SEED_DATA_TEXT_Q = @"C:\ALL CODE\4. GIT Folders\negometrix-project\Survello\Survello.Seeder\SeedFiles\textQuestions.csv";
        public const string SEED_DATA_MULTIPLE_Q = @"C:\ALL CODE\4. GIT Folders\negometrix-project\Survello\Survello.Seeder\SeedFiles\multipleQuestions.csv";
        public const string SEED_DATA_DOCUMENT_Q = @"C:\ALL CODE\4. GIT Folders\negometrix-project\Survello\Survello.Seeder\SeedFiles\documentQuestion.csv";
        public const string SEED_DATA_OPTIONS = @"C:\ALL CODE\4. GIT Folders\negometrix-project\Survello\Survello.Seeder\SeedFiles\options.csv";


        public static void Seeder(this ModelBuilder builder)
        {
            var forms = ReadRawData(SEED_DATA_FORMS);
            var textQuestion = ReadRawData(SEED_DATA_TEXT_Q);
            var multipleQuestion = ReadRawData(SEED_DATA_MULTIPLE_Q);
            var documentQuestion = ReadRawData(SEED_DATA_DOCUMENT_Q);
            var options = ReadRawData(SEED_DATA_OPTIONS);

            NormalizeData(forms, textQuestion, multipleQuestion, documentQuestion, options);

            List<Form> formsList = new List<Form>();
            formsList = CreateObjectFromListForms(forms);

            List<TextQuestion> textQuestionList = new List<TextQuestion>();
            textQuestionList = CreateObjectFromListTextQuestion(textQuestion);

            List<MultipleChoiceQuestion> multipleQuestionList = new List<MultipleChoiceQuestion>();
            multipleQuestionList = CreateObjectFromListMultipleQuestion(multipleQuestion);

            List<DocumentQuestion> documentQuestionList = new List<DocumentQuestion>();
            documentQuestionList = CreateObjectFromListDocumentQuestion(documentQuestion);

            List<MultipleChoiceOption> optionsList = new List<MultipleChoiceOption>();
            optionsList = CreateObjectFromListMultipleChoiceOption(options);

            builder.Entity<Form>().HasData(formsList);
            builder.Entity<TextQuestion>().HasData(textQuestionList);
            builder.Entity<MultipleChoiceQuestion>().HasData(multipleQuestionList);
            builder.Entity<DocumentQuestion>().HasData(documentQuestionList);
            builder.Entity<MultipleChoiceOption>().HasData(optionsList);

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

        private static List<MultipleChoiceOption> CreateObjectFromListMultipleChoiceOption(List<Dictionary<string, string>> options)
        {
            List<MultipleChoiceOption> newList = new List<MultipleChoiceOption>();
            foreach (var item in options)
            {
                if (item.Count > 0)
                {
                    var newMultipleChoiceOption = new MultipleChoiceOption();
                    newMultipleChoiceOption.Id = Guid.Parse(item["Id"]);
                    newMultipleChoiceOption.Option = item["Option"];
                    newMultipleChoiceOption.MultipleChoiceQuestionId = Guid.Parse(item["MultipleChoiceQuestionId"]);

                    newList.Add(newMultipleChoiceOption);
                }
            }
            return newList;
        }

        private static List<DocumentQuestion> CreateObjectFromListDocumentQuestion(List<Dictionary<string, string>> documentQuestion)
        {
            List<DocumentQuestion> newList = new List<DocumentQuestion>();
            foreach (var item in documentQuestion)
            {
                if (item.Count > 0)
                {
                    var newDocumentQuestion = new DocumentQuestion();
                    newDocumentQuestion.Id = Guid.Parse(item["Id"]);
                    newDocumentQuestion.Description = item["Description"];
                    newDocumentQuestion.FileNumberLimit = int.Parse(item["FileNumberLimit"]);
                    newDocumentQuestion.FileSize = int.Parse(item["FileSize"]);
                    newDocumentQuestion.FormId = Guid.Parse(item["FormId"]);
                    newDocumentQuestion.IsRequired = bool.Parse(item["IsRequired"]);
                    newDocumentQuestion.IsDeleted = false;
                    newDocumentQuestion.QuestionNumber = int.Parse(item["QuestionNumber"]);
                    newList.Add(newDocumentQuestion);
                }
            }
            return newList;
        }

        private static List<MultipleChoiceQuestion> CreateObjectFromListMultipleQuestion(List<Dictionary<string, string>> multipleChoiceQuestion)
        {
            List<MultipleChoiceQuestion> newList = new List<MultipleChoiceQuestion>();
            foreach (var item in multipleChoiceQuestion)
            {
                if (item.Count > 0)
                {
                    var newMultipleChoiceQuestion = new MultipleChoiceQuestion();
                    newMultipleChoiceQuestion.Id = Guid.Parse(item["Id"]);
                    newMultipleChoiceQuestion.Description = item["Description"];
                    newMultipleChoiceQuestion.IsRequired = bool.Parse(item["IsRequired"]);
                    newMultipleChoiceQuestion.IsMultipleAnswer = bool.Parse(item["IsMultipleAnswer"]);
                    newMultipleChoiceQuestion.IsDeleted = false;
                    newMultipleChoiceQuestion.FormId = Guid.Parse(item["FormId"]);
                    newMultipleChoiceQuestion.QuestionNumber = int.Parse(item["QuestionNumber"]);
                    newList.Add(newMultipleChoiceQuestion);
                }
            }
            return newList;
        }

        private static List<TextQuestion> CreateObjectFromListTextQuestion(List<Dictionary<string, string>> textQuestion)
        {
            List<TextQuestion> newList = new List<TextQuestion>();
            foreach (var item in textQuestion)
            {
                if (item.Count > 0)
                {
                    var newTextQuestion = new TextQuestion();
                    newTextQuestion.Id = Guid.Parse(item["Id"]);
                    newTextQuestion.Description = item["Description"];
                    newTextQuestion.IsLongAnswer = bool.Parse(item["IsLongAnswer"]);
                    newTextQuestion.IsRequired = bool.Parse(item["IsRequired"]);
                    newTextQuestion.IsDeleted = false;
                    newTextQuestion.FormId = Guid.Parse(item["FormId"]);
                    newTextQuestion.QuestionNumber = int.Parse(item["QuestionNumber"]);

                    newList.Add(newTextQuestion);
                }
            }
            return newList;
        }

        private static List<Form> CreateObjectFromListForms(List<Dictionary<string, string>> forms)
        {
            List<Form> newList = new List<Form>();
            foreach (var item in forms)
            {
                if (item.Count > 0)
                {
                    var form = new Form();
                    form.Id = Guid.Parse(item["Id"]);
                    form.CreatedOn = DateTime.Now;
                    form.IsDeleted = false;
                    form.Title = item["Title"];
                    form.Description = item["Description"];
                    form.NumberOfFilledForms = int.Parse(item["NumberOfFilledForms"]);
                    form.UserId = Guid.Parse(item["UserId"]);
                    newList.Add(form);

                }
            }
            return newList;
        }

        private static void NormalizeData(List<Dictionary<string, string>> forms, List<Dictionary<string, string>> textQuestion, List<Dictionary<string, string>> multipleQuestion, List<Dictionary<string, string>> documentQuestion, List<Dictionary<string, string>> options)
        {
            List<List<Dictionary<string, string>>> allQ = new List<List<Dictionary<string, string>>>();
            allQ.Add(textQuestion);
            allQ.Add(multipleQuestion);
            allQ.Add(documentQuestion);

            foreach (var item in forms)
            {
                if (item.Count > 0)
                {
                    var currFormID = Guid.NewGuid();
                    var oldId = item["Id"];
                    item["Id"] = currFormID.ToString();

                    foreach (var listWithQuestions in allQ)
                    {
                        foreach (var dictionaryWithQuestions in listWithQuestions)
                        {
                            if (dictionaryWithQuestions.Count != 0)
                            {
                                if (dictionaryWithQuestions["FormId"] == oldId)
                                {
                                    dictionaryWithQuestions["FormId"] = currFormID.ToString();
                                }
                            }

                        }
                    }
                }
            }
            foreach (var item in textQuestion)
            {
                if (item.Count > 0)
                {
                    item["Id"] = Guid.NewGuid().ToString();
                }
            }
            foreach (var item in documentQuestion)
            {
                if (item.Count > 0)
                {
                    item["Id"] = Guid.NewGuid().ToString();
                }
            }
            foreach (var item in multipleQuestion)
            {

                if (item.Count > 0)
                {
                    var oldId = item["Id"];

                    var newID = Guid.NewGuid();

                    item["Id"] = newID.ToString();

                    foreach (var option in options)
                    {
                        if (option.Count > 0)
                        {
                            option["Id"] = Guid.NewGuid().ToString();
                            if (option["MultipleChoiceQuestionId"] == oldId)
                            {
                                option["MultipleChoiceQuestionId"] = newID.ToString();
                            }
                        }
                    }
                }
            }


        }

        public static List<Dictionary<string, string>> ReadRawData(string filePath)
        {

            var allForms = new List<Dictionary<string, string>>();

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                var counter = 0;
                List<string> titleRow = new List<string>();
                while (!parser.EndOfData)
                {
                    var currFormDict = new Dictionary<string, string>();
                    if (counter == 0)
                    {
                        titleRow = parser.ReadFields().ToList();
                        counter++;
                    }
                    else
                    {
                        string[] field = parser.ReadFields();
                        for (int i = 0; i < field.Length; i++)
                        {
                            currFormDict.Add(titleRow[i], field[i]);
                        }
                    }
                    allForms.Add(currFormDict);
                }
            }
            return allForms;
        }
    }
}
