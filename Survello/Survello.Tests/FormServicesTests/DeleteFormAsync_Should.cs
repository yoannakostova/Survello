using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Survello.Database;
using Survello.Models.Entites;
using Survello.Services.CustomExceptions;
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
    public class DeleteFormAsync_Should
    {
        [TestMethod]
        public async Task ReturnTrue_WhenFormIsDeleted()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnTrue_WhenFormIsDeleted));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();

            var form = new Form
            {
                Id = Guid.NewGuid(),
                Title = "TestForm"
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
                var result = await sut.DeleteFormAsync(form.Id);

                Assert.IsTrue(result);
            }
        }
        [TestMethod]
        public async Task ThrowException_WhenNoFormFound()
        {
            var options = Utils.GetOptions(nameof(ThrowException_WhenNoFormFound));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();
            var id = Guid.NewGuid();

            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                await Assert.ThrowsExceptionAsync<BusinessLogicException>(() => sut.DeleteFormAsync(id));
            }
        }
    }
}
