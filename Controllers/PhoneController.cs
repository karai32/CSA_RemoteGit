using KlientServ.Models;
using KlientServ.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KlientServ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {

        private IStorage<Phone> _MEM;

        public PhoneController(IStorage<Phone> MemCache)
        {
            _MEM = MemCache;
        }
        [HttpGet]
        [HttpGet]
        public ActionResult<IEnumerable<Phone>> Get()
        {
            return Ok(_MEM.All);
        }

        [HttpGet("{id}")]
        public ActionResult<Phone> Get(Guid id)
        {
            if (!_MEM.Has(id)) return NotFound("No such");

            return Ok(_MEM[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Phone value)
        {
            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            _MEM.Add(value);

            return Ok($"{value.ToString()} has been added");
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Phone value)
        {
            if (!_MEM.Has(id)) return NotFound("No such");

            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var previousValue = _MEM[id];
            _MEM[id] = value;

            return Ok($"{previousValue.ToString()} has been updated to {value.ToString()}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_MEM.Has(id)) return NotFound("No such");

            var valueToRemove = _MEM[id];
            _MEM.RemoveAt(id);

            return Ok($"{valueToRemove.ToString()} has been removed");
        }
    }
}
