using ProjetoFinanceiro.Domain.Dtos;
using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Testes.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Testes.Domain
{
    public class DominioTeste
    {
        public void Execute()
        {
            TestarEntidade();
            TestarDto();
            TestarConversaoEntidadeParaDto();
            TestarConversaoDtoParaEntidade();
        }
        private void TestarEntidade()
        {
            Cliente cliente = ClienteFactory.GetCliente();  
            //Cliente cliente = new Cliente
            //{
            //    Clienteid = 1,
            //    Nome = "Debora",
            //    Cpf = "1234"
            //};

            string message = $"Id: {cliente.Clienteid}, Nome {cliente.Nome}";
            Console.WriteLine(message);
        }


        private void TestarConversaoEntidadeParaDto()
        {
            Cliente cliente = ClienteFactory.GetCliente();
            //Cliente cliente = new Cliente
            //{
            //    Clienteid = 1,
            //    Nome = "Debora",
            //    Cpf = "1234"
            //};

            ClienteDto dto = cliente.ConverterParaDto();

            string message = $"Id: {dto.Clienteid}, Nome {dto.Nome}";
            Console.WriteLine(message);
        }


        private void TestarDto()
        {
            ClienteDto cliente = ClienteDtoFactory.GetClienteDto();
            //ClienteDto cliente = new ClienteDto
            //{
            //    Clienteid = 1,
            //    Nome = "Debora",
            //    Cpf = "1234"
            //};

            string message = $"Id: {cliente.Clienteid}, Nome {cliente.Nome}";
            Console.WriteLine(message);
            Console.ReadLine();
        }

        private void TestarConversaoDtoParaEntidade()
        {
            ClienteDto cliente = ClienteDtoFactory.GetClienteDto();
            //ClienteDto cliente = new ClienteDto
            //{
            //    Clienteid = 1,
            //    Nome = "Debora",
            //    Cpf = "1234"
            //};

            Cliente entidade = cliente.ConverterParaEntidade();

            string message = $"Id: {entidade.Clienteid}, Nome {entidade.Nome}";
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
