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
        #region propriedades
        RepositorioCompromisso repositorioCompromisso;
        RepositorioContato repositorioContato;
        RepositorioTarefa repositorioTarefa;
        TelaCadastro telaCadastro;
        #endregion
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
            AtualizarCompromissosPassadosEFuturos( (false, DateTime.MinValue, DateTime.MinValue));
            AtualizarTarefasCompletasEIncompletas(repositorioTarefa, listBoxTarefasInCompletas, listBoxTarefasCompletas);
            AtualizaListagem(repositorioContato, listBoxContatos);
            buttonFiltrar.Visible = false;

        }





        #region ListBox selected index changed
        private void listBoxTarefas_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBoxTarefasInCompletas.SelectedIndex > -1)
            {
                labelA.Visible = false;
                dateTimePickerDataFim.Visible = false;
                dateTimePickerDataInicio.Visible = false;
                buttonFiltrar.Visible =false;
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
                buttonFiltrar.Visible = false;
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

                buttonFiltrar.Visible = false;
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
                labelA.Visible = false;
                dateTimePickerDataFim.Visible = false;
                dateTimePickerDataInicio.Visible = false;

                buttonFiltrar.Visible = false;
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
                buttonFiltrar.Visible = true;
                dateTimePickerDataFim.Visible = true;
                dateTimePickerDataInicio.Visible = true;
            }
            if (listBoxCompromissosFuturos.SelectedIndex == 0)
                listBoxCompromissosFuturos.SelectedIndex = -1;


        }

        #endregion

        #region Botões
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
                        AtualizarCompromissosPassadosEFuturos( (false, default, default));
                        break;
                    case Classes.Item:
                        repositorioTarefa.AdicionarItems(telaCadastro.Tarefa, telaCadastro.Items);
                        AtualizarTarefasCompletasEIncompletas(repositorioTarefa, listBoxTarefasInCompletas, listBoxTarefasCompletas);
                        break;
                }

            }
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
            else if (listBoxCompromissosPassados.SelectedIndex != -1 || listBoxCompromissosFuturos.SelectedIndex != -1)
            {
                Compromisso c = new();
                if (listBoxCompromissosFuturos.SelectedIndex > -1)
                {
                    c = (Compromisso)listBoxCompromissosFuturos.SelectedItem;
                }
                if (listBoxCompromissosPassados.SelectedIndex > -1)
                {
                    c = (Compromisso)listBoxCompromissosPassados.SelectedItem;
                }
                InicializaTelaCadastroParaCompromisso(c);
                var result = telaCadastro.ShowDialog();
                if (result == DialogResult.OK)
                {
                    repositorioCompromisso.Editar(c.id, telaCadastro.Compromisso);
                }
                AtualizarCompromissosPassadosEFuturos((false,default,default));
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
                if (repositorioCompromisso.GetRegistros().Exists(x => x.id == c.id))
                {
                    MessageBox.Show("contato atualmente em um comrpomisso");
                    return;
                }
                ExcluirRegistro(repositorioContato, listBoxContatos);
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
                    listBox = listBoxTarefasCompletas;
                }
                ExcluirRegistro(repositorioTarefa, listBox);
            }

        }
        private void buttonItem_Click(object sender, EventArgs e)
        {
            comboBoxInserirOpcoes.SelectedIndex = 3;
            buttonInserir.PerformClick();
        }
        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            AtualizarCompromissosPassadosEFuturos( (true, dateTimePickerDataInicio.Value, dateTimePickerDataFim.Value));
        }
        #endregion

        #region inizializações
        private void InicializaTelaCadastroParaItem()
        {
            if (listBoxTarefasInCompletas.SelectedIndex > -1)
                telaCadastro = new((Tarefa)listBoxTarefasInCompletas.SelectedItem);
            else
                telaCadastro = new((Tarefa)listBoxTarefasCompletas.SelectedItem);
            telaCadastro.TarefaVisibilidade(false);
            telaCadastro.CompromissoVisibilidade(false);
            telaCadastro.ContatosVisibilidade(false);
            telaCadastro.ItemsVisibilidade(true);
            telaCadastro.SetRepositorio(repositorioTarefa);
            telaCadastro.Entidade = new Item();
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
        #endregion

        #region Atualizações

        /// <summary>
        /// (Filtragem?,data inicio, data fim)
        /// </summary>
        /// <param name="filtragem"></param>
        private void AtualizarCompromissosPassadosEFuturos((bool, DateTime, DateTime) filtragem)
        {
            if (filtragem.Item1)
            {
                listBoxCompromissosFuturos.Items.Clear();
                AtualizarCabecalhoListbox(listBoxCompromissosFuturos);
                foreach (var compromisso in repositorioCompromisso.GetRegistros())
                {

                    if (compromisso.DataFim > DateTime.Now && compromisso.DataFim > filtragem.Item2 && compromisso.DataFim > filtragem.Item3)
                        listBoxCompromissosFuturos.Items.Add(compromisso);

                }
            }

            else
            {
                listBoxCompromissosPassados.Items.Clear();
                listBoxCompromissosFuturos.Items.Clear();
                AtualizarCabecalhoListbox(listBoxCompromissosPassados);
                AtualizarCabecalhoListbox(listBoxCompromissosFuturos);
                foreach (var compromisso in repositorioCompromisso.GetRegistros())
                {

                    if (compromisso.DataFim > DateTime.Now)
                        listBoxCompromissosFuturos.Items.Add(compromisso);
                    else
                        listBoxCompromissosPassados.Items.Add(compromisso);

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
                listBox.Items.Insert(0, "(id)".PadRight(10, ' ') + "(prioridade)".PadRight(20, ' ') + "(titulo)".PadRight(20, ' ') + "(data criação)".PadRight(30, ' ') +"(data conclusao)".PadRight(28, ' ') + "(%conclusão)");

            else if (listBox == listBoxCompromissosPassados || listBox == listBoxCompromissosFuturos)
                listBox.Items.Insert(0, "(id)".PadRight(10, ' ') + "(Local)".PadRight(20, ' ') + "(assunto)".PadRight(20, ' ') + "(data e hora inicio)".PadRight(30, ' ') + "(data e hora fim)".PadRight(28, ' ') + "(nome contato)");

            else if (listBox == listBoxContatos)
                listBox.Items.Insert(0, "(id)".PadRight(10, ' ') +  "(nome)".PadRight(20, ' ') +  "(email)".PadRight(20, ' ') + "(telefone)".PadRight(20, ' ') + "(empresa)".PadRight(20, ' ') + "(cargo)");
        }

        #endregion





        private void ExcluirRegistro<T>(RepositorioBase<T> repositorio, ListBox listBox) where T : EntidadeBase
        {
            EntidadeBase c = (EntidadeBase)listBox.SelectedItem;
            repositorio.Excluir(c.id);
            AtualizaListagem(repositorio, listBox);
        }


    }
}
