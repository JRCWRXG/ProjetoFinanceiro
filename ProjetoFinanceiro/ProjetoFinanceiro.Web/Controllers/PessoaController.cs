using Microsoft.AspNetCore.Mvc;
using ProjetoFinanceiro.Web.Models.Dtos;

namespace ProjetoFinanceiro.Web.Controllers
{
    public class PessoaController : Controller
    {
        private static List<PessoaDto> _pessoas = null;

        public PessoaController()
        {
            _pessoas = new List<PessoaDto>();

            PessoaDto pessoa1 = new PessoaDto {
                Id = Guid.NewGuid().ToString(),
                Nome = "Jose Robeto",
                Email = "jose@gmail.com"

            };    

            _pessoas.Add(pessoa1);

            PessoaDto pessoa2 = new PessoaDto
            {
                Id = Guid.NewGuid().ToString(),
                Nome = "Jose Beto",
                Email = "beto@gmail.com"

            };

            _pessoas.Add(pessoa2);

            PessoaDto pessoa3 = new PessoaDto
            {
                Id = Guid.NewGuid().ToString(),
                Nome = "Jose ",
                Email = "beto@gmail.com"

            };

            _pessoas.Add(pessoa3);
        }


        public IActionResult Listar()
        { 
        return View(_pessoas);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
