using TDD_Sample.Enums;

namespace TDD_Sample.Models
{
    public class Part : ModelBase
    {
        public decimal Price { get; set; }
        public PartCategory Category { get; set; }
    }
}
