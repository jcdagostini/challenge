using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Take.Challenge.Componentes.RepositoriosGit;

namespace Take.Challenge.WebApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepositoriosGitTakeController : ControllerBase
    {
        /// <summary>
        /// Busca os repositórios do GitHub da Take
        /// </summary>        
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> ListarRepositorios()
        {
            var retorno = await new RepositoriosGit().GetRepositoriosGitApi();
            if (retorno == null)
            {
                return NotFound();
            }
            return Ok(retorno);
        }   
    }
}
