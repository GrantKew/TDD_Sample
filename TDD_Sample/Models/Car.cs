using TDD_Sample.Enums;

namespace TDD_Sample.Models
{
    public class Car : ModelBase
    {
        public int YOM { get; set; }
        public CarTypes CarType { get; set; }
    }
}
