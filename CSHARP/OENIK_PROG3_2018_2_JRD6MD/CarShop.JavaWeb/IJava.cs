// <copyright file="IJava.cs" company="CarShop">
// Copyright (c) CarShop. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CarShop.JavaWeb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    /// <summary>
    /// IJava interface
    /// </summary>
    public interface IJava
    {
        /// <summary>
        /// Gets or sets url
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// Get elements from the JAVA servlet
        /// </summary>
        /// <returns>Returns the elements</returns>
        IEnumerable<JavaData> GetElements();
    }
}
