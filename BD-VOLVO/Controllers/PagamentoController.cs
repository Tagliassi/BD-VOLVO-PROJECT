using Microsoft.AspNetCore.Mvc;

namespace BD_VOLVO{

    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Pagamento pagamento)
        {
            using (var _context = new HotelContext())
            {
                _context.Pagamentos.Add(pagamento);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Pagamento> Get()
        {
            using (var _context = new HotelContext())
            {
                return _context.Pagamentos.ToList();
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Pagamentos.FirstOrDefault(t => t.IdPagamento == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Pagamento pagamento)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Pagamentos.FirstOrDefault(t => t.IdPagamento == id);
                if(item == null)
                {
                    return; 
                }
                _context.Entry(item).CurrentValues.SetValues(pagamento);
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Pagamentos.FirstOrDefault(t => t.IdPagamento == id);
                if(item == null)
                {
                    return; 
                }
                _context.Pagamentos.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}