using TDD_Sample;
using TDD_Sample.Controllers;
using TDD_Sample.Models;
using Enums = TDD_Sample.Enums;

namespace UnitTests
{
    [TestClass]
    public class Cars
    {
        CarController controller = new CarController();
        [TestMethod]
        public void ListCar()
        {
            var Cars = controller.ListCar();
            Assert.IsFalse(!Cars.Any(), "Unable to read Cars list");
        }

        [TestMethod]
        [DataRow]
        public void GetCarById(int id = -1)
        {
            var Cars = controller.ListCar();
            var randomId = id == -1 ? Common.RandomIntValue(Cars.Count - 1) : id;
            var Car = Cars.First(x => x.Id == randomId);
            Assert.IsTrue(Car is not null, $"No Car could be found for Id {randomId}");
        }

        [TestMethod]
        [DataRow]
        public void GetCarByName(string CarName = "")
        {
            var Cars = controller.ListCar();
            if (string.IsNullOrEmpty(CarName))
            {
                var randomId = Common.RandomIntValue(Cars.Count - 1);
                CarName = Cars.First(x => x.Id == randomId)?.Name ?? "N/A";
            }

            var Car = Cars.FirstOrDefault(x => x.Name.EqualsIgnoreCase(CarName));

            Assert.IsTrue(Car is not null, $"No Car could be found for name {CarName}");
        }

        [TestMethod]
        public void CreateCar() {

            var newCarId = 999999999;
            var CarName = "New Test Car";
            var Car = new Car
            {
                CarType = Enums.CarTypes.HyperCar,
                Id = newCarId,
                Name = CarName,
                YOM = DateTime.Now.Year
            };

            controller.CreateCar(Car);

            GetCarById(newCarId);
            GetCarByName(CarName);
        }
    }
}