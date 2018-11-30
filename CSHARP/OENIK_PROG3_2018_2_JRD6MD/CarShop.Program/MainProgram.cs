﻿// <copyright file="MainProgram.cs" company="CarShop">
// Copyright (c) CarShop. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CarShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;
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
            ICarBrandRepository carBrandRepository = new CarBrandRepository();
            IModelRepository modelRepository = new ModelRepository();
            IExtraRepository extraRepository = new ExtraRepository();
            IModelExtraSwitchRepository modelExtraSwitchRepository = new ModelExtraSwitchRepository();
            CarShopDataEntities carShopDataEntities = new CarShopDataEntities();
            ILogic logic = new CarBrandLogic(carBrandRepository, modelRepository, extraRepository, modelExtraSwitchRepository, carShopDataEntities);

            ConsoleMenu(logic);

            // carShopDataEntities.Dispose();
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
                                logic.Create(mainMenuWaitingKey);
                                Console.WriteLine("Press enter to continue.");
                                Console.ReadLine();
                                break;
                            }

                        case "1":
                            {
                                // Read
                                Console.Clear();
                                WriteArray(logic.ReadAll(mainMenuWaitingKey));
                                Console.WriteLine("Press enter to continue.");
                                Console.ReadLine();

                                break;
                            }

                        case "2":
                            {
                                // Update
                                Console.Clear();
                                Console.WriteLine("Not ready Yet");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }

                        case "3":
                            {
                                // Delete
                                Console.Clear();
                                logic.Delete(mainMenuWaitingKey);
                                Console.WriteLine("Press enter to continue.");
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
                    Console.Clear();
                    Console.WriteLine("Not ready Yet");
                    System.Threading.Thread.Sleep(1000);
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
                Console.WriteLine(item);
            }
        }
    }
}
