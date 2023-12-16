using ProjetoFinanceiro.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Domain.Entities
{
    public class Cliente
    {

        public int Clienteid { get; set; }
        public string Nome { get;set; }
        public string Cpf { get; set; }

        public ClienteDto ConverterParaDto()
        {
            return new ClienteDto
            {
                Clienteid = this.Clienteid,
                Nome = this.Nome,   
                Cpf = this.Cpf
            };
        }

        public static List<ClienteDto> ConverterParaDto(List<Cliente> clientes) 
           {
            List<ClienteDto> clienteDtos= new List<ClienteDto>();   

            foreach (Cliente cliente in clientes)
            {
                ClienteDto dto = cliente.ConverterParaDto();
                clienteDtos.Add(dto);   
            }

            return clienteDtos;
        }

        //private int Clienteid;

        //public int GetCliente()
        //{
        //    return Clienteid;
        //}

        //public void SetClienteId(int clienteid) 
        //{
        //    this.Clienteid = clienteid; 
        //}
    }
}
