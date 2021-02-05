using System.Collections.Generic;

namespace TP2.Entities
{
    public class CarType : EntityBase
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public List<EquipmentType> EquipmentTypes { get; set; }
    }
}