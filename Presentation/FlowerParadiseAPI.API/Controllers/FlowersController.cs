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
        private readonly IFlowerSpeciesRepository _flowerSpeciesRepository;

        public FlowersController(IFlowerRepository flowerRepository, IFlowerSpeciesRepository flowerSpeciesRepository)
        {
            _flowerRepository = flowerRepository;
            _flowerSpeciesRepository = flowerSpeciesRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var speciesId = Guid.NewGuid();
            //await _flowerSpeciesRepository.AddAsync(new() { Id = speciesId, SpeciesName = "Zambak", CreateDate = DateTime.UtcNow });

            //await _flowerRepository.AddAsync(new() { Name = "Zambak 7", Price = 16, Stock = 15,CreateDate=DateTime.UtcNow,SpeciesId=speciesId}) ;

            // await _flowerSpeciesRepository.SaveAsync();
            //Flower flower = await _flowerRepository.GetByIdAsync("6330b86e-a91b-4647-b0d5-ba66e4072089");
            //flower.Name = "Gül 2";
            await _flowerRepository.SaveAsync();
            return Ok(_flowerRepository.GetAll(false));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _flowerRepository.GetByIdAsync(id,false)); ;
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Flower model)
        {
            var speciesId = Guid.NewGuid();
            await _flowerSpeciesRepository.AddAsync(new() { Id = speciesId, SpeciesName = "Çiçek", CreateDate = DateTime.UtcNow });

            await _flowerRepository.AddAsync(new()
            {
                Name = model.Name,
                Stock = model.Stock,
                Price = model.Price,
                SpeciesId = speciesId
            }) ;
            await _flowerRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Flower model)
        {
            Flower flower =await _flowerRepository.GetByIdAsync(model.Id);
            flower.Stock = model.Stock;
            flower.Price = model.Price;
            flower.Name = model.Name;
            await _flowerRepository.SaveAsync();

            return Ok();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _flowerRepository.Remove(id);
            await _flowerRepository.SaveAsync();
            return Ok();
        }
    }
}
