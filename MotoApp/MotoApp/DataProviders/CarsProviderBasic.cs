﻿//using MotoApp.Entities;
//using MotoApp.Repositories;


//namespace MotoApp.DataProviders
//{
//    public class CarsProviderBasic : ICarsProvider
//    {
//        private readonly IRepository<Car> _carsRepository;
//        public CarsProviderBasic(IRepository<Car> carsRepository)
//        {
//            _carsRepository = carsRepository;
//        }

//        public List<Car> FilterCars(decimal minPrice)
//        {
//            var cars = _carsRepository.GetAll();
//            var list = new List<Car>();

//            foreach(var car in cars)
//            {
//                if(car.ListPrice > minPrice)
//                {
//                    list.Add(car);
//                }
//            }
//            return list;
//        }

//        public decimal GetMinimumPriceOfAllCars()
//        {
//            var cars = _carsRepository.GetAll();
//            decimal ret = decimal.MaxValue;

//            foreach(var car in cars)
//            {
//                if(car.ListPrice < ret)
//                {
//                    ret = car.ListPrice;
//                }
//            }
//            return ret;
//        }

//        public List<string> GetUniqueCarColors()
//        {
//            var cars = _carsRepository.GetAll();
//            List<string> list = new();

//            foreach (var car in cars)
//            {
//                if (!list.Contains(car.Color))
//                {
//                    list.Add(car.Color);
//                }
//            }
//            return list;
//        }
//    }
//}
