using ProjetoFinanceiro.Domain.Dtos;
using ProjetoFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Testes.Helpers
{
    public static class ClienteDtoFactory
    {
        public static ClienteDto GetClienteDto()
        {
            ClienteDto cliente = new ClienteDto
            {
                Clienteid = 1,
                Nome = "Debora",
                Cpf = "1234"
            };

            return cliente; 
        }
    }
}
