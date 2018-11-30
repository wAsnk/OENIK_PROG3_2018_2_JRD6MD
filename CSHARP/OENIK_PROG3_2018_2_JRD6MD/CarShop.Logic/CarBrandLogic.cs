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
    /// Business logic class
    /// </summary>
    public class CarBrandLogic : ILogic
    {
        private readonly ICarBrandRepository carBrandRepository;
        private readonly IModelRepository modelRepository;
        private readonly IExtraRepository extraRepository;
        private readonly IModelExtraSwitchRepository modelExtraSwitchRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarBrandLogic"/> class.
        /// </summary>
        /// <param name="carBrandRepository">Carbrand repo</param>
        /// <param name="modelRepository">Model repo</param>
        /// <param name="extraRepository">Extra repo</param>
        /// <param name="modelExtraSwitchRepository">Modelextraswitch repo</param>
        public CarBrandLogic(
            ICarBrandRepository carBrandRepository,
            IModelRepository modelRepository,
            IExtraRepository extraRepository,
            IModelExtraSwitchRepository modelExtraSwitchRepository)
        {
            this.carBrandRepository = carBrandRepository;
            this.modelRepository = modelRepository;
            this.extraRepository = extraRepository;
            this.modelExtraSwitchRepository = modelExtraSwitchRepository;
        }

        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="value">Object to create</param>
        public void Create(object value)
        {
            CarBrand carBrand = value as CarBrand;
            Model model = value as Model;
            Extra extra = value as Extra;
            ModelExtraswitch modelExtraswitch = value as ModelExtraswitch;

            if (carBrand != null)
            {
                this.carBrandRepository.Create(carBrand);
            }
            else if (model != null)
            {
                this.modelRepository.Create(model);
            }
            else if (extra != null)
            {
                this.extraRepository.Create(extra);
            }
            else if (modelExtraswitch != null)
            {
                this.modelExtraSwitchRepository.Create(modelExtraswitch);
            }
            else
            {
                throw new NoClassException("There is no such a table.", value);
            }
        }

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <returns>The wanted type of entities</returns>
        public IQueryable ReadAll(string mainMenuWaitingKey)
        {
            // { "Car Brand", "Models", "Extras", "Model-Extras" };
            if (mainMenuWaitingKey == "0")
            {
                IQueryable<string> everyCarbrand = this.carBrandRepository.ReadAll()
                    .Select(x =>
                    x.Carbrand_Id + "\t"
                    + x.Carbrand_Name + "\t"
                    + x.Carbrand_Country_Name + "\t"
                    + x.Carbrand_Url + "\t"
                    + x.Carbrand_Foundation_Year + "\t"
                    + x.Carbrand_Yearly_Traffic);
                return everyCarbrand;
            }
            else if (mainMenuWaitingKey == "1")
            {
                IQueryable<string> everyModel = this.modelRepository.ReadAll()
                    .Select(x =>
                    x.Model_Id + "\t"
                    + x.Carbrand_Id + "\t"
                    + x.Model_Name + "\t"
                    + x.Model_Release_Day + "\t"
                    + x.Model_Engine_Volume + "\t"
                    + x.Model_Horsepower + "\t"
                    + x.Model_Base_Price);

                return everyModel;
            }
            else if (mainMenuWaitingKey == "2")
            {
                IQueryable<string> everyExtra = this.extraRepository.ReadAll()
                    .Select(x =>
                    x.Extra_Id + "\t"
                    + x.Extra_Category_Name + "\t"
                    + x.Extra_Name + "\t"
                    + x.Extra_Price + "\t"
                    + x.Extra_Color + "\t"
                    + x.Extra_Multiple_Usage);

                return everyExtra;
            }
            else if (mainMenuWaitingKey == "3")
            {
                IQueryable<string> everyExtraSwitch = this.modelExtraSwitchRepository.ReadAll()
                    .Select(x =>
                    x.ModelExtraswitch_Id + "\t"
                    + x.Model_Id + "\t"
                    + x.Extra_Id);

                return everyExtraSwitch;
            }

            return null;
        }

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        public void Delete(string mainMenuWaitingKey)
        {
            if (mainMenuWaitingKey == "0")
            {
                Console.WriteLine("Carbrand ID to be deleted: ");
                var todelete = int.Parse(Console.ReadLine());
                CarBrand carBrandToDelete = this.carBrandRepository.ReadAll().FirstOrDefault(x => x.Carbrand_Id == todelete);
                this.carBrandRepository.Delete(carBrandToDelete);
            }
            else if (mainMenuWaitingKey == "1")
            {
                Console.WriteLine("Model ID to be deleted: ");
                var todelete = int.Parse(Console.ReadLine());
                Model modelToDelete = this.modelRepository.ReadAll().FirstOrDefault(x => x.Model_Id == todelete);
                this.modelRepository.Delete(modelToDelete);
            }
            else if (mainMenuWaitingKey == "2")
            {
                Console.WriteLine("Extra ID to be deleted: ");
                var todelete = int.Parse(Console.ReadLine());
                Extra extraToDelete = this.extraRepository.ReadAll().FirstOrDefault(x => x.Extra_Id == todelete);
                this.extraRepository.Delete(extraToDelete);
            }
            else if (mainMenuWaitingKey == "3")
            {
                Console.WriteLine("ModelExtraSwitch ID to be deleted: ");
                var todelete = int.Parse(Console.ReadLine());
                ModelExtraswitch modelExtraSwitchToDelete = this.modelExtraSwitchRepository.ReadAll().FirstOrDefault(x => x.ModelExtraswitch_Id == todelete);
                this.modelExtraSwitchRepository.Delete(modelExtraSwitchToDelete);
            }
        }

        /// <summary>
        /// Updates a parameter of a database entity.
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <param name="id">Id of the entity</param>
        /// <param name="updateData">Update date to be used</param>
        public void Update(string mainMenuWaitingKey, int id, string updateData)
        {
            if (mainMenuWaitingKey == "0")
            {
                this.carBrandRepository.ChangeYearlyTraffic(id, updateData);
            }
            else if (mainMenuWaitingKey == "1")
            {
                this.modelRepository.ChangeBasePrice(id, int.Parse(updateData));
            }
            else if (mainMenuWaitingKey == "2")
            {
                this.extraRepository.ChangePrice(id, int.Parse(updateData));
            }
            else if (mainMenuWaitingKey == "3")
            {
                this.modelExtraSwitchRepository.ChangeExtraId(id, int.Parse(updateData));
            }
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
