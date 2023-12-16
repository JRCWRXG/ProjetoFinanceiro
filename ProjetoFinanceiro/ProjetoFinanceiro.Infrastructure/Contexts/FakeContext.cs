using ProjetoFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Infrastructure.Contexts
{
    public class FakeContext : IContext
    {
        private List<Cliente> _clientes;

        public FakeContext()
        {
            LoadData();
        }

       

        

        public List<Cliente> ReadClientes()
        {
            return _clientes
                .OrderBy(p => p.Clienteid)
                .ToList();
        }

        public Cliente ReadCliente(int id)
        {
            Cliente result = _clientes
                .FirstOrDefault(p => p.Clienteid.Equals(id));

            return result;

            //return _clientes .FirstOrDefault(p => p.Equals(id));
        }

        public void CreateCliente(Cliente cliente)
        {
            _clientes.Add(cliente);
        }
        public void UpdateCliente(Cliente cliente)
        {
            Cliente objPesquisa = ReadCliente(cliente.Clienteid);
            _clientes.Remove(objPesquisa);

            objPesquisa = new Cliente
            { 
            Clienteid= cliente.Clienteid,
            Nome= !string.IsNullOrEmpty(cliente.Nome) ? cliente.Nome : objPesquisa.Nome,                
            Cpf= !string.IsNullOrEmpty(cliente.Cpf) ? cliente.Cpf : objPesquisa.Cpf,    
            };

            _clientes.Add(objPesquisa); 
        }

        public void DeleteCliente(int id)
        {
            Cliente cliente = ReadCliente(id);
            if (cliente != null) 
                _clientes.Remove(cliente);  

        }

        private void LoadData()
        {
            _clientes = new List<Cliente>();

            Cliente cliente = new Cliente
            {
                Clienteid = 1,
                Nome = "jose",
                Cpf = "123"
            };
            _clientes.Add(cliente);

            cliente = new Cliente
            {
                Clienteid = 2,
                Nome = "Maria",
                Cpf = "555"
            };
            _clientes.Add(cliente);


            cliente = new Cliente
            {
                Clienteid = 3,
                Nome = "pedro",
                Cpf = "555"
            };
            _clientes.Add(cliente);

            cliente = new Cliente
            {
                Clienteid = 4,
                Nome = "silvia",
                Cpf = "555"
            };
            _clientes.Add(cliente);


            cliente = new Cliente
            {
                Clienteid = 5,
                Nome = "debora",
                Cpf = "555"
            };
            _clientes.Add(cliente);
        }
    }
}
