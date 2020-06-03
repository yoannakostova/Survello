using Microsoft.AspNetCore.Identity;
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
    public class CreateFormAsync_Should
    {
        [TestMethod]
        public async Task CorrectlyCreatedForm()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CorrectlyCreatedForm));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();
            var userId = Guid.NewGuid();

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
                    }
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

            //Act & Assert
            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                await sut.CreateFormAsync(formDto);

                var result = assertContext.Forms.First();
                var resultTQ = assertContext.TextQuestions.First();
                var resultMCQ = assertContext.MultipleChoiceQuestions.First();
                var resultDQ = assertContext.DocumentQuestions.First();
                var resultOptions = assertContext.MultipleChoiceOptions.First();

                Assert.AreEqual(formDto.Title, result.Title);
                Assert.AreEqual(formDto.Description, result.Description);

                foreach (var tq in formDto.TextQuestions)
                {
                    Assert.AreEqual(tq.Description, resultTQ.Description);
                    Assert.AreEqual(tq.IsLongAnswer, resultTQ.IsLongAnswer);
                    Assert.AreEqual(tq.IsRequired, resultTQ.IsRequired);
                }
                foreach (var mcq in formDto.MultipleChoiceQuestions)
                {
                    Assert.AreEqual(mcq.Description, resultMCQ.Description);
                    Assert.AreEqual(mcq.IsMultipleAnswer, resultMCQ.IsMultipleAnswer);
                    Assert.AreEqual(mcq.IsRequired, resultMCQ.IsRequired);

                    foreach (var op in mcq.Options)
                    {
                        Assert.AreEqual(op.Option, resultOptions.Option);
                    }
                }
                foreach (var dq in formDto.DocumentQuestions)
                {
                    Assert.AreEqual(dq.Description, resultDQ.Description);
                    Assert.AreEqual(dq.FileNumberLimit, resultDQ.FileNumberLimit);
                    Assert.AreEqual(dq.FileSize, resultDQ.FileSize);
                }
            }
        }
        [TestMethod]
        public async Task ThrowException_WhenDtoIsNull()
        {
            var options = Utils.GetOptions(nameof(ThrowException_WhenDtoIsNull));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();
            var id = Guid.NewGuid();

            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                await Assert.ThrowsExceptionAsync<BusinessLogicException>(() => sut.CreateFormAsync(null));
            }
        }
        [TestMethod]
        public async Task ThrowException_WhenTitleIsNull()
        {
            var options = Utils.GetOptions(nameof(ThrowException_WhenTitleIsNull));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();
            var formDto = new FormDTO
            {
                Title = null
            };

            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                await Assert.ThrowsExceptionAsync<BusinessLogicException>(() => sut.CreateFormAsync(formDto));
            }
        }
    }
}
