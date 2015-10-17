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
            AssetFields = new List<CreateAssetFieldModel>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<CreateAssetFieldModel> AssetFields { get; set; }
    }

    public class EditAssetCategoryModel
    {
        public EditAssetCategoryModel()
        {
            AssetFields = new List<EditAssetFieldModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<EditAssetFieldModel> AssetFields { get; set; }
    }
}