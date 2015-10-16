using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class UserModel
    {
    }

    public class CreateUserModel
    {
        public int? LocationId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class EditUserModel
    {
        public int? LocationId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}