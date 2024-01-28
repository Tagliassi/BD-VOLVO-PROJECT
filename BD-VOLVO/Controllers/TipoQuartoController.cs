using Microsoft.AspNetCore.Mvc;

namespace BD_VOLVO{

    [Route("api/[controller]")]
    [ApiController]
    public class TipoQuartoController : Controller
    {
        [HttpPost]
        public void Post([FromBody] TipoQuarto tipoQuarto)
        {
            using (var _context = new HotelContext())
            {
                _context.TipoQuartos.Add(tipoQuarto);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<TipoQuarto> Get()
        {
            using (var _context = new HotelContext())
            {
                return _context.TipoQuartos.ToList();
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.TipoQuartos.FirstOrDefault(t => t.IdTipoQuarto == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] TipoQuarto employee)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.TipoQuartos.FirstOrDefault(t => t.IdTipoQuarto == id);
                if(item == null)
                {
                    return; 
                }
                _context.Entry(item).CurrentValues.SetValues(employee);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.TipoQuartos.FirstOrDefault(t => t.IdTipoQuarto == id);
                if(item == null)
                {
                    return; 
                }
                _context.TipoQuartos.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}