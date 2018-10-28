// <copyright file="DBActions.cs" company="CarShop">
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
    /// SUMMARY HERE
    /// </summary>
    public class DBActions : ILogic
    {
        /// <summary>
        /// Create new table elements
        /// </summary>
        /// <typeparam name="T">Type of the element</typeparam>
        /// <param name="value">Values for the new element</param>
        public void Create<T>(object value)
        {
            Type t = typeof(T);
            Console.WriteLine($"Please give the datas of your new {t}");
        }

        /// <summary>
        /// Get the element with the given key
        /// </summary>
        /// <typeparam name="T">Type of the element</typeparam>
        /// <param name="key">The key of the searched element</param>
        public void Read<T>(int key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// gafd
        /// </summary>
        /// <typeparam name="T">agf</typeparam>
        /// <param name="key">sdgf</param>
        /// <param name="newValues">hsgf</param>
        public void Update<T>(int key, object newValues)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// thzuj
        /// </summary>
        /// <typeparam name="T">rzmu</typeparam>
        /// <param name="key">gdfas</param>
        public void Delete<T>(int key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives the Average Base Price Per Brands
        /// </summary>
        public void AverageBasePrice_PerBrands()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives cars full price
        /// </summary>
        public void CarsFullPrice()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives beck the Extra categories usage
        /// </summary>
        public void ExtraCategoryUseage()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Request price offer using JAVA
        /// </summary>
        public void RequestPriceOffer()
        {
            throw new NotImplementedException();
        }
    }
}
