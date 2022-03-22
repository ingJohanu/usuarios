using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Authentication
{
    public class JsonWebToken
    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; } = "Bearer";
        public int Expires_In { get; set; }
        public string Refresh_Token { get; set; }
    }
}
