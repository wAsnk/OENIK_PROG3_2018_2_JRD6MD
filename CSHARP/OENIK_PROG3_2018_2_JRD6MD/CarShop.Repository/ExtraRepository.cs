// <copyright file="ExtraRepository.cs" company="CarShop">
// Copyright (c) CarShop. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;

    /// <summary>
    /// Repository which implements Extras
    /// </summary>
    public class ExtraRepository : IExtraRepository
    {
        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="newItem">Gives the new item which needs to be inserted.</param>
        public void Create(Extra newItem)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                carShopDataEntities.Extras.Add(newItem);
                carShopDataEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <returns>The wanted type of entities</returns>
        public IQueryable<Extra> ReadAll()
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                return carShopDataEntities.Extras;
            }
        }

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        /// <param name="itemToBeDeleted">The item which wanted to be deleted</param>
        public void Delete(Extra itemToBeDeleted)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                carShopDataEntities.Extras.Remove(itemToBeDeleted);
                carShopDataEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Change category name of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newCategoryName">New category name of the extra</param>
        public void ChangeCategoryName(int id, string newCategoryName)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                var extra = carShopDataEntities.Extras.Single(x => x.Extra_Id == id);
                extra.Extra_Category_Name = newCategoryName;
            }
        }

        /// <summary>
        /// Change  name of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newName">New  name of the extra</param>
        public void ChangeName(int id, string newName)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                var extra = carShopDataEntities.Extras.Single(x => x.Extra_Id == id);
                extra.Extra_Name = newName;
            }
        }

        /// <summary>
        /// Change price of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newPrice">New price of the extra</param>
        public void ChangePrice(int id, int newPrice)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                var extra = carShopDataEntities.Extras.Single(x => x.Extra_Id == id);
                extra.Extra_Price = newPrice;
            }
        }

        /// <summary>
        /// Change color of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newColor">New color of the extra</param>
        public void ChangeColor(int id, string newColor)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                var extra = carShopDataEntities.Extras.Single(x => x.Extra_Id == id);
                extra.Extra_Color = newColor;
            }
        }

        /// <summary>
        /// Change Multiple Usage of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newMultipleUsage">New Multiple Usage of the extra</param>
        public void ChangeMultipleUsage(int id, int newMultipleUsage)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                var extra = carShopDataEntities.Extras.Single(x => x.Extra_Id == id);
                extra.Extra_Multiple_Usage = newMultipleUsage;
            }
        }
    }
}
