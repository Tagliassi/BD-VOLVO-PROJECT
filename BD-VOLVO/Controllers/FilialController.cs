using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BD_VOLVO.Models;

namespace BD_VOLVO{

    [Route("api/[controller]")]
    [ApiController]
    public class FilialController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Filial filial)
        {
            using (var _context = new HotelContext())
            {
                _context.Filiais.Add(filial);
                _context.SaveChanges();
            }
        }
 
        [HttpGet]
        public List<Filial> Get()
        {
            using (var _context = new HotelContext())
            {
                return _context.Filiais.ToList();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Filiais.FirstOrDefault(t => t.IdFilial == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Filial filial)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Filiais.FirstOrDefault(t => t.IdFilial == id);
                if(item == null)
                {
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(filial);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Filiais.FirstOrDefault(t => t.IdFilial == id);
                if(item == null)
                {
                    return;
                }
                _context.Filiais.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}