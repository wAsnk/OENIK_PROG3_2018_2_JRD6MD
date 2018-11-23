// <copyright file="Class1.cs" company="CarShop">
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
    using Moq;
    using NUnit.Framework;
    using CarShop.Logic;

    /// <summary>
    /// SUMMARY HERE
    /// </summary>
    [TestFixture]
    public class LogicTest
    {
        /// <summary>
        /// Test test
        /// </summary>
        [Test]
        public void CreatedCarBrand()
        {
            Mock<ILogic> mock = new Mock<ILogic>();

            //mock.Setup(m => m.Create());
        }
    }
}
