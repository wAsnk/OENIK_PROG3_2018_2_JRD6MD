// <copyright file="IExtraRepository.cs" company="CarShop">
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
    /// Extra specific functions
    /// </summary>
    public interface IExtraRepository : IRepository<Extra>
    {
        /// <summary>
        /// Change category name of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newCategoryName">New category name of the extra</param>
        /// <param name="carShopDataEntities">Data entities</param>
        void ChangeCategoryName(int id, string newCategoryName, CarShopDataEntities carShopDataEntities);

        /// <summary>
        /// Change  name of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newName">New  name of the extra</param>
        /// <param name="carShopDataEntities">Data entities</param>
        void ChangeName(int id, string newName, CarShopDataEntities carShopDataEntities);

        /// <summary>
        /// Change price of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newPrice">New price of the extra</param>
        /// <param name="carShopDataEntities">Data entities</param>
        void ChangePrice(int id, int newPrice, CarShopDataEntities carShopDataEntities);

        /// <summary>
        /// Change color of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newColor">New color of the extra</param>
        /// <param name="carShopDataEntities">Data entities</param>
        void ChangeColor(int id, string newColor, CarShopDataEntities carShopDataEntities);

        /// <summary>
        /// Change Multiple Usage of the extra
        /// </summary>
        /// <param name="id">Id of the extra</param>
        /// <param name="newMultipleUsage">New Multiple Usage of the extra</param>
        /// <param name="carShopDataEntities">Data entities</param>
        void ChangeMultipleUsage(int id, int newMultipleUsage, CarShopDataEntities carShopDataEntities);
    }
}
