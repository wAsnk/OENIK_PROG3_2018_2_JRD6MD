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
        private readonly CarShopDataEntities carShopDataEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelRepository"/> class.
        /// </summary>
        /// <param name="carShopDataEntities">Data entities</param>
        public ModelRepository(CarShopDataEntities carShopDataEntities)
        {
            this.carShopDataEntities = carShopDataEntities;
        }

        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="newItem">Gives the new item which needs to be inserted.</param>
        public void Create(Model newItem)
        {
            this.carShopDataEntities.Models.Add(newItem);
            this.carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <returns>The wanted type of entities</returns>
        public IQueryable<Model> ReadAll()
        {
            return this.carShopDataEntities.Models;
        }

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        /// <param name="itemToBeDeleted">The item which wanted to be deleted</param>
        public void Delete(Model itemToBeDeleted)
        {
            this.carShopDataEntities.Models.Remove(itemToBeDeleted);
            this.carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Change name of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newName">New  name of the model</param>
        public void ChangeName(int id, string newName)
        {
            var extra = this.carShopDataEntities.Models.Single(x => x.Model_Id == id);
            extra.Model_Name = newName;
            this.carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Change Release Day of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newReleaseDay">New Release Day of the model</param>
        public void ChangeReleaseDay(int id, string newReleaseDay)
        {
            var extra = this.carShopDataEntities.Models.Single(x => x.Model_Id == id);
            extra.Model_Release_Day = DateTime.Parse(newReleaseDay);
            this.carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Change Engine Volume of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newEngineVolume">New Engine Volume of the model</param>
        public void ChangeEngineVolume(int id, int newEngineVolume)
        {
            var extra = this.carShopDataEntities.Models.Single(x => x.Model_Id == id);
            extra.Model_Engine_Volume = newEngineVolume;
            this.carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Change Horse Power of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newHorsePower">New Horse Power of the model</param>
        public void ChangeHorsePower(int id, int newHorsePower)
        {
            var extra = this.carShopDataEntities.Models.Single(x => x.Model_Id == id);
            extra.Model_Horsepower = newHorsePower;
            this.carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Change Bas ePrice of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newBasePrice">New Base Price of the model</param>
        public void ChangeBasePrice(int id, int newBasePrice)
        {
            var extra = this.carShopDataEntities.Models.Single(x => x.Model_Id == id);
            extra.Model_Base_Price = newBasePrice;
            this.carShopDataEntities.SaveChanges();
        }
    }
}
