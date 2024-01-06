using MotoApp.Components.CsvReader;
using MotoApp.Data;
using MotoApp.Data.Entities;

namespace MotoApp
{
    public class App : IApp
    {
        private readonly ICsvReader _csvReader;
        private readonly MotoAppDbContext _motoAppDbContext;

        public App(ICsvReader csvReader, MotoAppDbContext motoAppDbContext)
        {
            _csvReader = csvReader;
            _motoAppDbContext = motoAppDbContext;
            _motoAppDbContext.Database.EnsureCreated();
        }

        public void Run()
        {
            //InsertData();
            //ReadAllCarsFromDb();
            ReadGroupedCarsFromDb();

            //var cayman = this.ReadFirst("Cayman"); // Podmienianie
            //cayman.Name = "Mój samochód";
            //_motoAppDbContext.SaveChanges();

            //var cayman = this.ReadFirst("Cayman"); // Usuwanie
            //_motoAppDbContext.Remove(cayman);
            //_motoAppDbContext.SaveChanges();
        }

        private Car? ReadFirst(string name)
        {
            return _motoAppDbContext.Cars.FirstOrDefault(x => x.Name == name);
        }

        private void ReadGroupedCarsFromDb()
        {
            var groups = _motoAppDbContext.Cars
                .GroupBy(x => x.Manufacturer)
                .Select(x=> new 
                {
                    Name = x.Key, 
                    Cars = x.ToList()
                }).ToList();

            foreach (var group in groups)
            {
                Console.WriteLine(group.Name);
                Console.WriteLine("=====================================================");
                foreach(var car in group.Cars)
                {
                    Console.WriteLine($"\t{car.Name}: {car.Combined}");
                }
                Console.WriteLine();
            }

        }

        private void ReadAllCarsFromDb()
        {
            var carsFromDb = _motoAppDbContext.Cars.ToList();

            foreach (var carFromDb in carsFromDb)
            {
                Console.WriteLine($"\t{carFromDb.Name}: {carFromDb.Combined}");
            }
        }

        private void InsertData()
        {
            var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");

            foreach (var car in cars)
            {
                _motoAppDbContext.Cars.Add(new Car()
                {
                    Manufacturer = car.Manufacturer,
                    Name = car.Name,
                    Year = car.Year,
                    City = car.City,
                    Combined = car.Combined,
                    Cylinders = car.Cylinders,
                    Displacement = car.Displacement,
                    Highway = car.Highway
                });

            }
            _motoAppDbContext.SaveChanges();
        }
    }
}
