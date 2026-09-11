using Microsoft.AspNetCore.Mvc;
using Negocios;
using ObjetoTransferencia;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoNegocio produtoNegocio;

        public ProdutoController(ProdutoNegocio produtoNegocio)
        {
            this.produtoNegocio = produtoNegocio;
        }

        [HttpGet]
        public IActionResult Consultar(int? idProduto, string? descricao)
        {
            var produto = produtoNegocio.ConsultarProduto(idProduto, descricao);

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Iserir([FromBody] Produto produto)
        {
            string idProduto = produtoNegocio.InserirProduto(produto);

            return Ok(idProduto);
        }
    }
}
