// <copyright file="IModelExtraSwitchRepository.cs" company="CarShop">
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
    /// ModelExtraSwitch specific functions
    /// </summary>
    public interface IModelExtraSwitchRepository : IRepository<ModelExtraswitch>
    {
        /// <summary>
        /// Change name of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newId">>New  ID of the modelextraswitch</param>
        /// <param name="carShopDataEntities">Data entities</param>
        void ChangeModelId(int id, int newId, CarShopDataEntities carShopDataEntities);

        /// <summary>
        /// Change name of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newId">New  ID of the modelextraswitch</param>
        /// <param name="carShopDataEntities">Data entities</param>
        void ChangeExtraId(int id, int newId, CarShopDataEntities carShopDataEntities);
    }
}
