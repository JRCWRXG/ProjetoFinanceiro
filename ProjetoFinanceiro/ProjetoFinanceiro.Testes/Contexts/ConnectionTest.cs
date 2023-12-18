using Microsoft.Extensions.Configuration;
using ProjetoFinanceiro.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Testes.Contexts
{
    public class ConnectionTest
    {
        private readonly ConnectionManager _connectionManager;
        private readonly IConfiguration _configuration;

        public ConnectionTest(IConfiguration configuration)
        {
            _configuration = configuration;
            string connStr = _configuration["ApiConfig:ConnectionString:db_financeiro"];
            _connectionManager = new ConnectionManager(connStr);
        }

        public void Execute()
        {
           // ValidarConectividadeBancoDados();
            ValidarConsultaSimples();
        }

        private void ValidarConectividadeBancoDados()
        {
            SqlConnection connection = null;
            try
            {
                connection = _connectionManager.GetConnection();
                connection.Open();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (connection.State.Equals(ConnectionState.Open))
                {
                    connection.Close();
                    connection = null;

                }
            }
        }

        private void ValidarConsultaSimples()
        {
            SqlConnection connection = null;
            try
            {
                connection = _connectionManager.GetConnection();
                connection.Open();

                string StrSql = "Select * from tb_cliente";
                SqlCommand sqlCommand= new SqlCommand(StrSql, connection);  
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Nome {reader.GetString(1)}");


                        //string Nome = (string)reader[0];
                        //string Telefone = (string)reader[1];
                        //Console.WriteLine();
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
           
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (connection.State.Equals(ConnectionState.Open))
                {
                    connection.Close();
                    connection = null;

                }
            }
        }
    }
}
