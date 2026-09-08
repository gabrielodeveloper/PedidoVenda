using System;
using Negocios;
using ObjetoTransferencia;

namespace TesteNegocios
{
    public class Program
    {
        static void Main(string[] args)
        {
            // =========================
            // TESTE CLIENTE
            // =========================

            Cliente cliente = new Cliente();

            cliente.Nome = "Cliente Teste";
            cliente.CPF = "11111111111";

            ClienteNegocio clienteNegocio = new ClienteNegocio();

            string idCliente = clienteNegocio.InserirCliente(cliente);

            cliente.IDCliente = Convert.ToInt32(idCliente);

            Console.WriteLine($"Cliente cadastrado. ID: {cliente.IDCliente}");


            // =========================
            // TESTE PRODUTO
            // =========================

            Produto produto = new Produto();

            produto.Descricao = "Produto Teste";
            produto.Preco = 25.50m;
            produto.Estoque = 100;

            ProdutoNegocio produtoNegocio = new ProdutoNegocio();

            string idProduto = produtoNegocio.InserirProduto(produto);

            produto.IDProduto = Convert.ToInt32(idProduto);

            Console.WriteLine($"Produto cadastrado. ID: {produto.IDProduto}");


            // =========================
            // TESTE PEDIDO
            // =========================

            Pedido pedido = new Pedido();

            pedido.Cliente = cliente;
            pedido.DataHora = DateTime.Now;

            PedidoNegocio pedidoNegocio = new PedidoNegocio();

            string idPedido = pedidoNegocio.InserirPedido(pedido);

            pedido.IDPedido = Convert.ToInt32(idPedido);

            Console.WriteLine($"Pedido cadastrado. ID: {pedido.IDPedido}");


            // =========================
            // TESTE PEDIDO ITEM
            // =========================

            PedidoItem pedidoItem = new PedidoItem();

            pedidoItem.IDPedido = pedido.IDPedido;
            pedidoItem.Produto = produto;
            pedidoItem.Quantidade = 2;
            pedidoItem.PrecoUnitario = produto.Preco;

            PedidoItemNegocio pedidoItemNegocio = new PedidoItemNegocio();

            string idPedidoItem = pedidoItemNegocio.InserirPedidoItem(pedidoItem);

            pedidoItem.IDPedidoItem = Convert.ToInt32(idPedidoItem);

            Console.WriteLine($"Item do pedido cadastrado. ID: {pedidoItem.IDPedidoItem}");


            Console.WriteLine();
            Console.WriteLine("Todos os testes foram executados.");
            Console.ReadKey();
        }
    }
}