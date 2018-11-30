// <copyright file="ModelRepository.cs" company="CarShop">
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
    /// Repository which implements Models
    /// </summary>
    public class ModelRepository : IModelRepository
    {
        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="newItem">Gives the new item which needs to be inserted.</param>
        /// <param name="carShopDataEntities">Data entities</param>
        public void Create(Model newItem, CarShopDataEntities carShopDataEntities)
        {
            carShopDataEntities.Models.Add(newItem);
            carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <param name="carShopDataEntities">Data entites</param>
        /// <returns>The wanted type of entities</returns>
        public IQueryable<Model> ReadAll(CarShopDataEntities carShopDataEntities)
        {
            return carShopDataEntities.Models;
        }

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        /// <param name="itemToBeDeleted">The item which wanted to be deleted</param>
        /// <param name="carShopDataEntities">Data entities</param>
        public void Delete(Model itemToBeDeleted, CarShopDataEntities carShopDataEntities)
        {
            carShopDataEntities.Models.Remove(itemToBeDeleted);
            carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Change name of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newName">New  name of the model</param>
        /// <param name="carShopDataEntities">Data entities</param>
        public void ChangeName(int id, string newName, CarShopDataEntities carShopDataEntities)
        {
            var extra = carShopDataEntities.Models.Single(x => x.Model_Id == id);
            extra.Model_Name = newName;
            carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Change Release Day of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newReleaseDay">New Release Day of the model</param>
        /// <param name="carShopDataEntities">Data entities</param>
        public void ChangeReleaseDay(int id, string newReleaseDay, CarShopDataEntities carShopDataEntities)
        {
            var extra = carShopDataEntities.Models.Single(x => x.Model_Id == id);
            extra.Model_Release_Day = DateTime.Parse(newReleaseDay);
            carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Change Engine Volume of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newEngineVolume">New Engine Volume of the model</param>
        /// <param name="carShopDataEntities">Data entities</param>
        public void ChangeEngineVolume(int id, int newEngineVolume, CarShopDataEntities carShopDataEntities)
        {
            var extra = carShopDataEntities.Models.Single(x => x.Model_Id == id);
            extra.Model_Engine_Volume = newEngineVolume;
            carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Change Horse Power of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newHorsePower">New Horse Power of the model</param>
        /// <param name="carShopDataEntities">Data entities</param>
        public void ChangeHorsePower(int id, int newHorsePower, CarShopDataEntities carShopDataEntities)
        {
            var extra = carShopDataEntities.Models.Single(x => x.Model_Id == id);
            extra.Model_Horsepower = newHorsePower;
            carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Change Bas ePrice of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newBasePrice">New Base Price of the model</param>
        /// <param name="carShopDataEntities">Data entities</param>
        public void ChangeBasePrice(int id, int newBasePrice, CarShopDataEntities carShopDataEntities)
        {
            var extra = carShopDataEntities.Models.Single(x => x.Model_Id == id);
            extra.Model_Base_Price = newBasePrice;
            carShopDataEntities.SaveChanges();
        }
    }
}
