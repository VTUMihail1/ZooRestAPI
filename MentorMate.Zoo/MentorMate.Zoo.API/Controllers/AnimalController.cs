using MentorMate.Zoo.Business.DTOs.AnimalDTOs;
using MentorMate.Zoo.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MentorMate.Zoo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        // GET : api/Animal
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IEnumerable<AnimalResultDTO>>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _animalService.GetAllAsync();

            return Ok(response);
        }

        // GET : api/Animal/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AnimalViewDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var response = await _animalService.GetByIdAsync(id);

            if (response.HttpStatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.ErrorMessages);
            }

            return Ok(response.Data);
        }

        // POST: api/Animal
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AnimalResultDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AnimalResultDTO))]
        public async Task<IActionResult> CreateAsync([FromBody] AnimalAddDTO request)
        {
            var response = await _animalService.AddAsync(request);

            if (response.HttpStatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(response.ErrorMessages);
            }

            return Created(nameof(CreateAsync), response.Data);
        }

        // PUT: api/Animal/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AnimalResultDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AnimalResultDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] AnimalUpdateDTO request)
        {
            var response = await _animalService.UpdateAsync(id, request);

            if (response.HttpStatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(response.ErrorMessages);
            }

            if (response.HttpStatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.ErrorMessages);
            }

            return Ok(response.Data);
        }

        // DELETE: api/Animal/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var response = await _animalService.DeleteAsync(id);

            if (response.HttpStatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.ErrorMessages);
            }

            return NoContent();
        }
    }
}
