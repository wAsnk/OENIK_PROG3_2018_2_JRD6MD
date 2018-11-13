// <copyright file="ModelExtraSwitchRepository.cs" company="CarShop">
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
    /// Repository which implements ModelExtraSwitch
    /// </summary>
    public class ModelExtraSwitchRepository : IModelExtraSwitch
    {
        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="newItem">Gives the new item which needs to be inserted.</param>
        public void Create(ModelExtraswitch newItem)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                carShopDataEntities.ModelExtraswitches.Add(newItem);
                carShopDataEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        /// <param name="itemToBeDeleted">The item which wanted to be deleted</param>
        public void Delete(ModelExtraswitch itemToBeDeleted)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                carShopDataEntities.ModelExtraswitches.Remove(itemToBeDeleted);
                carShopDataEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <returns>The wanted type of entities</returns>
        public IQueryable<ModelExtraswitch> ReadAll()
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                return carShopDataEntities.ModelExtraswitches;
            }
        }
    }
}
