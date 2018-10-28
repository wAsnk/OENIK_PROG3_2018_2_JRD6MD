// <copyright file="Repos.cs" company="CarShop">
// Copyright (c) CarShop. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;

    /// <summary>
    /// adsadsa
    /// </summary>
    public class Repos : IRepository
    {
        /// <summary>
        /// Insert object in the correct table
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="value">The object which will be inserted into the database.</param>
        public void Create<T>(object value)
        {
            try
            {
                using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
                {
                    Type t = typeof(T);

                    // Type a = typeof(object); // Might be used instead of Type t = typeof(T)
                    if (t == typeof(CarBrand))
                    {
                        CarBrand carBrand = value as CarBrand;
                        carShopDataEntities.CarBrands.Add(carBrand);
                    }
                    else if (t == typeof(Extra))
                    {
                        Extra extra = value as Extra;
                        carShopDataEntities.Extras.Add(extra);
                    }
                    else if (t == typeof(Model))
                    {
                        Model model = value as Model;
                        carShopDataEntities.Models.Add(model);
                    }
                    else if (t == typeof(ModelExtraswitch))
                    {
                        ModelExtraswitch modelExtraswitch = value as ModelExtraswitch;
                        carShopDataEntities.ModelExtraswitches.Add(modelExtraswitch);
                    }

                    carShopDataEntities.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Read or Select function
        /// </summary>
        /// <typeparam name="T">Type of the object where</typeparam>
        /// <param name="key">The key which will be search for.</param>
        /// <returns>Returns the object with the key</returns>
        public object Read<T>(int key)
        {
            try
            {
                using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
                {
                    Type t = typeof(T);

                    // Type a = typeof(object); // Might be used instead of Type t = typeof(T)
                    if (t == typeof(CarBrand))
                    {
                        CarBrand carBrand = carShopDataEntities.CarBrands.FirstOrDefault(x => x.Carbrand_Id == key);
                        return carBrand;
                    }
                    else if (t == typeof(Extra))
                    {
                        Extra extra = carShopDataEntities.Extras.FirstOrDefault(x => x.Extra_Id == key);
                        return extra;
                    }
                    else if (t == typeof(Model))
                    {
                        Model model = carShopDataEntities.Models.FirstOrDefault(x => x.Model_Id == key);
                        return model;
                    }
                    else if (t == typeof(ModelExtraswitch))
                    {
                        ModelExtraswitch modelExtraswitch = carShopDataEntities.ModelExtraswitches.FirstOrDefault(x => x.ModelExtraswitch_Id == key);
                        return modelExtraswitch;
                    }

                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// agdf
        /// </summary>
        /// <typeparam name="T">gfj</typeparam>
        /// <param name="key">jsf</param>
        /// <param name="newValues">gfjs</param>
        public void Update<T>(int key, object newValues)
        {
            try
            {
                using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
                {
                    Type t = typeof(T);

                    // Type a = typeof(object); // Might be used instead of Type t = typeof(T)
                    if (t == typeof(CarBrand))
                    {
                        CarBrand carBrand = carShopDataEntities.CarBrands.FirstOrDefault(x => x.Carbrand_Id == key);
                        carBrand = newValues as CarBrand;
                        Console.WriteLine($"{carBrand.Carbrand_Name} was updated");
                    }
                    else if (t == typeof(Extra))
                    {
                        Extra extra = carShopDataEntities.Extras.FirstOrDefault(x => x.Extra_Id == key);
                        extra = newValues as Extra;
                        Console.WriteLine($"{extra.Extra_Name} was updated");
                    }
                    else if (t == typeof(Model))
                    {
                        Model model = carShopDataEntities.Models.FirstOrDefault(x => x.Model_Id == key);
                        model = newValues as Model;
                        Console.WriteLine($"{model.Model_Name} was updated");
                    }
                    else if (t == typeof(ModelExtraswitch))
                    {
                        ModelExtraswitch modelExtraswitch = carShopDataEntities.ModelExtraswitches.FirstOrDefault(x => x.ModelExtraswitch_Id == key);
                        modelExtraswitch = newValues as ModelExtraswitch;
                        Console.WriteLine($"ModelExtraSwitch ID:{modelExtraswitch.ModelExtraswitch_Id} was updated");
                    }

                    carShopDataEntities.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Delete summary
        /// </summary>
        /// <typeparam name="T">assummary</typeparam>
        /// <param name="key">dgfsummary</param>
        public void Delete<T>(int key)
        {
            try
            {
                using (CarShopDataEntities carShopDataEntities = new CarShopDataEntities())
                {
                    Type t = typeof(T);

                    // Type a = typeof(object); // Might be used instead of Type t = typeof(T)
                    if (t == typeof(CarBrand))
                    {
                        CarBrand carBrand = carShopDataEntities.CarBrands.FirstOrDefault(x => x.Carbrand_Id == key);
                        carShopDataEntities.CarBrands.Remove(carBrand);
                    }
                    else if (t == typeof(Extra))
                    {
                        Extra extra = carShopDataEntities.Extras.FirstOrDefault(x => x.Extra_Id == key);
                        carShopDataEntities.Extras.Remove(extra);
                    }
                    else if (t == typeof(Model))
                    {
                        Model model = carShopDataEntities.Models.FirstOrDefault(x => x.Model_Id == key);
                        carShopDataEntities.Models.Remove(model);
                    }
                    else if (t == typeof(ModelExtraswitch))
                    {
                        ModelExtraswitch modelExtraswitch = carShopDataEntities.ModelExtraswitches.FirstOrDefault(x => x.ModelExtraswitch_Id == key);
                        carShopDataEntities.ModelExtraswitches.Remove(modelExtraswitch);
                    }

                    carShopDataEntities.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
