namespace TP2.Entities
{
    public class Car : EntityBase
    {
        public long? Id { get; set; }
        public CarType Type { get; set; }
        public string Registration { get; set; }
        public double? Mileage { get; set; }
    }
}