using ContactManager.Domain.Models;
using ContactManager.Domain.Repositories;
using ContactManager.Service.Interfaces;
using ContactManager.Service.Services;
using ContactManager.Service.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Tests
{
    [TestClass]
    public class ContactServiceTests
    {
        private IContactService _contactService;

        [TestInitialize]
        public void Initialize() 
        {
            this._contactService = new ContactService(new UnitOfWork(new ContactManagerContext()));
        }
        

        [TestMethod]
        [TestCategory("ContactServiceRead")]
        public void GetAllContactTest()
        {
            var allContacts = this._contactService.GetAll();
            Assert.IsNotNull(allContacts);
            Assert.IsTrue(allContacts.Count() > 0);
        }

        [TestMethod]
        [TestCategory("ContactServiceRead")]
        public void GetSingleContactTest()
        {
            var contact = this._contactService.GetByID(5);
            Assert.IsNotNull(contact);
            Assert.IsInstanceOfType(contact, typeof(ContactViewModel));
        }
    }
}
