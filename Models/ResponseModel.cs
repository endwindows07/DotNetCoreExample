using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreExample.Models
{
    public class ResponseModel
    {
        public ResponseModel(bool status, string message)
        {
            Status = status;
            Message = message;
        }

        public ResponseModel(bool status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public bool Status { get; set; }
        public string Message{ get; set; }
        public object Data { get; set; }
    }
}
