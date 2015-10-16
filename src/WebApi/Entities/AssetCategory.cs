using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Entities
{
    public class AssetCategory
    {
        public AssetCategory()
        {
            Assets = new Collection<Asset>();
            AssetFields = new Collection<AssetField>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(32), Index(IsUnique = true)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<AssetField> AssetFields { get; set; }
    }
}