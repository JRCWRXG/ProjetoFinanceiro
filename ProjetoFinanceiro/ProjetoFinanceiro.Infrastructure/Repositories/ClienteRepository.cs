﻿using ProjetoFinanceiro.Domain.Configuration;
using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Domain.Enums;
using ProjetoFinanceiro.Domain.Setup;
using ProjetoFinanceiro.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly IContext _context;
        private readonly IApiConfig _apiConfig;
         

        public ClienteRepository(IApiConfig apiConfig)
        {
            _apiConfig = apiConfig;

            switch (ConfiguracoesApp.SELECTED_DATABASE)
            {
                case DataBaseTypes.Fake:
                    _context = new FakeContext();
                    break;

                case DataBaseTypes.SqlServer:
                    _context = new SqlServerContext(_apiConfig);
                    break;

            }



            //if (ConfiguracoesApp.SELECTED_DATABASE.Equals(DataBaseTypes.Fake))
            //{
            //    _context = new FakeContext();
            //}
        }

        public void Atualizar(Cliente cliente)
        {
            _context.UpdateCliente(cliente);
        }

        public void Excluir(int Id)
        {
            _context.DeleteCliente(Id);
        }

        public List<Cliente> Listar()
        {
            return _context.ReadClientes();
        }

        public Cliente Pesquisar(int Id)
        {
            return _context.ReadCliente(Id);
        }

        public void Salvar(Cliente cliente)
        {
            if (ConfiguracoesApp.SELECTED_DATABASE.Equals(DataBaseTypes.Fake))
            {
                cliente.Clienteid = _context.NextId();
            }
           
            _context.CreateCliente(cliente);
        }
    }
}
