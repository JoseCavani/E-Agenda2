namespace E_Agenda2
{
    partial class TelaListagems
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxTarefasInCompletas = new System.Windows.Forms.ListBox();
            this.listBoxCompromissosPassados = new System.Windows.Forms.ListBox();
            this.listBoxContatos = new System.Windows.Forms.ListBox();
            this.buttonInserir = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonItem = new System.Windows.Forms.Button();
            this.comboBoxInserirOpcoes = new System.Windows.Forms.ComboBox();
            this.listBoxTarefasCompletas = new System.Windows.Forms.ListBox();
            this.listBoxCompromissosFuturos = new System.Windows.Forms.ListBox();
            this.buttonFiltrar = new System.Windows.Forms.Button();
            this.dateTimePickerDataFim = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDataInicio = new System.Windows.Forms.DateTimePicker();
            this.labelA = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxTarefasInCompletas
            // 
            this.listBoxTarefasInCompletas.FormattingEnabled = true;
            this.listBoxTarefasInCompletas.ItemHeight = 15;
            this.listBoxTarefasInCompletas.Location = new System.Drawing.Point(12, 82);
            this.listBoxTarefasInCompletas.Name = "listBoxTarefasInCompletas";
            this.listBoxTarefasInCompletas.Size = new System.Drawing.Size(415, 79);
            this.listBoxTarefasInCompletas.TabIndex = 0;
            this.listBoxTarefasInCompletas.SelectedIndexChanged += new System.EventHandler(this.listBoxTarefas_SelectedIndexChanged);
            // 
            // listBoxCompromissosPassados
            // 
            this.listBoxCompromissosPassados.FormattingEnabled = true;
            this.listBoxCompromissosPassados.ItemHeight = 15;
            this.listBoxCompromissosPassados.Location = new System.Drawing.Point(12, 190);
            this.listBoxCompromissosPassados.Name = "listBoxCompromissosPassados";
            this.listBoxCompromissosPassados.Size = new System.Drawing.Size(415, 94);
            this.listBoxCompromissosPassados.TabIndex = 1;
            this.listBoxCompromissosPassados.SelectedIndexChanged += new System.EventHandler(this.listBoxCompromissosPassados_SelectedIndexChanged);
            // 
            // listBoxContatos
            // 
            this.listBoxContatos.FormattingEnabled = true;
            this.listBoxContatos.ItemHeight = 15;
            this.listBoxContatos.Location = new System.Drawing.Point(12, 291);
            this.listBoxContatos.Name = "listBoxContatos";
            this.listBoxContatos.Size = new System.Drawing.Size(802, 109);
            this.listBoxContatos.TabIndex = 2;
            this.listBoxContatos.SelectedIndexChanged += new System.EventHandler(this.listBoxContatos_SelectedIndexChanged);
            // 
            // buttonInserir
            // 
            this.buttonInserir.Location = new System.Drawing.Point(184, 12);
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(97, 23);
            this.buttonInserir.TabIndex = 3;
            this.buttonInserir.Text = "Inserir";
            this.buttonInserir.UseVisualStyleBackColor = true;
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(318, 12);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(75, 23);
            this.buttonEditar.TabIndex = 4;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Location = new System.Drawing.Point(457, 12);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(75, 23);
            this.buttonExcluir.TabIndex = 5;
            this.buttonExcluir.Text = "Excluir";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // buttonItem
            // 
            this.buttonItem.Location = new System.Drawing.Point(12, 53);
            this.buttonItem.Name = "buttonItem";
            this.buttonItem.Size = new System.Drawing.Size(75, 23);
            this.buttonItem.TabIndex = 6;
            this.buttonItem.Text = "Items";
            this.buttonItem.UseVisualStyleBackColor = true;
            this.buttonItem.Click += new System.EventHandler(this.buttonItem_Click);
            // 
            // comboBoxInserirOpcoes
            // 
            this.comboBoxInserirOpcoes.AutoCompleteCustomSource.AddRange(new string[] {
            "Tarefa",
            "Contato",
            "Compromisso"});
            this.comboBoxInserirOpcoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInserirOpcoes.Items.AddRange(new object[] {
            "Tarefa",
            "Contato",
            "Compromisso"});
            this.comboBoxInserirOpcoes.Location = new System.Drawing.Point(184, 41);
            this.comboBoxInserirOpcoes.Name = "comboBoxInserirOpcoes";
            this.comboBoxInserirOpcoes.Size = new System.Drawing.Size(123, 23);
            this.comboBoxInserirOpcoes.TabIndex = 7;
            // 
            // listBoxTarefasCompletas
            // 
            this.listBoxTarefasCompletas.FormattingEnabled = true;
            this.listBoxTarefasCompletas.ItemHeight = 15;
            this.listBoxTarefasCompletas.Location = new System.Drawing.Point(433, 82);
            this.listBoxTarefasCompletas.Name = "listBoxTarefasCompletas";
            this.listBoxTarefasCompletas.Size = new System.Drawing.Size(381, 79);
            this.listBoxTarefasCompletas.TabIndex = 8;
            this.listBoxTarefasCompletas.SelectedIndexChanged += new System.EventHandler(this.listBoxTarefasCompletas_SelectedIndexChanged);
            // 
            // listBoxCompromissosFuturos
            // 
            this.listBoxCompromissosFuturos.FormattingEnabled = true;
            this.listBoxCompromissosFuturos.ItemHeight = 15;
            this.listBoxCompromissosFuturos.Location = new System.Drawing.Point(433, 190);
            this.listBoxCompromissosFuturos.Name = "listBoxCompromissosFuturos";
            this.listBoxCompromissosFuturos.Size = new System.Drawing.Size(381, 94);
            this.listBoxCompromissosFuturos.TabIndex = 9;
            this.listBoxCompromissosFuturos.SelectedIndexChanged += new System.EventHandler(this.listBoxCompromissosFuturos_SelectedIndexChanged);
            // 
            // buttonFiltrar
            // 
            this.buttonFiltrar.Location = new System.Drawing.Point(739, 167);
            this.buttonFiltrar.Name = "buttonFiltrar";
            this.buttonFiltrar.Size = new System.Drawing.Size(75, 23);
            this.buttonFiltrar.TabIndex = 10;
            this.buttonFiltrar.Text = "Filtrar";
            this.buttonFiltrar.UseVisualStyleBackColor = true;
            this.buttonFiltrar.Click += new System.EventHandler(this.buttonFiltrar_Click);
            // 
            // dateTimePickerDataFim
            // 
            this.dateTimePickerDataFim.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePickerDataFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDataFim.Location = new System.Drawing.Point(598, 165);
            this.dateTimePickerDataFim.Name = "dateTimePickerDataFim";
            this.dateTimePickerDataFim.Size = new System.Drawing.Size(134, 23);
            this.dateTimePickerDataFim.TabIndex = 11;
            // 
            // dateTimePickerDataInicio
            // 
            this.dateTimePickerDataInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePickerDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDataInicio.Location = new System.Drawing.Point(440, 165);
            this.dateTimePickerDataInicio.Name = "dateTimePickerDataInicio";
            this.dateTimePickerDataInicio.Size = new System.Drawing.Size(131, 23);
            this.dateTimePickerDataInicio.TabIndex = 12;
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(577, 169);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(15, 15);
            this.labelA.TabIndex = 13;
            this.labelA.Text = "A";
            // 
            // TelaListagems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 412);
            this.Controls.Add(this.labelA);
            this.Controls.Add(this.dateTimePickerDataInicio);
            this.Controls.Add(this.dateTimePickerDataFim);
            this.Controls.Add(this.buttonFiltrar);
            this.Controls.Add(this.listBoxCompromissosFuturos);
            this.Controls.Add(this.listBoxTarefasCompletas);
            this.Controls.Add(this.comboBoxInserirOpcoes);
            this.Controls.Add(this.buttonItem);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonInserir);
            this.Controls.Add(this.listBoxContatos);
            this.Controls.Add(this.listBoxCompromissosPassados);
            this.Controls.Add(this.listBoxTarefasInCompletas);
            this.Name = "TelaListagems";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTarefasInCompletas;
        private System.Windows.Forms.ListBox listBoxCompromissosPassados;
        private System.Windows.Forms.ListBox listBoxContatos;
        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Button buttonItem;
        private System.Windows.Forms.ComboBox comboBoxInserirOpcoes;
        private System.Windows.Forms.ListBox listBoxTarefasCompletas;
        private System.Windows.Forms.ListBox listBoxCompromissosFuturos;
        private System.Windows.Forms.Button buttonFiltrar;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataFim;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataInicio;
        private System.Windows.Forms.Label labelA;
    }
}
