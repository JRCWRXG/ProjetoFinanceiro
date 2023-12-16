using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Testes
{
    public class RepositorioTeste
    {
        private readonly IClienteRepository _clienteRepository;

        public RepositorioTeste(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Execute()
        {

            try
            {
                ValidarListagemClientes();
                ValidarPesquisaCliente();
                ValidarCadastroCliente();
                ValidarAtualizaçãoCliente();
                ValidarExclusaoCliente();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private void ValidarListagemClientes()
        {
            List<Cliente> clientes = _clienteRepository.Listar();

            foreach (Cliente Cliente in clientes)
            {
                Console.WriteLine($"Id: {Cliente.Clienteid}, Nome: {Cliente.Nome}");
            }
        }

        private void ValidarPesquisaCliente()
        {
            int id = 1;
            Cliente Cliente = _clienteRepository.Pesquisar(id);
            Console.WriteLine($"Id: {Cliente.Clienteid}, Nome: {Cliente.Nome}");
        }

        private void ValidarCadastroCliente()
        {
            int Id = 99;
            Cliente cliente = new Cliente
            {
                Clienteid = Id,
                Nome = "Spider",
                Cpf = "1234"
            };

            _clienteRepository.Salvar(cliente);

            Cliente objPesquisa = _clienteRepository.Pesquisar(Id);
            Console.WriteLine($"Id: {objPesquisa.Clienteid}, Nome: {objPesquisa.Nome}");
        }

        private void ValidarAtualizaçãoCliente()
        {
            int Id = 99;
            Cliente cliente = _clienteRepository.Pesquisar(Id);
            cliente.Nome = "Batman";
            _clienteRepository.Atualizar(cliente);

            Cliente objPesquisa = _clienteRepository.Pesquisar(Id);
            Console.WriteLine($"Id: {objPesquisa.Clienteid}, Nome: {objPesquisa.Nome}");
        }

        private void ValidarExclusaoCliente()
        {
            int Id = 1;
            _clienteRepository.Excluir(Id);
            Cliente objPesquisa = _clienteRepository.Pesquisar(Id);
        }
    }
}
