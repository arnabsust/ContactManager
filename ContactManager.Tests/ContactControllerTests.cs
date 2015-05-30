using ContactManager.Domain.Models;
using ContactManager.Domain.Repositories;
using ContactManager.Service.Services;
using ContactManager.Service.ViewModels;
using ContactManager.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ContactManager.Tests
{
    [TestClass]
    public class ContactControllerTests
    {
        private ContactController contactController;

        [TestInitialize]
        public void Initialize()
        {
            this.contactController = new ContactController(
                new ContactService(
                    new UnitOfWork(
                        new ContactManagerContext()
                        )));
        }

        [TestMethod]
        [TestCategory("ContactController")]
        public void ContactIndex()
        {
            var result = this.contactController.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("ContactController")]
        public void Get()
        {
            var result = this.contactController.Get() as JsonResult;
            dynamic jsonObject = result.Data;

            Assert.IsNotNull(jsonObject);
        }

        [TestMethod]
        [TestCategory("ContactController")]
        public void GetDetails()
        {
            var result = this.contactController.GetDetails(5) as JsonResult;
            dynamic jsonObject = result.Data;

            Assert.IsNotNull(jsonObject);
            Assert.AreEqual(5, jsonObject.ContactID);
        }
    }
}
