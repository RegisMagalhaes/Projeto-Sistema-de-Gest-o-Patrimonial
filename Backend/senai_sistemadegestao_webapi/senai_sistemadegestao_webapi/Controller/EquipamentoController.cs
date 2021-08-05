using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_sistemadegestao_webapi.Domains;
using senai_sistemadegestao_webapi.Interfaces;
using senai_sistemadegestao_webapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_sistemadegestao_webapi.Controller
{
    //Define que a resposta vai ser em json
    [Produces("application/json")]

    //passa a rota da api
    [Route("api/[controller]")]

    //Define que é um controlador
    [ApiController]
    public class EquipamentoController : ControllerBase
    {

        private IEquipamentosRepository _equipamentoRepository { get; set; }

        public EquipamentoController()
        {
            _equipamentoRepository = new EquipamentosRepository();
        }

        /// <summary>
        /// Faz a listagem dos equipamentos
        /// </summary>
        /// <returns>Uma lista com todos os equipamentos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_equipamentoRepository.ListarTodos());
        }

        /// <summary>
        /// Faz a busca pelo identificador
        /// </summary>
        /// <param name="id">Identificador do equipamento</param>
        /// <returns>O equipamento procurado com seu identificador</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_equipamentoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Faz o cadastro de um novo equipamento
        /// </summary>
        /// <param name="novoEquipamento">Nomenclatura de cadastro</param>
        /// <returns>Objeto cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Equipamento novoEquipamento)
        {
            _equipamentoRepository.Cadastrar(novoEquipamento);

            return StatusCode(201);
        }

        /// <summary>
        /// Faz a atualização dos equipamentos
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="equipamentoAtualizado">Nomenclatura de atualização</param>
        /// <returns>objeto atualizado com suas informações</returns>
        [HttpPut]
        public IActionResult Atualizar(int id, Equipamento equipamentoAtualizado)
        {
            _equipamentoRepository.Atualizar(id, equipamentoAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Faz a exclusão do objeto
        /// </summary>
        /// <param name="id">Identificador do objeto</param>
        /// <returns>O objeto excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _equipamentoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
