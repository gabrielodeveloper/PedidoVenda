using AcessoBancoDados;
using ObjetoTransferencia;
using System.Data;

namespace Negocios
{
    public class ProdutoNegocio
    {
          public string InserirProduto(Produto produto)
        {
            AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();

            acessoDadosSqlServer.LimparParametros();
            acessoDadosSqlServer.AdicionarParametros("@Descricao", produto.Descricao);
            acessoDadosSqlServer.AdicionarParametros("@Preco", produto.Preco);
            acessoDadosSqlServer.AdicionarParametros("@Estoque", produto.Estoque);
            string IDProduto = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspCadastrarProduto").ToString();

            return IDProduto;
        }


    }
}
