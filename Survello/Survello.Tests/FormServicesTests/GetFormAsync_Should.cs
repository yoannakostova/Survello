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
using System.Text;
using System.Threading.Tasks;

namespace Survello.Tests.FormServicesTests
{
    [TestClass]
    public class GetFormAsync_Should
    {
        [TestMethod]
        public async Task ReturnCorrectDtoWhen_ParamsAreValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnCorrectDtoWhen_ParamsAreValid));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();

            var testId = Guid.NewGuid();

            var form = new Form
            {
                Id = testId,
                Title = "TestForm1",
                Description = "TestDescription"
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
                var result = await sut.GetFormAsync(testId);

                Assert.AreEqual(form.Id, result.Id);
                Assert.AreEqual(form.Title, result.Title);
                Assert.AreEqual(form.Description, result.Description);
            }
        }
        [TestMethod]
        public async Task ThrowWhen_FormNotFound()
        {
            var options = Utils.GetOptions(nameof(ThrowWhen_FormNotFound));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();

            var testId = Guid.NewGuid();
            var testId2 = Guid.NewGuid();

            var form = new Form
            {
                Id = testId,
                Title = "TestForm1",
                Description = "TestDescription"
            };

            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                await Assert.ThrowsExceptionAsync<BusinessLogicException>(() => sut.GetFormAsync(testId2));
            }
        }
    }
}
