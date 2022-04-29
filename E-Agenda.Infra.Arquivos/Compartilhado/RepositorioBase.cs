using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.ConsoleApp1.Compartilhado
{
   public abstract class RepositorioBase<T> where T : EntidadeBase
    {
        private readonly List<T> registros;
        int contador = 0;

        protected List<T> Registros => registros;

        public RepositorioBase()
        {
            registros = new List<T>();
        }
        public virtual void Excluir(int numeroId)
        {
            registros.Remove(registros.Find(x => x.id == numeroId));
            
        }
        public virtual void Editar(int numeroId,T entidadeNova)
        {
          
          int index =  registros.FindIndex(x => x.id == numeroId);
            entidadeNova.id = registros[index].id;
            registros[index] = entidadeNova;
        }
        public virtual void Inserir(T entidade)
        {
            entidade.id = ++contador;
            Registros.Add(entidade);
        }
        public virtual List<T> GetRegistros()
        {
            return Registros;
        }
        public virtual T GetRegistro(int id)
        {
            return Registros.Find(x => x.id == id);
        }

    }
}
