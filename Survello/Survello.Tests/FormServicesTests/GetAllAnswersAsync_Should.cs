using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Survello.Database;
using Survello.Models.Entites;
using Survello.Services.CustomExceptions;
using Survello.Services.DTOEntities;
using Survello.Services.Provider.Contract;
using Survello.Services.Services;
using Survello.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Tests.FormServicesTests
{
    [TestClass]
   public class GetAllAnswersAsync_Should
    {
        [TestMethod]
        public async Task CorrectlyGetAllAnswers()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CorrectlyGetAllAnswers));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();
            var userId = Guid.NewGuid();
            var formId = Guid.NewGuid();
            var multipleChoicOptionId = Guid.NewGuid();

            var form = new Form
            {
                Id = formId,
                Title = "TestForm",
                Description = "TestDescrtiption",
                UserId = userId,
                TextQuestions = new List<TextQuestion>() {
                 new TextQuestion
                  {
                      Description = "Where are you from?",
                      IsLongAnswer = false,
                      IsRequired = true,
                      Answers = new List<TextAnswer>()
                      {
                          new TextAnswer()
                          {
                              Answer = "Bourgas",
                          }
                      }
                  }
                },
                MultipleChoiceQuestions = new List<MultipleChoiceQuestion>()
                {
                    new MultipleChoiceQuestion
                    {
                         Description = "How would you rate your experience with our product?",
                         IsRequired = true,
                         IsMultipleAnswer = false,
                         Options = new List<MultipleChoiceOption>()
                         {
                             new MultipleChoiceOption
                             {
                                  Option = "Satisfied",
                                  MultipleChoiceAnswers = new List<MultipleChoiceAnswer>()
                                  {
                                      new MultipleChoiceAnswer()
                                      {
                                          MultipleChoiceOptionId = multipleChoicOptionId
                                      }
                                  }
                             }
                         }
                    }
                },
                DocumentQuestions = new List<DocumentQuestion>()
                {
                    new DocumentQuestion
                    {
                         Description = "TestDescription",
                         FileNumberLimit = 10,
                         FileSize = 1,
                         Answers = new List<DocumentAnswer>()
                         {
                             new DocumentAnswer()
                             {
                                 FileName = "TestFilePath"
                             }
                         }
                    }
                }
            };

            var user = new User
            {
                Id = userId,
                UserName = "TestUser"
            };
            using (var arrangeContext = new SurvelloContext(options))
            {
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                await sut.GetAllAnswersAsync(formId);

                var result = assertContext.Forms.First();
                var resultTA = assertContext.TextAnswers.First();
                var resultMCA = assertContext.MultipleChoiceAnswers.First();
                var resultDA = assertContext.DocumentAnswers.First();
                var resultOptions = assertContext.MultipleChoiceOptions.First();

                Assert.AreEqual(form.Title, result.Title);
                Assert.AreEqual(form.Description, result.Description);

                foreach (var tq in form.TextQuestions)
                {
                    foreach (var ta in tq.Answers)
                    {
                        Assert.AreEqual(ta.Answer, resultTA.Answer);                                          
                    }
                }
                foreach (var mcq in form.MultipleChoiceQuestions)
                {
                    foreach (var op in mcq.Options)
                    {
                        foreach (var mcqa in op.MultipleChoiceAnswers)
                        {
                            Assert.AreEqual(mcqa.MultipleChoiceOptionId,resultMCA.MultipleChoiceOptionId);
                        }
                    }
                }
                foreach (var dq in form.DocumentQuestions)
                {
                    foreach (var da in dq.Answers)
                    {
                        Assert.AreEqual(da.FileName, resultDA.FileName);
                    }
                }
            }
        }
        [TestMethod]
        public async Task ThrowExcep_WhenNoFormFound()
        {
            var options = Utils.GetOptions(nameof(ThrowExcep_WhenNoFormFound));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();
            var id = Guid.NewGuid();

            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                await Assert.ThrowsExceptionAsync<BusinessLogicException>(() => sut.GetAllAnswersAsync(id));
            }
        }
    }
}
