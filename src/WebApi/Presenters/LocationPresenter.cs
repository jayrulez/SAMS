using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Presenters
{
    public class LocationPresenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationPresenter Parent { get; set; }
    }
}