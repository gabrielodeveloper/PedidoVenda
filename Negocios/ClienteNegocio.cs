using AcessoBancoDados;
using ObjetoTransferencia;
using System.Data;

namespace Negocios
{
    public class ClienteNegocio
    {
        public string InserirCliente(Cliente cliente)
        {
            AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();

            acessoDadosSqlServer.LimparParametros();
            acessoDadosSqlServer.AdicionarParametros("@Nome", cliente.Nome);
            acessoDadosSqlServer.AdicionarParametros("@CPF", cliente.CFP);
            string IDCliente = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspCadastrarCliente").ToString();

            return IDCliente;
        }
    }
}
