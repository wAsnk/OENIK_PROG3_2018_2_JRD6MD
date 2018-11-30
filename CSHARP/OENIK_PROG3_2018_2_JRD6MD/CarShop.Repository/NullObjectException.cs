// <copyright file="NullObjectException.cs" company="CarShop">
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
    /// Exception which is thrown in case of a null object.
    /// </summary>
    public class NullObjectException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullObjectException"/> class.
        /// </summary>
        /// <param name="nullObject">The object with null in it</param>
        /// <param name="message">Message for the exception.</param>
        public NullObjectException(object nullObject, string message)
        {
            this.EMessage = message;
            this.NullObject = nullObject;
        }

        /// <summary>
        /// Gets or sets exception message
        /// </summary>
        public string EMessage { get; set; }

        /// <summary>
        /// Gets or sets exception nullobject
        /// </summary>
        public object NullObject { get; set; }
    }
}
