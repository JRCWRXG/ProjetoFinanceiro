using ProjetoFinanceiro.Domain.Dtos;
using ProjetoFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Testes.Helpers
{
    public static class ClienteFactory
    {
        public static Cliente GetCliente()
        {
            Cliente cliente = new Cliente
            {
                Clienteid = 1,
                Nome = "deb",
                Cpf = "1234"
            };

            return cliente;
        }

        public static Cliente GetNovoCliente()
        {
            Cliente cliente = new Cliente
            {
                Clienteid = 10,
                Nome = "Roberto",
                Cpf = "1234"
            };
            return cliente; 

        }
    }
}
