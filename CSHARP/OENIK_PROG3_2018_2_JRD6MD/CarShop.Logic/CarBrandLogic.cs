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
        private readonly CarShopDataEntities carShopDataEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarBrandLogic"/> class.
        /// </summary>
        /// <param name="carBrandRepository">Carbrand repo</param>
        /// <param name="modelRepository">Model repo</param>
        /// <param name="extraRepository">Extra repo</param>
        /// <param name="modelExtraSwitchRepository">Modelextraswitch repo</param>
        /// <param name="carShopDataEntities">Carshop data entities</param>
        public CarBrandLogic(
            ICarBrandRepository carBrandRepository,
            IModelRepository modelRepository,
            IExtraRepository extraRepository,
            IModelExtraSwitchRepository modelExtraSwitchRepository,
            CarShopDataEntities carShopDataEntities)
        {
            this.carBrandRepository = carBrandRepository;
            this.modelRepository = modelRepository;
            this.extraRepository = extraRepository;
            this.modelExtraSwitchRepository = modelExtraSwitchRepository;
            this.carShopDataEntities = carShopDataEntities;
        }

        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        public void Create(string mainMenuWaitingKey)
        {
            try
            {
                // "Car Brand", "Models", "Extras", "Model-Extras"
                if (mainMenuWaitingKey == "0")
                {
                    // ICarBrandRepository icarbrandrepo = new CarBrandRepository();
                    Console.Write("New car brand name: ");
                    var brandname = Console.ReadLine();
                    Console.Write("\nNew car brand country name: ");
                    var countryname = Console.ReadLine();
                    Console.Write("\nNew car brand Url: ");
                    var url = Console.ReadLine();
                    Console.Write("\nNew car brand Foundation Year (number e.g.: 1950): ");
                    var foundationyear = int.Parse(Console.ReadLine());
                    Console.Write("\nNew car brand Yearly Traffic: ");
                    var yearlytraffic = Console.ReadLine();
                    CarBrand carBrand = new CarBrand()
                    {
                        Carbrand_Name = brandname,
                        Carbrand_Country_Name = countryname,
                        Carbrand_Url = url,
                        Carbrand_Foundation_Year = foundationyear,
                        Carbrand_Yearly_Traffic = yearlytraffic
                    };
                    this.carBrandRepository.Create(carBrand, this.carShopDataEntities);
                }
                else if (mainMenuWaitingKey == "1")
                {
                    // IModelRepository modelRepository = new ModelRepository();
                    Console.Write("New model carbrand ID (number): ");
                    var carbrandid = int.Parse(Console.ReadLine());
                    Console.Write("New model name: ");
                    var modelname = Console.ReadLine();
                    Console.Write("New model release day e.g. 2018-11-23: ");
                    var releaseday = DateTime.Parse(Console.ReadLine());
                    Console.Write("New model engine volume (number) e.g. 1900 : ");
                    var enginevolume = int.Parse(Console.ReadLine());
                    Console.Write("New model horsepower (number) e.g. 75 : ");
                    var horsepower = int.Parse(Console.ReadLine());
                    Console.Write("New model base price (number) e.g. 50000: ");
                    var baseprice = int.Parse(Console.ReadLine());

                    Model model = new Model()
                    {
                        Carbrand_Id = carbrandid,
                        Model_Name = modelname,
                        Model_Release_Day = releaseday,
                        Model_Engine_Volume = enginevolume,
                        Model_Horsepower = horsepower,
                        Model_Base_Price = baseprice
                    };
                    this.modelRepository.Create(model, this.carShopDataEntities);
                }
                else if (mainMenuWaitingKey == "2")
                {
                    // IExtraRepository extraRepository = new ExtraRepository();
                    Console.Write("New extra caregory name: ");
                    var categoryname = Console.ReadLine();
                    Console.Write("New extra name: ");
                    var extraname = Console.ReadLine();
                    Console.Write("New extra price (number) e.g. 3000: ");
                    var extraprice = int.Parse(Console.ReadLine());
                    Console.Write("New extra color: ");
                    var extracolor = Console.ReadLine();
                    Console.Write("New extra multiple usage (0 == no, 1 == yes): ");
                    var multipleUsage = int.Parse(Console.ReadLine());
                    Extra extra = new Extra()
                    {
                        Extra_Category_Name = categoryname,
                        Extra_Name = extraname,
                        Extra_Price = extraprice,
                        Extra_Color = extracolor,
                        Extra_Multiple_Usage = multipleUsage
                    };
                    this.extraRepository.Create(extra, this.carShopDataEntities);
                }
                else if (mainMenuWaitingKey == "3")
                {
                    // IModelExtraSwitchRepository modelExtraSwitchRepository = new ModelExtraSwitchRepository();
                    Console.Write("New Model_Id (number): ");
                    var modelid = int.Parse(Console.ReadLine());
                    Console.Write("New Extra_Id (number): ");
                    var extraid = int.Parse(Console.ReadLine());
                    ModelExtraswitch modelExtraswitch = new ModelExtraswitch()
                    {
                        Model_Id = modelid,
                        Extra_Id = extraid
                    };
                    this.modelExtraSwitchRepository.Create(modelExtraswitch, this.carShopDataEntities);
                }
            }
            catch (NullObjectException exception)
            {
                Console.WriteLine(exception.EMessage + " : " + exception.NullObject);
            }
            catch (FormatException exception)
            {
                Console.WriteLine("\n\nYou gave wrong format to the previous table data, try again!\n\nException message: " + exception.Message + "\n\n");
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
                // ICarBrandRepository icarbrandrepo = new CarBrandRepository();
                IQueryable<string> everyCarbrand = this.carBrandRepository.ReadAll(this.carShopDataEntities)
                    .Select(x =>
                    x.Carbrand_Id + "\t"
                    + x.Carbrand_Name + "\t"
                    + x.Carbrand_Country_Name + "\t"
                    + x.Carbrand_Url + "\t"
                    + x.Carbrand_Foundation_Year + "\t"
                    + x.Carbrand_Yearly_Traffic);
                Console.WriteLine("Carbrand_Id \t Carbrand_Name \t Carbrand_Url \t Carbrand_Foundation_Year \t Carbrand_Yearly_Traffic");
                return everyCarbrand;
            }
            else if (mainMenuWaitingKey == "1")
            {
                // IModelRepository imodelrepo = new ModelRepository();
                IQueryable<string> everyModel = this.modelRepository.ReadAll(this.carShopDataEntities)
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
                // IExtraRepository iextrarepo = new ExtraRepository();
                IQueryable<string> everyExtra = this.extraRepository.ReadAll(this.carShopDataEntities).Select(x => x.Extra_Id + "\t" + x.Extra_Category_Name
                + "\t" + x.Extra_Name + "\t" + x.Extra_Price + "\t" + x.Extra_Color + "\t" + x.Extra_Multiple_Usage);

                return everyExtra;
            }
            else if (mainMenuWaitingKey == "3")
            {
                // IModelExtraSwitchRepository imodelExtraSwitch = new ModelExtraSwitchRepository();
                IQueryable<string> everyExtraSwitch = this.modelExtraSwitchRepository.ReadAll(this.carShopDataEntities)
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
                // ICarBrandRepository icarbrandrepo = new CarBrandRepository();
                Console.WriteLine("Carbrand ID to be deleted: ");
                var todelete = int.Parse(Console.ReadLine());
                CarBrand carBrandToDelete = this.carBrandRepository.ReadAll(this.carShopDataEntities).FirstOrDefault(x => x.Carbrand_Id == todelete);
                this.carBrandRepository.Delete(carBrandToDelete, this.carShopDataEntities);
            }
            else if (mainMenuWaitingKey == "1")
            {
                // IModelRepository modelRepository = new ModelRepository();
                Console.WriteLine("Model ID to be deleted: ");
                var todelete = int.Parse(Console.ReadLine());
                Model modelToDelete = this.modelRepository.ReadAll(this.carShopDataEntities).FirstOrDefault(x => x.Model_Id == todelete);
                this.modelRepository.Delete(modelToDelete, this.carShopDataEntities);
            }
            else if (mainMenuWaitingKey == "2")
            {
                // IExtraRepository extraRepository = new ExtraRepository();
                Console.WriteLine("Extra ID to be deleted: ");
                var todelete = int.Parse(Console.ReadLine());
                Extra extraToDelete = this.extraRepository.ReadAll(this.carShopDataEntities).FirstOrDefault(x => x.Extra_Id == todelete);
                this.extraRepository.Delete(extraToDelete, this.carShopDataEntities);
            }
            else if (mainMenuWaitingKey == "3")
            {
                // IModelExtraSwitchRepository modelExtraSwitchRepository = new ModelExtraSwitchRepository();
                Console.WriteLine("ModelExtraSwitch ID to be deleted: ");
                var todelete = int.Parse(Console.ReadLine());
                ModelExtraswitch modelExtraSwitchToDelete = this.modelExtraSwitchRepository.ReadAll(this.carShopDataEntities).FirstOrDefault(x => x.ModelExtraswitch_Id == todelete);
                this.modelExtraSwitchRepository.Delete(modelExtraSwitchToDelete, this.carShopDataEntities);
            }
        }

        /// <summary>
        /// Updates a parameter of a database entity.
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        public void Update(string mainMenuWaitingKey)
        {
            // { "Car Brand", "Models", "Extras", "Model-Extras" };
            if (mainMenuWaitingKey == "0")
            {
                Console.WriteLine("What do you want to update?");
                Console.WriteLine("1. Carbrand_Name");
                Console.WriteLine("2. Carbrand_Country_Name");
                Console.WriteLine("3. Carbrand_Url");
                Console.WriteLine("4. Carbrand_Foundation_Year");
                Console.WriteLine("5. Carbrand_Yearly_Traffic");
                Console.Write("Answer (1-5)  [Only 1st implemented]: ");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.Write("Update Carbrand_Yearly_Traffic of Car Brand ID: ");
                    var id = int.Parse(Console.ReadLine());
                    Console.Write("New Yearly Traffic: ");
                    var yearlyTraffic = Console.ReadLine();

                    // ICarBrandRepository icarBrandRepository = new CarBrandRepository();
                    this.carBrandRepository.ChangeYearlyTraffic(id, yearlyTraffic, this.carShopDataEntities);
                }
                else if (answer == "2")
                {
                    Console.WriteLine("Not implemented.");
                }
                else if (answer == "3")
                {
                    Console.WriteLine("Not implemented.");
                }
                else if (answer == "4")
                {
                    Console.WriteLine("Not implemented.");
                }
                else if (answer == "5")
                {
                    Console.WriteLine("Not implemented.");
                }
            }
            else if (mainMenuWaitingKey == "1")
            {
                Console.WriteLine("What do you want to update?");
                Console.WriteLine("1. Carbrand_id");
                Console.WriteLine("2. Model_Name");
                Console.WriteLine("3. Model_Release_Day");
                Console.WriteLine("4. Model_Engine_Volume");
                Console.WriteLine("5. Model_Horsepower");
                Console.WriteLine("6. Model_Base_Price");
                Console.Write("Answer (1-6) [Only 6th implemented]: ");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.WriteLine("Not implemented.");
                }
                else if (answer == "2")
                {
                    Console.WriteLine("Not implemented.");
                }
                else if (answer == "3")
                {
                    Console.WriteLine("Not implemented.");
                }
                else if (answer == "4")
                {
                    Console.WriteLine("Not implemented.");
                }
                else if (answer == "5")
                {
                    Console.WriteLine("Not implemented.");
                }
                else if (answer == "6")
                {
                    Console.Write("Update Model_Base_Price of Model ID: ");
                    var id = int.Parse(Console.ReadLine());
                    Console.Write("New Model_Base_Price: ");
                    var baseprice = int.Parse(Console.ReadLine());

                    // IModelRepository imodelRepository = new ModelRepository();
                    this.modelRepository.ChangeBasePrice(id, baseprice, this.carShopDataEntities);
                }
            }
            else if (mainMenuWaitingKey == "2")
            {
                Console.WriteLine("What do you want to update?");
                Console.WriteLine("1. Extra_Category_Name");
                Console.WriteLine("2. Extra_Name");
                Console.WriteLine("3. Extra_Price");
                Console.WriteLine("4. Extra_Color");
                Console.WriteLine("5. Extra_Multiple_Usage");
                Console.Write("Answer (1-5) [Only 3rd implemented]: ");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.WriteLine("Not implemented.");
                }
                else if (answer == "2")
                {
                    Console.WriteLine("Not implemented.");
                }
                else if (answer == "3")
                {
                    Console.Write("Update Extra of Extra ID: ");
                    var id = int.Parse(Console.ReadLine());
                    Console.Write("New Extra_Price: ");
                    var extraprice = int.Parse(Console.ReadLine());

                    // IExtraRepository iextraRepository = new ExtraRepository();
                    this.extraRepository.ChangePrice(id, extraprice, this.carShopDataEntities);
                }
                else if (answer == "4")
                {
                    Console.WriteLine("Not implemented.");
                }
                else if (answer == "5")
                {
                    Console.WriteLine("Not implemented.");
                }
                else if (answer == "6")
                {
                    Console.WriteLine("Not implemented.");
                }
            }
            else if (mainMenuWaitingKey == "3")
            {
                Console.WriteLine("What do you want to update?");
                Console.WriteLine("1. Model_Id");
                Console.WriteLine("2. Extra_Id");
                Console.Write("Answer (1-2): ");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.Write("Update Model_Id of ModelExtraSwitch ID: ");
                    var id = int.Parse(Console.ReadLine());
                    Console.Write("New Model_Id: ");
                    var modelid = int.Parse(Console.ReadLine());

                    // IModelExtraSwitchRepository imodelExtraSwitchRepository = new ModelExtraSwitchRepository();
                    this.modelExtraSwitchRepository.ChangeModelId(id, modelid, this.carShopDataEntities);
                }
                else if (answer == "2")
                {
                    Console.Write("Update Extra_Id of ModelExtraSwitch ID: ");
                    var id = int.Parse(Console.ReadLine());
                    Console.Write("New Extra_Id: ");
                    var extraid = int.Parse(Console.ReadLine());

                    // IModelExtraSwitchRepository imodelExtraSwitchRepository = new ModelExtraSwitchRepository();
                    this.modelExtraSwitchRepository.ChangeExtraId(id, extraid, this.carShopDataEntities);
                }
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
