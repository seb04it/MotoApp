using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace MotoApp.Entities
{
    public class Employee : EntityBase
    {
        public Employee()
        {
        }

        public string? FirstName { get; set; }
        public override string ToString() => $"Id: {Id}, FirstName: {FirstName}";
    }
}