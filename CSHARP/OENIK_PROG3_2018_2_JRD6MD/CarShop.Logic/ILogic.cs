// <copyright file="ILogic.cs" company="CarShop">
// Copyright (c) CarShop. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;

    /// <summary>
    /// ILogic interface defined here
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <param name="carShopDataEntities">Data entity</param>
        void Create(string mainMenuWaitingKey, CarShopDataEntities carShopDataEntities);

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <param name="carShopDataEntities">Data entity</param>
        /// <returns>The wanted type of entities</returns>
        IQueryable ReadAll(string mainMenuWaitingKey, CarShopDataEntities carShopDataEntities);

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <param name="carShopDataEntities">Data entity</param>
        void Delete(string mainMenuWaitingKey, CarShopDataEntities carShopDataEntities);

        /// <summary>
        /// Updates a parameter of a database entity.
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <param name="carShopDataEntities">Data entity</param>
        void Update(string mainMenuWaitingKey, CarShopDataEntities carShopDataEntities);

        /// <summary>
        /// Gives cars full price
        /// </summary>
        void CarsFullPrice();

        /// <summary>
        /// Gives the Average Base Price Per Brands
        /// </summary>
        void AverageBasePrice_PerBrands();

        /// <summary>
        /// Gives beck the Extra categories usage
        /// </summary>
        void ExtraCategoryUseage();

        /// <summary>
        /// Request price offer using JAVA
        /// </summary>
        void RequestPriceOffer();
    }
}
