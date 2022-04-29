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
   

        public override void Excluir(int id)
        {
            int index = Registros.FindIndex(x => x.id == id);
            Registros.RemoveAt(index);
        }

        public override void Editar(int numeroId, Tarefa entidadeNova)
        {

            int index = Registros.FindIndex(x => x.id == numeroId);

            entidadeNova.id = Registros[index].id;
            entidadeNova.DataConclusao = Registros[index].DataConclusao;
            Registros[index] = entidadeNova;
        }

        public void Ordenar()
        {
            Registros.Sort();
        }

        public void AdicionarItems(Tarefa tarefa,List<Item> items)
        {
           tarefa.Items = items;
            tarefa.CalculaPercentualConclusao();
        }


    }
}
