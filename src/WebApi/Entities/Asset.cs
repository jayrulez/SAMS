using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Entities
{
    public class Asset
    {
        public Asset()
        {
            AssetFieldValues = new Collection<AssetFieldValue>();
            AssetAssignments = new Collection<AssetAssignment>();
        }

        [Key]
        public int Id { get; set; }

        [Required, Index("UniqueAsset", IsUnique = true, Order = 1)]
        public int AssetCategoryId { get; set; }

        [Required, MaxLength(100), Index("UniqueAsset", IsUnique = true, Order = 2)]
        public string Name { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public Decimal? PurchaseCost { get; set; }

        public string Comments { get; set; }

        public virtual AssetCategory AssetCategory { get; set; }
        public virtual ICollection<AssetFieldValue> AssetFieldValues { get; set; }
        public virtual ICollection<AssetAssignment> AssetAssignments { get; set; }
    }
}