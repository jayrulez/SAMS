using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class AssetCategoryModel
    {
    }

    public class CreateAssetCategoryModel
    {
        public CreateAssetCategoryModel()
        {
            AssetFields = new List<AssetFieldModel>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<AssetFieldModel> AssetFields { get; set; }
    }
}