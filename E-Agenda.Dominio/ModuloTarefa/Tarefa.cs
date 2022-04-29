﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp1.ModuloItem;

using E_Agenda.ConsoleApp1.Compartilhado;

namespace E_Agenda.ConsoleApp1.ModuloTarefa
{
    public class Tarefa : EntidadeBase, IComparable<Tarefa>
    {
       public Prioridade prioridade;
        string titulo;
        DateTime dataCriacao;
        DateTime dataConclusao;
        double percentualConclusao;
        List<Item> items;

        public Tarefa(Prioridade prioridade, string titulo, DateTime dataCriacao, DateTime dataConclusao)
        {
            this.prioridade = prioridade;
            this.titulo = titulo;
            this.dataCriacao = dataCriacao;
            this.dataConclusao = dataConclusao;
            items = new();
        }
        public DateTime DataConclusao { get => dataConclusao; set => dataConclusao = value; }
        public List<Item> Items { get => items; set => items = value; }
        public double PercentualConclusao { get => percentualConclusao;}
        public string Titulo { get => titulo;}
        public DateTime DataCriacao { get => dataCriacao; }

        public override string ToString()
        {
            return $"{id}  -" +
                $"{prioridade}  -" +
                $"{Titulo}  -" +
                $"{dataCriacao}  -" +
                $"{DataConclusao}  -" +
                $"{percentualConclusao}% ";
        }

        public void CalculaPercentualConclusao()
        {
            if (items.Count == 0)
            {
                percentualConclusao = 0;
                return;
            }
            int c = 0;
            foreach (Item item in items)
            {
                if (item.concluido)
                    c++;
            }
            percentualConclusao = (double)c/(double)items.Count *100;
        }

        public int CompareTo(Tarefa other)
        {
         return other.prioridade.CompareTo(prioridade);
        }
    }
}
