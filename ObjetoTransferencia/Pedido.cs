using System;

namespace ObjetoTransferencia
{
    public class Pedido
    {
        public int IDPedido { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataHora { get; set; }

    }
}
