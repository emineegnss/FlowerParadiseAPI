using FlowerParadiseAPI.Application.Repositories;
using FlowerParadiseAPI.Application.ViewModels.Flowers;
using FlowerParadiseAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Net.WebRequestMethods;

namespace FlowerParadiseAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private readonly IFlowerRepository _flowerRepository;

        public FlowersController(IFlowerRepository flowerRepository, IFlowerSpeciesRepository flowerSpeciesRepository)
        {
            _flowerRepository = flowerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var speciesId = Guid.NewGuid();
            //await _flowerSpeciesRepository.AddAsync(new() { Id = speciesId, SpeciesName = "Gül", CreateDate = DateTime.UtcNow });

            //await _flowerRepository.AddAsync(new() { Name = "Gül 1", Price = 12, Stock = 15,CreateDate=DateTime.UtcNow,SpeciesId=speciesId}) ;

            // await _flowerSpeciesRepository.SaveAsync();
            //Flower flower = await _flowerRepository.GetByIdAsync("6330b86e-a91b-4647-b0d5-ba66e4072089");
            //flower.Name = "Gül 2";
            //_flowerRepository.SaveAsync();
            return Ok(_flowerRepository.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Flower model)
        {
           await _flowerRepository.AddAsync(new()
            {
                Name = model.Name,
                Stock = model.Stock,
                Price = model.Price,
            });
            await _flowerRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put()
        {

        }
    }
}
