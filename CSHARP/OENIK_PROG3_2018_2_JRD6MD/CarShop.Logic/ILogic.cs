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

    /// <summary>
    /// ILogic interface defined here
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        void Create(string mainMenuWaitingKey);

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <returns>The wanted type of entities</returns>
        IQueryable ReadAll(string mainMenuWaitingKey);

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        void Delete();

        /// <summary>
        /// Updates a parameter of a database entity.
        /// </summary>
        void Update();

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
