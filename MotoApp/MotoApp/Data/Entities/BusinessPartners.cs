namespace MotoApp.Data.Entities
{
    public class BuisinessPartners : EntityBase
    {
        public string? Name { get; set; }
        public override string ToString() => $"Id: {Id}, Name: {Name}";
    }
}

