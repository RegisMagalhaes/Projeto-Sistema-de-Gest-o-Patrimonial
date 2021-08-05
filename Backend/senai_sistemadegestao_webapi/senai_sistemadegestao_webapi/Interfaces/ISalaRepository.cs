using senai_sistemadegestao_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_sistemadegestao_webapi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo Repositório Sala Repository
    /// </summary>
    interface ISalaRepository
    {
        //Definição de método segue essa estrutura
        //Tipo de Retorno nomedoMetodo(tipoParametro nomeParametro)

        /// <summary>
        /// Lista todas as Salas
        /// </summary>
        /// <returns>Devolve uma lista de salas</returns>
        List<Sala> ListarTodos();

        /// <summary>
        /// Busca uma sala através do seu Id
        /// </summary>
        /// <param name="id">id da Sala que será buscada</param>
        /// <returns>retorna uma sala que foi buscada pelo id</returns>
        Sala BuscarPorId(int id);

       /// <summary>
       /// Cadastra uma nova sala
       /// </summary>
       /// <param name="novaSala">nova sala a ser cadastradda</param>
        void Cadastrar(Sala novaSala);

        /// <summary>
        /// Atualiza uma nova sala
        /// </summary>
        /// <param name="id">id da sala a ser atualizada</param>
        /// <param name="salaAtualizada">Objeto sala com as novas informações</param>
        void Atualizar(int id, Sala salaAtualizada);

        /// <summary>
        /// Deleta uma sala
        /// </summary>
        /// <param name="id">id da sala que será deletada</param>
        void Deletar(int id);
    }
}
