using FlowerParadiseAPI.Application.Repositories;
using FlowerParadiseAPI.Domain.Entities;
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
        public async Task<IActionResult> GetAll()
        {
            //var speciesId = Guid.NewGuid();
            //await _flowerSpeciesRepository.AddAsync(new() { Id = speciesId, SpeciesName = "Gül", CreateDate = DateTime.UtcNow });

            //await _flowerRepository.AddAsync(new() { Name = "Gül 1", Price = 12, Stock = 15,CreateDate=DateTime.UtcNow,SpeciesId=speciesId}) ;

            // await _flowerSpeciesRepository.SaveAsync();
            Flower flower = await _flowerRepository.GetByIdAsync("6330b86e-a91b-4647-b0d5-ba66e4072089");
            flower.Name = "Gül 2";
            _flowerRepository.SaveAsync();
            return Ok();
        }
    }
}
