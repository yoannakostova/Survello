using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Survello.Database;
using Survello.Models.Entites;
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
    public class SortForms_Should
    {
        [TestMethod]
        public void SortByTitleDesc_Succeed()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SortByTitleDesc_Succeed));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();

            var testId = Guid.NewGuid();
            var testId2 = Guid.NewGuid();
            var testId3 = Guid.NewGuid();
            var sortOrder = "title_desc";

            var form1 = new Form
            {
                Id = testId,
                Title = "FirstPlace",
                UserId = testId3
            };
            var form2 = new Form
            {
                Id = testId2,
                Title = "SecondPlace",
                UserId = testId3
            };
            var user = new User
            {
                Id = testId3,
                UserName = "TestUser"
            };

            using (var arrangeContext = new SurvelloContext(options))
            {
                arrangeContext.Users.AddAsync(user);
                arrangeContext.Forms.AddAsync(form1);
                arrangeContext.Forms.AddAsync(form2);
                arrangeContext.Forms.AddAsync(form2);
                arrangeContext.SaveChangesAsync();
            }
            //Act & Assert
            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                var result = sut.Sort(sortOrder, user.Id);

                Assert.AreEqual(form1.Id, result.Last().Id);
                Assert.AreEqual(form1.Title, result.Last().Title);
                Assert.AreEqual(form2.Id, result.First().Id);
                Assert.AreEqual(form2.Title, result.First().Title);
            }
        }
        [TestMethod]
        public void SortByCreatedOn_Succeed()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SortByCreatedOn_Succeed));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();

            var testId = Guid.NewGuid();
            var testId2 = Guid.NewGuid();
            var testId3 = Guid.NewGuid();
            var sortOrder = "CreatedOn";

            var form1 = new Form
            {
                Id = testId,
                Title = "FirstPlace",
                UserId = testId3,
                CreatedOn = DateTime.Now
            };
            var form2 = new Form
            {
                Id = testId2,
                Title = "SecondPlace",
                UserId = testId3,
                CreatedOn = DateTime.UtcNow
            };
            var user = new User
            {
                Id = testId3,
                UserName = "TestUser"
            };

            using (var arrangeContext = new SurvelloContext(options))
            {
                arrangeContext.Users.AddAsync(user);
                arrangeContext.Forms.AddAsync(form1);
                arrangeContext.Forms.AddAsync(form2);
                arrangeContext.Forms.AddAsync(form2);
                arrangeContext.SaveChangesAsync();
            }
            //Act & Assert
            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                var result = sut.Sort(sortOrder, user.Id);

                Assert.AreEqual(form1.Id, result.Last().Id);
                Assert.AreEqual(form1.Title, result.Last().Title);
                Assert.AreEqual(form1.CreatedOn, result.Last().CreatedOn);
                Assert.AreEqual(form2.Id, result.First().Id);
                Assert.AreEqual(form2.Title, result.First().Title);
                Assert.AreEqual(form2.CreatedOn, result.First().CreatedOn);
            }
        }
        [TestMethod]
        public void SortByCreatedOnDesc_Succeed()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SortByCreatedOn_Succeed));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();

            var testId = Guid.NewGuid();
            var testId2 = Guid.NewGuid();
            var testId3 = Guid.NewGuid();
            var sortOrder = "createdon_desc";

            var form1 = new Form
            {
                Id = testId,
                Title = "FirstPlace",
                UserId = testId3,
                CreatedOn = DateTime.Now
            };
            var form2 = new Form
            {
                Id = testId2,
                Title = "SecondPlace",
                UserId = testId3,
                CreatedOn = DateTime.UtcNow
            };
            var user = new User
            {
                Id = testId3,
                UserName = "TestUser"
            };

            using (var arrangeContext = new SurvelloContext(options))
            {
                arrangeContext.Users.AddAsync(user);
                arrangeContext.Forms.AddAsync(form1);
                arrangeContext.Forms.AddAsync(form2);
                arrangeContext.Forms.AddAsync(form2);
                arrangeContext.SaveChangesAsync();
            }
            //Act & Assert
            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                var result = sut.Sort(sortOrder, user.Id);
     
                Assert.AreEqual(form1.Id, result.First().Id);
                Assert.AreEqual(form1.Title, result.First().Title);
                Assert.AreEqual(form1.CreatedOn, result.First().CreatedOn);
                Assert.AreEqual(form2.Id, result.Last().Id);
                Assert.AreEqual(form2.Title, result.Last().Title);
                Assert.AreEqual(form2.CreatedOn, result.Last().CreatedOn);
            }
        }
        [TestMethod]
        public void SortByNumberOfFilledForms()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SortByCreatedOn_Succeed));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();

            var testId = Guid.NewGuid();
            var testId2 = Guid.NewGuid();
            var testId3 = Guid.NewGuid();
            var sortOrder = "NUmberOffFilledForms";

            var form1 = new Form
            {
                Id = testId,
                Title = "FirstPlace",
                UserId = testId3,
                CreatedOn = DateTime.Now,
                NumberOfFilledForms = 3
            };
            var form2 = new Form
            {
                Id = testId2,
                Title = "SecondPlace",
                UserId = testId3,
                CreatedOn = DateTime.UtcNow,
                NumberOfFilledForms = 5
            };
            var user = new User
            {
                Id = testId3,
                UserName = "TestUser"
            };

            using (var arrangeContext = new SurvelloContext(options))
            {
                arrangeContext.Users.AddAsync(user);
                arrangeContext.Forms.AddAsync(form1);
                arrangeContext.Forms.AddAsync(form2);
                arrangeContext.Forms.AddAsync(form2);
                arrangeContext.SaveChangesAsync();
            }
            //Act & Assert
            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                var result = sut.Sort(sortOrder, user.Id);

                Assert.AreEqual(form1.Id, result.First().Id);
                Assert.AreEqual(form1.Title, result.First().Title);
                Assert.AreEqual(form1.NumberOfFilledForms, result.First().NumberOfFilledForms);
                Assert.AreEqual(form2.Id, result.Last().Id);
                Assert.AreEqual(form2.Title, result.Last().Title);
                Assert.AreEqual(form2.CreatedOn, result.Last().CreatedOn);
            }
        }
        [TestMethod]
        public void SortByNumberOfFilledFormDesc()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SortByNumberOfFilledFormDesc));
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockBlobService = new Mock<IBlobServices>();

            var testId = Guid.NewGuid();
            var testId2 = Guid.NewGuid();
            var testId3 = Guid.NewGuid();
            var sortOrder = "numberoffilledforms_desc";

            var form1 = new Form
            {
                Id = testId,
                Title = "FirstPlace",
                UserId = testId3,
                CreatedOn = DateTime.Now,
                NumberOfFilledForms = 5
            };
            var form2 = new Form
            {
                Id = testId2,
                Title = "SecondPlace",
                UserId = testId3,
                CreatedOn = DateTime.UtcNow,
                NumberOfFilledForms = 3
            };
            var user = new User
            {
                Id = testId3,
                UserName = "TestUser"
            };

            using (var arrangeContext = new SurvelloContext(options))
            {
                arrangeContext.Users.AddAsync(user);
                arrangeContext.Forms.AddAsync(form1);
                arrangeContext.Forms.AddAsync(form2);
                arrangeContext.Forms.AddAsync(form2);
                arrangeContext.SaveChangesAsync();
            }
            //Act & Assert
            using (var assertContext = new SurvelloContext(options))
            {
                var sut = new FormServices(assertContext, mockDateTimeProvider.Object, mockBlobService.Object);
                var result = sut.Sort(sortOrder, user.Id).ToArray();
                
                Assert.AreEqual(form1.Id, result.First().Id);
                Assert.AreEqual(form1.Title, result.First().Title);
                Assert.AreEqual(form1.NumberOfFilledForms, result.First().NumberOfFilledForms);
                Assert.AreEqual(form2.Id, result.Last().Id);
                Assert.AreEqual(form2.Title, result.Last().Title);
                Assert.AreEqual(form2.CreatedOn, result.Last().CreatedOn);
            }
        }
        }
    }

