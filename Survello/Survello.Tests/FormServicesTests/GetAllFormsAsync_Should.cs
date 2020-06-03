using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Survello.Database;
using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
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
    public class GetAllFormsAsync_Should
    {
        [TestMethod]
        public async Task ReturnCorrectForms_WhenParamsAreValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnCorrectForms_WhenParamsAreValid));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();

            var testId = Guid.NewGuid();
            var testId2 = Guid.NewGuid();

            var form1 = new Form
            {
                Id = testId,
                Title = "TestForm1"
            };
            var form2 = new Form
            {
                Id = testId2,
                Title = "TestForm2"
            };

            using (var arrangeContext = new SurvelloContext(options))
            {
                await arrangeContext.Forms.AddAsync(form1);
                await arrangeContext.Forms.AddAsync(form2);

                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                var result = await sut.GetAllFormsAsync();

                Assert.AreEqual(form1.Id, result.First().Id);
                Assert.AreEqual(form1.Title, result.First().Title);
                Assert.AreEqual(form2.Id, result.Last().Id);
                Assert.AreEqual(form2.Title, result.Last().Title);
            }
        }
        [TestMethod]
        public async Task ThrowException_WhenNoFormsFound()
        {
            var options = Utils.GetOptions(nameof(ThrowException_WhenNoFormsFound));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();

            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                await Assert.ThrowsExceptionAsync<BusinessLogicException>(() => sut.GetAllFormsAsync());
            }
        }
    }
}

