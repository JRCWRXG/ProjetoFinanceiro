using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Infrastructure.Repositories;
using ProjetoFinanceiro.Services.Service;
using ProjetoFinanceiro.Testes.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Testes.Services
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
            Console.WriteLine("\nTeste camada serviço: ValidarListagemClientes");

            List<Cliente> clientes = _clienteService.Listar();

            foreach (Cliente Cliente in clientes)
            {
                Console.WriteLine($"Id: {Cliente.Clienteid}, Nome: {Cliente.Nome}");
            }
        }

        private void ValidarPesquisaCliente()
        {
            Console.WriteLine("\nTeste camada serviço: ValidarPesquisaCliente");

            int id = 2;
            Cliente Cliente = _clienteService.Pesquisar(id);
            Console.WriteLine($"Id: {Cliente.Clienteid}, Nome: {Cliente.Nome}");
        }

        private void ValidarCadastroCliente()
        {
            Console.WriteLine("\nTeste camada serviço: ValidarCadastroCliente");

            Cliente cliente = ClienteFactory.GetNovoCliente();
            int Id = cliente.Clienteid;



            //int Id = 99;
            //Cliente cliente = new Cliente
            //{
            //    Clienteid = Id,
            //    Nome = "Spider",
            //    Cpf = "1234"
            //};

            _clienteService.Salvar(cliente);

            Cliente objPesquisa = _clienteService.Pesquisar(Id);
            Console.WriteLine($"Id: {objPesquisa.Clienteid}, Nome: {objPesquisa.Nome}");
        }

        private void ValidarAtualizaçãoCliente()
        {
            Console.WriteLine("\nTeste camada serviço: ValidarAtualizaçãoCliente");

            int Id = 5;
            Cliente cliente = _clienteService.Pesquisar(Id);
            cliente.Nome = "Batman";
            _clienteService.Atualizar(cliente);

            Cliente objPesquisa = _clienteService.Pesquisar(Id);
            Console.WriteLine($"Id: {objPesquisa.Clienteid}, Nome: {objPesquisa.Nome}");
        }

        private void ValidarExclusaoCliente()
        {
            Console.WriteLine("\nTeste camada serviço: ValidarExclusaoCliente");
            int Id = 1;
            _clienteService.Excluir(Id);
            Cliente objPesquisa = _clienteService.Pesquisar(Id);
        }
    }
}
