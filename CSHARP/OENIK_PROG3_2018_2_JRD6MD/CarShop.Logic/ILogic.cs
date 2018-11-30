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
        /// <param name="value">Object to be created</param>
        void Create(object value);

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <returns>The wanted type of entities</returns>
        IQueryable ReadAll(string mainMenuWaitingKey);

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        void Delete(string mainMenuWaitingKey);

        /// <summary>
        /// Updates a parameter of a database entity.
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <param name="id">Id of the entity</param>
        /// <param name="updateData">Update date to be used</param>
        void Update(string mainMenuWaitingKey, int id, string updateData);

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
