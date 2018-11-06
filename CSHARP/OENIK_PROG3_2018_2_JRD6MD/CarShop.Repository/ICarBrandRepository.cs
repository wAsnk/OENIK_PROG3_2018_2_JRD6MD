// <copyright file="ICarBrandRepository.cs" company="CarShop">
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
    /// Car brand specific functions
    /// </summary>
    public interface ICarBrandRepository : IRepository<CarBrand>
    {
        /// <summary>
        /// Rename car brand
        /// </summary>
        /// <param name="id">Id of the carbarnd</param>
        /// <param name="newName">New name of the carbrand</param>
        void ChangeName(int id, string newName);

        /// <summary>
        /// Change country of the car brand
        /// </summary>
        /// <param name="id">Id of the car brand</param>
        /// <param name="newCountry">New country of the car brand</param>
        void ChangeCountry(int id, string newCountry);

        /// <summary>
        /// Change URL of the car brand
        /// </summary>
        /// <param name="id">Id of the car brand</param>
        /// <param name="newUrl">New URL of the car brand</param>
        void ChangeUrl(int id, string newUrl);

        /// <summary>
        /// Change Foundation Year of the car brand
        /// </summary>
        /// <param name="id">Id of the car brand</param>
        /// <param name="newFoundationYear">New Foundation Year of the car brand</param>
        void ChangeFoundationYear(int id, string newFoundationYear);

        /// <summary>
        /// Change Yearly traffic of the car brand
        /// </summary>
        /// <param name="id">Id of the car brand</param>
        /// <param name="newYearlyTraffic">New yearly traffic of the car brand</param>
        void ChangeYearlyTraffic(int id, string newYearlyTraffic);
    }
}
