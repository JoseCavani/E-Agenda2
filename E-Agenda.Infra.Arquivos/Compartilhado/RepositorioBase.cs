using E_Agenda.Infra.Arquivos.Compartilhado;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.ConsoleApp1.Compartilhado
{
   public abstract class RepositorioBase<T> where T : EntidadeBase
    {
        protected readonly SerializadorJason<T> serializador;
        private readonly List<T> registros = new();
        int contador = 0;

        protected List<T> Registros => registros;

        public RepositorioBase()
        {
            serializador = new();
            registros = serializador.CarregarDoArquivo();
            if (registros.Count > 0)
                contador = registros.Max(x => x.id);
        }
        public virtual void Excluir(int numeroId)
        {
            registros.Remove(registros.Find(x => x.id == numeroId));
            serializador.GravarTarefasEmArquivo(Registros);
        }
        public virtual void Editar(int numeroId,T entidadeNova)
        {
          
          int index =  registros.FindIndex(x => x.id == numeroId);
            entidadeNova.id = registros[index].id;
            registros[index] = entidadeNova;
            serializador.GravarTarefasEmArquivo(Registros);
        }
        public virtual void Inserir(T entidade)
        {
            entidade.id = ++contador;
            Registros.Add(entidade);
            serializador.GravarTarefasEmArquivo(Registros);
        }

        /// <summary>
        /// IMPLEMETAR IComparable NA CLASSE.CS PARA FUNCIONAR
        /// </summary>
        public void Ordenar()
        {
            Registros.Sort();
        }

        public virtual List<T> GetRegistros()
        {
            return Registros;
        }

    }
}
