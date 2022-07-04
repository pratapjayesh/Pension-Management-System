using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Models
{
    public class SignInResponse
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
    }
}
