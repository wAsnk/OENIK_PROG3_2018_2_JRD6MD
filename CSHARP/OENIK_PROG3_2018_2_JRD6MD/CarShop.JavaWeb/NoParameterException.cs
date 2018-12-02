// <copyright file="NoParameterException.cs" company="CarShop">
// Copyright (c) CarShop. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CarShop.JavaWeb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Exception which is thrown in case of a null object.
    /// </summary>
    [Serializable]
    public class NoParameterException : Exception, ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoParameterException"/> class.
        /// </summary>
        /// <param name="value">The object with null in it</param>
        /// <param name="message">Message for the exception.</param>
        public NoParameterException(object value, string message)
        {
            this.EMessage = message;
            this.NullObject = value;
        }

        /// <summary>
        /// Gets or sets exception message
        /// </summary>
        public string EMessage { get; set; }

        /// <summary>
        /// Gets or sets exception nullobject
        /// </summary>
        public object NullObject { get; set; }

        /// <summary>
        /// Serialization
        /// </summary>
        /// <param name="info">Info</param>
        /// <param name="context">Context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TestProperty", this.EMessage);
            base.GetObjectData(info, context);
        }
    }
}
