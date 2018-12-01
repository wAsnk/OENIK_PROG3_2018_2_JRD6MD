// <copyright file="NoIdFoundException.cs" company="CarShop">
// Copyright (c) CarShop. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// No class exception
    /// </summary>
    [Serializable]
    public class NoIdFoundException : Exception, ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoIdFoundException"/> class.
        /// </summary>
        /// <param name="msg">Message of the exception</param>
        /// <param name="value">Object for the exception</param>
        public NoIdFoundException(string msg, object value)
        {
            this.Msg = msg;
            this.ObjectException = value;
        }

        /// <summary>
        /// Gets the message of the exception.
        /// </summary>
        public string Msg { get; }

        /// <summary>
        /// Gets the object of the exception.
        /// </summary>
        public object ObjectException { get; }

        /// <summary>
        /// Serialization
        /// </summary>
        /// <param name="info">Info</param>
        /// <param name="context">Context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TestProperty", this.Msg);
            base.GetObjectData(info, context);
        }
    }
}
