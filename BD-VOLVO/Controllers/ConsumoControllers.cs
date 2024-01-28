using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BD_VOLVO.Models;

namespace BD_VOLVO{

    [Route("api/[controller]")]
    [ApiController]
    public class ConsumoController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Consumo consumo)
        {
            using (var _context = new HotelContext())
            {
                _context.Consumos.Add(consumo);
                _context.SaveChanges();
            }
        }
 
        [HttpGet]
        public List<Consumo> Get()
        {
            using (var _context = new HotelContext())
            {
                return _context.Consumos.ToList();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Consumos.FirstOrDefault(t => t.IdConsumo == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }
        /*
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Consumo consumo)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Consumos.FirstOrDefault(t => t.IdConsumo == id);
                if(item == null)
                {
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(consumo);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Consumos.FirstOrDefault(t => t.IdConsumo == id);
                if(item == null)
                {
                    return;
                }
                _context.Consumos.Remove(item);
                _context.SaveChanges();
            }
        }
        */
    }
}