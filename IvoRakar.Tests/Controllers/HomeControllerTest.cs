using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IvoRakar;
using IvoRakar.Controllers;
using Moq;
using IvoRakar.Business.Persistence.Repositories;
using IvoRakar.Business.Persistence;
using IvoRakar.Models;
using IvoRakar.Business.Enums;
using IvoRakar.ViewModels;
using IvoRakar.Business.Definitions;

namespace IvoRakar.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //// Arrange
            var mockSubscriberRepository = new Mock<ISubscriberRepository>();
            var moqUnitOfWork = new Mock<IUnitOfWork>();
            HomeController controller = new HomeController(moqUnitOfWork.Object, mockSubscriberRepository.Object);

            //// Act
            ViewResult result = controller.Index() as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Can_Submit_Successfully()
        {
            //// Arrange
            var email = "test@test.com";
            var subscriber = new Subscriber()
            {
                Email = email,
                MarketingTool = MarketingTool.Advert
            };
            var mockSubscriberRepository = new Mock<ISubscriberRepository>();
            mockSubscriberRepository.Setup(r => r.Get(email)).Returns((Subscriber)null);
            var moqUnitOfWork = new Mock<IUnitOfWork>();
            HomeController controller = new HomeController(moqUnitOfWork.Object, mockSubscriberRepository.Object);

            //// Act
            PartialViewResult result = controller.Subscribe(subscriber) as PartialViewResult;
            var resultViewModel = result.Model as SubscriberViewModel;

            ////Assert
            Assert.IsTrue(resultViewModel.Status.Type == StatusType.success);
            Assert.IsTrue(resultViewModel.Status.Message == SubscribeFormDefinitions.SuccessMessage);
        }

        [TestMethod]
        public void Can_Detect_Duplicate()
        {
            //// Arrange
            var email = "test@test.com";
            var subscriber = new Subscriber()
            {
                Email = email,
                MarketingTool = MarketingTool.Advert
            };
            var mockSubscriberRepository = new Mock<ISubscriberRepository>();
            mockSubscriberRepository.Setup(r => r.Get(email)).Returns(subscriber);
            var moqUnitOfWork = new Mock<IUnitOfWork>();
            HomeController controller = new HomeController(moqUnitOfWork.Object, mockSubscriberRepository.Object);

            //// Act
            PartialViewResult result = controller.Subscribe(subscriber) as PartialViewResult;
            var resultViewModel = result.Model as SubscriberViewModel;

            ////Assert
            Assert.IsTrue(resultViewModel.Status.Type == StatusType.danger);
            Assert.IsTrue(resultViewModel.Status.Message == SubscribeFormDefinitions.DuplicateMessage);
        }

    }
}
