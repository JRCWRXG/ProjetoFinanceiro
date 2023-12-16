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

        public AppTestePrincipal(RepositorioTeste repositorioTeste, ServicoTeste servicoTeste)
        {
            _repositorioTeste = repositorioTeste;
            _servicoTeste = servicoTeste;
        }

        public void Execute()
        {
            ValidarCamadaDominio();
            ValidarCamadaEstrutura_Context();
            ValidarCamadaRepositorio();
            ValidarCamadaSevico();

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
    }
}
