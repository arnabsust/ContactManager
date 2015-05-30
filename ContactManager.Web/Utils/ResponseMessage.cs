using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.Web.Utils
{
    public class ResponseMessage
    {
        public static object ErrorResponse(List<string> errorList)
        {
            string error = string.Empty;

            foreach (string item in errorList)
            {
                error += "<li>" + item + "</li>";
            }
            return new { Success = false, ErrorMessage = error };
        }

        public static object ErrorResponse(string errorMessage)
        {
            return new { Success = false, ErrorMessage = errorMessage };
        }

        public static object SuccessResponse()
        {
            return new { Success = true };
        }

        public static object SuccessResponse(object referenceObject)
        {
            return new { Success = true, Object = referenceObject };
        }
    }
}