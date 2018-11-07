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
        private CarShopDataEntities carShopDataEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelExtraSwitchRepository"/> class.
        /// </summary>
        /// <param name="carShopDataEntities">Dataentity</param>
        public ModelExtraSwitchRepository(CarShopDataEntities carShopDataEntities)
        {
            this.carShopDataEntities = carShopDataEntities;
        }

        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="newItem">Gives the new item which needs to be inserted.</param>
        public void Create(ModelExtraswitch newItem)
        {
            this.carShopDataEntities.ModelExtraswitches.Add(newItem);
            this.carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        /// <param name="itemToBeDeleted">The item which wanted to be deleted</param>
        public void Delete(ModelExtraswitch itemToBeDeleted)
        {
            this.carShopDataEntities.ModelExtraswitches.Remove(itemToBeDeleted);
            this.carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <returns>The wanted type of entities</returns>
        public IQueryable<ModelExtraswitch> ReadAll()
        {
            return this.carShopDataEntities.ModelExtraswitches;
        }
    }
}
