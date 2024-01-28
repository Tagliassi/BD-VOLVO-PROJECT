using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BD_VOLVO.Models;

namespace BD_VOLVO{

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteContaController : Controller
    {
        [HttpPost]
        public void Post([FromBody] ClienteConta ClienteConta)
        {
            using (var _context = new HotelContext())
            {
                _context.ClienteContas.Add(ClienteConta);
                _context.SaveChanges();
            }
        }
 
        [HttpGet]
        public List<ClienteConta> Get()
        {
            using (var _context = new HotelContext())
            {
                return _context.ClienteContas.ToList();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.ClienteContas.FirstOrDefault(t => t.IdConta == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id,[FromBody] ClienteConta ClienteConta)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.ClienteContas.FirstOrDefault(t => t.IdConta == id);
                if(item == null)
                {
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(ClienteConta);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.ClienteContas.FirstOrDefault(t => t.IdConta == id);
                if(item == null)
                {
                    return;
                }
                _context.ClienteContas.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}