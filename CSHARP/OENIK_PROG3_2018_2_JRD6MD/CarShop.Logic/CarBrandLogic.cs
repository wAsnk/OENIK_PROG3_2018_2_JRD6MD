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
        /// <summary>
        /// Create a new item in the database, CREATE
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <param name="carShopDataEntities">Data entities</param>
        public void Create(string mainMenuWaitingKey, CarShopDataEntities carShopDataEntities)
        {
            // "Car Brand", "Models", "Extras", "Model-Extras"
            if (mainMenuWaitingKey == "0")
            {
                ICarBrandRepository icarbrandrepo = new CarBrandRepository();
                Console.Write("New car brand name: ");
                var brandname = Console.ReadLine();
                Console.Write("\nNew car brand country name: ");
                var countryname = Console.ReadLine();
                Console.Write("\nNew car brand Url: ");
                var url = Console.ReadLine();
                Console.Write("\nNew car brand Foundation Year: ");
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
                icarbrandrepo.Create(carBrand, carShopDataEntities);
            }
            else if (mainMenuWaitingKey == "1")
            {
                IModelRepository modelRepository = new ModelRepository();
                Console.Write("New model carbrand ID: ");
                var carbrandid = int.Parse(Console.ReadLine());
                Console.Write("New model name: ");
                var modelname = Console.ReadLine();
                Console.Write("New model release day: e.g. 2018-11-23: ");
                var releaseday = DateTime.Parse(Console.ReadLine());
                Console.Write("New model engine volume: ");
                var enginevolume = int.Parse(Console.ReadLine());
                Console.Write("New model horsepower: ");
                var horsepower = int.Parse(Console.ReadLine());
                Console.Write("New model base price: ");
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
                modelRepository.Create(model, carShopDataEntities);
            }
            else if (mainMenuWaitingKey == "2")
            {
                IExtraRepository extraRepository = new ExtraRepository();
                Console.Write("New extra caregory name: ");
                var categoryname = Console.ReadLine();
                Console.Write("New extra name: ");
                var extraname = Console.ReadLine();
                Console.Write("New extra price: ");
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
                extraRepository.Create(extra, carShopDataEntities);
            }
            else if (mainMenuWaitingKey == "3")
            {
                IModelExtraSwitchRepository modelExtraSwitchRepository = new ModelExtraSwitchRepository();
                Console.Write("New Model_Id: ");
                var modelid = int.Parse(Console.ReadLine());
                Console.Write("New Extra_Id: ");
                var extraid = int.Parse(Console.ReadLine());
                ModelExtraswitch modelExtraswitch = new ModelExtraswitch()
                {
                    Model_Id = modelid,
                    Extra_Id = extraid
                };
                modelExtraSwitchRepository.Create(modelExtraswitch, carShopDataEntities);
            }
        }

        /// <summary>
        /// Get all entities from the database, READ
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <param name="carShopDataEntities">Data entity</param>
        /// <returns>The wanted type of entities</returns>
        public IQueryable ReadAll(string mainMenuWaitingKey, CarShopDataEntities carShopDataEntities)
        {
            // { "Car Brand", "Models", "Extras", "Model-Extras" };
            if (mainMenuWaitingKey == "0")
            {
                ICarBrandRepository icarbrandrepo = new CarBrandRepository();
                IQueryable<string> everyCarbrand = icarbrandrepo.ReadAll(carShopDataEntities)
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
                IModelRepository imodelrepo = new ModelRepository();
                IQueryable<string> everyModel = imodelrepo.ReadAll(carShopDataEntities)
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
                IExtraRepository iextrarepo = new ExtraRepository();
                IQueryable<string> everyExtra = iextrarepo.ReadAll(carShopDataEntities).Select(x => x.Extra_Id + "\t" + x.Extra_Category_Name
                + "\t" + x.Extra_Name + "\t" + x.Extra_Price + "\t" + x.Extra_Color + "\t" + x.Extra_Multiple_Usage);

                return everyExtra;
            }
            else if (mainMenuWaitingKey == "3")
            {
                IModelExtraSwitchRepository imodelExtraSwitch = new ModelExtraSwitchRepository();
                IQueryable<string> everyExtraSwitch = imodelExtraSwitch.ReadAll(carShopDataEntities)
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
        /// <param name="carShopDataEntities">Data entity</param>
        public void Delete(string mainMenuWaitingKey, CarShopDataEntities carShopDataEntities)
        {
            if (mainMenuWaitingKey == "0")
            {
                ICarBrandRepository icarbrandrepo = new CarBrandRepository();
                Console.WriteLine("Carbrand ID to be deleted: ");
                var todelete = int.Parse(Console.ReadLine());
                CarBrand carBrandToDelete = icarbrandrepo.ReadAll(carShopDataEntities).FirstOrDefault(x => x.Carbrand_Id == todelete);
                icarbrandrepo.Delete(carBrandToDelete, carShopDataEntities);
            }
            else if (mainMenuWaitingKey == "1")
            {
                IModelRepository modelRepository = new ModelRepository();
                Console.WriteLine("Model ID to be deleted: ");
                var todelete = int.Parse(Console.ReadLine());
                Model modelToDelete = modelRepository.ReadAll(carShopDataEntities).FirstOrDefault(x => x.Model_Id == todelete);
                modelRepository.Delete(modelToDelete, carShopDataEntities);
            }
            else if (mainMenuWaitingKey == "2")
            {
                IExtraRepository extraRepository = new ExtraRepository();
                Console.WriteLine("Extra ID to be deleted: ");
                var todelete = int.Parse(Console.ReadLine());
                Extra extraToDelete = extraRepository.ReadAll(carShopDataEntities).FirstOrDefault(x => x.Extra_Id == todelete);
                extraRepository.Delete(extraToDelete, carShopDataEntities);
            }
            else if (mainMenuWaitingKey == "3")
            {
                IModelExtraSwitchRepository modelExtraSwitchRepository = new ModelExtraSwitchRepository();
                Console.WriteLine("ModelExtraSwitch ID to be deleted: ");
                var todelete = int.Parse(Console.ReadLine());
                ModelExtraswitch modelExtraSwitchToDelete = modelExtraSwitchRepository.ReadAll(carShopDataEntities).FirstOrDefault(x => x.ModelExtraswitch_Id == todelete);
                modelExtraSwitchRepository.Delete(modelExtraSwitchToDelete, carShopDataEntities);
            }
        }

        /// <summary>
        /// Updates a parameter of a database entity.
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <param name="carShopDataEntities">Data entity</param>
        public void Update(string mainMenuWaitingKey, CarShopDataEntities carShopDataEntities)
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
                    ICarBrandRepository icarBrandRepository = new CarBrandRepository();
                    icarBrandRepository.ChangeYearlyTraffic(id, yearlyTraffic, carShopDataEntities);
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
                    IModelRepository imodelRepository = new ModelRepository();
                    imodelRepository.ChangeBasePrice(id, baseprice, carShopDataEntities);
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
                    IExtraRepository iextraRepository = new ExtraRepository();
                    iextraRepository.ChangePrice(id, extraprice, carShopDataEntities);
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
                    IModelExtraSwitchRepository imodelExtraSwitchRepository = new ModelExtraSwitchRepository();
                    imodelExtraSwitchRepository.ChangeModelId(id, modelid, carShopDataEntities);
                }
                else if (answer == "2")
                {
                    Console.Write("Update Extra_Id of ModelExtraSwitch ID: ");
                    var id = int.Parse(Console.ReadLine());
                    Console.Write("New Extra_Id: ");
                    var extraid = int.Parse(Console.ReadLine());
                    IModelExtraSwitchRepository imodelExtraSwitchRepository = new ModelExtraSwitchRepository();
                    imodelExtraSwitchRepository.ChangeExtraId(id, extraid, carShopDataEntities);
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
