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
        RepositorioCompromisso repositorioCompromisso;
        RepositorioContato repositorioContato;
        RepositorioTarefa repositorioTarefa;
        TelaCadastro telaCadastro;
        public TelaListagems()
        {
            InitializeComponent();
            repositorioCompromisso = new();
            repositorioContato = new();
            repositorioTarefa = new();
            buttonItem.Visible = false;
            AtualizarCabecalhoListbox(listBoxTarefasInCompletas);
            AtualizarCabecalhoListbox(listBoxContatos);
            AtualizarCabecalhoListbox(listBoxCompromissosPassados);
            AtualizarCabecalhoListbox(listBoxTarefasCompletas);
            AtualizarCabecalhoListbox(listBoxCompromissosFuturos);
            comboBoxInserirOpcoes.DataSource = Enum.GetNames(typeof(Classes));
            comboBoxInserirOpcoes.SelectedIndex = 0;
            labelA.Visible = false;
            dateTimePickerDataFim.Visible = false;
            dateTimePickerDataInicio.Visible = false;
            AtualizarCompromissosPassadosEFuturos(listBoxCompromissosPassados, listBoxCompromissosFuturos,(false,DateTime.MinValue,DateTime.MinValue));
            AtualizarTarefasCompletasEIncompletas(repositorioTarefa,listBoxTarefasInCompletas,listBoxTarefasCompletas);
            AtualizaListagem(repositorioContato,listBoxContatos);
        }





        #region ListBox selected index changed
        private void listBoxTarefas_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBoxTarefasInCompletas.SelectedIndex > -1)
            {
                labelA.Visible = false;
                dateTimePickerDataFim.Visible = false;
                dateTimePickerDataInicio.Visible = false;
                listBoxCompromissosPassados.SelectedIndex = -1;
                listBoxContatos.SelectedIndex = -1;
                listBoxTarefasCompletas.SelectedIndex = -1;
                buttonItem.Visible = true;
            }
            if (listBoxTarefasInCompletas.SelectedIndex == 0)
            {
                listBoxTarefasInCompletas.SelectedIndex = -1;
                buttonItem.Visible = false;
                labelA.Visible = false;
                dateTimePickerDataFim.Visible = false;
                dateTimePickerDataInicio.Visible = false;
            }
        }

        private void listBoxCompromissosPassados_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBoxCompromissosPassados.SelectedIndex > -1)
            {
                listBoxTarefasInCompletas.SelectedIndex = -1;
                listBoxContatos.SelectedIndex = -1;
                listBoxTarefasCompletas.SelectedIndex = -1;
                buttonItem.Visible = false;
                labelA.Visible = false;
                dateTimePickerDataFim.Visible = false;
                dateTimePickerDataInicio.Visible = false;
            }
            if (listBoxCompromissosPassados.SelectedIndex == 0)
                listBoxCompromissosPassados.SelectedIndex = -1;
        }

        private void listBoxContatos_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBoxContatos.SelectedIndex > -1)
            {
                listBoxTarefasInCompletas.SelectedIndex = -1;
                listBoxTarefasCompletas.SelectedIndex = -1;
                listBoxCompromissosPassados.SelectedIndex = -1;
                buttonItem.Visible = false;
                labelA.Visible = false;
                dateTimePickerDataFim.Visible = false;
                dateTimePickerDataInicio.Visible = false;
            }
            if (listBoxContatos.SelectedIndex == 0)
                listBoxContatos.SelectedIndex = -1;
        }

        private void listBoxTarefasCompletas_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBoxTarefasCompletas.SelectedIndex > -1)
            {
                listBoxCompromissosPassados.SelectedIndex = -1;
                listBoxContatos.SelectedIndex = -1;
                listBoxTarefasInCompletas.SelectedIndex = -1;
                buttonItem.Visible = true;
            }
            if (listBoxTarefasCompletas.SelectedIndex == 0)
            {
                listBoxTarefasCompletas.SelectedIndex = -1;
                buttonItem.Visible = false;
            }
        }

        private void listBoxCompromissosFuturos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCompromissosFuturos.SelectedIndex > -1)
            {
                listBoxTarefasInCompletas.SelectedIndex = -1;
                listBoxContatos.SelectedIndex = -1;
                listBoxTarefasCompletas.SelectedIndex = -1;
                buttonItem.Visible = false;
                labelA.Visible = true;
                dateTimePickerDataFim.Visible = true;
                dateTimePickerDataInicio.Visible = true;
            }
            if (listBoxCompromissosFuturos.SelectedIndex == 0)
                listBoxCompromissosFuturos.SelectedIndex = -1;
        

    }

    #endregion

    private void buttonInserir_Click(object sender, EventArgs e)
        {

            switch ((Classes)Enum.Parse(typeof(Classes), comboBoxInserirOpcoes.Text))
            {
                case Classes.Item:
                    if (listBoxTarefasCompletas.SelectedIndex == -1 && listBoxTarefasInCompletas.SelectedIndex == -1)
                    {
                        MessageBox.Show("selecionar tarefa");
                        return;
                    }

                    InicializaTelaCadastroParaItem();
                    break;


                case Classes.Tarefa:
                    InicializaTelaCadastroParaTarefa(new Tarefa());
                    break;
                case Classes.Compromisso:
                    if (repositorioContato.GetRegistros().Count == 0)
                    {
                        MessageBox.Show("não ha contatos");
                        return;
                    }
                    InicializaTelaCadastroParaCompromisso(new Compromisso());
                    break;
                case Classes.Contato:
                    InicializaTelaCadastroParaContato(new Contato());
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
                        InserirEAtualizar(repositorioTarefa, listBoxTarefasInCompletas, telaCadastro.Tarefa);
                        break;
                    case Classes.Contato:
                        InserirEAtualizar(repositorioContato, listBoxContatos, telaCadastro.Contato);
                        break;
                    case Classes.Compromisso:
                        repositorioCompromisso.Inserir(telaCadastro.Compromisso);
                        AtualizarCompromissosPassadosEFuturos(listBoxCompromissosPassados, listBoxCompromissosFuturos,(false,default,default));
                        break;
                    case Classes.Item:
                        repositorioTarefa.AdicionarItems(telaCadastro.Tarefa, telaCadastro.Items);
                        AtualizarTarefasCompletasEIncompletas(repositorioTarefa, listBoxTarefasInCompletas, listBoxTarefasCompletas);
                        break;
                }

            }
        }

        private void InicializaTelaCadastroParaItem()
        {
            if (listBoxTarefasInCompletas.SelectedIndex > -1)
                telaCadastro = new((Tarefa)listBoxTarefasInCompletas.SelectedItem, new Item());
            else
                telaCadastro = new((Tarefa)listBoxTarefasCompletas.SelectedItem, new Item());
            telaCadastro.TarefaVisibilidade(false);
            telaCadastro.CompromissoVisibilidade(false);
            telaCadastro.ContatosVisibilidade(false);
            telaCadastro.ItemsVisibilidade(true);
            telaCadastro.SetRepositorio(repositorioTarefa);
        }

        private void InicializaTelaCadastroParaTarefa(Tarefa tarefa)
        {
            telaCadastro = new(tarefa);
            telaCadastro.ContatosVisibilidade(false);
            telaCadastro.CompromissoVisibilidade(false);
            telaCadastro.TarefaVisibilidade(true);
            telaCadastro.ItemsVisibilidade(false);
            telaCadastro.SetRepositorio(repositorioTarefa);
        }

        private void InicializaTelaCadastroParaCompromisso(Compromisso compromisso)
        {
            telaCadastro = new(compromisso);
            telaCadastro.TarefaVisibilidade(false);
            telaCadastro.ContatosVisibilidade(false);
            telaCadastro.CompromissoVisibilidade(true);
            telaCadastro.ItemsVisibilidade(false);
            telaCadastro.SetRepositorio(repositorioCompromisso);
            telaCadastro.SetContatos(repositorioContato.GetRegistros());
        }

        private void InserirEAtualizar<T>(RepositorioBase<T> repositorio, ListBox listBox, T entidade) where T : EntidadeBase
        {
            repositorio.Inserir(entidade);
            AtualizaListagem(repositorio, listBox);
        }

        private void InicializaTelaCadastroParaContato(Contato contato)
        {
            telaCadastro = new(contato);
            telaCadastro.TarefaVisibilidade(false);
            telaCadastro.CompromissoVisibilidade(false);
            telaCadastro.ContatosVisibilidade(true);
            telaCadastro.ItemsVisibilidade(false);
            telaCadastro.SetRepositorio(repositorioContato);
        }

        /// <summary>
        /// (Filtragem?,data inicio, data fim)
        /// </summary>
        /// <param name="filtragem"></param>
        private void AtualizarCompromissosPassadosEFuturos(ListBox listBoxPassados, ListBox listBoxFuturos, (bool, DateTime, DateTime) filtragem)
        {
            if (filtragem.Item1)
            {
                listBoxFuturos.Items.Clear();
                AtualizarCabecalhoListbox(listBoxFuturos);
                foreach (var compromisso in repositorioCompromisso.GetRegistros())
                {

                    if (compromisso.DataFim > DateTime.Now && compromisso.DataFim > filtragem.Item2 && compromisso.DataFim > filtragem.Item3)
                        listBoxFuturos.Items.Add(compromisso);

                }
            }

            else
            {
                listBoxPassados.Items.Clear();
                listBoxFuturos.Items.Clear();
                AtualizarCabecalhoListbox(listBoxPassados);
                AtualizarCabecalhoListbox(listBoxFuturos);
                foreach (var compromisso in repositorioCompromisso.GetRegistros())
                {

                    if (compromisso.DataFim > DateTime.Now)
                        listBoxFuturos.Items.Add(compromisso);
                    else
                        listBoxPassados.Items.Add(compromisso);

                }
            }
        }

        private void AtualizarTarefasCompletasEIncompletas(RepositorioTarefa repositorio, ListBox listBoxTarefasIncompletas, ListBox listBoxTarefasCompletas)
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

            if (repositorio is RepositorioTarefa || repositorio is RepositorioContato)
                repositorio.Ordenar();

            foreach (var item in repositorio.GetRegistros())
            {
                listBox.Items.Add(item);
            }
        }

        private void AtualizarCabecalhoListbox(ListBox listBox)
        {
            if (listBox == listBoxTarefasInCompletas || listBox == listBoxTarefasCompletas)
                listBox.Items.Insert(0, "(id)  (prioridade)  (titulo)  (data criação)  data conclusao)  (%conclusão)");

            else if (listBox == listBoxCompromissosPassados || listBox == listBoxCompromissosFuturos)
                listBox.Items.Insert(0, "(id) (Local) (assunto) (data e hora inicio) (data e hora fim) (nome contato)");

            else if (listBox == listBoxContatos)
                listBox.Items.Insert(0, "(id)  (nome)  (email)  (telefone)  (empresa)  (cargo)");
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
                Contato c = (Contato)listBoxContatos.SelectedItem;
                InicializaTelaCadastroParaContato(c);
                var result = telaCadastro.ShowDialog();
                if (result == DialogResult.OK)
                {
                    repositorioContato.Editar(c.id, telaCadastro.Contato);
                }
                AtualizaListagem(repositorioContato, listBoxContatos);
            }
            else if (listBoxCompromissosPassados.SelectedIndex != -1)
            {
                Compromisso c = (Compromisso)listBoxCompromissosPassados.SelectedItem;
                InicializaTelaCadastroParaCompromisso(c);
                var result = telaCadastro.ShowDialog();
                if (result == DialogResult.OK)
                {
                    repositorioCompromisso.Editar(c.id, telaCadastro.Compromisso);
                }
                AtualizaListagem(repositorioCompromisso, listBoxCompromissosPassados);
            }
            else
            {
                Tarefa t;
                ListBox listBox;
                if (listBoxTarefasInCompletas.SelectedIndex > -1)
                {
                    t = (Tarefa)listBoxTarefasInCompletas.SelectedItem;
                    listBox = listBoxTarefasInCompletas;
                }
                else
                {
                    t = (Tarefa)listBoxTarefasCompletas.SelectedItem;
                    listBox = listBoxTarefasInCompletas;
                }
                InicializaTelaCadastroParaTarefa(t);
                var result = telaCadastro.ShowDialog();
                if (result == DialogResult.OK)
                {
                    repositorioTarefa.Editar(t.id, telaCadastro.Tarefa);
                }
                repositorioTarefa.Ordenar();
                AtualizaListagem(repositorioTarefa, listBox);
            }
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            if (listBoxContatos.SelectedIndex != -1)
            {
                Contato c = (Contato)listBoxContatos.SelectedItem;
                if(repositorioCompromisso.GetRegistros().Exists(x => x.id == c.id))
                {
                    MessageBox.Show("contato atualmente em um comrpomisso");
                        return ;
                }
                ExcluirRegistro(repositorioContato,listBoxContatos);
            }
          else if (listBoxCompromissosPassados.SelectedIndex != -1)
            {
                ExcluirRegistro(repositorioCompromisso, listBoxCompromissosPassados);
            }
            else
            {
                ListBox listBox;
                if (listBoxTarefasInCompletas.SelectedIndex > -1)
                {
                    MessageBox.Show("tarefas incompletas nao poderão ser apagadas");
                    return;
                }
                else
                {
                    listBox = listBoxTarefasInCompletas;
                }
                ExcluirRegistro(repositorioTarefa, listBox);
            }

        }

        private void ExcluirRegistro<T>(RepositorioBase<T> repositorio,ListBox listBox)where T : EntidadeBase
        {
            EntidadeBase c = (EntidadeBase)listBox.SelectedItem;
            repositorio.Excluir(c.id);
            AtualizaListagem(repositorio,listBox);
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            AtualizarCompromissosPassadosEFuturos(listBoxCompromissosPassados,listBoxCompromissosFuturos,(true,dateTimePickerDataInicio.Value,dateTimePickerDataFim.Value));
        }
    }
}
