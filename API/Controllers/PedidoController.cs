using Microsoft.AspNetCore.Mvc;
using Negocios;
using ObjetoTransferencia;

namespace API.Controllers
{
    public class PedidoController : ControllerBase
    {
        private readonly PedidoNegocio pedidoNegocio;

        public PedidoController(PedidoNegocio pedidoNegocio)
        {
            this.pedidoNegocio = pedidoNegocio;
        }

        [HttpGet]
        public IActionResult Consultar(int idPedido)
        {
            var pedido = pedidoNegocio.ConsultarPedido(idPedido);

            return Ok(pedido);
        }

        [HttpPost]
        public IActionResult Iserir([FromBody] Pedido pedido)
        {
            var idPedido = pedidoNegocio.InserirPedido(pedido);

            return Ok(idPedido);
        }
    }
}
