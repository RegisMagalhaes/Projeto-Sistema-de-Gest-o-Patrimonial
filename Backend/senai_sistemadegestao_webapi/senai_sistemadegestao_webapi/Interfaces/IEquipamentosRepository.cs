using senai_sistemadegestao_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_sistemadegestao_webapi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório EquipamentosRepository
    /// </summary>
    interface IEquipamentosRepository
    {
        //Definição de método segue essa estrutura
        //Tipo de Retorno nomedoMetodo(tipoParametro nomeParametro)

        /// <summary>
        /// Lista todos os Equipamentos
        /// </summary>
        /// <returns>Devolve uma lista de Equipamentos</returns>
        List<Equipamento> ListarTodos();

        /// <summary>
        /// Busca um Equipamento através do seu Id
        /// </summary>
        /// <param name="id">Id do Equipamento que será buscado</param>
        /// <returns>Um Equipamento encontrado </returns>
        Equipamento BuscarPorId(int id);

        /// <summary>
        /// Cadastra um Equipamento
        /// </summary>
        /// <param name="novoEquipamento">Novo Equipamento a ser cadastrado</param>
        void Cadastrar(Equipamento novoEquipamento);

        /// <summary>
        /// Atualiza um equipamento existente
        /// </summary>
        /// <param name="id">Id do equipamento que será atualizado</param>
        /// <param name="equipamentoAtualizado">Objeto Equipamento com as novas informações </param>
        void Atualizar(int id, Equipamento equipamentoAtualizado);

        /// <summary>
        /// Deleta um equipamento existente
        /// </summary>
        /// <param name="id">id do equipamento que será deletado</param>
        void Deletar(int id);


    }
}
