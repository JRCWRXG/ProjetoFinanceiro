using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Testes
{
    public class AppTestePrincipal
    {
        private readonly RepositorioTeste _repositorioTeste;

        public AppTestePrincipal(RepositorioTeste repositorioTeste)
        {
            _repositorioTeste = repositorioTeste;
        }

        public void Execute()
        {
            ValidarCamadaDominio();
            ValidarCamadaEstrutura_Context();
            ValidarCamadaRepositorio();

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
    }
}
