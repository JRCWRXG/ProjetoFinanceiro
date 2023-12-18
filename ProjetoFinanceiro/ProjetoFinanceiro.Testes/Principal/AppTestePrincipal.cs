using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinanceiro.Testes.Contexts;
using ProjetoFinanceiro.Testes.Domain;
using ProjetoFinanceiro.Testes.Repositories;
using ProjetoFinanceiro.Testes.Services;

namespace ProjetoFinanceiro.Testes.Principal
{
    public class AppTestePrincipal
    {
        private readonly RepositorioTeste _repositorioTeste;
        private readonly ServicoTeste _servicoTeste;
        private readonly ConnectionTest _connectionTest;

        public AppTestePrincipal(RepositorioTeste repositorioTeste,
                                                    ServicoTeste servicoTeste, 
                                                    ConnectionTest connectionTest)
        {
            _repositorioTeste = repositorioTeste;
            _servicoTeste = servicoTeste;
            _connectionTest = connectionTest;
        }

        public void Execute()
        {
            //ValidarCamadaDominio();
            //ValidarCamadaEstrutura_Context();
            //ValidarCamadaRepositorio();
            //ValidarCamadaSevico();
            ValidarConectividade();

        }

        private void ValidarCamadaEstrutura_Context()
        {
            FakeContextTeste teste = new FakeContextTeste();
            teste.Execute();

            //teste.TestarListagem();
            //teste.TestarInclusao();
        }

        private void ValidarCamadaDominio()
        {
            DominioTeste teste = new DominioTeste();
            teste.Execute();

            //teste.TestarEntidade();
            //teste.TestarDto();

            //teste.TestarConversaoEntidadeParaDto();
            //teste.TestarConversaoDtoParaEntidade();
        }

        private void ValidarCamadaRepositorio()
        {
            _repositorioTeste.Execute();
        }

        private void ValidarCamadaSevico()
        {
            _servicoTeste.Execute();
        }

        private void ValidarConectividade()
        { 
        _connectionTest.Execute();
        }
    }
}
