using ProjetoFinanceiro.Domain.Configuration;
using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Domain.Enums;
using ProjetoFinanceiro.Infrastructure.Connection;
using ProjetoFinanceiro.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Infrastructure.Contexts
{
    public class SqlServerContext : IContext
    {
        private readonly IApiConfig _api_Config;
        private readonly ConnectionManager _connectionManager;

        private static string _connectionString = "";

        public SqlServerContext(IApiConfig config)
        {
            _api_Config = config;
            _connectionString = _api_Config.ConnectionString.db_financeiro;
            _connectionManager = new ConnectionManager(_connectionString);
        }

        public void CreateCliente(Cliente cliente)
        {
            SqlConnection cn = null;

            try
            {
                string strSql = SqlManager.GetSql(SqlQueryType.Cadastrar_Cliente);
                cn = _connectionManager.GetConnection();
                SqlCommand cmd = new SqlCommand(strSql, cn);
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.Add("@cpf_cli", SqlDbType.VarChar).Value = cliente.Cpf;

                cn.Open();
                cmd.ExecuteNonQuery();

                cmd = null;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteCliente(int id)
        {
            SqlConnection cn = null;

            try
            {
                string strSql = SqlManager.GetSql(SqlQueryType.Excluir_Cliente);
                cn = _connectionManager.GetConnection();
                SqlCommand cmd = new SqlCommand(strSql, cn);
                cmd.Parameters.Add("@cod_cli", SqlDbType.Int).Value = id;

                cn.Open();
                cmd.ExecuteNonQuery();

                cmd = null;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                    cn.Close();
                cn = null;
            }
        }

        public int NextId()
        {
            return 0;
        }

        public Cliente ReadCliente(int id)
        {
            SqlConnection cn = null;

            Cliente result = null;

            try
            {

                cn = _connectionManager.GetConnection();
                string strSql = SqlManager.GetSql(SqlQueryType.Pesquisar_Cliente);

                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand(strSql, cn);

                cmd.Parameters.Add("@cod_cli", SqlDbType.Int).Value = id;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "PesquisaCliente");

                DataRowCollection registros = ds.Tables["PesquisaCliente"].Rows;


                foreach (DataRow item in registros)
                {
                    result = new Cliente
                    {
                        Clienteid = Int32.Parse(item["cod_cli"].ToString()),
                        Nome = item["nome"].ToString(),
                        Cpf = item["cpf_cli"].ToString()
                    };

                    return result;
                }

                ds.Clear();
                ds = null;
                cmd = null;

                return null;



            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                cn = null;
            }
        }

        public List<Cliente> ReadClientes()
        {
            List<Cliente> result = new List<Cliente>();

            SqlConnection cn = null;
            try
            {

                cn = _connectionManager.GetConnection();
                string strSql = SqlManager.GetSql(SqlQueryType.Listar_Cliente);

                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(strSql, cn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "consultaCliente");



                foreach (DataRow registro in ds.Tables["consultaCliente"].Rows)
                {
                    Cliente cliente = new Cliente
                    {
                        Clienteid = Int32.Parse(registro["cod_cli"].ToString()),
                        Nome = registro["nome"].ToString(),
                        Cpf = registro["cpf_cli"].ToString()
                    };

                    result.Add(cliente);
                }

                ds.Clear();
                ds = null;
                cmd = null;

                return result;

                //using (SqlConnection cn1 = _connectionManager.GetConnection())
                //{

                //    //outra forma de usar porem esta destroe apos o uso
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                    cn.Close();
                cn = null;
            }


        }

        public void UpdateCliente(Cliente cliente)
        {
            SqlConnection cn = null;

            try
            {
                string strSql = SqlManager.GetSql(SqlQueryType.Autualizar_Cliente);
                cn = _connectionManager.GetConnection();
                SqlCommand cmd = new SqlCommand(strSql, cn);
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.Add("@cpf_cli", SqlDbType.VarChar).Value = cliente.Cpf;
                cmd.Parameters.Add("@cod_cli", SqlDbType.Int).Value = cliente.Clienteid;

                cn.Open();
                cmd.ExecuteNonQuery();

                cmd = null;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                    cn.Close();
                cn = null;
            }
        }
    }
}
