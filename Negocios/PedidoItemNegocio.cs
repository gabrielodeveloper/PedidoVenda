using AcessoBancoDados;
using ObjetoTransferencia;
using System.Data;

namespace Negocios
{
    public class PedidoItemNegocio
    {
        public string InserirPedidoItem(PedidoItem pedidoItem)
        {
            AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
            acessoDadosSqlServer.LimparParametros();
            acessoDadosSqlServer.AdicionarParametros("@IDPedido", pedidoItem.IDPedido);
            acessoDadosSqlServer.AdicionarParametros("@IDProduto", pedidoItem.Produto.IDProduto);
            acessoDadosSqlServer.AdicionarParametros("@Quantidade", pedidoItem.Quantidade);
            acessoDadosSqlServer.AdicionarParametros("@PrecoUnitario", pedidoItem.PrecoUnitario);
            string IDPedido = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspCadastrarPedidoItem").ToString();

            return IDPedido;
        }
    }
}
