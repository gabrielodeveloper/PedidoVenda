using AcessoBancoDados;
using ObjetoTransferencia;
using System.Data;

namespace Negocios
{
    public class PedidoNegocio
    {
        public string InserirPedido(Pedido pedido)
        {
            AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
            acessoDadosSqlServer.LimparParametros();
            acessoDadosSqlServer.AdicionarParametros("@IDCliente", pedido.Cliente.IDCliente);
            string IDPedido = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspCadastrarPedido").ToString();

            return IDPedido;
        }
    }
}
