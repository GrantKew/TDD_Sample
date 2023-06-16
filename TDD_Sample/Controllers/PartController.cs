using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TDD_Sample.Data;
using TDD_Sample.Enums;
using TDD_Sample.Models;

namespace TDD_Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartController : ControllerBase
    {
        private List<Part> parts = new List<Part>();

        public PartController()
        {
            parts = DataReader.ReadAndonvertData<List<Part>>("parts");
        }

        [HttpGet(Name = "ListParts")]
        public List<Part> ListPart()
        {
            return parts;
        }

        [HttpGet(Name = "ListParts/{category}")]
        public List<Part> ListPart(PartCategory category)
        {
            return parts.Where(x => x.Category == category).ToList();
        }

        [HttpGet(Name = "GetPart/{id}")]
        public Part GetPartById(int PartId)
        {
            //first here because an id should always return a Part
            return parts.First(x => x.Id == PartId);
        }

        [HttpGet(Name = "GetPart/{name}")]
        public Part GetPartByName(string PartName)
        {
            //first or default here ecause this could be a search 
            return parts.FirstOrDefault(x => x.Name.EqualsIgnoreCase(PartName));
        }

        [HttpPost(Name = "CreatePart")]
        public void CreatePart(Part Part)
        {
            parts.Add(Part);
        }
    }
}