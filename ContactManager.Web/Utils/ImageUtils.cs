using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.Web.Utils
{
    public class ImageUtils
    {
        public static bool IsImage(HttpPostedFileBase file)
        {
            if (file.ContentType.Contains("image"))
            {
                return true;
            }

            string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

            return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }
    }
}