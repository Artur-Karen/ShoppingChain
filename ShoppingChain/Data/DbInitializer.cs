using ShoppingChain.Models;

namespace ShoppingChain.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ShopDb>();
               var isCreated= context.Database.EnsureCreated();
                if (!context.shops.Any())
                {
                    context.shops.AddRange(new List<Shop>()
                    {
                        new Shop()
                        {
                            Name="Best",
                            Address="Erevan",
                            PhoneNumber="000000000"
                        },
                        new Shop()
                        {
                            Name="Fine",
                            Address="New York",
                            PhoneNumber="1111111111"
                        },
                        new Shop()
                        {
                            Name="Happy",
                            Address="London",
                            PhoneNumber="3333333333"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.bakeries.Any())
                {
                    context.bakeries.AddRange(new List<Bakery>()
                    {
                        new Bakery()
                        {
                            BakeryFor="Fine",
                            PhoneNumber="44444444444",
                            ShopId=2
                        },
                        new Bakery()
                        {
                            BakeryFor="Best",
                            PhoneNumber="666666666",
                            ShopId=1
                        },
                        new Bakery()
                        {
                            BakeryFor="Happy",
                            PhoneNumber="9999999999",
                            ShopId=3
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.storages.Any())
                {
                    context.storages.AddRange(new List<Storage>()
                    {
                        new Storage()
                        {
                            Name="Fine",
                            PhoneNumber="654482456",
                            ShopId=2
                        },
                        new Storage()
                        {
                            Name="Best",
                            PhoneNumber="666666888",
                            ShopId=1
                        },
                        new Storage()
                        {
                            Name="Happy",
                            PhoneNumber="99999915547",
                            ShopId=3
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.employees.Any()) 
                {
                    context.employees.AddRange(new List<Employee>()
                    {
                        new Employee()
                        {
                            FirstName="Roman",
                            LastName="Harutyunyan",
                            DateOfEmployment=new DateTime(2015-01-20),
                            PhoneNumber="002542212",
                            Email="Roman08@gmail.com",
                            Salary="1000$",
                            StorageId=1,
                        },
                        new Employee()
                        {
                            FirstName="Kayi",
                            LastName="Harutyunyan",
                            DateOfEmployment=new DateTime(2016-01-20),
                            PhoneNumber="002542312",
                            Email="Kayi27@gmail.com",
                            Salary="1001$",
                            StorageId=2,
                        },
                        new Employee()
                        {
                            FirstName="Artur",
                            LastName="Harutyunyan",
                            DateOfEmployment=new DateTime(2017-01-20),
                            PhoneNumber="002542216",
                            Email="Artur04@gmail.com",
                            Salary="1100$",
                            StorageId=3,
                        },
                        new Employee()
                        {
                            FirstName="Arev",
                            LastName="Baghdasaryan",
                            DateOfEmployment=new DateTime(2019-01-20),
                            PhoneNumber="002642212",
                            Email="Arev08@gmail.com",
                            Salary="1020$",
                            BakeryId=1,
                        },
                        new Employee()
                        {
                            FirstName="Luse",
                            LastName="Harutyunyan",
                            DateOfEmployment=new DateTime(2018-01-22),
                            PhoneNumber="002562212",
                            Email="Luse23@gmail.com",
                            Salary="1400$",
                            BakeryId=2,
                        },
                        new Employee()
                        {
                            FirstName="Anahit",
                            LastName="Harutyunyan",
                            DateOfEmployment=new DateTime(2015-05-20),
                            PhoneNumber="00233312",
                            Email="Anahit01@gmail.com",
                            Salary="1220$",
                            BakeryId=3,
                        },
                        new Employee()
                        {
                            FirstName="Nune",
                            LastName="Avdalyan",
                            DateOfEmployment=new DateTime(2019-01-20),
                            PhoneNumber="002444212",
                            Email="Nune11@gmail.com",
                            Salary="1005$",
                            ShopId=1,
                        },
                        new Employee()
                        {
                            FirstName="Daniel",
                            LastName="Harutyunyan",
                            DateOfEmployment=new DateTime(2017-09-20),
                            PhoneNumber="00257852",
                            Email="Daniel06@gmail.com",
                            Salary="1010$",
                            ShopId=2,
                        },
                        new Employee()
                        {
                            FirstName="Ben",
                            LastName="Harutyunyan",
                            DateOfEmployment=new DateTime(2013-01-20),
                            PhoneNumber="00271112",
                            Email="Ben09@gmail.com",
                            Salary="1150$",
                            ShopId=3,
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
