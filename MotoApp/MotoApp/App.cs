using MotoApp.DataProviders;
using MotoApp.Entities;
using MotoApp.Repositories;
using System.Security.Cryptography.X509Certificates;

namespace MotoApp
{
    public class App : IApp
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Car> _carsRepository;
        private readonly ICarsProvider _carsProvider;

        public App(IRepository<Employee> employeeRepository, IRepository<Car> carsRepository, ICarsProvider carsProvider)
        {
            _employeeRepository = employeeRepository;
            _carsRepository = carsRepository;
            _carsProvider = carsProvider;
        }

        public void Run()
        {
            Console.WriteLine("I'm here in Run() method");

            // adding
            var employees = new[]
            {
                new Employee {FirstName = "Adam"},
                new Employee {FirstName = "Piotr"},
                new Employee {FirstName = "Zuzanna"}
            };

            foreach (var employee in employees)
            {
                _employeeRepository.Add(employee);
            }

            _employeeRepository.Save();

            var items = _employeeRepository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            // cars
            var cars = GenerateSampleCars();
            foreach (var car in cars)
            {
                _carsRepository.Add(car);
            }

            Console.WriteLine();
            Console.WriteLine("GetUniqueCarColors");
            foreach (var item in _carsProvider.GetUniqueCarColors())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("GetMinimumPriceOfAllCars");
            Console.WriteLine(_carsProvider.GetMinimumPriceOfAllCars());

            Console.WriteLine();
            Console.WriteLine("GetSpecificComumnsMethod");
            foreach (var item in _carsProvider.GetSpecificColums())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("AnonymousClassInString");
            Console.WriteLine(_carsProvider.AnonymousClass());

            Console.WriteLine();
            Console.WriteLine("OrderByName");
            foreach (var item in _carsProvider.OrderByName())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("OrderByNameDescending");
            foreach (var item in _carsProvider.OrderByNameDescending())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("OrderByColorAndName");
            foreach (var item in _carsProvider.OrderByNameDescending())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("WhereStartsWith");
            foreach (var item in _carsProvider.WhereStartsWith("A"))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("WhereStartsWithAndCostIsGreaterThan");
            foreach (var item in _carsProvider.WhereStartsWithAndCostIsGreaterThan("F", 1000))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("WhereColorIs");
            foreach (var item in _carsProvider.WhereColorIs("Pink"))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("FirstByColor");
            Console.WriteLine(_carsProvider.FirstByColor("Pink"));

            Console.WriteLine();
            Console.WriteLine("FirstOrDefaultByColor");
            Console.WriteLine(_carsProvider.FirstOrDefaultByColor("Pink"));

            Console.WriteLine();
            Console.WriteLine("FirstOrDefaultByColorWithDefault");
            Console.WriteLine(_carsProvider.FirstOrDefaultByColorWithDefault("Pink"));

            Console.WriteLine();
            Console.WriteLine("LastNyColor");
            Console.WriteLine(_carsProvider.LastByColor("Pink"));

            Console.WriteLine();
            Console.WriteLine("SingleById");
            Console.WriteLine(_carsProvider.SingleById(680));

            Console.WriteLine();
            Console.WriteLine("SingleOrDefaultById");
            Console.WriteLine(_carsProvider.SingleOrDefaultById(680));

            Console.WriteLine();
            Console.WriteLine("TakeCars");
            foreach (var car in _carsProvider.TakeCars(2))
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();
            Console.WriteLine("TakeCarsRange");
            foreach (var car in _carsProvider.TakeCars(1..3))
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();
            Console.WriteLine("TakeCarsWhileNameStartsWith");
            foreach (var car in _carsProvider.TakeCarsWhileNameStartsWith("F"))
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();
            Console.WriteLine("SkipCars");
            foreach (var item in _carsProvider.SkipCars(4))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("SkipCarsWhileNameStartsWith");
            foreach (var item in _carsProvider.SkipCarsWhileNameStartsWith("F"))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("DistinctAllColors");
            foreach (var item in _carsProvider.DistinctAllColors())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("DistinctByColors");
            foreach (var item in _carsProvider.DistinctByColors())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("ChunkCars");
            foreach (var item in _carsProvider.ChunkCars(3))
            {
                Console.WriteLine($"Chunk: ");
                foreach (var i in item)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("####");
            }


            Console.WriteLine();
            Console.WriteLine("Paging");
            int pageNumber = 2;
            int pageSize = 3; // Specify the number of items per page

            var c = _carsProvider.SkipCars((pageNumber - 1) * pageSize).Take(pageSize);

            foreach (var item in c)
            {
                Console.WriteLine(item);
            }
        }

        public static List<Car> GenerateSampleCars()
        {
            return new List<Car>
            {
                new Car
                {
                    Id = 680,
                    Name = "Honda",
                    Color = "Black",
                    StandardCost = 1059.31M,
                    ListPrice = 1431.50M,
                    Type = "58",
                },
                new Car
                {
                    Id = 706,
                    Name = "Hiundai",
                    Color = "Red",
                    StandardCost = 900.31M,
                    ListPrice = 990.50M,
                    Type = "69"
                },
                new Car
                {
                    Id = 500,
                    Name = "Ferrari",
                    Color = "Yellow",
                    StandardCost = 1536.31M,
                    ListPrice = 1700.00M,
                    Type = "70"
                },
                new Car
                {
                    Id = 205,
                    Name = "Fiat",
                    Color = "Pink",
                    StandardCost = 1285.31M,
                    ListPrice = 1490.90M,
                    Type = "59"
                },
                new Car
                {
                    Id = 706,
                    Name = "Mercedes",
                    Color = "Green",
                    StandardCost = 890.29M,
                    ListPrice = 1150.50M,
                    Type = "42"
                },
                new Car
                {
                    Id = 545,
                    Name = "Miata",
                    Color = "Green",
                    StandardCost = 324.29M,
                    ListPrice = 400.50M,
                    Type = "20"
                }
            };
        }
    }
}
