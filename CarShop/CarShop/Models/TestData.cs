using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Models
{
    public class TestData
    {
        public static void Initialize(CarContext context)
        {
            if (!context.Cars.Any())
            {
                context.Cars.AddRange(

                    new Car
                    {
                        Title = "Honda",
                        Model = "Accord",
                        Price = 50000
                    },
                    new Car
                    {
                        Title = "Lexus",
                        Model = "IS250",
                        Price = 54500
                    },
                    new Car
                    {
                        Title = "Mitsubishi",
                        Model = "Lancer",
                        Price = 35000
                    },
                    new Car
                    {
                        Title = "Subaru",
                        Model = "Impreza",
                        Price = 39900
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
