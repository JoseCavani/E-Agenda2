using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp1.Compartilhado;
using E_Agenda.ConsoleApp1.ModuloContato;

namespace E_Agenda.ConsoleApp1.ModuloCompromisso
{
        public class Compromisso : EntidadeBase
        {
            string assunto;
            string local;
            DateTime dataInicio;
            DateTime dataFim;
            Contato contato;

        public Compromisso() { }

            public Compromisso(string assunto,
        string local,
        DateTime dataInicio,
        DateTime dataFim,
        Contato contato)
            {
             this.assunto = assunto;
            this.dataInicio = dataInicio;
            this.local = local;
            this.dataFim = dataFim;
            this.contato = contato;
            }

        public DateTime DataInicio { get => dataInicio; set => dataInicio = value; }
        public DateTime DataFim { get => dataFim; set => dataFim = value; }
        public string Assunto { get => assunto; set => assunto = value; }
        public string Local { get => local; set => local = value; }
        public Contato Contato { get => contato; set => contato = value; }

        public override string ToString()
            {
                return $"({id})   " +
                    $"({local})   " +
                    $"({assunto})   " +
                    $"({DataInicio})   " +
                    $"({DataFim})   " +
                    $"({contato.Nome})   ";
            }
        }
    }
