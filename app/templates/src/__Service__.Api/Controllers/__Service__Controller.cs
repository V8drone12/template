using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using __Namespace__.__Service__.Core.Domain.Models;
using __Namespace__.__Service__.Core.Domain.Repositories.Interfaces;
using __Namespace__.__Service__.Core.MessageHandlers.Interfaces;

namespace __Namespace__.__Service__.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class __Service__Controller : ControllerBase
    {
        private readonly I__Service__Repository _repository;
        private readonly I__Service__Producer _producer;

        public __Service__Controller(I__Service__Repository repository, I__Service__Producer producer)
        {
            _repository = repository;
            _producer = producer;
        }

        [HttpGet]
        public async Task<IActionResult> Get__Service__s()
        {
            var dtos = await _repository.Get__Service__s();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get__Service__([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = await _repository.Get__Service__(id);

            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put__Service__([FromRoute] int id, [FromBody] __Service__Dto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
            await _repository.Update__Service__(dto);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post__Service__s([FromBody] IEnumerable<__Service__Dto> dtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }                
            var result = await _repository.Add__Service__s(dtos);

            _producer.Produce(JsonConvert.SerializeObject(result));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete__Service__([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repository.Delete__Service__(id);

            return result ? Ok() : (IActionResult)NotFound();
        }
    }
}