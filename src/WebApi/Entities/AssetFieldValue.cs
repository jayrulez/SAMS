using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Entities
{
    public class AssetFieldValue
    {
        [Key, Column(Order =1)]
        public int AssetFieldId { get; set; }

        [Key, Column(Order = 2)]
        public int AssetId { get; set; }

        public string Value { get; set; }

        public virtual AssetField AssetField { get; set; }
        public virtual Asset Asset { get; set; }
    }
}