using TDD_Sample;
using TDD_Sample.Controllers;
using TDD_Sample.Models;
using Enums = TDD_Sample.Enums;

namespace UnitTests
{
    [TestClass]
    public class Parts
    {
        PartController controller = new PartController();
        [TestMethod]
        public void ListPart()
        {
            var parts = controller.ListPart();
            Assert.IsFalse(!parts.Any(), "Unable to read parts list");
        }

        [TestMethod]
        public void ListPartByCategory()
        {
            var category = Common.RandomEnumValue<Enums.PartCategory>();
            category = Enum.Parse<Enums.PartCategory>(category.ToString());
            var parts = controller.ListPart(category);

            Assert.IsFalse(!parts.Any(), $"Unable to find parts of category {category}");
        }

        [TestMethod]
        [DataRow]
        public void GetPartById(int id = -1)
        {
            var parts = controller.ListPart();
            var randomId = id == -1 ? Common.RandomIntValue(parts.Count - 1) : id;

            var part = controller.GetPartById(randomId);
            Assert.IsTrue(part is not null, $"No part could be found for Id {randomId}");
        }

        [TestMethod]
        [DataRow]
        public void GetPartByName(string partName = "")
        {
            var parts = controller.ListPart();
            if (string.IsNullOrEmpty(partName))
            {
                var randomId = Common.RandomIntValue(parts.Count - 1);
                partName = parts.First(x => x.Id == randomId)?.Name ?? "N/A";
            }

            var part = controller.GetPartByName(partName);

            Assert.IsTrue(part is not null, $"No part could be found for name {partName}");
        }

        [TestMethod]
        public void CreatePart() {

            var newPartId = 999999999;
            var PartName = "New Test Part";
            var part = new Part
            {
                Category = Enums.PartCategory.Body,
                Id = newPartId,
                Name = PartName,
                Price = 100m
            };

            controller.CreatePart(part);

            GetPartById(newPartId);
            GetPartByName(PartName);
        }
    }
}