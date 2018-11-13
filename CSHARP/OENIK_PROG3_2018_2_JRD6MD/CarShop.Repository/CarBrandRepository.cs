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
        // private CarShopDataEntities carShopDataEntities = new CarShopDataEntities();

        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="newItem">Gives the new item which needs to be inserted.</param>
        public void Create(CarBrand newItem)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                carShopDataEntities.CarBrands.Add(newItem);
                carShopDataEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <returns>The wanted type of entities</returns>
        public IQueryable<CarBrand> ReadAll()
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                return carShopDataEntities.CarBrands;
            }
        }

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        /// <param name="itemToBeDeleted">The item which wanted to be deleted</param>
        public void Delete(CarBrand itemToBeDeleted)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                carShopDataEntities.CarBrands.Remove(itemToBeDeleted);
                carShopDataEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Rename car brand
        /// </summary>
        /// <param name="id">Id of the carbarnd</param>
        /// <param name="newName">New name of the carbrand</param>
        public void ChangeName(int id, string newName)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                var carbrand = carShopDataEntities.CarBrands.Single(x => x.Carbrand_Id == id);
                carbrand.Carbrand_Name = newName;
            }
        }

        /// <summary>
        /// Change country of the car brand
        /// </summary>
        /// <param name="id">Id of the car brand</param>
        /// <param name="newCountry">New country of the car brand</param>
        public void ChangeCountry(int id, string newCountry)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                var carbrand = carShopDataEntities.CarBrands.Single(x => x.Carbrand_Id == id);
                carbrand.Carbrand_Country_Name = newCountry;
            }
        }

        /// <summary>
        /// Change URL of the car brand
        /// </summary>
        /// <param name="id">Id of the car brand</param>
        /// <param name="newUrl">New URL of the car brand</param>
        public void ChangeUrl(int id, string newUrl)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                var carbrand = carShopDataEntities.CarBrands.Single(x => x.Carbrand_Id == id);
                carbrand.Carbrand_Url = newUrl;
            }
        }

        /// <summary>
        /// Change Foundation Year of the car brand
        /// </summary>
        /// <param name="id">Id of the car brand</param>
        /// <param name="newFoundationYear">New Foundation Year of the car brand</param>
        public void ChangeFoundationYear(int id, string newFoundationYear)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                var carbrand = carShopDataEntities.CarBrands.Single(x => x.Carbrand_Id == id);
                carbrand.Carbrand_Foundation_Year = DateTime.Parse(newFoundationYear);
            }
        }

        /// <summary>
        /// Change Yearly traffic of the car brand
        /// </summary>
        /// <param name="id">Id of the car brand</param>
        /// <param name="newYearlyTraffic">New yearly traffic of the car brand</param>
        public void ChangeYearlyTraffic(int id, string newYearlyTraffic)
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                var carbrand = carShopDataEntities.CarBrands.Single(x => x.Carbrand_Id == id);
                carbrand.Carbrand_Yearly_Traffic = newYearlyTraffic;
            }
        }
    }
}
