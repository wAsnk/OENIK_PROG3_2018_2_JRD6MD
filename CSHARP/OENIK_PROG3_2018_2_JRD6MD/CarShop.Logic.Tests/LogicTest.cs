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
    using CarShop.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Test class for business logic
    /// </summary>
    [TestFixture]
    public class LogicTest
    {
        /// <summary>
        /// When selected a not existing menu it returns null
        /// </summary>
        [Test]
        public void WhenSelectedANotExistingMenu_ReturnNull()
        {
            // Arrange
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();
            Mock<CarShopDataEntities> entityMock = new Mock<CarShopDataEntities>();
            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object, entityMock.Object);

            // Act
            var result = logic.ReadAll("10");

            // Assert
            Assert.That(result, Is.EqualTo(null));
        }

        /// <summary>
        /// When selected an existing menu it returns not null
        /// </summary>
        /// <param name="existingMenu">An existing menu which represents a table</param>
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void WhenSelectedAnExistingMenu_ReturnsNotNull(int existingMenu)
        {
            // Arrange
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();
            Mock<CarShopDataEntities> entityMock = new Mock<CarShopDataEntities>();
            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object, entityMock.Object);

            List<CarBrand> carbrands = new List<CarBrand>()
            {
                new CarBrand() { Carbrand_Id = 1, Carbrand_Name = "Ferrari", Carbrand_Country_Name = "Italy", Carbrand_Url = "https://ferrari.com", Carbrand_Foundation_Year = 1952, Carbrand_Yearly_Traffic = "56 billion euro" },
                new CarBrand() { Carbrand_Id = 2, Carbrand_Name = "Fiat", Carbrand_Country_Name = "Italy", Carbrand_Url = "https://fiat.com", Carbrand_Foundation_Year = 1960, Carbrand_Yearly_Traffic = "30 billion euro" }
            };

            List<Model> models = new List<Model>()
            {
                new Model() { Model_Id = 1, Carbrand_Id = 1, Model_Name = "Model1", Model_Release_Day = DateTime.Parse("2018-11-23"), Model_Engine_Volume = 123123, Model_Horsepower = 3000, Model_Base_Price = 20000 },
                new Model() { Model_Id = 2, Carbrand_Id = 2, Model_Name = "Model2", Model_Release_Day = DateTime.Parse("2018-11-24"), Model_Engine_Volume = 321321, Model_Horsepower = 4000, Model_Base_Price = 30000 }
            };

            List<Extra> extras = new List<Extra>()
            {
                new Extra() { Extra_Id = 1, Extra_Category_Name = "Name1", Extra_Name = "Name1-1", Extra_Price = 3000, Extra_Color = "blue", Extra_Multiple_Usage = 0 },
                new Extra() { Extra_Id = 2, Extra_Category_Name = "Name2", Extra_Name = "Name2-1", Extra_Price = 4000, Extra_Color = "red", Extra_Multiple_Usage = 1 }
            };

            List<ModelExtraswitch> modelExtraswitches = new List<ModelExtraswitch>()
            {
                new ModelExtraswitch() { ModelExtraswitch_Id = 1, Model_Id = 1, Extra_Id = 1 },
                new ModelExtraswitch() { ModelExtraswitch_Id = 2, Model_Id = 1, Extra_Id = 2 },
                new ModelExtraswitch() { ModelExtraswitch_Id = 3, Model_Id = 2, Extra_Id = 1 },
                new ModelExtraswitch() { ModelExtraswitch_Id = 4, Model_Id = 2, Extra_Id = 2 }
            };

            carbrandMock.Setup(x => x.ReadAll(entityMock.Object)).Returns(carbrands.AsQueryable);
            modelMock.Setup(x => x.ReadAll(entityMock.Object)).Returns(models.AsQueryable);
            extraMock.Setup(x => x.ReadAll(entityMock.Object)).Returns(extras.AsQueryable);
            modelextraMock.Setup(x => x.ReadAll(entityMock.Object)).Returns(modelExtraswitches.AsQueryable);

            // Act
            var result = logic.ReadAll(existingMenu.ToString());

            // Assert
            Assert.That(result, Is.Not.EqualTo(null));
        }
    }
}
