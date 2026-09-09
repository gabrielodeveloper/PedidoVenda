using AcessoBancoDados;
using ObjetoTransferencia;
using System.Data;
using System;

namespace Negocios
{
    public class PedidoItemNegocio
    {
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
        public string InserirPedidoItem(PedidoItem pedidoItem)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IDPedido", pedidoItem.IDPedido);
                acessoDadosSqlServer.AdicionarParametros("@IDProduto", pedidoItem.Produto.IDProduto);
                acessoDadosSqlServer.AdicionarParametros("@Quantidade", pedidoItem.Quantidade);
                acessoDadosSqlServer.AdicionarParametros("@PrecoUnitario", pedidoItem.PrecoUnitario);
                string IDPedidoItem = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspCadastrarPedidoItem").ToString();

                return IDPedidoItem;
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível inserir o item no pedido Detalhes: {ex.Message}");
            }
        }

        public PedidoItemColecao ConsultarPedidoItem(int idPedido)
        {
            try
            {
                PedidoItemColecao pedidoItems = new PedidoItemColecao();
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IDPedido", idPedido);
                DataTable dataTablePedidoItem = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspConsultarPedidoItem");

                foreach (DataRow row in dataTablePedidoItem.Rows)
                {
                    PedidoItem pedidoItem = new PedidoItem();

                    pedidoItem.IDPedidoItem = Convert.ToInt32(row["IDPedidoItem"]);
                    pedidoItem.Produto = new Produto();
                    pedidoItem.Produto.IDProduto = Convert.ToInt32(row["IDProduto"]);
                    pedidoItem.Produto.Descricao = Convert.ToString(row["Descricao"]);
                    pedidoItem.Quantidade = Convert.ToInt32(row["Quantidade"]);
                    pedidoItem.PrecoUnitario = Convert.ToDecimal(row["PrecoUnitario"]);

                    pedidoItems.Add(pedidoItem);
                }

                return pedidoItems;
            }
            catch (Exception ex)
            {

                throw new Exception($"Não foi possível consultar o item do pedido, Detalhes: {ex.Message}");
            }
        }
    }
}
