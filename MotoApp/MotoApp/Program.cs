using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.Components.CsvReader;
using MotoApp.Data;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

// Data Source=DESKTOP-TFF998T\SQLEXPRESS;Initial Catalog=TestStorage;Integrated Security=True

var connectionString = "Data Source=DESKTOP-TFF998T\\SQLEXPRESS;Initial Catalog=MotoAppStorage;Integrated Security=True;TrustServerCertificate=True";

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddDbContext<MotoAppDbContext>(options => options.UseSqlServer(connectionString));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();

//var services = new ServiceCollection();
//services.AddSingleton<IApp, App>();
//services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
//services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
//services.AddSingleton<ICsvReader, CsvReader>();
//services.AddDbContext<MotoAppDbContext>(options => options
//.UseSqlServer("Data Source=DESKTOP-TFF998T\\SQLEXPRESS;Initial Catalog=MotoAppStorage;Integrated Security=True"));


//var serviceProvider = services.BuildServiceProvider();
//var app = serviceProvider.GetService<IApp>()!;
//app.Run();

//using MotoApp.Data;
//using MotoApp.Entities;
//using MotoApp.Repositories;
//using MotoApp.Repositories.Extensions;

//var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), EmployeeAdded);
//employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;

//static void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
//{
//    Console.WriteLine($"Employee added => {e.FirstName} from {sender?.GetType().Name}");
//}

//AddEmployee(employeeRepository);
//WriteAllToConsole(employeeRepository);

//static void EmployeeAdded(Employee item)
//{
//    Console.WriteLine($"{item.FirstName} added");
//}

//static void AddEmployee(IRepository<Employee> employeeRepository)
//{
//    var employees = new[]
//    {
//        new Employee { FirstName = "Adam" },
//        new Employee { FirstName = "Piotr" },
//        new Employee { FirstName = "Zuzanna" }
//    };

//    employeeRepository.AddBatch(employees);

//}

////static void AddBatch<T>(IRepository<T> repository, T[] items)
////    where T : class, IEntity
////{
////    foreach (var item in items)
////    {
////        repository.Add(item);
////    }
////    repository.Save();
////}

//static void WriteAllToConsole(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }
//}