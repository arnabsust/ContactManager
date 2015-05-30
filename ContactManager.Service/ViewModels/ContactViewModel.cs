using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ContactManager.Service.ViewModels
{
    public class ContactViewModel
    {
        public int ContactID { get; set; }

        [Required(AllowEmptyStrings=false, ErrorMessage="Name is Required")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        public string ImageUrl { get; set; }

        public string ImagePath { get; set; }

        public HttpPostedFileBase Attachment { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number is Required")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Email format is not valid")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Website is Required")]
        public string Website { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Short Notes is Required")]
        public string ShortNotes { get; set; }
    }
}
