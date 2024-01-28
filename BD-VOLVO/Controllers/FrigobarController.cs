using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BD_VOLVO.Models;

namespace BD_VOLVO{

    [Route("api/[controller]")]
    [ApiController]
    public class FrigobarController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Frigobar frigobar)
        {
            using (var _context = new HotelContext())
            {
                _context.Frigobares.Add(frigobar);
                _context.SaveChanges();
            }
        }
 
        [HttpGet]
        public List<Frigobar> Get()
        {
            using (var _context = new HotelContext())
            {
                return _context.Frigobares.ToList();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Frigobares.FirstOrDefault(t => t.IdFrigobar == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Frigobar frigobar)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Frigobares.FirstOrDefault(t => t.IdFrigobar == id);
                if(item == null)
                {
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(frigobar);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Frigobares.FirstOrDefault(t => t.IdFrigobar == id);
                if(item == null)
                {
                    return;
                }
                _context.Frigobares.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}