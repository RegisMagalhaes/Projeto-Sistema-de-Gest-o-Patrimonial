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

    //Define a rota da api
    [Route("api/[controller]")]

    //Define que é um controlador
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Busca através do id
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto procurado com suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Faz a atualização do email
        /// </summary>
        /// <param name="Email">Passe de acesso</param>
        /// <param name="usuarioAtualizado">Nomenclatura de atualização</param>
        /// <returns>O email do usuário atualizado</returns>
        [HttpPut("{email}")]
        public IActionResult AtualizarEmail(string Email, Usuario usuarioAtualizado)
        {
            _usuarioRepository.AtualizarEmail(Email, usuarioAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Faz a atualização da senha
        /// </summary>
        /// <param name="Senha">Confirmação de acesso</param>
        /// <param name="usuarioAtualizado">Nomenclatura de atualização</param>
        /// <returns>Objeto atualizado</returns>
        [HttpPut("{senha}")]
        public IActionResult AtualizarSenha(string Senha, Usuario usuarioAtualizado)
        {
            _usuarioRepository.AtualizarSenha(Senha, usuarioAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Faz o cadastro de um usuário
        /// </summary>
        /// <param name="novoUsuario">Nomenclatura de cadastro</param>
        /// <returns>Objeto cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Faz a exclusão do objeto
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioRepository.Delete(id);

                return StatusCode(204);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

      
    }
}
