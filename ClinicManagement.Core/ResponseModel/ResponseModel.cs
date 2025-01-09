using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core.ResponseModel
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ResponseModel<T> CreateSuccessResponse(T data, string message = "")
        {
            return new ResponseModel<T> { Success = true, Message = message, Data = data };
        }

        public static ResponseModel<T> CreateErrorResponse(string message)
        {
            return new ResponseModel<T> { Success = false, Message = message, Data = default };
        }
    }
}
