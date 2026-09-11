using Microsoft.AspNetCore.Mvc;
using Negocios;
using ObjetoTransferencia;

namespace API.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class PedidoItemController : ControllerBase
    {
        private readonly PedidoItemNegocio pedidoItemNegocio;
        public PedidoItemController(PedidoItemNegocio pedidoItemNegocio)
        {
            this.pedidoItemNegocio = pedidoItemNegocio;
        }

        [HttpGet]
        public IActionResult Consultar(int idPedido) 
        { 
            var itens = pedidoItemNegocio.ConsultarPedidoItem(idPedido);

            return Ok(itens);
        }
        [HttpPost]
        public IActionResult Iserir(PedidoItem pedidoItem)
        {
            var item = pedidoItemNegocio.InserirPedidoItem(pedidoItem);

            return Ok(item);
        }
    }
}
