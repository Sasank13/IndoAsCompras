using Infraestrutura.Repositorios.Comum.Filtro;
using System;
using System.Collections.Generic;

namespace Infraestrutura.Repositorios.Comum.Interfaces
{
    /// <summary>
    /// Repositório Base da Camada Infraestrutura
    /// Esse é um contrato padrão e que à partir daqui
    /// devemos estender para outros contratos se necessário
    /// Essa interface, como a camada de Repositório deve ser
    /// desenvolvida sem a necessidade de acoplamento de Frameworks
    /// Essa interface deve ser utilizada sem a necessidade de alterar seus parâmetros
    /// </summary>
    /// <typeparam name="T">Entidade</typeparam>
    public interface IBase<T>
        where T: class
    {
        /// <summary>
        /// Grava uma Entidade no Banco
        /// </summary>
        /// <param name="entidade">Entidade a ser persistida</param>
        void Salvar(T entidade);

        /// <summary>
        /// Altera valores de uma entidade
        /// </summary>
        /// <param name="entidade">Entidade a ser persistida</param>
        void Alterar(T entidade);

        /// <summary>
        /// Exclui uma entidade do Banco
        /// </summary>
        /// <param name="entidade">Entidade a ser persistida</param>
        void Excluir(T entidade);

        /// <summary>
        /// Efetua um filtro que só retorna um Objeto
        /// </summary>
        /// <returns>Entidade a ser persistida</returns>
        T BuscarUnico(FiltroDeBusca filtro);

        /// <summary>
        /// Efetua uma busca que retorna uma lista de objetos
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        ICollection<T> BuscarVarios(FiltroDeBusca filtro);                
        void Dispose();
    }
}
