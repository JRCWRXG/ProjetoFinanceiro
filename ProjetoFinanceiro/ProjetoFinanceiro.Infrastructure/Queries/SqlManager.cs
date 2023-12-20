using ProjetoFinanceiro.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Infrastructure.Queries
{
    public class SqlManager
    {
        public static string GetSql(SqlQueryType sqlQueryType)
        {
            string StrSql = "";

            switch (sqlQueryType)
            {
                case SqlQueryType.Cadastrar_Cliente:
                    StrSql = "insert into tb_cliente(nome, cpf_cli) values(@nome, @cpf_cli)";
                    break;
                case SqlQueryType.Autualizar_Cliente:
                    StrSql = "update tb_cliente set nome = @nome, cpf_cli = @cpf_cli";
                    break;
                case SqlQueryType.Excluir_Cliente:
                    StrSql = "delete FROM tb_cliente where cod_cli = @cod_cli";
                    break;
                case SqlQueryType.Listar_Cliente:
                    StrSql = "SELECT  cod_cli ,nome, cpf_cli FROM tb_cliente";
                    break;
                case SqlQueryType.Pesquisar_Cliente:
                    StrSql = "SELECT  cod_cli ,nome, cpf_cli FROM tb_cliente where cod_cli = @cod_cli";
                    break;
                default:
                    break;
            }
            return StrSql;
        }
    }
}
