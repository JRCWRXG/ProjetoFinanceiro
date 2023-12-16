using ProjetoFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Domain.Dtos
{
    public class ClienteDto
    {
        public int Clienteid { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }





        public Cliente ConverterParaEntidade()
        {
            return new Cliente
            {
                Clienteid = this.Clienteid,
                Nome = this.Nome,
                Cpf = this.Cpf
            };
        }

            

        public static List<Cliente> ConverterParaEntidade(List<ClienteDto> clienteDto)
        {
            List<Cliente> clientes = new List<Cliente>();

            foreach (ClienteDto cliente in clienteDto)
            {
                Cliente entidade = cliente.ConverterParaEntidade();
                clientes.Add(entidade);
            }

            return clientes;
    } }


}
