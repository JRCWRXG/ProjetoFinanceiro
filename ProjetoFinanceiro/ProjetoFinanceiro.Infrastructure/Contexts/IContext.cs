using ProjetoFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Infrastructure.Contexts
{
    public interface IContext
    {
        public void CreateCliente(Cliente cliente);
        public List<Cliente> ReadClientes();
        public Cliente ReadCliente(int id);
        public void UpdateCliente(Cliente cliente);
        public void DeleteCliente(int id);

        public int NextId();



    }
}
