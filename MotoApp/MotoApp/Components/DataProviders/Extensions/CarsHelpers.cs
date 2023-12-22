using MotoApp.Data.Entities;

namespace MotoApp.Components.DataProviders.Extensions
{
    public static class CarsHelpers
    {
        public static IEnumerable<Car> ByColor(this IEnumerable<Car> query, string color)
        {
            return query.Where(x => x.Color == color);
        }
    }
}
