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
        private CarShopDataEntities carShopDataEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtraRepository"/> class.
        /// </summary>
        /// <param name="carShopDataEntities">Dataentity</param>
        public ExtraRepository(CarShopDataEntities carShopDataEntities)
        {
            this.carShopDataEntities = carShopDataEntities;
        }

        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="newItem">Gives the new item which needs to be inserted.</param>
        public void Create(Extra newItem)
        {
            this.carShopDataEntities.Extras.Add(newItem);
            this.carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <returns>The wanted type of entities</returns>
        public IQueryable<Extra> ReadAll()
        {
            return this.carShopDataEntities.Extras;
        }

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        /// <param name="itemToBeDeleted">The item which wanted to be deleted</param>
        public void Delete(Extra itemToBeDeleted)
        {
            this.carShopDataEntities.Extras.Remove(itemToBeDeleted);
            this.carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Change category name of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newCategoryName">New category name of the extra</param>
        public void ChangeCategoryName(int id, string newCategoryName)
        {
            var extra = this.carShopDataEntities.Extras.Single(x => x.Extra_Id == id);
            extra.Extra_Category_Name = newCategoryName;
        }

        /// <summary>
        /// Change  name of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newName">New  name of the extra</param>
        public void ChangeName(int id, string newName)
        {
            var extra = this.carShopDataEntities.Extras.Single(x => x.Extra_Id == id);
            extra.Extra_Name = newName;
        }

        /// <summary>
        /// Change price of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newPrice">New price of the extra</param>
        public void ChangePrice(int id, int newPrice)
        {
            var extra = this.carShopDataEntities.Extras.Single(x => x.Extra_Id == id);
            extra.Extra_Price = newPrice;
        }

        /// <summary>
        /// Change color of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newColor">New color of the extra</param>
        public void ChangeColor(int id, string newColor)
        {
            var extra = this.carShopDataEntities.Extras.Single(x => x.Extra_Id == id);
            extra.Extra_Color = newColor;
        }

        /// <summary>
        /// Change Multiple Usage of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newMultipleUsage">New Multiple Usage of the extra</param>
        public void ChangeMultipleUsage(int id, int newMultipleUsage)
        {
            var extra = this.carShopDataEntities.Extras.Single(x => x.Extra_Id == id);
            extra.Extra_Multiple_Usage = newMultipleUsage;
        }
    }
}
