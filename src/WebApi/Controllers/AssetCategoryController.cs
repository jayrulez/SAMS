using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Infrastructure.Managers;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/asset_categories")]
    public class AssetCategoryController : BaseController
    {
        internal AssetCategoryManager _manager;

        public AssetCategoryController()
        {
            _manager = new AssetCategoryManager();
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_manager.AssetCategories.ToList().Select(a => a.ToPresenter()));
        }

        [Route("create")]
        [HttpPost]
        public async Task<IHttpActionResult> Create([ModelBinder(typeof(FieldValueModelBinder))] CreateAssetCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = new AssetCategory
            {
                Name = model.Name,
                Description = model.Description
            };

            foreach (var assetFieldModel in model.AssetFields)
            {
                if (assetFieldModel != null)
                {
                    var assetField = new AssetField
                    {
                        FieldType = assetFieldModel.FieldType,
                        Name = assetFieldModel.Name,
                        Description = assetFieldModel.Description,
                        Position = assetFieldModel.Position,
                        ValidationRules = assetFieldModel.ValidationRules,
                    };

                    entity.AssetFields.Add(assetField);
                }
            }

            var response = await _manager.CreateAsync(entity);

            if (!response.IsSuccessful)
            {
                ModelState.AddModelError("", response.Error.Message);

                return BadRequest(ModelState);
            }

            return Ok(entity.ToPresenter());
        }
    }
}
