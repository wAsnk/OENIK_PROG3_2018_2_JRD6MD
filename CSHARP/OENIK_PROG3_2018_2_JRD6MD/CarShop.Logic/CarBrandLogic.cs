// <copyright file="CarBrandLogic.cs" company="CarShop">
// Copyright (c) CarShop. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using CarShop.Data;
    using CarShop.JavaWeb;
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
        /// <returns>Every entity in the given repository</returns>
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
        /// <param name="idToDelete">Id of the data to be deleted.</param>
        public void Delete(string mainMenuWaitingKey, int idToDelete)
        {
            if (mainMenuWaitingKey == "0")
            {
                CarBrand carBrandToDelete = this.carBrandRepository.ReadAll().FirstOrDefault(x => x.Carbrand_Id == idToDelete);
                if (carBrandToDelete == null)
                {
                    throw new NoIdFoundException("There is no such an ID.", carBrandToDelete);
                }
                else
                {
                    this.carBrandRepository.Delete(carBrandToDelete);
                }
            }
            else if (mainMenuWaitingKey == "1")
            {
                Model modelToDelete = this.modelRepository.ReadAll().FirstOrDefault(x => x.Model_Id == idToDelete);
                if (modelToDelete == null)
                {
                    throw new NoIdFoundException("There is no such an ID.", modelToDelete);
                }
                else
                {
                    this.modelRepository.Delete(modelToDelete);
                }
            }
            else if (mainMenuWaitingKey == "2")
            {
                Extra extraToDelete = this.extraRepository.ReadAll().FirstOrDefault(x => x.Extra_Id == idToDelete);
                if (extraToDelete == null)
                {
                    throw new NoIdFoundException("There is no such an ID.", extraToDelete);
                }
                else
                {
                    this.extraRepository.Delete(extraToDelete);
                }
            }
            else if (mainMenuWaitingKey == "3")
            {
                ModelExtraswitch modelExtraSwitchToDelete = this.modelExtraSwitchRepository.ReadAll().FirstOrDefault(x => x.ModelExtraswitch_Id == idToDelete);
                if (modelExtraSwitchToDelete == null)
                {
                    throw new NoIdFoundException("There is no such an ID.", modelExtraSwitchToDelete);
                }
                else
                {
                    this.modelExtraSwitchRepository.Delete(modelExtraSwitchToDelete);
                }
            }
            else
            {
                throw new NoClassException("There is no such a table.", mainMenuWaitingKey);
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
            else
            {
                throw new NoClassException("There is no such a table.", mainMenuWaitingKey);
            }
        }

        /// <summary>
        /// Gives cars full price
        /// </summary>
        /// <returns>Cars full Price</returns>
        public IQueryable CarsFullPrice()
        {
            // Legyen lehetőségünk kiírni minden autóhoz az autó TELJES árát is: alapár + a rajta lévő extrák összára
            var carbrands = this.carBrandRepository.ReadAll();
            var extras = this.extraRepository.ReadAll();
            var models = this.modelRepository.ReadAll();
            var modelextraswitch = this.modelExtraSwitchRepository.ReadAll();

            var prepreResult = modelextraswitch.Join(models, x => x.Model_Id, y => y.Model_Id, (e, d) => new
            {
                MODELID = d.Model_Id,
                MODELNAME = d.Model_Name,
                EXTRAID = e.Extra_Id,
                MODELPRICE = d.Model_Base_Price
            }).Join(extras, z => z.EXTRAID, c => c.Extra_Id, (a, b) => new
            {
                MODELID = a.MODELID,
                MODELNAME = a.MODELNAME,
                EXTRAID = a.EXTRAID,
                FULLPRICE = a.MODELPRICE + b.Extra_Price
            }).GroupBy(x => x.MODELNAME);

            var preresult = prepreResult.Select(x => new
            {
                MODELNAME = x.Key,
                Price = x.Sum(y => y.FULLPRICE)
            });

            var result = preresult.Select(x => "Model name: " + x.MODELNAME + "\n\t Price with all extra on it: " + x.Price + " euro");
            return result;
        }

        /// <summary>
        /// Gives the Average Base Price Per Brands
        /// </summary>
        /// <returns>Returns Average price per car brand</returns>
        public IQueryable AverageBasePrice_PerBrands()
        {
            // Legyen lehetőségünk kiírni márkánként az autók átlagos alapárát
            var carbrands = this.carBrandRepository.ReadAll();
            var models = this.modelRepository.ReadAll();

            var phaseOne = carbrands.Join(models, x => x.Carbrand_Id, y => y.Carbrand_Id, (a, b) => new
            {
                NAME = a.Carbrand_Name,
                BASEPRICE = b.Model_Base_Price
            }).GroupBy(x => x.NAME).Select(y => new
            {
                NAME = y.Key,
                BASEPRICE = y.Average(x => x.BASEPRICE)
            });

            var result = phaseOne.Select(x => "Car brand: " + x.NAME + "\n\tAverage base price: " + x.BASEPRICE + " euro");

            return result;
        }

        /// <summary>
        /// Gives beck the Extra categories usage
        /// </summary>
        /// <returns>Returns Extra category useage</returns>
        public IQueryable ExtraCategoryUseage()
        {
            /* Legyen lehetőségünk kiírni az extrák kategórianeveként csoportosítva azt,
             hogy melyik kategória hányszor van autókhoz kapcsolva */
            var carbrands = this.carBrandRepository.ReadAll();
            var extras = this.extraRepository.ReadAll();
            var models = this.modelRepository.ReadAll();
            var modelextraswitch = this.modelExtraSwitchRepository.ReadAll();

            var phaseOne = extras.Join(modelextraswitch, x => x.Extra_Id, y => y.Extra_Id, (a, b) => new
            {
                CATEGORY_NAME = a.Extra_Category_Name,
                MODELID = b.Model_Id
            }).GroupBy(x => x.CATEGORY_NAME).Select(y => new
            {
                CATEGORY_NAME = y.Key,
                COUNT = y.Count()
            });

            var result = phaseOne.Select(x => x.CATEGORY_NAME + "\t" + x.COUNT);

            return result;
        }

        /// <summary>
        /// Request price offer using JAVA
        /// </summary>
        /// <param name="fullname">Fulname parameter</param>
        /// <param name="carname">carname parameter</param>
        /// <param name="price">Price parameter</param>
        /// <returns>Returns java offer request data</returns>
        public IEnumerable<string> RequestPriceOffer(string fullname, string carname, string price)
        {
                string url = "http://localhost:8080/Arajanlatkero/Arajanlat?carname=" + carname + "&price=" + price + "&name=" + fullname;
                var javas = new Java(url).GetElements().Select(x => "Full name: " + x.Name + "\nCar name: " + x.Carname + "\nPrice: " + x.Price);
                return javas;
        }
    }
}
