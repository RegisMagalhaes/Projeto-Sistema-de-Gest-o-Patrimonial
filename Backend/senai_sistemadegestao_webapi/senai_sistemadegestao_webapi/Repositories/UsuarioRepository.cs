using senai_sistemadegestao_webapi.Contexts;
using senai_sistemadegestao_webapi.Domains;
using senai_sistemadegestao_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_sistemadegestao_webapi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        PatrimonioContext ctx = new PatrimonioContext();

        /// <summary>
        /// Faz a atualização de email
        /// </summary>
        /// <param name="email">Passe de entrada</param>
        /// <param name="usuarioAtualizado">Nomenclatura de atualização</param>
        public void AtualizarEmail(string email, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(email);

            if (usuarioAtualizado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a atualização de senha
        /// </summary>
        /// <param name="senha">Confirmação de passe</param>
        /// <param name="usuarioAtualizado">Nomenclatura de atualização</param>
        public void AtualizarSenha(string senha, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(senha);

            if (usuarioAtualizado.Senha != null)
            {
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a busca do usuário pelo identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O usuário procurado com suas informações</returns>
        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        /// <summary>
        /// Fa zo cadastro de um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Nomenclatura de cadastro</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a exclusão do usuário
        /// </summary>
        /// <param name="id">Idenificador do usuário procurado</param>
        public void Delete(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz o login do usuário
        /// </summary>
        /// <param name="email">Passe de entrada</param>
        /// <param name="senha">Confirmação de entrada</param>
        /// <returns></returns>
        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
