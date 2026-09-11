using System;
using Negocios;
using ObjetoTransferencia;

namespace TesteNegocios
{
    public class Program
    {
        static void Main(string[] args)
        {
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            PedidoItemNegocio pedidoItemNegocio = new PedidoItemNegocio();


            // ====================================
            // CONSULTAR PEDIDO
            // ====================================

            Console.WriteLine("====================================");
            Console.WriteLine("       CONSULTA DE PEDIDO");
            Console.WriteLine("====================================");

            Console.Write("Digite o ID do pedido: ");
            int idPedido = Convert.ToInt32(Console.ReadLine());

            PedidoColacao pedidos = pedidoNegocio.ConsultarPedido(idPedido);

            if (pedidos.Count == 0)
            {
                Console.WriteLine("\nPedido não encontrado.");
            }
            else
            {
                foreach (Pedido pedido in pedidos)
                {
                    Console.WriteLine("\n--- DADOS DO PEDIDO ---");

                    Console.WriteLine($"ID Pedido: {pedido.IDPedido}");
                    Console.WriteLine($"Data: {pedido.DataHora}");
                    Console.WriteLine($"ID Cliente: {pedido.Cliente.IDCliente}");
                    Console.WriteLine($"Cliente: {pedido.Cliente.Nome}");
                    Console.WriteLine($"CPF: {pedido.Cliente.CPF}");

                    Console.WriteLine($"Quantidade Total: {pedido.QuantidadeTotal}");
                    Console.WriteLine($"Valor Total: {pedido.ValorTotal:C}");
                }
            }


            // ====================================
            // CONSULTAR ITENS DO PEDIDO
            // ====================================

            Console.WriteLine("\n--- ITENS DO PEDIDO ---");

            PedidoItemColecao itens =
                pedidoItemNegocio.ConsultarPedidoItem(idPedido);

            if (itens.Count == 0)
            {
                Console.WriteLine("Nenhum item encontrado.");
            }
            else
            {
                foreach (PedidoItem item in itens)
                {
                    Console.WriteLine("\n----------------------------");

                    Console.WriteLine($"ID Item: {item.IDPedidoItem}");
                    Console.WriteLine($"ID Produto: {item.Produto.IDProduto}");
                    Console.WriteLine($"Produto: {item.Produto.Descricao}");
                    Console.WriteLine($"Quantidade: {item.Quantidade}");
                    Console.WriteLine($"Preço Unitário: {item.PrecoUnitario:C}");
                    Console.WriteLine($"Valor Total: {item.ValorTotal:C}");
                }
            }


            Console.WriteLine("\n====================================");
            Console.WriteLine("          TESTE FINALIZADO");
            Console.WriteLine("====================================");

            Console.ReadKey();
        }
    }
}