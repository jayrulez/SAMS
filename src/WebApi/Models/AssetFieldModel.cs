using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CreateAssetFieldModel
    {
        [Required]
        public AssetFieldType FieldType { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int Position { get; set; }

        public string ValidationRules { get; set; }
    }

    public class EditAssetFieldModel
    {
        public int Id { get; set; }

        [Required]
        public AssetFieldType FieldType { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int Position { get; set; }

        public string ValidationRules { get; set; }
    }
}