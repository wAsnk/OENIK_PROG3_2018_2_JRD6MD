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
    using CarShop.JavaWeb;
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
        /// When selected a not existing menu it returns null, READ
        /// </summary>
        [Test]
        public void WhenSelectedANotExistingMenu_ReturnNull()
        {
            // Arrange
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();
            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object);

            // Act
            var result = logic.ReadAll("10");

            // Assert
            Assert.That(result, Is.EqualTo(null));
        }

        /// <summary>
        /// When selected an existing menu it returns not null, READ
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

            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object);

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

            carbrandMock.Setup(x => x.ReadAll()).Returns(carbrands.AsQueryable);
            modelMock.Setup(x => x.ReadAll()).Returns(models.AsQueryable);
            extraMock.Setup(x => x.ReadAll()).Returns(extras.AsQueryable);
            modelextraMock.Setup(x => x.ReadAll()).Returns(modelExtraswitches.AsQueryable);

            // Act
            var result = logic.ReadAll(existingMenu.ToString());

            // Assert
            Assert.That(result, Is.Not.EqualTo(null));
        }

        /// <summary>
        /// When creating a table with wrong data format exception is thrown. CREATE
        /// </summary>
        [Test]
        public void WhenCreatingaTableWithWrongDataFormat_ExceptionIsThrown()
        {
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();

            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object);

            string testObject = "WRONG";

            Assert.Throws<NoClassException>(() => logic.Create(testObject));
        }

        /// <summary>
        /// Creating CarBrand without exception thrown. CREATE
        /// </summary>
        [Test]
        public void WhenCreatingCarBrandData_WithoutError_NoExceptionThrown()
        {
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();
            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object);

            CarBrand carBrand = new CarBrand() { Carbrand_Id = 1, Carbrand_Name = "Ferrari", Carbrand_Country_Name = "Italy", Carbrand_Url = "https://ferrari.com", Carbrand_Foundation_Year = 1952, Carbrand_Yearly_Traffic = "56 billion euro" };

            // ASSERT
            Assert.That(() => logic.Create(carBrand), Throws.Nothing);
            carbrandMock.Verify(x => x.Create(It.IsAny<CarBrand>()), Times.Once);
        }

        /// <summary>
        /// Creating Model without exception thrown. CREATE
        /// </summary>
        [Test]
        public void WhenCreatingModelData_WithoutError_NoExceptionThrown()
        {
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();
            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object);

            Model model = new Model() { Model_Id = 1, Carbrand_Id = 1, Model_Name = "Model1", Model_Release_Day = DateTime.Parse("2018-11-23"), Model_Engine_Volume = 123123, Model_Horsepower = 3000, Model_Base_Price = 20000 };

            // ASSERT
            Assert.That(() => logic.Create(model), Throws.Nothing);
            modelMock.Verify(x => x.Create(It.IsAny<Model>()), Times.Once);
        }

        /// <summary>
        /// Creating Extra without exception thrown. CREATE
        /// </summary>
        [Test]
        public void WhenCreatingExtraData_WithoutError_NoExceptionThrown()
        {
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();
            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object);

            Extra extra = new Extra() { Extra_Id = 1, Extra_Category_Name = "Name1", Extra_Name = "Name1-1", Extra_Price = 3000, Extra_Color = "blue", Extra_Multiple_Usage = 0 };

            // ASSERT
            Assert.That(() => logic.Create(extra), Throws.Nothing);
            extraMock.Verify(x => x.Create(It.IsAny<Extra>()), Times.Once);
        }

        /// <summary>
        /// Creating ModelExtraSwitch without exception thrown. CREATE
        /// </summary>
        [Test]
        public void WhenCreatingModelExtraSwitchData_WithoutError_NoExceptionThrown()
        {
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();
            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object);

            ModelExtraswitch modelExtraswitch = new ModelExtraswitch() { ModelExtraswitch_Id = 1, Model_Id = 1, Extra_Id = 1 };

            // ASSERT
            Assert.That(() => logic.Create(modelExtraswitch), Throws.Nothing);
            modelextraMock.Verify(x => x.Create(It.IsAny<ModelExtraswitch>()), Times.Once);
        }

        /// <summary>
        /// When deleting a not existing ID table data it throws exception. DELETE
        /// </summary>
        /// <param name="menu">Main menu key</param>
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void WhenDeletingNotExistingId_ExceptionThrown(int menu)
        {
            // Arrange
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();

            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object);

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

            carbrandMock.Setup(x => x.ReadAll()).Returns(carbrands.AsQueryable);
            modelMock.Setup(x => x.ReadAll()).Returns(models.AsQueryable);
            extraMock.Setup(x => x.ReadAll()).Returns(extras.AsQueryable);
            modelextraMock.Setup(x => x.ReadAll()).Returns(modelExtraswitches.AsQueryable);

            Assert.Throws<NoIdFoundException>(() => logic.Delete(menu.ToString(), 10));
        }

        /// <summary>
        /// When deleting a not existing table it throws exception. DELETE
        /// </summary>
        /// <param name="menu">Main menu key</param>
        [TestCase(10)]
        public void WhenDeletingNotExistingTable_ExceptionThrown(int menu)
        {
            // Arrange
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();

            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object);

            Assert.Throws<NoClassException>(() => logic.Delete(menu.ToString(), 1));
        }

        /// <summary>
        /// When updating a not existing table it throws exception. UPDATE
        /// </summary>
        /// <param name="menu">Main menu key</param>
        [TestCase(10)]
        public void WhenUpdatingNotExistingTable_ExceptionThrown(int menu)
        {
            // Arrange
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();

            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object);

            Assert.Throws<NoClassException>(() => logic.Update(menu.ToString(), 1, "Updatedata"));
        }

        /// <summary>
        /// When Cars full Price called only read all got called.
        /// </summary>
        [Test]
        public void When_CarsFullPrice_Called_OnlyReadAllIsCalled()
        {
            // Legyen lehetőségünk kiírni minden autóhoz az autó TELJES árát is: alapár + a rajta lévő extrák összára
            // Arrange
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();

            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object);

            logic.CarsFullPrice();
            carbrandMock.Verify(x => x.ReadAll(), Times.Once);
            carbrandMock.Verify(x => x.Delete(It.IsAny<CarBrand>()), Times.Never);
            carbrandMock.Verify(x => x.Create(It.IsAny<CarBrand>()), Times.Never);
            carbrandMock.Verify(x => x.ChangeYearlyTraffic(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        /// <summary>
        /// When AverageBasePrice_PerBrands is called only readall function got called
        /// </summary>
        [Test]
        public void When_AverageBasePrice_PerBrands_Called_OnlyReadAllIsCalled()
        {
            // Legyen lehetőségünk kiírni márkánként az autók átlagos alapárát
            // Arrange
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();

            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object);

            logic.AverageBasePrice_PerBrands();
            carbrandMock.Verify(x => x.ReadAll(), Times.Once);
            carbrandMock.Verify(x => x.Delete(It.IsAny<CarBrand>()), Times.Never);
            carbrandMock.Verify(x => x.Create(It.IsAny<CarBrand>()), Times.Never);
            carbrandMock.Verify(x => x.ChangeYearlyTraffic(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        /// <summary>
        /// When ExtraCategoryUseage is called only readall function got called
        /// </summary>
        [Test]
        public void When_ExtraCategoryUseage_Called_OnlyReadAllIsCalled()
        {
            // Legyen lehetőségünk kiírni márkánként az autók átlagos alapárát
            // Arrange
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();

            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object);

            logic.ExtraCategoryUseage();
            carbrandMock.Verify(x => x.ReadAll(), Times.Once);
            carbrandMock.Verify(x => x.Delete(It.IsAny<CarBrand>()), Times.Never);
            carbrandMock.Verify(x => x.Create(It.IsAny<CarBrand>()), Times.Never);
            carbrandMock.Verify(x => x.ChangeYearlyTraffic(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        /// <summary>
        /// When java endpoint is called with missing parameter exception is thrown
        /// </summary>
        [Test]
        public void WhenJavaEndpointCalledWithMissingParameter_NoParameterExceptionThrown()
        {
            Mock<ICarBrandRepository> carbrandMock = new Mock<ICarBrandRepository>();
            Mock<IModelRepository> modelMock = new Mock<IModelRepository>();
            Mock<IExtraRepository> extraMock = new Mock<IExtraRepository>();
            Mock<IModelExtraSwitchRepository> modelextraMock = new Mock<IModelExtraSwitchRepository>();
            CarBrandLogic logic = new CarBrandLogic(carbrandMock.Object, modelMock.Object, extraMock.Object, modelextraMock.Object);

            Assert.Throws<NoParameterException>(() => logic.RequestPriceOffer(string.Empty, "Something", "100"));
        }
    }
}