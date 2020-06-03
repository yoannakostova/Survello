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
    public class GetUserFormssync_Should
    {
        [TestMethod]
        public async Task ReturnCorrectFormDtoWhen_ParamsAreValid()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnCorrectFormDtoWhen_ParamsAreValid));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();

            var testId = Guid.NewGuid();
            var testId2 = Guid.NewGuid();
            var testId3 = Guid.NewGuid();

            var form = new Form
            {
                Id = testId,
                Title = "TestForm1",
                Description = "TestDescription",
                UserId = testId3
            };
            var form2 = new Form
            {
                Id = testId2,
                Title = "TestForm2",
                Description = "TestDescription2",
                UserId = testId3
            };

            var user = new User
            {
                Id = testId3,
                UserName = "TestUser"
            };

            using (var arrangeContext = new SurvelloContext(options))
            {
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.Forms.AddAsync(form);
                await arrangeContext.Forms.AddAsync(form2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act & Assert
            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                var result = (await sut.GetUserFormsAsync(testId3)).ToList();

                Assert.AreEqual(2, result.Count);
                Assert.AreEqual(form.Id, result[0].Id);
                Assert.AreEqual(form.Title, result[0].Title);
                Assert.AreEqual(form.Description, result[0].Description);
                Assert.AreEqual(form2.Id, result[1].Id);
                Assert.AreEqual(form2.Title, result[1].Title);
                Assert.AreEqual(form2.Description, result[1].Description);
            }
        }
        [TestMethod]
        public async Task ThrowException_WhenNoUserFormsFound()
        {
            var options = Utils.GetOptions(nameof(ThrowException_WhenNoUserFormsFound));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                UserName = "TestUser"
            };

            using (var arrangeContext = new SurvelloContext(options))
            {
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                await Assert.ThrowsExceptionAsync<BusinessLogicException>(() => sut.GetUserFormsAsync(userId));
            }
        }
    }
}
