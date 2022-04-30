namespace E_Agenda2
{
    partial class TelaCadastro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTitulo = new System.Windows.Forms.TextBox();
            this.comboBoxPrioridade = new System.Windows.Forms.ComboBox();
            this.dateTimePickerDataInicio = new System.Windows.Forms.DateTimePicker();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.dateTimePickerDataFim = new System.Windows.Forms.DateTimePicker();
            this.labelDataInicio = new System.Windows.Forms.Label();
            this.labelDataFim = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxEmpresa = new System.Windows.Forms.TextBox();
            this.textBoxCargo = new System.Windows.Forms.TextBox();
            this.textBoxAssunto = new System.Windows.Forms.TextBox();
            this.textBoxLocal = new System.Windows.Forms.TextBox();
            this.comboBoxNomeContatos = new System.Windows.Forms.ComboBox();
            this.labelNomeContato = new System.Windows.Forms.Label();
            this.maskedTextBoxTelefone = new System.Windows.Forms.MaskedTextBox();
            this.checkedListBoxItems = new System.Windows.Forms.CheckedListBox();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTitulo
            // 
            this.textBoxTitulo.Location = new System.Drawing.Point(12, 12);
            this.textBoxTitulo.Name = "textBoxTitulo";
            this.textBoxTitulo.PlaceholderText = "Titulo";
            this.textBoxTitulo.Size = new System.Drawing.Size(100, 23);
            this.textBoxTitulo.TabIndex = 1;
            // 
            // comboBoxPrioridade
            // 
            this.comboBoxPrioridade.FormattingEnabled = true;
            this.comboBoxPrioridade.Location = new System.Drawing.Point(12, 41);
            this.comboBoxPrioridade.Name = "comboBoxPrioridade";
            this.comboBoxPrioridade.Size = new System.Drawing.Size(100, 23);
            this.comboBoxPrioridade.TabIndex = 2;
            // 
            // dateTimePickerDataInicio
            // 
            this.dateTimePickerDataInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePickerDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDataInicio.Location = new System.Drawing.Point(12, 87);
            this.dateTimePickerDataInicio.Name = "dateTimePickerDataInicio";
            this.dateTimePickerDataInicio.Size = new System.Drawing.Size(154, 23);
            this.dateTimePickerDataInicio.TabIndex = 3;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Location = new System.Drawing.Point(12, 241);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(75, 23);
            this.buttonSalvar.TabIndex = 6;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // dateTimePickerDataFim
            // 
            this.dateTimePickerDataFim.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePickerDataFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDataFim.Location = new System.Drawing.Point(12, 143);
            this.dateTimePickerDataFim.Name = "dateTimePickerDataFim";
            this.dateTimePickerDataFim.Size = new System.Drawing.Size(154, 23);
            this.dateTimePickerDataFim.TabIndex = 7;
            // 
            // labelDataInicio
            // 
            this.labelDataInicio.AutoSize = true;
            this.labelDataInicio.Location = new System.Drawing.Point(12, 69);
            this.labelDataInicio.Name = "labelDataInicio";
            this.labelDataInicio.Size = new System.Drawing.Size(115, 15);
            this.labelDataInicio.TabIndex = 8;
            this.labelDataInicio.Text = "Data e hora de inicio";
            // 
            // labelDataFim
            // 
            this.labelDataFim.AutoSize = true;
            this.labelDataFim.Location = new System.Drawing.Point(12, 125);
            this.labelDataFim.Name = "labelDataFim";
            this.labelDataFim.Size = new System.Drawing.Size(104, 15);
            this.labelDataFim.TabIndex = 9;
            this.labelDataFim.Text = "Data e hora de fim";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(12, 14);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.PlaceholderText = "Nome";
            this.textBoxNome.Size = new System.Drawing.Size(100, 23);
            this.textBoxNome.TabIndex = 10;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(12, 43);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.PlaceholderText = "Email";
            this.textBoxEmail.Size = new System.Drawing.Size(100, 23);
            this.textBoxEmail.TabIndex = 11;
            // 
            // textBoxEmpresa
            // 
            this.textBoxEmpresa.Location = new System.Drawing.Point(12, 101);
            this.textBoxEmpresa.Name = "textBoxEmpresa";
            this.textBoxEmpresa.PlaceholderText = "Empresa";
            this.textBoxEmpresa.Size = new System.Drawing.Size(100, 23);
            this.textBoxEmpresa.TabIndex = 13;
            // 
            // textBoxCargo
            // 
            this.textBoxCargo.Location = new System.Drawing.Point(12, 130);
            this.textBoxCargo.Name = "textBoxCargo";
            this.textBoxCargo.PlaceholderText = "Cargo";
            this.textBoxCargo.Size = new System.Drawing.Size(100, 23);
            this.textBoxCargo.TabIndex = 14;
            // 
            // textBoxAssunto
            // 
            this.textBoxAssunto.Location = new System.Drawing.Point(12, 14);
            this.textBoxAssunto.Name = "textBoxAssunto";
            this.textBoxAssunto.PlaceholderText = "Assunto";
            this.textBoxAssunto.Size = new System.Drawing.Size(100, 23);
            this.textBoxAssunto.TabIndex = 15;
            // 
            // textBoxLocal
            // 
            this.textBoxLocal.Location = new System.Drawing.Point(12, 43);
            this.textBoxLocal.Name = "textBoxLocal";
            this.textBoxLocal.PlaceholderText = "Local";
            this.textBoxLocal.Size = new System.Drawing.Size(100, 23);
            this.textBoxLocal.TabIndex = 16;
            // 
            // comboBoxNomeContatos
            // 
            this.comboBoxNomeContatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNomeContatos.FormattingEnabled = true;
            this.comboBoxNomeContatos.Location = new System.Drawing.Point(12, 190);
            this.comboBoxNomeContatos.Name = "comboBoxNomeContatos";
            this.comboBoxNomeContatos.Size = new System.Drawing.Size(121, 23);
            this.comboBoxNomeContatos.TabIndex = 17;
            // 
            // labelNomeContato
            // 
            this.labelNomeContato.AutoSize = true;
            this.labelNomeContato.Location = new System.Drawing.Point(12, 169);
            this.labelNomeContato.Name = "labelNomeContato";
            this.labelNomeContato.Size = new System.Drawing.Size(101, 15);
            this.labelNomeContato.TabIndex = 18;
            this.labelNomeContato.Text = "Nome do contato";
            // 
            // maskedTextBoxTelefone
            // 
            this.maskedTextBoxTelefone.Location = new System.Drawing.Point(12, 72);
            this.maskedTextBoxTelefone.Mask = "(99)-99999-9999";
            this.maskedTextBoxTelefone.Name = "maskedTextBoxTelefone";
            this.maskedTextBoxTelefone.Size = new System.Drawing.Size(100, 23);
            this.maskedTextBoxTelefone.TabIndex = 19;
            this.maskedTextBoxTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // checkedListBoxItems
            // 
            this.checkedListBoxItems.FormattingEnabled = true;
            this.checkedListBoxItems.Location = new System.Drawing.Point(12, 41);
            this.checkedListBoxItems.Name = "checkedListBoxItems";
            this.checkedListBoxItems.Size = new System.Drawing.Size(173, 94);
            this.checkedListBoxItems.TabIndex = 20;
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(12, 14);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.PlaceholderText = "Descrição";
            this.textBoxDescricao.Size = new System.Drawing.Size(100, 23);
            this.textBoxDescricao.TabIndex = 22;
            // 
            // buttonGravar
            // 
            this.buttonGravar.Location = new System.Drawing.Point(118, 11);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(75, 23);
            this.buttonGravar.TabIndex = 23;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // TelaCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 276);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.textBoxDescricao);
            this.Controls.Add(this.maskedTextBoxTelefone);
            this.Controls.Add(this.labelNomeContato);
            this.Controls.Add(this.comboBoxNomeContatos);
            this.Controls.Add(this.textBoxLocal);
            this.Controls.Add(this.textBoxAssunto);
            this.Controls.Add(this.textBoxCargo);
            this.Controls.Add(this.textBoxEmpresa);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelDataFim);
            this.Controls.Add(this.labelDataInicio);
            this.Controls.Add(this.dateTimePickerDataFim);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.dateTimePickerDataInicio);
            this.Controls.Add(this.comboBoxPrioridade);
            this.Controls.Add(this.textBoxTitulo);
            this.Controls.Add(this.checkedListBoxItems);
            this.Name = "TelaCadastro";
            this.Text = "TelaCadastro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTitulo;
        private System.Windows.Forms.ComboBox comboBoxPrioridade;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataInicio;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataFim;
        private System.Windows.Forms.Label labelDataInicio;
        private System.Windows.Forms.Label labelDataFim;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxEmpresa;
        private System.Windows.Forms.TextBox textBoxCargo;
        private System.Windows.Forms.TextBox textBoxAssunto;
        private System.Windows.Forms.TextBox textBoxLocal;
        private System.Windows.Forms.ComboBox comboBoxNomeContatos;
        private System.Windows.Forms.Label labelNomeContato;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefone;
        private System.Windows.Forms.CheckedListBox checkedListBoxItems;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Button buttonGravar;
    }
}