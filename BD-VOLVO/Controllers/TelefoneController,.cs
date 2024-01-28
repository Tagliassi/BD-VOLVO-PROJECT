using Microsoft.AspNetCore.Mvc;

namespace BD_VOLVO{

    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Telefone telefone)
        {
            using (var _context = new HotelContext())
            {
                _context.Telefones.Add(telefone);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Telefone> Get()
        {
            using (var _context = new HotelContext())
            {
                return _context.Telefones.ToList();
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Telefones.FirstOrDefault(t => t.IdTelefone == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Telefone telefone)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Telefones.FirstOrDefault(t => t.IdTelefone == id);
                if(item == null)
                {
                    return; 
                }
                _context.Entry(item).CurrentValues.SetValues(telefone);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Telefones.FirstOrDefault(t => t.IdTelefone == id);
                if(item == null)
                {
                    return; 
                }
                _context.Telefones.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}