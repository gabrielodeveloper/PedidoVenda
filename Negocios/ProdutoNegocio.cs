using AcessoBancoDados;
using ObjetoTransferencia;
using System;
using System.Data;

namespace Negocios
{
    public class ProdutoNegocio
    {
          AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();
          public string InserirProduto(Produto produto)
          {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Descricao", produto.Descricao);
                acessoDadosSqlServer.AdicionarParametros("@Preco", produto.Preco);
                acessoDadosSqlServer.AdicionarParametros("@Estoque", produto.Estoque);
                string IDProduto = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspCadastrarProduto").ToString();

                return IDProduto;
            }
            catch (Exception ex)
            {

                throw new Exception($"Não foi possível inserir produto, Detalhes: {ex.Message}"); ;
            }
          }

        public ProdutoColecao ConsultarProduto(int? idProduto, string descricao)
        {
            try
            {
                ProdutoColecao produtos = new ProdutoColecao();

                object codigo = idProduto ?? (object)DBNull.Value;
                object descricaoProduto = string.IsNullOrEmpty(descricao) ? (object)DBNull.Value : descricao;

                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("IDProduto", codigo);
                acessoDadosSqlServer.AdicionarParametros("Descricao", descricaoProduto);
                DataTable dataTableProduto = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspConsultarProdutoPorCodigoOuDescricao");

                foreach (DataRow row in dataTableProduto.Rows)
                {
                    Produto produto = new Produto();

                    produto.IDProduto = Convert.ToInt32(row["IDProduto"]);
                    produto.Descricao = Convert.ToString(row["Descricao"]);
                    produto.Preco = Convert.ToDecimal(row["Preco"]);
                    produto.Estoque = Convert.ToInt32(row["Estoque"]);
                    produto.Ativo = Convert.ToBoolean(row["Ativo"]);

                    produtos.Add(produto);
                }

                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível consultar produto, Detalhes: {ex.Message}"); ;
            }
        }
    }
}
