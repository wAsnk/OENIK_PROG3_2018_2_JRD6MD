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
    using System.Xml.Linq;

    /// <summary>
    /// The class for the JAVA endpoint.
    /// </summary>
    public class Java : IJava
    {
        private string url;

        /// <summary>
        /// Initializes a new instance of the <see cref="Java"/> class.
        /// </summary>
        /// <param name="url">Url of the request.</param>
        public Java(string url)
        {
            this.url = url;
        }

        /// <summary>
        /// Get elements from the JAVA servlet
        /// </summary>
        /// <returns>Returns the elements</returns>
        public IEnumerable<JavaData> GetElements()
        {
            XDocument xDoc = this.DownloadFeed(this.url);
            var cars = xDoc.Element("cars").Elements("car");

            IEnumerable<JavaData> javas = cars.Select(x => new JavaData()
            {
                Carname = x.Element("carbrand").Value,
                Price = x.Element("price").Value,
                Name = x.Element("name").Value
            });

            return javas;
        }

        /// <summary>
        /// Get data from the url parameter
        /// </summary>
        /// <param name="source">The parameter where the data is pulled from.</param>
        /// <returns>Returns XDocument element</returns>
        private XDocument DownloadFeed(string source)
        {
            string rssString = string.Empty;
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    rssString = webClient.DownloadString(source);
                    return XDocument.Parse(rssString);
                }
            }
            catch (System.Xml.XmlException exception)
            {
                throw new NoParameterException(exception, rssString);
            }
        }
    }
}
