// <copyright file="Java.cs" company="CarShop">
// Copyright (c) CarShop. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CarShop.JavaWeb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The class for the JAVA endpoint.
    /// </summary>
    public static class Java
    {
        /// <summary>
        /// Get data from the url parameter
        /// </summary>
        /// <param name="url">The parameter where the data is pulled from.</param>
        public static void GetData(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                string temp = webClient.DownloadString(url);
                Console.WriteLine(temp);
            }
        }
    }
}
