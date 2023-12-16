using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Services.Service
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> Listar()
        {
            return _clienteRepository.Listar();
        }

        public Cliente Pesquisar(int Id)
        {
            return _clienteRepository.Pesquisar(Id);
        }

        public void Salvar(Cliente cliente)
        {
            _clienteRepository.Salvar(cliente); 
        }

        public void Atualizar(Cliente cliente)
        {
            _clienteRepository.Atualizar(cliente);  
        }

        public void Excluir(int Id)
        {
            _clienteRepository.Excluir(Id);
        }
    }
}
