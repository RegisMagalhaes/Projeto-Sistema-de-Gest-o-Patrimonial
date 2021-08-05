using senai_sistemadegestao_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_sistemadegestao_webapi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Faz a atualização do email do usuário
        /// </summary>
        /// <param name="email">Passe de acesso do usuário</param>
        /// <param name="usuarioAtualizado">Nomenclatura de atualização</param>
        public void AtualizarEmail(string email, Usuario usuarioAtualizado);

        /// <summary>
        /// Faz a atualização da senha do usuário
        /// </summary>
        /// <param name="senha">Confirmação de identidade</param>
        /// <param name="usuarioAtualizado">Nomenclatura de atualização</param>
        public void AtualizarSenha(string senha, Usuario usuarioAtualizado);

        /// <summary>
        /// Faz a exclusão do usuário
        /// </summary>
        /// <param name="id">identificador do usuário</param>
        void Delete(int id);

        /// <summary>
        /// Faz o cadastro do usuário
        /// </summary>
        /// <param name="novoUsuario">Nomenclatura do usuário cadastrado</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Faz a busca pelo identiifcador
        /// </summary>
        /// <param name="id">identificador</param>
        /// <returns>O usuário com o identifiador correspondente</returns>
        Usuario BuscarPorId(int id);

       /// <summary>
       /// Faz o login do usuário
       /// </summary>
       /// <param name="email">Passe de entrada</param>
       /// <param name="senha">Confirmação de autenticação</param>
       /// <returns></returns>
        Usuario Login(string email, string senha);
    }
}
