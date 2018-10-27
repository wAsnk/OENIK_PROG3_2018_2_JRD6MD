// <copyright file="IRepository.cs" company="CarShop">
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

    /// <summary>
    /// IRepository Interface
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Create
        /// </summary>
        void Create();

        /// <summary>
        /// Read
        /// </summary>
        void Read();

        /// <summary>
        /// Update
        /// </summary>
        void Update();

        /// <summary>
        /// Delete
        /// </summary>
        void Delete();
    }
}
