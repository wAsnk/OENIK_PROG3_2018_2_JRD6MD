// <copyright file="CarBrandRepository.cs" company="CarShop">
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
    /// Repository which implements car brand
    /// </summary>
    public class CarBrandRepository : ICarBrandRepository
    {
        /// <summary>
        /// Data entities for the database
        /// </summary>
        private CarShopDataEntities carShopDataEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarBrandRepository"/> class.
        /// </summary>
        /// <param name="carShopDataEntities">Dataentity</param>
        public CarBrandRepository(CarShopDataEntities carShopDataEntities)
        {
            this.carShopDataEntities = carShopDataEntities;
        }

        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="newItem">Gives the new item which needs to be inserted.</param>
        public void Create(CarBrand newItem)
        {
            this.carShopDataEntities.CarBrands.Add(newItem);
            this.carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <returns>The wanted type of entities</returns>
        public IQueryable<CarBrand> ReadAll()
        {
            return this.carShopDataEntities.CarBrands;
        }

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        /// <param name="itemToBeDeleted">The item which wanted to be deleted</param>
        public void Delete(CarBrand itemToBeDeleted)
        {
            this.carShopDataEntities.CarBrands.Remove(itemToBeDeleted);
            this.carShopDataEntities.SaveChanges();
        }

        /// <summary>
        /// Rename car brand
        /// </summary>
        /// <param name="id">Id of the carbarnd</param>
        /// <param name="newName">New name of the carbrand</param>
        public void ChangeName(int id, string newName)
        {
            var carbrand = this.carShopDataEntities.CarBrands.Single(x => x.Carbrand_Id == id);
            carbrand.Carbrand_Name = newName;
        }

        /// <summary>
        /// Change country of the car brand
        /// </summary>
        /// <param name="id">Id of the car brand</param>
        /// <param name="newCountry">New country of the car brand</param>
        public void ChangeCountry(int id, string newCountry)
        {
            var carbrand = this.carShopDataEntities.CarBrands.Single(x => x.Carbrand_Id == id);
            carbrand.Carbrand_Country_Name = newCountry;
        }

        /// <summary>
        /// Change URL of the car brand
        /// </summary>
        /// <param name="id">Id of the car brand</param>
        /// <param name="newUrl">New URL of the car brand</param>
        public void ChangeUrl(int id, string newUrl)
        {
            var carbrand = this.carShopDataEntities.CarBrands.Single(x => x.Carbrand_Id == id);
            carbrand.Carbrand_Url = newUrl;
        }

        /// <summary>
        /// Change Foundation Year of the car brand
        /// </summary>
        /// <param name="id">Id of the car brand</param>
        /// <param name="newFoundationYear">New Foundation Year of the car brand</param>
        public void ChangeFoundationYear(int id, string newFoundationYear)
        {
            var carbrand = this.carShopDataEntities.CarBrands.Single(x => x.Carbrand_Id == id);
            carbrand.Carbrand_Foundation_Year = DateTime.Parse(newFoundationYear);
        }

        /// <summary>
        /// Change Yearly traffic of the car brand
        /// </summary>
        /// <param name="id">Id of the car brand</param>
        /// <param name="newYearlyTraffic">New yearly traffic of the car brand</param>
        public void ChangeYearlyTraffic(int id, string newYearlyTraffic)
        {
            var carbrand = this.carShopDataEntities.CarBrands.Single(x => x.Carbrand_Id == id);
            carbrand.Carbrand_Yearly_Traffic = newYearlyTraffic;
        }
    }
}
