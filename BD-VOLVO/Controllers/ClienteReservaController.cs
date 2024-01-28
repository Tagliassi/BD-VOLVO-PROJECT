using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BD_VOLVO.Models;

namespace BD_VOLVO{

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteReservaController : Controller
    {
        [HttpPost]
        public void Post([FromBody] ClienteReserva ClienteReserva)
        {
            using (var _context = new HotelContext())
            {
                _context.ClienteReservas.Add(ClienteReserva);
                _context.SaveChanges();
            }
        }
 
        [HttpGet]
        public List<ClienteReserva> Get()
        {
            using (var _context = new HotelContext())
            {
                return _context.ClienteReservas.ToList();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.ClienteReservas.FirstOrDefault(t => t.FkIdConta == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id,[FromBody] ClienteReserva ClienteReserva)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.ClienteReservas.FirstOrDefault(t => t.FkIdConta == id);
                if(item == null)
                {
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(ClienteReserva);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.ClienteReservas.FirstOrDefault(t => t.FkIdConta == id);
                if(item == null)
                {
                    return;
                }
                _context.ClienteReservas.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}