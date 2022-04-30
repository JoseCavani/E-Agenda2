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
        public string arquivo;
        private readonly List<T> registros = new();
        int contador = 0;

        protected List<T> Registros => registros;

        public RepositorioBase()
        {
            this.arquivo = @"D:\visual studio files\junk\" + typeof(T).Name + ".json";
            registros = CarregarDoArquivo();
            if (registros.Count > 0)
                contador = registros.Max(x => x.id);
        }
        public virtual void Excluir(int numeroId)
        {
            registros.Remove(registros.Find(x => x.id == numeroId));
            GravarTarefasEmArquivo(Registros);
        }
        public virtual void Editar(int numeroId,T entidadeNova)
        {
          
          int index =  registros.FindIndex(x => x.id == numeroId);
            entidadeNova.id = registros[index].id;
            registros[index] = entidadeNova;
            GravarTarefasEmArquivo(Registros);
        }
        public virtual void Inserir(T entidade)
        {
            entidade.id = ++contador;
            Registros.Add(entidade);
            GravarTarefasEmArquivo(Registros);
        }


        public void Ordenar()
        {
            Registros.Sort();
        }

        public virtual List<T> GetRegistros()
        {
            return Registros;
        }
        public virtual T GetRegistro(int id)
        {
            return Registros.Find(x => x.id == id);
        }

        public List<T> CarregarDoArquivo()
        {
            if (File.Exists(arquivo) == false)
                return new List<T>();

            string registrosJson = File.ReadAllText(arquivo);

            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;

           return JsonConvert.DeserializeObject<List<T>>(registrosJson, settings);
           
        }

        public void GravarTarefasEmArquivo(List<T> registros)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;

            string tarefasJson = JsonConvert.SerializeObject(registros, settings);

            File.WriteAllText(arquivo, tarefasJson);
        }


    }
}
