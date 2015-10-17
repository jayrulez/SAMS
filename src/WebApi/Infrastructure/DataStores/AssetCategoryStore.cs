using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.Entities;

namespace WebApi.Infrastructure.DataStores
{
    public class AssetCategoryStore : EntityStore
    {
        public IQueryable<AssetCategory> AssetCategories
        {
            get
            {
                return _dbContext.AssetCategories;
            }
        }

        public Task CreateAsync(AssetCategory entity)
        {
            _dbContext.AssetCategories.Add(entity);

            _dbContext.SaveChangesAsync();

            return Task.FromResult(0);
        }

        public Task UpdateAsync(AssetCategory entity)
        {
            foreach(var existingField in _dbContext.AssetFields)
            {
                var current = entity.AssetFields.FirstOrDefault(a => a.Id == existingField.Id);

                if(current == null)
                {
                    _dbContext.Entry<AssetField>(existingField).State = EntityState.Deleted;
                }
                else
                {
                    _dbContext.AssetFields.Remove(existingField);
                }
            }

            //var newAssetFields = entity.AssetFields.Where(a => a.Id <= 0);

            //foreach(var newAssetField in newAssetFields)
            //{
            //    entity.AssetFields.Remove(newAssetField);
            //}

            var assetFields = entity.AssetFields;
            entity.AssetFields = new Collection<AssetField>();

            foreach (var assetField in assetFields)
            {
                if (assetField.Id <= 0)
                {
                    entity.AssetFields.Add(assetField);
                }
                else
                {
                    _dbContext.Entry<AssetField>(assetField).State = EntityState.Modified;
                }
            }

            _dbContext.Entry<AssetCategory>(entity).State = EntityState.Modified;

            //foreach(var assetField in assetFields)
            //{
            //    entity.AssetFields.Add(assetField);
            //}

            //foreach (var newAssetField in newAssetFields)
            //{
            //    entity.AssetFields.Add(newAssetField);
            //}

            _dbContext.SaveChangesAsync();

            return Task.FromResult(0);
        }
    }
}