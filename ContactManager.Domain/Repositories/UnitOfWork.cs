using ContactManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Domain.Repositories
{
    public class UnitOfWork
    {
        private ContactManagerContext db;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public UnitOfWork(ContactManagerContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        private IRepository<Contact> contactRepo;
        public IRepository<Contact> ContactRepository
        {
            get
            {
                if (this.contactRepo == null)
                {
                    this.contactRepo = new Repository<Contact>(db);
                }
                return contactRepo;
            }
        }
    }
}
