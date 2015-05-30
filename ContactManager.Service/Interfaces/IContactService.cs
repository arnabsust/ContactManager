using ContactManager.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Service.Interfaces
{
    public interface IContactService
    {
        void Create(ContactViewModel contactVM);
        void Update(ContactViewModel contactVM);
        ContactViewModel GetByID(int contactID);
        IEnumerable<ContactViewModel> GetAll();
    }
}
