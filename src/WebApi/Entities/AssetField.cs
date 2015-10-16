using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Entities
{
    public class AssetField
    {
        public AssetField() {
            AssetFieldValues = new Collection<AssetFieldValue>();
        }

        [Key]
        public int Id { get; set; }

        [Required, Index("UniqueAssetField", IsUnique = true, Order = 1)]
        public int AssetCategoryId { get; set; }

        [Required]
        public AssetFieldType FieldType { get; set; }

        [Required, MaxLength(32), Index("UniqueAssetField", IsUnique = true, Order = 2)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int Position { get; set; }

        public string ValidationRules { get; set; }

        public virtual AssetCategory AssetCategory { get; set; }
        public virtual ICollection<AssetFieldValue> AssetFieldValues { get; set; }
    }
}