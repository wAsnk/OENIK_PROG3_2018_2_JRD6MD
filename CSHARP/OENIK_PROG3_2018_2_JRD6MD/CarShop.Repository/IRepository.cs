﻿// <copyright file="IRepository.cs" company="CarShop">
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
    /// Repository interface for CRUD
    /// </summary>
    /// <typeparam name="T">Type of the class</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="newItem">Gives the new item which needs to be inserted.</param>
        /// <param name="carShopDataEntities">Data entities</param>
        void Create(T newItem, CarShopDataEntities carShopDataEntities);

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <param name="carShopDataEntities">Data entities</param>
        /// <returns>The wanted type of entities</returns>
        IQueryable<T> ReadAll(CarShopDataEntities carShopDataEntities);

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        /// <param name="itemToBeDeleted">The item which wanted to be deleted</param>
        /// <param name="carShopDataEntities">Data entities</param>
        void Delete(T itemToBeDeleted, CarShopDataEntities carShopDataEntities);
    }
}
