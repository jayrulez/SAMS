using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Presenters
{
    public class UserPresenter
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public LocationPresenter Location { get; set; }
    }
}