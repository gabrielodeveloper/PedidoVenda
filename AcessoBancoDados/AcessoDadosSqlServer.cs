using Microsoft.Data.SqlClient;
using System.Data;

namespace AcessoBancoDados
{
    public class AcessoDadosSqlServer
    {
        private readonly string stringConexao;

        public AcessoDadosSqlServer(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }
        //Cria a conexão com o banco de dados.
        private SqlConnection CriarConexao()
        {
            return new SqlConnection(stringConexao);
        }

        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        public object ExecutarManipulacao(CommandType commandType, string nomeStoredProcedureOuTextoSql)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;
                sqlCommand.CommandTimeout = 7200;

                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                return sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public DataTable ExecutarConsulta(CommandType commandType, string nomeStoredProcedureOuTextoSql)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;
                sqlCommand.CommandTimeout = 7200;

                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)

            {

                throw new Exception(ex.Message);
            }

        }
    }
}
