using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Survello.Database;
using Survello.Models.Entites;
using Survello.Services.DTOEntities;
using System;
using System.Collections.Generic;

namespace Survello.Tests
{
    [TestClass]
    public class Utils
    {
        public static readonly Guid userId = Guid.NewGuid();

        public static DbContextOptions<SurvelloContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<SurvelloContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

        }

        public static void Seeder(SurvelloContext context)
        {
            var formDto = new FormDTO
            {
                Title = "TestForm",
                Description = "TestDescrtiption",
                UserId = userId,
                TextQuestions = new List<TextQuestionDTO>() {
                 new TextQuestionDTO
                  {

                      Description = "Where are you from?",
                      IsLongAnswer = false,
                      IsRequired = true,
                  }
                },
                MultipleChoiceQuestions = new List<MultipleChoiceQuestionDTO>()
                {
                    new MultipleChoiceQuestionDTO
                    {
                         Description = "How would you rate your experience with our product?",
                         IsRequired = true,
                         IsMultipleAnswer = false,
                         Options = new List<MultipleChoiceOptionDTO>()
                         {
                             new MultipleChoiceOptionDTO
                             {
                                  Option = "Satisfied",
                             }
                         }
                    },
                },
                DocumentQuestions = new List<DocumentQuestionDTO>()
                {
                    new DocumentQuestionDTO
                    {
                         Description = "TestDescription",
                         FileNumberLimit = 10,
                         FileSize = 1,
                    }
                }
            };

            var user = new User
            {
                Id = userId,
                UserName = "TestUser"
            };
        }
    }
}
