using System;

namespace ObjetoTransferencia
{
    public class Produto
    {
        public int IDProduto { get; set; }
        public string Descricao { get; set; }
        public Decimal Preco { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; }
    }
}
