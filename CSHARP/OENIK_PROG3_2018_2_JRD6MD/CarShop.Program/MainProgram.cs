// <copyright file="MainProgram.cs" company="CarShop">
// Copyright (c) CarShop. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CarShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;
    using CarShop.JavaWeb;
    using CarShop.Logic;
    using CarShop.Repository;

    /// <summary>
    /// The program start here and loads needed dlls.
    /// </summary>
    public static class MainProgram
    {
        /// <summary>
        /// Main program runs here
        /// </summary>
        public static void Main()
        {
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                ICarBrandRepository carBrandRepository = new CarBrandRepository(carShopDataEntities);
                IModelRepository modelRepository = new ModelRepository(carShopDataEntities);
                IExtraRepository extraRepository = new ExtraRepository(carShopDataEntities);
                IModelExtraSwitchRepository modelExtraSwitchRepository = new ModelExtraSwitchRepository(carShopDataEntities);

                ILogic logic = new CarBrandLogic(carBrandRepository, modelRepository, extraRepository, modelExtraSwitchRepository);

                ConsoleMenu(logic);
            }
        }

        /// <summary>
        /// Console Menu
        /// </summary>
        /// <param name="logic">Business logic interface parameter</param>
        public static void ConsoleMenu(ILogic logic)
        {
            string menuBordersTopAndBottom = "---------------------------------------";
            string menuBordersLeft = "|\t";
            string menuBordersRight = "|";
            string mainMenuWaitingKey = string.Empty;
            string subMenuWaitingKey = string.Empty;
            string tabulatorAndText = "{0,-40}";
            string[] menuElements = { "Car Brand", "Models", "Extras", "Model-Extras" };
            string[] subMenuElements = { "Create", "Read", "Update", "Delete" };
            while (mainMenuWaitingKey != "x")
            {
                Console.Clear();
                Console.WriteLine("\n" + menuBordersTopAndBottom);
                for (int i = 0; i < menuElements.Length; i++)
                {
                    Console.WriteLine(menuBordersLeft + tabulatorAndText + menuBordersRight, $"{i}.) {menuElements[i]} Operations");
                }

                Console.WriteLine(menuBordersLeft + tabulatorAndText + menuBordersRight, string.Empty);

                Console.WriteLine(menuBordersLeft + tabulatorAndText + menuBordersRight, $"a.) Cars full price");
                Console.WriteLine(menuBordersLeft + tabulatorAndText + menuBordersRight, $"b.) Average base price per brands.");
                Console.WriteLine(menuBordersLeft + tabulatorAndText + menuBordersRight, $"c.) Extra categories usage.");
                Console.WriteLine(menuBordersLeft + tabulatorAndText + menuBordersRight, $"d.) Request price offer.");

                Console.WriteLine(menuBordersLeft + tabulatorAndText + menuBordersRight, string.Empty);

                Console.WriteLine(menuBordersLeft + tabulatorAndText + menuBordersRight, "x.) To Exit");
                Console.Write(menuBordersLeft + "Select Menu: ");
                mainMenuWaitingKey = Console.ReadLine();
                if (mainMenuWaitingKey == "0"
                    || mainMenuWaitingKey == "1"
                    || mainMenuWaitingKey == "2"
                    || mainMenuWaitingKey == "3")
                {
                    Console.Clear();
                    for (int i = 0; i < subMenuElements.Length; i++)
                    {
                        Console.WriteLine(menuBordersLeft + "{0,-30}" + menuBordersRight, $"{i}.) {subMenuElements[i]}");
                    }

                    Console.Write(menuBordersLeft + "Select Menu: ");
                    subMenuWaitingKey = Console.ReadLine();

                    switch (subMenuWaitingKey)
                    {
                        // "Create", "Read", "Update", "Delete"
                        case "0":
                            {
                                // Create
                                Console.Clear();
                                GetInfosForNewElement(mainMenuWaitingKey, logic);
                                Console.WriteLine("Press enter to return to the main menu.");
                                Console.ReadLine();
                                break;
                            }

                        case "1":
                            {
                                // Read
                                Console.Clear();
                                WriteArray(logic.ReadAll(mainMenuWaitingKey));
                                Console.WriteLine("Press enter to return to the main menu.");
                                Console.ReadLine();

                                break;
                            }

                        case "2":
                            {
                                // Update
                                Console.Clear();
                                UpdateParameters(mainMenuWaitingKey, logic);
                                Console.WriteLine("Press enter to return to the main menu.");
                                Console.ReadLine();

                                break;
                            }

                        case "3":
                            {
                                // Delete
                                Console.Clear();
                                DeleteParameters(mainMenuWaitingKey, logic);
                                Console.WriteLine("Press enter to return to the main menu.");
                                Console.ReadLine();

                                break;
                            }

                        case "x":
                            {
                                break;
                            }

                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("There is no such menu.");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                    }
                }
                else if (mainMenuWaitingKey == "a"
                    || mainMenuWaitingKey == "b"
                    || mainMenuWaitingKey == "c"
                    || mainMenuWaitingKey == "d")
                {
                    switch (mainMenuWaitingKey)
                    {
                        // "Create", "Read", "Update", "Delete"
                        case "a":
                            {
                                Console.Clear();
                                WriteArray(logic.CarsFullPrice());
                                Console.WriteLine("Press enter to return to the main menu.");
                                Console.ReadLine();
                                break;
                            }

                        case "b":
                            {
                                Console.Clear();
                                WriteArray(logic.AverageBasePrice_PerBrands());
                                Console.WriteLine("Press enter to return to the main menu.");
                                Console.ReadLine();

                                break;
                            }

                        case "c":
                            {
                                Console.Clear();
                                WriteArray(logic.ExtraCategoryUseage());
                                Console.WriteLine("Press enter to return to the main menu.");
                                Console.ReadLine();

                                break;
                            }

                        case "d":
                            {
                                Console.Clear();

                                // Process p = Process.Start("http://localhost:8080/Arajanlatkero/");
                                // Java.DotheJava();
                                string url = "http://users.nik.uni-obuda.hu/bpeter/Data/war_of_westeros.xml";
                                Java.GetData(url);

                                Console.WriteLine("Press enter to return to the main menu.");
                                Console.ReadLine();

                                break;
                            }

                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("There is no such menu.");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// Writes to the console the given IQueryable array.
        /// </summary>
        /// <param name="array">IQueryable which should be written on the console.</param>
        private static void WriteArray(IQueryable array)
        {
            foreach (var item in array)
            {
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------------------------------------------");
            }
        }

        /// <summary>
        /// Get infos for new element
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key</param>
        /// <param name="logic">ILogic interface</param>
        private static void GetInfosForNewElement(string mainMenuWaitingKey, ILogic logic)
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
                    logic.Create(carBrand);
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
                    logic.Create(model);
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
                    logic.Create(extra);
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
                    logic.Create(modelExtraswitch);
                }
            }
            catch (FormatException exception)
            {
                Console.WriteLine("\n\nYou gave wrong format to the previous table data, try again!\n\nException message: " + exception.Message + "\n\n");
            }
            catch (NoClassException exception)
            {
                Console.WriteLine(exception.Msg);
            }
        }

        /// <summary>
        /// Updates a parameter of a database entity.
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <param name="logic">ILogic interface</param>
        private static void UpdateParameters(string mainMenuWaitingKey, ILogic logic)
        {
            try
            {
                // { "Car Brand", "Models", "Extras", "Model-Extras" };
                if (mainMenuWaitingKey == "0")
                {
                    Console.Write("Update Carbrand_Yearly_Traffic:");
                    Console.Write("Car Brand ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("New Yearly Traffic: ");
                    string yearlyTraffic = Console.ReadLine();

                    logic.Update(mainMenuWaitingKey, id, yearlyTraffic);
                }
                else if (mainMenuWaitingKey == "1")
                {
                    Console.WriteLine("Update Model_Base_Price:");
                    Console.Write("Model ID: ");
                    var id = int.Parse(Console.ReadLine());
                    Console.Write("New Model_Base_Price: ");
                    var baseprice = Console.ReadLine();

                    logic.Update(mainMenuWaitingKey, id, baseprice);
                }
                else if (mainMenuWaitingKey == "2")
                {
                    Console.WriteLine("Update Extra_Price:");
                    Console.Write("Update Extra of Extra ID: ");
                    var id = int.Parse(Console.ReadLine());
                    Console.Write("New Extra_Price: ");
                    var extraprice = Console.ReadLine();

                    logic.Update(mainMenuWaitingKey, id, extraprice);
                }
                else if (mainMenuWaitingKey == "3")
                {
                    Console.WriteLine("Update Model_Id:");
                    Console.Write("ModelExtraSwitch ID: ");
                    var id = int.Parse(Console.ReadLine());
                    Console.Write("New Model_Id: ");
                    var modelid = Console.ReadLine();
                    logic.Update(mainMenuWaitingKey, id, modelid);
                }
            }
            catch (NoIdFoundException exception)
            {
                Console.WriteLine(exception.Msg);
            }
            catch (NoClassException exception)
            {
                Console.WriteLine(exception.Msg);
            }
            catch (NullObjectException exception)
            {
                Console.WriteLine(exception.EMessage);
            }
            catch (FormatException exception)
            {
                Console.WriteLine("\n\nYou gave wrong format to the previous table data, try again!\n\nException message: " + exception.Message + "\n\n");
            }
        }

        /// <summary>
        /// Removes an item from the database DELETE
        /// </summary>
        /// <param name="mainMenuWaitingKey">Main menu key which defines the table</param>
        /// <param name="logic">ILogic interface</param>
        private static void DeleteParameters(string mainMenuWaitingKey, ILogic logic)
        {
            try
            {
                if (mainMenuWaitingKey == "0")
                {
                    Console.WriteLine("Carbrand ID to be deleted: ");
                    var idToDelete = int.Parse(Console.ReadLine());
                    logic.Delete(mainMenuWaitingKey, idToDelete);
                }
                else if (mainMenuWaitingKey == "1")
                {
                    Console.WriteLine("Model ID to be deleted: ");
                    var idToDelete = int.Parse(Console.ReadLine());
                    logic.Delete(mainMenuWaitingKey, idToDelete);
                }
                else if (mainMenuWaitingKey == "2")
                {
                    Console.WriteLine("Extra ID to be deleted: ");
                    var idToDelete = int.Parse(Console.ReadLine());
                    logic.Delete(mainMenuWaitingKey, idToDelete);
                }
                else if (mainMenuWaitingKey == "3")
                {
                    Console.WriteLine("ModelExtraSwitch ID to be deleted: ");
                    var idToDelete = int.Parse(Console.ReadLine());
                    logic.Delete(mainMenuWaitingKey, idToDelete);
                }
            }
            catch (NoClassException exception)
            {
                Console.WriteLine(exception.Msg);
            }
            catch (NullObjectException exception)
            {
                Console.WriteLine(exception.EMessage);
            }
            catch (FormatException exception)
            {
                Console.WriteLine("\n\nYou gave wrong format to the previous table data, try again!\n\nException message: " + exception.Message + "\n\n");
            }
        }
    }
}