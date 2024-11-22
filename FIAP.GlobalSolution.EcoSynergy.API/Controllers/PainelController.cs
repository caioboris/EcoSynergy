using FIAP.GlobalSolution.EcoSynergy.Application.Dtos;
using FIAP.GlobalSolution.EcoSynergy.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FIAP.GlobalSolution.EcoSynergy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PainelController : ControllerBase
    {

        private readonly IPainelService _service;

        public PainelController(IPainelService service)
        {
            _service = service;
        }

        /// <summary>
        /// Metodo para obter os dados de todos os paineis
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces<IEnumerable<PainelDTO>>]
        public IActionResult Get()
        {
            var objModel = _service.ObterTodos();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados solicitados");
        }

        /// <summary>
        /// Método para obter os dados de um painel específico por seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces<PainelDTO>]
        public IActionResult GetPorId(int id)
        {
            var objModel = _service.ObterPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados solicitados");
        }

        /// <summary>
        /// Método para adicionar novo painel
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces<PainelDTO>]
        public IActionResult Post([FromBody] PainelDTO entity)
        {
            try
            {
                var objModel = _service.Inserir(entity);

                if (objModel)
                    return Ok(objModel);

                return BadRequest("Não foi possivel salvar os dados solicitados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Método para alterar os dados de um painel existente.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces<PainelDTO>]
        public IActionResult Put(int id, [FromBody] PainelDTO entity)
        {
            try
            {
                var objModel = _service.Atualizar(id, entity);

                if (objModel)
                    return Ok(objModel);

                return BadRequest("Não foi possivel salvar os dados solicitados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        // Método para excluir um painel
        [HttpDelete("{id}")]
        [Produces<PainelDTO>]
        public IActionResult Delete(int id)
        {
            var objModel = _service.Deletar(id);

            if (objModel)
                return Ok(objModel);

            return BadRequest("Não foi possivel deletar os dados solicitados");
        }
    }
}

