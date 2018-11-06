// <copyright file="IModelRepository.cs" company="CarShop">
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
    /// Model specific functions
    /// </summary>
    public interface IModelRepository : IRepository<Model>
    {
        /// <summary>
        /// Change name of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newName">New  name of the model</param>
        void ChangeName(int id, string newName);

        /// <summary>
        /// Change Release Day of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newReleaseDay">New Release Day of the model</param>
        void ChangeReleaseDay(int id, string newReleaseDay);

        /// <summary>
        /// Change Engine Volume of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newEngineVolume">New Engine Volume of the model</param>
        void ChangeEngineVolume(int id, int newEngineVolume);

        /// <summary>
        /// Change Horse Power of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newHorsePower">New Horse Power of the model</param>
        void ChangeHorsePower(int id, int newHorsePower);

        /// <summary>
        /// Change Bas ePrice of the model
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <param name="newBasePrice">New Base Price of the model</param>
        void ChangeBasePrice(int id, int newBasePrice);
    }
}
