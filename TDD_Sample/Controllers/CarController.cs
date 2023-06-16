using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TDD_Sample.Data;
using TDD_Sample.Models;

namespace TDD_Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private List<Car> cars = new List<Car>();
        public CarController()
        {
            cars = DataReader.ReadAndonvertData<List<Car>>("cars");
        }

        [HttpGet(Name = "ListCars")]
        public List<Car> ListCar()
        {
            return cars;
        }

        [HttpGet(Name = "GetCar/{id}")]
        public Car GetCarById(int carId)
        {
            //first here because an id should always return a car
            return cars.First(x => x.Id == carId);
        }

        [HttpGet(Name = "GetCar/{name}")]
        public Car GetCarByName(string carName)
        {
            //first or default here ecause this could be a search 
            return cars.FirstOrDefault(x => x.Name.EqualsIgnoreCase(carName));
        }

        [HttpPost(Name = "CreateCar")]
        public void CreateCar(Car car)
        {
            cars.Add(car);
            var x = JsonConvert.SerializeObject(car);
        }
    }
}