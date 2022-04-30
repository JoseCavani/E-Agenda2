using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using E_Agenda.ConsoleApp1.Compartilhado;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp1.ModuloItem;

namespace E_Agenda.ConsoleApp1.ModuloTarefa
{
    public class RepositorioTarefa : RepositorioBase<Tarefa>
    {

        public void AdicionarItems(Tarefa tarefa,List<Item> items)
        {
           tarefa.Items = items;
            tarefa.CalculaPercentualConclusao();
            serializador.GravarTarefasEmArquivo(Registros);
        }

    
    }
}
