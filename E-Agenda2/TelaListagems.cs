using E_Agenda.ConsoleApp1.Compartilhado;
using E_Agenda.ConsoleApp1.ModuloCompromisso;
using E_Agenda.ConsoleApp1.ModuloContato;
using E_Agenda.ConsoleApp1.ModuloItem;
using E_Agenda.ConsoleApp1.ModuloTarefa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Agenda2
{
    public partial class TelaListagems : Form
    {
        RepositorioCompromisso repositorioCompromisso = new();
        RepositorioContato repositorioContato = new();
        RepositorioTarefa repositorioTarefa = new();
        TelaCadastro telaCadastro;
        public TelaListagems()
        {
            InitializeComponent();
            buttonItem.Visible = false;
            AtualizarCabecalhoListbox(listBoxTarefasIncompletas);
            AtualizarCabecalhoListbox(listBoxContatos);
            AtualizarCabecalhoListbox(listBoxCompromissos);
            AtualizarCabecalhoListbox(listBoxTarefasCompletas);
            comboBoxInserirOpcoes.DataSource = Enum.GetNames(typeof(Classes));
            comboBoxInserirOpcoes.SelectedIndex = 0;
        }





        #region ListBox selected index changed
        private void listBoxTarefas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                if (listBoxTarefasIncompletas.SelectedIndex > -1)
            {
                listBoxCompromissos.SelectedIndex = -1;
                listBoxContatos.SelectedIndex = -1;
                listBoxTarefasCompletas.SelectedIndex = -1;
                buttonItem.Visible = true;
            }
            if (listBoxTarefasIncompletas.SelectedIndex == 0)
            {
                listBoxTarefasIncompletas.SelectedIndex = -1;
                buttonItem.Visible = false;
            }
        }

        private void listBoxCompromissos_SelectedIndexChanged(object sender, EventArgs e)
        {
          
                if (listBoxCompromissos.SelectedIndex > -1)
            {
                listBoxTarefasIncompletas.SelectedIndex = -1;
                listBoxContatos.SelectedIndex = -1;
                listBoxTarefasCompletas.SelectedIndex = -1;
                buttonItem.Visible = false;
            }
            if (listBoxCompromissos.SelectedIndex == 0)
                listBoxCompromissos.SelectedIndex = -1;
        }

        private void listBoxContatos_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                if (listBoxContatos.SelectedIndex > -1)
            {
                listBoxTarefasIncompletas.SelectedIndex = -1;
                listBoxTarefasCompletas.SelectedIndex = -1;
                listBoxCompromissos.SelectedIndex = -1;
                buttonItem.Visible = false;
            }
            if (listBoxContatos.SelectedIndex == 0)
                listBoxContatos.SelectedIndex = -1;
        }

  private void listBoxTarefasCompletas_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBoxTarefasCompletas.SelectedIndex > -1)
            {
                listBoxCompromissos.SelectedIndex = -1;
                listBoxContatos.SelectedIndex = -1;
                listBoxTarefasIncompletas.SelectedIndex = -1;
                buttonItem.Visible = true;
            }
            if (listBoxTarefasCompletas.SelectedIndex == 0)
            {
                listBoxTarefasCompletas.SelectedIndex = -1;
                buttonItem.Visible = false;
            }
        }

    

    #endregion

    private void buttonInserir_Click(object sender, EventArgs e)
        {

            switch ((Classes)Enum.Parse(typeof(Classes), comboBoxInserirOpcoes.Text))
            {
                case Classes.Item:
                    if (listBoxTarefasCompletas.SelectedIndex == -1 && listBoxTarefasIncompletas.SelectedIndex == -1)
                    {
                        MessageBox.Show("selecionar tarefa");
                        return;
                    }

                    InicializaTelaCadastroParaItem();
                    break;


                case Classes.Tarefa:
                    InicializaTelaCadastroParaTarefa(Classes.Tarefa);
                    break;
                case Classes.Compromisso:
                    if (repositorioContato.GetRegistros().Count == 0)
                    {
                        MessageBox.Show("não ha contatos");
                        return;
                    }
                    InicializaTelaCadastroParaCompromisso(repositorioContato.GetRegistros());
                    break;
                case Classes.Contato:
                    InicializaTelaCadastroParaContato(Classes.Contato);
                    break;

                default:
                    return;
            }
            var result = telaCadastro.ShowDialog();
            if (result == DialogResult.OK)
            {
                switch ((Classes)Enum.Parse(typeof(Classes), comboBoxInserirOpcoes.Text))
                {
                    case Classes.Tarefa:
                        InserirEAtualizar(repositorioTarefa, listBoxTarefasIncompletas,telaCadastro.Tarefa);
                        break;
                    case Classes.Contato:
                        InserirEAtualizar(repositorioContato,listBoxContatos,telaCadastro.Contato);
                        break;
                    case Classes.Compromisso:
                        InserirEAtualizar(repositorioCompromisso, listBoxCompromissos,telaCadastro.Compromisso);
                        break;
                    case Classes.Item:
                        repositorioTarefa.AdicionarItems(telaCadastro.Tarefa, telaCadastro.Items);
                        AtualizarTarefasCompletasEIncompletas(repositorioTarefa, listBoxTarefasIncompletas,listBoxTarefasCompletas);
                        break;
                }

            }
        }

        private void InicializaTelaCadastroParaItem()
        {
            if (listBoxTarefasIncompletas.SelectedIndex > -1)
                telaCadastro = new((Tarefa)listBoxTarefasIncompletas.SelectedItem);
            else
                telaCadastro = new((Tarefa)listBoxTarefasCompletas.SelectedItem);
            telaCadastro.TarefaVisibilidade(false);
            telaCadastro.CompromissoVisibilidade(false);
            telaCadastro.ContatosVisibilidade(false);
            telaCadastro.ItemsVisibilidade(true);
            telaCadastro.PegarRepositorio(repositorioTarefa);
        }

        private void InicializaTelaCadastroParaTarefa(dynamic tarefa)
        {
            telaCadastro = new(tarefa);
            telaCadastro.ContatosVisibilidade(false);
            telaCadastro.CompromissoVisibilidade(false);
            telaCadastro.TarefaVisibilidade(true);
            telaCadastro.ItemsVisibilidade(false);
        }

        private void InicializaTelaCadastroParaCompromisso(dynamic compromisso)
        {
            telaCadastro = new(compromisso);
            telaCadastro.TarefaVisibilidade(false);
            telaCadastro.ContatosVisibilidade(false);
            telaCadastro.CompromissoVisibilidade(true);
            telaCadastro.ItemsVisibilidade(false);
            telaCadastro.PegarRepositorio(repositorioCompromisso);
        }

        private void InserirEAtualizar<T>(RepositorioBase<T> repositorio, ListBox listBox,T entidade) where T : EntidadeBase
        {
            repositorio.Inserir(entidade);
            AtualizaListagem(repositorio, listBox);
        }

        private void InicializaTelaCadastroParaContato(dynamic contato)
        {
            telaCadastro = new(contato);
            telaCadastro.TarefaVisibilidade(false);
            telaCadastro.CompromissoVisibilidade(false);
            telaCadastro.ContatosVisibilidade(true);
            telaCadastro.ItemsVisibilidade(false);
            telaCadastro.PegarRepositorio(repositorioContato);
        }

        private void AtualizarTarefasCompletasEIncompletas(RepositorioTarefa repositorio,ListBox listBoxTarefasIncompletas, ListBox listBoxTarefasCompletas)
        {

            repositorioTarefa.Ordenar();
            listBoxTarefasIncompletas.Items.Clear();
            listBoxTarefasCompletas.Items.Clear();
            AtualizarCabecalhoListbox(listBoxTarefasIncompletas);
            AtualizarCabecalhoListbox(listBoxTarefasCompletas);

            foreach (var tarefa in repositorio.GetRegistros())
            {
               
                    if (tarefa.PercentualConclusao == 100)
                        listBoxTarefasCompletas.Items.Add(tarefa);
                    else
                        listBoxTarefasIncompletas.Items.Add(tarefa);
                
            }
        }

        private void AtualizaListagem<T>(RepositorioBase<T> repositorio, ListBox listBox) where T : EntidadeBase
        {
            listBox.Items.Clear();
            AtualizarCabecalhoListbox(listBox);

            foreach (var item in repositorio.GetRegistros())
            {
                listBox.Items.Add(item);
            }
        }

        private void AtualizarCabecalhoListbox(ListBox listBox)
        {
            if (listBox == listBoxTarefasIncompletas || listBox == listBoxTarefasCompletas)
                listBox.Items.Insert(0, "id  prioridade  titulo  data  criação  data conclusao  %conclusão");

            else if (listBox == listBoxCompromissos)
                listBox.Items.Insert(0, "id  Local assunto  data e hora de inicio  data e hora de fim  nome do contato");

            else if (listBox == listBoxContatos)
                listBox.Items.Insert(0, "id  nome  email  telefone  empresa  cargo");
        }

        private void buttonItem_Click(object sender, EventArgs e)
        {
            comboBoxInserirOpcoes.SelectedIndex = 3;
            buttonInserir.PerformClick();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (listBoxContatos.SelectedIndex != -1)
            {
                InicializaTelaCadastroParaContato(listBoxContatos.SelectedItem);
                telaCadastro.ShowDialog();
                telaCadastro.PegarRepositorio(repositorioContato);
                AtualizaListagem(repositorioContato,listBoxContatos);
            }
        }
    }
}
