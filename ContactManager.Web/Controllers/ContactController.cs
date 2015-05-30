
using ContactManager.Service.Interfaces;
using ContactManager.Service.ViewModels;
using ContactManager.Web.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactManager.Web.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private IContactService contactService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactService"></param>
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactVM"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Create(ContactViewModel contactVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (contactVM.Attachment == null)
                    {
                        ModelState.AddModelError("Attachment", "Please upload a image");
                    }
                    else
                    {
                        if (!ImageUtils.IsImage(contactVM.Attachment))
                        {
                            ModelState.AddModelError("Attachment", "Please upload a valid image file");
                        }
                        else
                        {
                            string extension = Path.GetExtension(contactVM.Attachment.FileName);
                            string fileName = System.Guid.NewGuid().ToString("N") + extension;

                            contactVM.ImageUrl = fileName;
                            contactVM.ImagePath = Server.MapPath("~/Content/UploadedImages/" + fileName);

                            contactService.Create(contactVM);
                            return Json(ResponseMessage.SuccessResponse(), JsonRequestBehavior.DenyGet);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(ResponseMessage.ErrorResponse(ex.InnerException.Message), JsonRequestBehavior.DenyGet);
            }
            var errorList = (from item in ModelState.Values
                             from error in item.Errors
                             select error.ErrorMessage).ToList();

            return Json(ResponseMessage.ErrorResponse(errorList), JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactVM"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Update(ContactViewModel contactVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (contactVM.Attachment != null)
                    {
                        if (!ImageUtils.IsImage(contactVM.Attachment))
                        {
                            ModelState.AddModelError("Attachment", "Please select a Image file");
                        }
                        else
                        {
                            string extension = Path.GetExtension(contactVM.Attachment.FileName);
                            string fileName = System.Guid.NewGuid().ToString("N") + extension;

                            contactVM.ImageUrl = fileName;
                            contactVM.ImagePath = Server.MapPath("~/Content/UploadedImages/" + fileName);

                            contactService.Update(contactVM);
                            return Json(ResponseMessage.SuccessResponse(), JsonRequestBehavior.DenyGet);
                        }
                    }
                    else
                    {
                        contactService.Update(contactVM);
                        return Json(ResponseMessage.SuccessResponse(), JsonRequestBehavior.DenyGet);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(ResponseMessage.ErrorResponse(ex.InnerException.Message), JsonRequestBehavior.DenyGet);
            }
            var errorList = (from item in ModelState.Values
                             from error in item.Errors
                             select error.ErrorMessage).ToList();

            return Json(ResponseMessage.ErrorResponse(errorList), JsonRequestBehavior.DenyGet);
        }

        public JsonResult GetDetails(int contactID)
        {
            try
            {
                var data = contactService.GetByID(contactID);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Get()
        {
            try
            {
                var data = contactService.GetAll();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}