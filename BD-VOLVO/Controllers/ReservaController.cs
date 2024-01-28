using Microsoft.AspNetCore.Mvc;

namespace BD_VOLVO{

    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Reserva reserva)
        {
            using (var _context = new HotelContext())
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Reserva> Get()
        {
            using (var _context = new HotelContext())
            {
                return _context.Reservas.ToList();
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Reservas.FirstOrDefault(t => t.IdReserva == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Reserva reserva)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Reservas.FirstOrDefault(t => t.IdReserva == id);
                if(item == null)
                {
                    return; 
                }
                _context.Entry(item).CurrentValues.SetValues(reserva);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Reservas.FirstOrDefault(t => t.IdReserva == id);
                if(item == null)
                {
                    return; 
                }
                _context.Reservas.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}