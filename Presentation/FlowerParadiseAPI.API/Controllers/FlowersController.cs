using FlowerParadiseAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace FlowerParadiseAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private readonly IFlowerRepository _flowerRepository;
        private readonly IFlowerSpeciesRepository _flowerSpeciesRepository;

        public FlowersController(IFlowerRepository flowerRepository, IFlowerSpeciesRepository flowerSpeciesRepository)
        {
            _flowerRepository = flowerRepository;
            _flowerSpeciesRepository = flowerSpeciesRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var speciesId = Guid.NewGuid();
            _flowerSpeciesRepository.AddAsync(new() { Id = speciesId, SpeciesName = "Gül", CreateDate = DateTime.UtcNow });

            _flowerRepository.AddAsync(new() { Id = Guid.NewGuid(), Name = "Gül 1", Price = 12, Stock = 15,CreateDate=DateTime.UtcNow,SpeciesId=speciesId}) ;
            _flowerSpeciesRepository.SaveAsync();
            return Ok(_flowerRepository.GetAll(false));
        }
    }
}
