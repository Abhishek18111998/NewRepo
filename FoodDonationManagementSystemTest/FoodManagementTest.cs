using AutoFixture;
using FoodDonationManagementSystem.Controllers;
using FoodDonationManagementSystem.Core;
using FoodDonationManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDonationManagementSystemTest
{
    [TestClass]
    public class FoodManagementTest
    {
        private Mock<IDonars> _donarMock;
        private Fixture _fixture;
        private FoodDonarController _donarController;

        public FoodManagementTest()
        {
            _fixture = new Fixture();
            _donarMock = new Mock<IDonars>();
        }
        [TestMethod]
        public async Task AddNewDonarTest()
        {
            var schoolModel = _fixture.Create<SchoolModel>();
            _donarMock.Setup(x => x.AddNewDonar(It.IsAny<SchoolModel>())).Returns(Task.FromResult(schoolModel));
            _donarController = new FoodDonarController(_donarMock.Object);
            var result = await _donarController.AddingDonar(schoolModel);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task AddNewDonarException()
        {
            var schoolModel = new SchoolModel();
            _donarMock.Setup(x => x.AddNewDonar(It.IsAny<SchoolModel>())).Throws(new Exception());
            _donarController = new FoodDonarController(_donarMock.Object);
            var result = await _donarController.AddingDonar(schoolModel);
            var obj = result as ObjectResult;
            Assert.AreEqual(400, obj.StatusCode);
        }
        [TestMethod]
        public async Task DisplayAllDonarsTest()
        {
            var donarlist = _fixture.CreateMany<SchoolModel>(4).ToList();
            _donarMock.Setup(x => x.DisplayAllDonars()).Returns(Task.FromResult(donarlist));
            _donarController = new FoodDonarController(_donarMock.Object);
            var result = await _donarController.DisplayDonars();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task DisplayAllDonarsException()
        {
            _donarMock.Setup(x => x.DisplayAllDonars()).Throws(new Exception());
            _donarController = new FoodDonarController(_donarMock.Object);
            var result = await _donarController.DisplayDonars();
            var obj = result as ObjectResult;
            Assert.AreEqual(400, obj.StatusCode);
        }
    }
}
