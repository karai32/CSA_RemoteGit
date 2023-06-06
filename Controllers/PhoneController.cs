using KlientServ.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KlientServ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private static List<Phone> _MEM = new List<Phone>();

        [HttpGet]
        public ActionResult<IEnumerable<Phone>> Get()
        {
            return _MEM;
        }

        [HttpGet("{id}")]
        public ActionResult<Phone> Get(int id)
        {
            if (_MEM.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            return _MEM[id];
        }

        [HttpPost]
        public void Post([FromBody] Phone value)
        {
            _MEM.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Phone value)
        {
            if (_MEM.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            _MEM[id] = value;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_MEM.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            _MEM.RemoveAt(id);
        }
    }
}
