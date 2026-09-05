using System;

namespace ObjetoTransferencia
{
    public class PedidoItem
    {
        public int IDPedidoItem { get; set; }
        public int IDPedido { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public Decimal PrecoUnitario { get; set; }
    }
}
