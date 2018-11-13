// <copyright file="CarBrandLogic.cs" company="CarShop">
// Copyright (c) CarShop. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;
    using CarShop.Repository;

    /// <summary>
    /// onreoi
    /// </summary>
    public class CarBrandLogic : ILogic
    {
        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        public void Create(string mainMenuWaitingKey)
        {
            // "Car Brand", "Models", "Extras", "Model-Extras"
            if (mainMenuWaitingKey == "0")
            {
                ICarBrandRepository icarbrandrepo = new CarBrandRepository();
                Console.Write("New car brand name:");
                var brandname = Console.ReadLine();
                Console.Write("\nNew car brand country name:");
                var countryname = Console.ReadLine();
                Console.Write("\nNew car brand Url:");
                var url = Console.ReadLine();
                Console.Write("\nNew car brand Foundation Year:");
                var foundationyear = int.Parse(Console.ReadLine());
                Console.Write("\nNew car brand Yearly Traffic");
                var yearlytraffic = Console.ReadLine();
                CarBrand carBrand = new CarBrand()
                {
                    Carbrand_Name = brandname,
                    Carbrand_Country_Name = countryname,
                    Carbrand_Url = url,
                    Carbrand_Foundation_Year = foundationyear,
                    Carbrand_Yearly_Traffic = yearlytraffic
                };
                icarbrandrepo.Create(carBrand);
            }
        }

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <returns>The wanted type of entities</returns>
        public IQueryable ReadAll(string mainMenuWaitingKey)
        {
            if (mainMenuWaitingKey == "0")
            {
                ICarBrandRepository icarbrandrepo = new CarBrandRepository();
                var everyCarbrand = icarbrandrepo.ReadAll();
                return everyCarbrand;
            }

            return null;
        }

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        public void Delete()
        {
        }

        /// <summary>
        /// Updates a parameter of a database entity.
        /// </summary>
        public void Update()
        {
        }

        /// <summary>
        /// Gives cars full price
        /// </summary>
        public void CarsFullPrice()
        {
        }

        /// <summary>
        /// Gives the Average Base Price Per Brands
        /// </summary>
        public void AverageBasePrice_PerBrands()
        {
        }

        /// <summary>
        /// Gives beck the Extra categories usage
        /// </summary>
        public void ExtraCategoryUseage()
        {
        }

        /// <summary>
        /// Request price offer using JAVA
        /// </summary>
        public void RequestPriceOffer()
        {
        }
    }
}
