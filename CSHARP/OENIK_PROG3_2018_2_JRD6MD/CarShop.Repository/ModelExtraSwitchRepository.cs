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
    public class ModelExtraSwitchRepository : IModelExtraSwitchRepository
    {
        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="newItem">Gives the new item which needs to be inserted.</param>
        /// <param name="carShopDataEntities">Data entities</param>
        public void Create(ModelExtraswitch newItem, CarShopDataEntities carShopDataEntities)
        {
            carShopDataEntities.ModelExtraswitches.Add(newItem);
            carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        /// <param name="itemToBeDeleted">The item which wanted to be deleted</param>
        /// <param name="carShopDataEntities">Data entities</param>
        public void Delete(ModelExtraswitch itemToBeDeleted, CarShopDataEntities carShopDataEntities)
        {
            carShopDataEntities.ModelExtraswitches.Remove(itemToBeDeleted);
            carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <param name="carShopDataEntities">Data entites</param>
        /// <returns>The wanted type of entities</returns>
        public IQueryable<ModelExtraswitch> ReadAll(CarShopDataEntities carShopDataEntities)
        {
            return carShopDataEntities.ModelExtraswitches;
        }

        /// <summary>
        /// Change name of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newId">>New  ID of the modelextraswitch</param>
        /// <param name="carShopDataEntities">Data entities</param>
        public void ChangeModelId(int id, int newId, CarShopDataEntities carShopDataEntities)
        {
        }

        /// <summary>
        /// Change name of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newId">New  ID of the modelextraswitch</param>
        /// <param name="carShopDataEntities">Data entities</param>
        public void ChangeExtraId(int id, int newId, CarShopDataEntities carShopDataEntities)
        {
        }
    }
}
