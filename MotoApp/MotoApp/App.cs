using MotoApp.Components.CsvReader;
using MotoApp.Data.Entities;
using System.Xml.Linq;

namespace MotoApp
{
    public class App : IApp
    {
        private readonly ICsvReader _csvReader;

        public App(ICsvReader csvReader)
        {
            _csvReader = csvReader;
        }

        public void Run()
        {
            CreateXml();
            QueryXml();

            //var groups = manufacturers.GroupJoin(
            //    cars,
            //    manufacturer => manufacturer.Name,
            //    car => car.Manufacturer,
            //    (m, c) =>
            //    new
            //    {
            //        Manufacturer = m,
            //        Cars = c
            //    })
            //    .OrderBy(x => x.Manufacturer.Name);

            //foreach(var group in groups)
            //{
            //    Console.WriteLine($"Manufacturer: {group.Manufacturer.Name}");
            //    Console.WriteLine($"\t Cars: {group.Cars.Count()}");
            //    Console.WriteLine($"\t Max: {group.Cars.Max(x => x.Combined)}");
            //    Console.WriteLine($"\t Max: {group.Cars.Min(x => x.Combined)}");
            //    Console.WriteLine($"\t Max: {group.Cars.Average(x => x.Combined)}");
            //    Console.WriteLine();
            //}

            //var groups = cars
            //    .GroupBy(x => x.Manufacturer)
            //    .Select(g => new
            //    {
            //        Name = g.Key,
            //        Max = g.Max(c => c.Combined),
            //        Min = g.Min(c => c.Combined),
            //        Average = g.Average(c => c.Combined)
            //    })
            //    .OrderBy(x => x.Average);

            //foreach (var group in groups)
            //{
            //    Console.WriteLine($"{group.Name}");
            //    Console.WriteLine($"\t Max: {group.Max}");
            //    Console.WriteLine($"\t Average: {group.Average}");
            //}

            //var carsInCountry = cars.Join(
            //    manufacturers,
            //    x => x.Manufacturer,
            //    x => x.Name,
            //    (car, manufacturer) => new
            //    {
            //        manufacturer.Country,
            //        car.Name,
            //        car.Combined
            //    })
            //    .OrderByDescending(x => x.Combined)
            //    .ThenBy(x => x.Name);

            //foreach (var car in carsInCountry)
            //{
            //    Console.WriteLine($"Country: {car.Country}");
            //    Console.WriteLine($"\tName: {car.Name}");
            //    Console.WriteLine($"\tCombined: {car.Combined}");
            //}

            //var carsInCountry = cars.Join(
            //    manufacturers,
            //    c => new { c.Manufacturer, c.Year },
            //    m => new { Manufacturer = m.Name, m.Year },
            //    (car, manufacturer) => new
            //    {
            //        manufacturer.Country,
            //        car.Name,
            //        car.Combined
            //    })
            //    .OrderByDescending(x => x.Combined)
            //    .ThenBy(x => x.Name);

            //foreach (var car in carsInCountry)
            //{
            //    Console.WriteLine($"Country: {car.Country}");
            //    Console.WriteLine($"\tName: {car.Name}");
            //    Console.WriteLine($"\tCombined: {car.Combined}");
            //}
        }

        private void CreateXml()
        {
            //var groups = manufacturers.GroupJoin(
            //    cars,
            //    manufacturer => manufacturer.Name,
            //    car => car.Manufacturer,
            //    (m, c) =>
            //    new
            //    {
            //        Manufacturer = m,
            //        Cars = c
            //    })
            //    .OrderBy(x => x.Manufacturer.Name);

            //foreach(var group in groups)
            //{
            //    Console.WriteLine($"Manufacturer: {group.Manufacturer.Name}");
            //    Console.WriteLine($"\t Cars: {group.Cars.Count()}");
            //    Console.WriteLine($"\t Max: {group.Cars.Max(x => x.Combined)}");
            //    Console.WriteLine($"\t Max: {group.Cars.Min(x => x.Combined)}");
            //    Console.WriteLine($"\t Max: {group.Cars.Average(x => x.Combined)}");
            //    Console.WriteLine();
            //}

            //var groups = cars
            //    .GroupBy(x => x.Manufacturer)
            //    .Select(g => new
            //    {
            //        Name = g.Key,
            //        Max = g.Max(c => c.Combined),
            //        Min = g.Min(c => c.Combined),
            //        Average = g.Average(c => c.Combined)
            //    })
            //    .OrderBy(x => x.Average);

            //foreach (var group in groups)
            //{
            //    Console.WriteLine($"{group.Name}");
            //    Console.WriteLine($"\t Max: {group.Max}");
            //    Console.WriteLine($"\t Average: {group.Average}");
            //}

            //var carsInCountry = cars.Join(
            //    manufacturers,
            //    x => x.Manufacturer,
            //    x => x.Name,
            //    (car, manufacturer) => new
            //    {
            //        manufacturer.Country,
            //        car.Name,
            //        car.Combined
            //    })
            //    .OrderByDescending(x => x.Combined)
            //    .ThenBy(x => x.Name);

            //foreach (var car in carsInCountry)
            //{
            //    Console.WriteLine($"Country: {car.Country}");
            //    Console.WriteLine($"\tName: {car.Name}");
            //    Console.WriteLine($"\tCombined: {car.Combined}");
            //}

            //var carsInCountry = cars.Join(
            //    manufacturers,
            //    c => new { c.Manufacturer, c.Year },
            //    m => new { Manufacturer = m.Name, m.Year },
            //    (car, manufacturer) => new
            //    {
            //        manufacturer.Country,
            //        car.Name,
            //        car.Combined
            //    })
            //    .OrderByDescending(x => x.Combined)
            //    .ThenBy(x => x.Name);

            //foreach (var car in carsInCountry)
            //{
            //    Console.WriteLine($"Country: {car.Country}");
            //    Console.WriteLine($"\tName: {car.Name}");
            //    Console.WriteLine($"\tCombined: {car.Combined}");
            //}

            var records = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
            var manufacturers = _csvReader.ProcessManufacturer("Resources\\Files\\manufacturers.csv");

            var document = new XDocument();
            var cars = new XElement("Cars", records.Select(x =>
            new XElement("Car",
            new XAttribute("Name", x.Name),
            new XAttribute("Combined", x.Combined),
            new XAttribute("Manufacturer", x.Manufacturer))));

            document.Add(cars);
            document.Save("fuel.xml");
        }
        private void QueryXml()
        {
            var document = XDocument.Load("fuel.xml");
            var names = document
                .Element("Cars")?
                .Elements("Car")
                .Where(x=>x.Attribute("Manufacturer")?.Value == "BMW")
                .Select(x => x.Attribute("Name")?.Value);

            foreach (var name in names)
            {
                Console.WriteLine(name);
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
