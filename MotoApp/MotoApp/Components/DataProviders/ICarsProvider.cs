﻿using MotoApp.Data.Entities;
using System.Data.Common;

namespace MotoApp.Components.DataProviders
{
    public interface ICarsProvider
    {
        // select
        List<string> GetUniqueCarColors();

        decimal GetMinimumPriceOfAllCars();

        List<Car> GetSpecificColums();

        string AnonymousClass();

        // order by

        List<Car> OrderByName();
        List<Car> OrderByNameDescending();
        List<Car> OrderByColorAndName();
        List<Car> OrderByColorAndNameDescending();

        // where

        List<Car> WhereStartsWith(string prefix);
        List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);
        List<Car> WhereColorIs(string color);

        // first, last, single
        Car FirstByColor(string color);
        Car? FirstOrDefaultByColor(string color);
        Car FirstOrDefaultByColorWithDefault(string color);
        Car LastByColor(string color);
        Car SingleById(int id);
        Car? SingleOrDefaultById(int id);

        // take
        List<Car> TakeCars(int howMany);
        List<Car> TakeCars(Range range);
        List<Car> TakeCarsWhileNameStartsWith(string prefix);

        // skip
        List<Car> SkipCars(int howMany);
        List<Car> SkipCarsWhileNameStartsWith(string prefix);

        // distinct
        List<string> DistinctAllColors();
        List<Car> DistinctByColors();

        // chunk
        List<Car[]> ChunkCars(int size);

        // paging
        //List<Car> Paging(int pageNumber);

    }
}
