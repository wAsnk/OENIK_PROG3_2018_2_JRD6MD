// <copyright file="MainProgram.cs" company="CarShop">
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

    /// <summary>
    /// SUMMARY HERE
    /// </summary>
    public class MainProgram
    {
        /// <summary>
        /// Main program runs here
        /// </summary>
        public static void Main()
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
                Console.WriteLine(menuBordersLeft + tabulatorAndText + menuBordersRight, $"c.) Function C");
                Console.WriteLine(menuBordersLeft + tabulatorAndText + menuBordersRight, $"d.) Function JAVA");

                Console.WriteLine(menuBordersLeft + tabulatorAndText + menuBordersRight, string.Empty);

                Console.WriteLine(menuBordersLeft + tabulatorAndText + menuBordersRight, "x.) To Exit");
                Console.Write(menuBordersLeft + "Select Menu: ");
                mainMenuWaitingKey = Console.ReadLine();
                if (mainMenuWaitingKey != "x"
                    && mainMenuWaitingKey != string.Empty
                    && mainMenuWaitingKey != "a"
                    && mainMenuWaitingKey != "b"
                    && mainMenuWaitingKey != "c"
                    && mainMenuWaitingKey != "d")
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
                        case "0":
                            {
                                Console.Clear();
                                Console.WriteLine("Not ready Yet");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }

                        case "1":
                            {
                                Console.Clear();
                                Console.WriteLine("Not ready Yet");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }

                        case "2":
                            {
                                Console.Clear();
                                Console.WriteLine("Not ready Yet");
                                System.Threading.Thread.Sleep(1000);
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
        /// SUMMARY HERE
        /// </summary>
        public void Methode()
        {
        }
    }
}
