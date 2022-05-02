using E_Agenda.ConsoleApp1.Compartilhado;
using E_Agenda.ConsoleApp1.ModuloCompromisso;
using E_Agenda.ConsoleApp1.ModuloContato;
using E_Agenda.ConsoleApp1.ModuloItem;
using E_Agenda.ConsoleApp1.ModuloTarefa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Agenda2
{
    public partial class TelaCadastro : Form
    {
        #region atributos e propriedades
        private Tarefa? tarefa;
        private Contato? contato;
        private Compromisso? compromisso;
        List<Contato>? contatos;
        List<Item>? items;
        RepositorioTarefa? repositorioTarefa;
        RepositorioContato? repositorioContato;
        private RepositorioCompromisso? repositorioCompromisso;
        EntidadeBase? entidade;

        public Tarefa? Tarefa { get => tarefa; }
        public Contato? Contato { get => contato; }
        public Compromisso? Compromisso { get => compromisso; }
        public List<Item>? Items { get => items; }
        public EntidadeBase? Entidade { set => entidade = value; }
        #endregion

        #region visibilidades
        public void ItemsVisibilidade(bool flag)
        {
            buttonGravar.Visible = flag;
            checkedListBoxItems.Visible = flag;
            textBoxDescricao.Visible = flag;
        }
        public void TarefaVisibilidade(bool flag)
        {
            textBoxTitulo.Visible = flag;
            comboBoxPrioridade.Visible = flag;
            labelDataFim.Visible = flag;
            labelDataInicio.Visible = flag;
            dateTimePickerDataFim.Visible = flag;
            dateTimePickerDataInicio.Visible = flag;

        }
        public void ContatosVisibilidade(bool flag)
        {
            textBoxCargo.Visible = flag;
            textBoxEmail.Visible = flag;
            textBoxEmpresa.Visible = flag;
            textBoxNome.Visible = flag;
            maskedTextBoxTelefone.Visible = flag;
        }

        public void CompromissoVisibilidade(bool flag)
        {
            textBoxAssunto.Visible = flag;
            textBoxLocal.Visible = flag;
            comboBoxNomeContatos.Visible = flag;
            labelDataFim.Visible = flag;
            labelDataInicio.Visible = flag;
            dateTimePickerDataFim.Visible = flag;
            dateTimePickerDataInicio.Visible = flag;
            labelNomeContato.Visible = flag;
        }
        #endregion
        #region construtores
        public TelaCadastro(EntidadeBase entidade)
        {
            InitializeComponent();
            this.entidade = entidade;
            if (entidade is Tarefa)
            {
                comboBoxPrioridade.DataSource = Enum.GetNames(typeof(Prioridade));
                tarefa = (Tarefa)entidade;
                if (tarefa.DataCriacao != DateTime.MinValue)
                {
                    this.items = tarefa.Items;
                    AtualizarListoBoxItems();
                    dateTimePickerDataInicio.Enabled = false;
                    textBoxTitulo.Text = tarefa.Titulo;
                    dateTimePickerDataFim.Enabled = false;
                    comboBoxPrioridade.SelectedItem = (Classes)tarefa.prioridade;
                    dateTimePickerDataInicio.Value = tarefa.DataCriacao;
                    dateTimePickerDataFim.Value = tarefa.DataConclusao;
                }
            }
            else if (entidade is Contato)
            {
                contato = (Contato)entidade;
                if (Contato.Nome != "")
                {
                    textBoxNome.Text = contato.Nome;
                    textBoxEmail.Text = contato.Email;
                    maskedTextBoxTelefone.Text = contato.Telefone;
                    textBoxEmpresa.Text = contato.Email;
                    textBoxCargo.Text = contato.Cargo;
                }
            }
            else if (entidade is Compromisso)
            {
                compromisso = (Compromisso)entidade;
                if (compromisso.DataInicio != DateTime.MinValue)
                {
                    textBoxAssunto.Text = compromisso.Assunto;
                    textBoxLocal.Text = compromisso.Local;
                    dateTimePickerDataFim.Value = compromisso.DataFim;
                    dateTimePickerDataInicio.Value = compromisso.DataInicio;
                    comboBoxNomeContatos.SelectedItem = compromisso.Contato.Nome;
                }
            }
        }
    

        #endregion
        public void SetContatos(List<Contato> contatos)
        {
            this.contatos = contatos;
            foreach (var item in contatos)
            {
                comboBoxNomeContatos.Items.Add(item.Nome);
                comboBoxNomeContatos.SelectedIndex = 0;
            }
        }

        private void AtualizarListoBoxItems()
        {
            int contador = 0;
            checkedListBoxItems.Items.Clear();
            foreach (var item in Items)
            {
                checkedListBoxItems.Items.Add(item);
                if (item.concluido)
                {
                    checkedListBoxItems.SetItemChecked(contador, true);
                }
                contador++;
            }
        }

        private bool IsValidEmail(string emailaddress)
        {
            return new EmailAddressAttribute().IsValid(emailaddress);
        }
        #region botões
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (entidade is Tarefa)
            {
                if (repositorioTarefa.GetRegistros().Exists(x => x.Titulo == textBoxTitulo.Text) || textBoxTitulo.Text == "")
                {
                    MessageBox.Show("titulo ja existe ou nao digitado");
                    return;
                }

                tarefa = new Tarefa((Prioridade)Enum.Parse(typeof(Prioridade), comboBoxPrioridade.Text), textBoxTitulo.Text, dateTimePickerDataInicio.Value, dateTimePickerDataFim.Value);
            }
            if (entidade is Contato)
            {

                if (textBoxNome.Text == "" || textBoxEmail.Text == "" || maskedTextBoxTelefone.Text == "")
                {
                    MessageBox.Show("nome email ou telefone vazio");
                    return;
                }

                if (repositorioContato.GetRegistros().Exists(x => x.Nome == textBoxNome.Text) && repositorioContato.GetRegistros().Exists(x => x.Telefone == maskedTextBoxTelefone.Text) && repositorioContato.GetRegistros().Exists(x => x.Email == textBoxEmail.Text))
                {
                    MessageBox.Show("email nome e telefone ja existente");
                    return;
                }


                if (!IsValidEmail(textBoxEmail.Text) || !maskedTextBoxTelefone.MaskFull)
                {
                    MessageBox.Show("email ou telefone invalido");
                    return;
                }



                contato = new Contato(textBoxNome.Text, textBoxEmail.Text, maskedTextBoxTelefone.Text, textBoxEmpresa.Text, textBoxCargo.Text);
            }
            if (entidade is Compromisso)
            {

                if (repositorioCompromisso.GetRegistros().Exists(x => x.DataFim < dateTimePickerDataFim.Value && x.DataInicio > dateTimePickerDataInicio.Value))
                {
                    MessageBox.Show("data inical ultrapassou uma data final");
                    return;
                }

                if (dateTimePickerDataInicio.Value <= DateTime.Now)
                {
                    MessageBox.Show("data inical invalida");
                    return;
                }

                if (dateTimePickerDataInicio.Value >= dateTimePickerDataFim.Value)
                {
                    MessageBox.Show("data inical maior que a final");
                    return;
                }

                if (dateTimePickerDataFim.Value < dateTimePickerDataInicio.Value)
                {
                    MessageBox.Show("data inicial maior que a final");
                    return;
                }




                if (textBoxAssunto.Text == "" || textBoxLocal.Text == "")
                {
                    MessageBox.Show("assunto ou local vazio");
                    return;
                }

                compromisso = new Compromisso(textBoxAssunto.Text, textBoxLocal.Text, dateTimePickerDataInicio.Value, dateTimePickerDataFim.Value, contatos.Find(x => x.Nome == comboBoxNomeContatos.Text));
            }
            if (entidade is Item)
            {
                foreach (Item item in checkedListBoxItems.CheckedItems)
                {
                    item.concluido = true;
                }
                items = checkedListBoxItems.Items.Cast<Item>().ToList();
            }

                this.DialogResult = DialogResult.OK;
        }

        private void MarcarItemsCheckado()
        {
            foreach (var item in checkedListBoxItems.CheckedItems)
            {
                items.Find(x => x == item).concluido = true;
            }
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            if (textBoxDescricao.Text == "") 
            {
                MessageBox.Show("descrição vazia");
                return;
            }
            items.Add(new Item(textBoxDescricao.Text));
            MarcarItemsCheckado();
            AtualizarListoBoxItems();
        }
        #endregion


        #region setar repositorios
        internal void SetRepositorio(RepositorioTarefa repositorioTarefa)
        {
            this.repositorioTarefa = repositorioTarefa;
        }

        internal void SetRepositorio(RepositorioContato repositorioContato)
        {
            this.repositorioContato = repositorioContato;
        }
        internal void SetRepositorio(RepositorioCompromisso repositorioCompromisso)
        {
            this.repositorioCompromisso = repositorioCompromisso;
        }
        #endregion

    }
}
