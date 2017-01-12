using Infraestrutura.Repositorios.Comum.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestrutura.Repositorios.Comum.Filtro;

namespace Infraestrutura.Repositorios.Implementacao.Orms.Nhibernate
{
    public class Repositorio<T> : IBase<T>, IDisposable
        where T: class
    {
        public void Salvar(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Alterar(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(T entidade)
        {
            throw new NotImplementedException();
        }

        private T BuscarPorId(FiltroDeBusca filtro)
        {
            throw new NotImplementedException();
        }

        private ICollection<T> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        private ICollection<T> BuscarTodos(FiltroDeBusca filtro)
        {
            throw new NotImplementedException();
        }                

        private T FiltrarUmPor(Func<T, bool> predicado)
        {
            throw new NotImplementedException();
        }

        private ICollection<T> FiltrarVariosPor(Func<T, bool> predicado)
        {
            throw new NotImplementedException();
        }

        private ICollection<T> FiltrarVariosPor(Func<T, bool> predicado, int pageIndex, int pageCount)
        {
            throw new NotImplementedException();
        }        

        public T BuscarUnico(FiltroDeBusca filtro)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> BuscarVarios(FiltroDeBusca filtro)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
