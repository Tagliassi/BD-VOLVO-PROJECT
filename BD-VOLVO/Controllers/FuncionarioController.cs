using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BD_VOLVO.Models;

namespace BD_VOLVO{

    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Funcionario funcionario)
        {
            using (var _context = new HotelContext())
            {
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
            }
        }
 
        [HttpGet]
        public List<Funcionario> Get()
        {
            using (var _context = new HotelContext())
            {
                return _context.Funcionarios.ToList();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Funcionarios.FirstOrDefault(t => t.IdFuncionario == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Funcionario funcionario)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Funcionarios.FirstOrDefault(t => t.IdFuncionario == id);
                if(item == null)
                {
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(funcionario);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelContext())
            {
                var item = _context.Funcionarios.FirstOrDefault(t => t.IdFuncionario == id);
                if(item == null)
                {
                    return;
                }
                _context.Funcionarios.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}