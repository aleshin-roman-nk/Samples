﻿using Microsoft.AspNetCore.Mvc;
using RazorAPI.Models;
using RazorAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RazorAPI.Controllers
{
    [Route("api/Car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        // GET: api/Car
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _carService.ReadAll();
        }
        // GET: api/Car/5
        [HttpGet("{id}", Name = "Get")]
        public Car Get(int id)
        {
            return _carService.Read(id);
        }
        // POST: api/Car
        [HttpPost]
        public void Post([FromBody] Car car)
        {
            _carService.Create(car);
        }
        // PUT: api/Car/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car car)
        {
            _carService.Update(car);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _carService.Delete(id);
        }
    }
}
