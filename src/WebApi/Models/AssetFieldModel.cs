using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class AssetFieldModel
    {
        public AssetFieldType FieldType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public string ValidationRules { get; set; }
    }
}