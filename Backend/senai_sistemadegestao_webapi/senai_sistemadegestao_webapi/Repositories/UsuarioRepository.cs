using senai_sistemadegestao_webapi.Contexts;
using senai_sistemadegestao_webapi.Domains;
using senai_sistemadegestao_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_sistemadegestao_webapi.Repositories
{
    //Instância da interface para ter referência aos métodos
    public class UsuarioRepository : IUsuarioRepository
    {
        //Gera o context para uso nos métodos
        PatrimonioContext ctx = new PatrimonioContext();

        /// <summary>
        /// Faz a atualização de email
        /// </summary>
        /// <param name="email">Passe de entrada</param>
        /// <param name="usuarioAtualizado">Nomenclatura de atualização</param>
        public void AtualizarEmail(string email, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(email);

            //Faz a alteração do email
            if (usuarioAtualizado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            //Faz a atualização
            ctx.Usuarios.Update(usuarioBuscado);

            //Salva as alterações
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

            //Faz a alteração da senha
            if (usuarioAtualizado.Senha != null)
            {
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            //Faz a atualização
            ctx.Usuarios.Update(usuarioBuscado);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a busca do usuário pelo identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O usuário procurado com suas informações</returns>
        public Usuario BuscarPorId(int id)
        {
            //Faz a busca pelo identificador
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id); // havia dado erro aqui em IdUsuario
        }

        /// <summary>
        /// Faz o cadastro de um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Nomenclatura de cadastro</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            //Faz a inserção e adiciona
            ctx.Usuarios.Add(novoUsuario);

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a exclusão do usuário
        /// </summary>
        /// <param name="id">Idenificador do usuário procurado</param>
        public void Delete(int id)
        {
            //Faz a exclusão de informações
            ctx.Usuarios.Remove(BuscarPorId(id));

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz o login do usuário
        /// </summary>
        /// <param name="email">Passe de entrada</param>
        /// <param name="senha">Confirmação de entrada</param>
        /// <returns>O usuário logado</returns>
        public Usuario Login(string email, string senha)
        {
            //Faz o login 
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
