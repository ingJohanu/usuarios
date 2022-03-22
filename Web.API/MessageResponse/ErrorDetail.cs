using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.MessageResponse
{
    public class ErrorDetail
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        /*deserealizar objecto response*/
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
