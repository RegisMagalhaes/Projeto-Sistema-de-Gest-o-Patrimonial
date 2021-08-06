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
    public class EquipamentosRepository : IEquipamentosRepository
    {
        //Gera o context para uso nos métodos
        PatrimonioContext ctx = new PatrimonioContext();

        /// <summary>
        /// Faz a atualização de um equipamento
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="equipamentoAtualizado">Nomenclatura de atualização</param>
        public void Atualizar(int id, Equipamento equipamentoAtualizado)
        {
            Equipamento equipamentoBuscado = ctx.Equipamentos.Find(id);

            //Sistema de atualização das entidades
            if (equipamentoAtualizado.Descricao != null)
            {
                equipamentoBuscado.Descricao = equipamentoAtualizado.Descricao;
            }

            if (equipamentoAtualizado.Marca != null )
            {
                equipamentoBuscado.Marca = equipamentoAtualizado.Marca;
            }

            if (equipamentoAtualizado.NumeroDeSerie != null)
            {
                equipamentoBuscado.NumeroDeSerie = equipamentoAtualizado.NumeroDeSerie;
            }

            if (equipamentoAtualizado.Tipo != null)
            {
                equipamentoBuscado.Tipo = equipamentoAtualizado.Tipo;
            }

            if (equipamentoAtualizado.Status != null)
            {
                equipamentoBuscado.Status = equipamentoAtualizado.Status;
            }

            if (equipamentoAtualizado.NumeroPatrimonio != null)
            {
                equipamentoBuscado.NumeroPatrimonio = equipamentoAtualizado.NumeroPatrimonio;
            }
        }

        /// <summary>
        /// Faz a busca pelo identificador
        /// </summary>
        /// <param name="id">Identificador do equipamento</param>
        /// <returns>O equipamento com suas informações</returns>
        public Equipamento BuscarPorId(int id)
        {
            //Método de busca
            return ctx.Equipamentos.FirstOrDefault(e => e.IdEquipamento == id);
        }

        /// <summary>
        /// Faz o cadastro de um equipamento
        /// </summary>
        /// <param name="novoEquipamento">Nomenclatura de cadastro</param>
        public void Cadastrar(Equipamento novoEquipamento)
        {
            //Faz o cadastro
            ctx.Equipamentos.Add(novoEquipamento);

            //Salva as inserções
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a exclusão de um equipamento
        /// </summary>
        /// <param name="id">Identificador</param>
        public void Deletar(int id)
        {
            //Apaga os dados
            ctx.Equipamentos.Remove(BuscarPorId(id));

            //Salva alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Faz a listagem dos equipamentos
        /// </summary>
        /// <returns>A lista com todos os equipamentos cadastrados</returns>
        public List<Equipamento> ListarTodos()
        {
            //Faz toda a listagem
            return ctx.Equipamentos.ToList();
        }
    }
}
