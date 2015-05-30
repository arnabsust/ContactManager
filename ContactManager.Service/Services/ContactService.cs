using ContactManager.Domain.Models;
using ContactManager.Domain.Repositories;
using ContactManager.Service.Interfaces;
using ContactManager.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Service.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactService : IContactService
    {
        private Contact contact;
        private UnitOfWork unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ContactService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactVM"></param>
        public void Create(ContactViewModel contactVM)
        {
            contact = new Contact
            {
                Name = contactVM.Name,
                Address = contactVM.Address,
                ImageUrl = contactVM.ImageUrl,
                PhoneNumber = contactVM.PhoneNumber,
                Email = contactVM.Email,
                Website = contactVM.Website,
                ShortNotes = contactVM.ShortNotes
            };
            unitOfWork.ContactRepository.Insert(contact);
            unitOfWork.Save();

            contactVM.Attachment.SaveAs(contactVM.ImagePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactVM"></param>
        public void Update(ContactViewModel contactVM)
        {
            contact = unitOfWork.ContactRepository.GetById(contactVM.ContactID);

            contact.ContactID = contactVM.ContactID;
            contact.Name = contactVM.Name;
            contact.Address = contactVM.Address;
            contact.PhoneNumber = contactVM.PhoneNumber;
            contact.Email = contactVM.Email;
            contact.Website = contactVM.Website;
            contact.ShortNotes = contactVM.ShortNotes;

            if (contactVM.Attachment != null)
            {
                contact.ImageUrl = contactVM.ImageUrl;
                contactVM.Attachment.SaveAs(contactVM.ImagePath);
            }

            unitOfWork.ContactRepository.Update(contact);
            unitOfWork.Save();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactID"></param>
        /// <returns></returns>
        public ContactViewModel GetByID(int contactID)
        {
            var result = (from c in unitOfWork.ContactRepository.Get()
                          where c.ContactID == contactID
                          select new ContactViewModel
                          {
                              ContactID = c.ContactID,
                              Name = c.Name,
                              Address = c.Address,
                              ImageUrl = c.ImageUrl,
                              PhoneNumber = c.PhoneNumber,
                              Email = c.Email,
                              Website = c.Website,
                              ShortNotes = c.ShortNotes
                          }).SingleOrDefault();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContactViewModel> GetAll()
        {
            var result = (from c in unitOfWork.ContactRepository.Get()
                          select new ContactViewModel
                          {
                              ContactID = c.ContactID,
                              Name = c.Name,
                              Address = c.Address,
                              ImageUrl = c.ImageUrl,
                              PhoneNumber = c.PhoneNumber,
                              Email = c.Email,
                              Website = c.Website,
                              ShortNotes = c.ShortNotes
                          }).AsEnumerable();
            return result;
        }
    }
}
