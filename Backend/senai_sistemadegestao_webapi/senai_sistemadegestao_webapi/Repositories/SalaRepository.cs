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
    public class SalaRepository : ISalaRepository
    {
        //Gera o context para uso nos métodos
        PatrimonioContext ctx = new PatrimonioContext();

        /// <summary>
        /// Faz a atualização da sala
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="salaAtualizada">Nomenclatura de atualização</param>
        public void Atualizar(int id, Sala salaAtualizada)
        {
            Sala salaBuscada = ctx.Salas.Find(id);

            //Sistema de atualização das entidades
            if (salaAtualizada.Metragem != null)
            {
                salaBuscada.Metragem = salaAtualizada.Metragem;
            }

            if (salaAtualizada.Nome != null)
            {
                salaBuscada.Nome = salaAtualizada.Nome;
            }

            if (salaAtualizada.Andar != null)
            {
                salaBuscada.Andar = salaAtualizada.Andar;
            }
        }

        /// <summary>
        /// Faz a busca pelo identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Sala buscada com suas informações</returns>
        public Sala BuscarPorId(int id)
        {
            //Faz a busca pelo identificador
            return ctx.Salas.FirstOrDefault(s => s.IdSala == id);
        }

        /// <summary>
        /// Faz o cadastro de uma nova sala
        /// </summary>
        /// <param name="novaSala">Nomenclatura de cadastro</param>
        public void Cadastrar(Sala novaSala)
        {
            //Faz a inserção de dados, adiciona
            ctx.Salas.Add(novaSala);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a exclusão de uma sala
        /// </summary>
        /// <param name="id">Identifcador</param>
        public void Deletar(int id)
        {
            //Faz a exclusão do objeto
            ctx.Salas.Remove(BuscarPorId(id));

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a listagem das salas
        /// </summary>
        /// <returns>O retorno de uma lista com as salas</returns>
        public List<Sala> ListarTodos()
        {
            //Faz a listagem 
            return ctx.Salas.ToList();
        }
    }
}
