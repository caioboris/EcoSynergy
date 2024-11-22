using FIAP.GlobalSolution.EcoSynergy.Application.Dtos;
using FIAP.GlobalSolution.EcoSynergy.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FIAP.GlobalSolution.EcoSynergy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducaoEnergiaController : ControllerBase
    {

        private readonly IProducaoEnergiaService _service;

        public ProducaoEnergiaController(IProducaoEnergiaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Metodo para obter os dados da producao de energia
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces<IEnumerable<ProducaoEnergiaDTO>>]
        public IActionResult Get()
        {
            var objModel = _service.ObterTodos();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados desejados");
        }

        /// <summary>
        /// Método para obter os dados de uma producao de energia específico por seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces<ProducaoEnergiaDTO>]
        public IActionResult GetPorId(int id)
        {
            var objModel = _service.ObterPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados desejados");
        }

        /// <summary>
        /// Método para adicionar novos dados de uma produção de energia 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces<ProducaoEnergiaDTO>]
        public IActionResult Post([FromBody] ProducaoEnergiaDTO entity)
        {
            try
            {
                var objModel = _service.Inserir(entity);

                if (objModel)
                    return Ok(objModel);

                return BadRequest("Não foi possivel salvar os dados desejados");
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
        /// Método para alterar os dados de uma producao de energia existente.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces<ProducaoEnergiaDTO>]
        public IActionResult Put(int id, [FromBody] ProducaoEnergiaDTO entity)
        {
            try
            {
                var objModel = _service.Atualizar(id, entity);

                if (objModel)
                    return Ok(objModel);

                return BadRequest("Não foi possivel salvar os dados desejados");
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

        // Método para excluir uma producao de energia
        [HttpDelete("{id}")]
        [Produces<ProducaoEnergiaDTO>]
        public IActionResult Delete(int id)
        {
            var objModel = _service.Deletar(id);

            if (objModel)
                return Ok(objModel);

            return BadRequest("Não foi possivel deletar os dados desejados");
        }
    }
}

