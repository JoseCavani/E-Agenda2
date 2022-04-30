using E_Agenda.ConsoleApp1.Compartilhado;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.Infra.Arquivos.Compartilhado
{
    public class SerializadorJason<T> where T : EntidadeBase
    {
        string arquivo = @"D:\visual studio files\junk\" + typeof(T).Name + ".json";

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
