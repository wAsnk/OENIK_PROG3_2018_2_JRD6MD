// <copyright file="LogicTest.cs" company="CarShop">
// Copyright (c) CarShop. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CarShop.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;
    using CarShop.Logic;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Test class for business logic
    /// </summary>
    [TestFixture]
    public class LogicTest
    {
        /// <summary>
        /// When table doesnt exist returns null
        /// </summary>
        [Test]
        public void WhenTableDoesntExists_ReturnNull()
        {
            var logic = new CarBrandLogic();
            using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
            {
                var result = logic.ReadAll("10", carShopDataEntities);
                Assert.That(result, Is.EqualTo(null));
            }
        }
    }
}
