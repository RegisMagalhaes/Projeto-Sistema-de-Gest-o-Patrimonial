using senai_sistemadegestao_webapi.Contexts;
using senai_sistemadegestao_webapi.Domains;
using senai_sistemadegestao_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_sistemadegestao_webapi.Repositories
{
    public class SalaRepository : ISalaRepository
    {
        PatrimonioContext ctx = new PatrimonioContext();

        /// <summary>
        /// Faz a atualização da sala
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="salaAtualizada">Nomenclatura de atualização</param>
        public void Atualizar(int id, Sala salaAtualizada)
        {
            Sala salaBuscada = ctx.Salas.Find(id);

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
            return ctx.Salas.FirstOrDefault(s => s.IdSala == id);
        }

        /// <summary>
        /// Faz o cadastro de uma nova sala
        /// </summary>
        /// <param name="novaSala">Nomenclatura de cadastro</param>
        public void Cadastrar(Sala novaSala)
        {
            ctx.Salas.Add(novaSala);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a exclusão de uma sala
        /// </summary>
        /// <param name="id">Identifcador</param>
        public void Deletar(int id)
        {
            ctx.Salas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a listagem das salas
        /// </summary>
        /// <returns>O retorno de uma lista com as salas</returns>
        public List<Sala> ListarTodos()
        {
            return ctx.Salas.ToList();
        }
    }
}
