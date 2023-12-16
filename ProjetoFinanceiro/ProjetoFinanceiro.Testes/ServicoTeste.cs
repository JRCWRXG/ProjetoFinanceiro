using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Infrastructure.Repositories;
using ProjetoFinanceiro.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Testes
{
    public class ServicoTeste
    {
        private readonly ClienteService _clienteService;
        public ServicoTeste(ClienteService clienteService)
        {
            _clienteService = clienteService;
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
            List<Cliente> clientes = _clienteService.Listar();

            foreach (Cliente Cliente in clientes)
            {
                Console.WriteLine($"Id: {Cliente.Clienteid}, Nome: {Cliente.Nome}");
            }
        }

        private void ValidarPesquisaCliente()
        {
            int id = 1;
            Cliente Cliente = _clienteService.Pesquisar(id);
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

            _clienteService.Salvar(cliente);

            Cliente objPesquisa = _clienteService.Pesquisar(Id);
            Console.WriteLine($"Id: {objPesquisa.Clienteid}, Nome: {objPesquisa.Nome}");
        }

        private void ValidarAtualizaçãoCliente()
        {
            int Id = 99;
            Cliente cliente = _clienteService.Pesquisar(Id);
            cliente.Nome = "Batman";
            _clienteService.Atualizar(cliente);

            Cliente objPesquisa = _clienteService.Pesquisar(Id);
            Console.WriteLine($"Id: {objPesquisa.Clienteid}, Nome: {objPesquisa.Nome}");
        }

        private void ValidarExclusaoCliente()
        {
            int Id = 1;
            _clienteService.Excluir(Id);
            Cliente objPesquisa = _clienteService.Pesquisar(Id);
        }
    }
}
