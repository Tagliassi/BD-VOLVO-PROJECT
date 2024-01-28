using Microsoft.AspNetCore.Mvc;

namespace BD_VOLVO{

    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Restaurante restaurante)
        {
            using (var _context = new HotelContext())
            {
                _context.Restaurantes.Add(restaurante);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Restaurante> Get()
        {
            using (var _context = new HotelContext())
            {
                return _context.Restaurantes.ToList();
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Restaurantes.FirstOrDefault(t => t.IdRestaurante == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Restaurante restaurante)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Restaurantes.FirstOrDefault(t => t.IdRestaurante == id);
                if(item == null)
                {
                    return; 
                }
                _context.Entry(item).CurrentValues.SetValues(restaurante);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Restaurantes.FirstOrDefault(t => t.IdRestaurante == id);
                if(item == null)
                {
                    return; 
                }
                _context.Restaurantes.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}