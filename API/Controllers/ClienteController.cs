using Microsoft.AspNetCore.Mvc;
using Negocios;
using ObjetoTransferencia;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteNegocio clienteNegocio;
        public ClienteController(ClienteNegocio clienteNegocio)
        {
            this.clienteNegocio = clienteNegocio;
        }

        [HttpGet]
        public IActionResult Consultar(int? idCliente, string? nome)
        {
            var clientes = clienteNegocio.ConsultarClientePorCodigoOuNome(idCliente, nome);

            return Ok(clientes);    
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] Cliente cliente)
        {
            string idCliente = clienteNegocio.InserirCliente(cliente);

            return Ok(new
            {
                idCliente = idCliente
            });
        }
    }
}

