using Microsoft.AspNetCore.Mvc;

namespace BD_VOLVO{

    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Servicos servico)
        {
            using (var _context = new HotelContext())
            {
                _context.Servicos.Add(servico);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Servicos> Get()
        {
            using (var _context = new HotelContext())
            {
                return _context.Servicos.ToList();
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Servicos.FirstOrDefault(t => t.IdServico == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Servicos servico)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Servicos.FirstOrDefault(t => t.IdServico == id);
                if(item == null)
                {
                    return; 
                }
                _context.Entry(item).CurrentValues.SetValues(servico);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Servicos.FirstOrDefault(t => t.IdServico == id);
                if(item == null)
                {
                    return; 
                }
                _context.Servicos.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}