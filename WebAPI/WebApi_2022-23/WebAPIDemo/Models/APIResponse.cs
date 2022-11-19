using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebAPIDemo.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }

        public APIResponse()
        {
            ErrorMessages = new List<string>();
            IsSuccess = true;
        }
    }
}
