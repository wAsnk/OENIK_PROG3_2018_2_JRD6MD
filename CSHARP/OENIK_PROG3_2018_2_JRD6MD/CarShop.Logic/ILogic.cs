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
    /// ILogic Summary here
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Create new table elements
        /// </summary>
        /// <typeparam name="T">Type of the element</typeparam>
        /// <param name="value">Values for the new element</param>
        void Create<T>(object value);

        /// <summary>
        /// Get the element with the given key
        /// </summary>
        /// <typeparam name="T">Type of the element</typeparam>
        /// <param name="key">The key of the searched element</param>
        /// <returns>Returns the element with the given key.</returns>
        object Read<T>(int key);

        /// <summary>
        /// gafd
        /// </summary>
        /// <typeparam name="T">agf</typeparam>
        /// <param name="key">sdgf</param>
        /// <param name="newValues">hsgf</param>
        void Update<T>(int key, object newValues);

        /// <summary>
        /// thzuj
        /// </summary>
        /// <typeparam name="T">rzmu</typeparam>
        /// <param name="key">gdfas</param>
        void Delete<T>(int key);

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
