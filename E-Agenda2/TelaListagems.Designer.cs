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
            this.listBoxTarefasIncompletas = new System.Windows.Forms.ListBox();
            this.listBoxCompromissos = new System.Windows.Forms.ListBox();
            this.listBoxContatos = new System.Windows.Forms.ListBox();
            this.buttonInserir = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonItem = new System.Windows.Forms.Button();
            this.comboBoxInserirOpcoes = new System.Windows.Forms.ComboBox();
            this.listBoxTarefasCompletas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxTarefasIncompletas
            // 
            this.listBoxTarefasIncompletas.FormattingEnabled = true;
            this.listBoxTarefasIncompletas.ItemHeight = 15;
            this.listBoxTarefasIncompletas.Location = new System.Drawing.Point(12, 105);
            this.listBoxTarefasIncompletas.Name = "listBoxTarefasIncompletas";
            this.listBoxTarefasIncompletas.Size = new System.Drawing.Size(415, 79);
            this.listBoxTarefasIncompletas.TabIndex = 0;
            this.listBoxTarefasIncompletas.SelectedIndexChanged += new System.EventHandler(this.listBoxTarefas_SelectedIndexChanged);
            // 
            // listBoxCompromissos
            // 
            this.listBoxCompromissos.FormattingEnabled = true;
            this.listBoxCompromissos.ItemHeight = 15;
            this.listBoxCompromissos.Location = new System.Drawing.Point(12, 190);
            this.listBoxCompromissos.Name = "listBoxCompromissos";
            this.listBoxCompromissos.Size = new System.Drawing.Size(802, 94);
            this.listBoxCompromissos.TabIndex = 1;
            this.listBoxCompromissos.SelectedIndexChanged += new System.EventHandler(this.listBoxCompromissos_SelectedIndexChanged);
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
            // 
            // buttonItem
            // 
            this.buttonItem.Location = new System.Drawing.Point(12, 76);
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
            this.listBoxTarefasCompletas.Location = new System.Drawing.Point(433, 105);
            this.listBoxTarefasCompletas.Name = "listBoxTarefasCompletas";
            this.listBoxTarefasCompletas.Size = new System.Drawing.Size(381, 79);
            this.listBoxTarefasCompletas.TabIndex = 8;
            this.listBoxTarefasCompletas.SelectedIndexChanged += new System.EventHandler(this.listBoxTarefasCompletas_SelectedIndexChanged);
            // 
            // TelaListagems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 412);
            this.Controls.Add(this.listBoxTarefasCompletas);
            this.Controls.Add(this.comboBoxInserirOpcoes);
            this.Controls.Add(this.buttonItem);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonInserir);
            this.Controls.Add(this.listBoxContatos);
            this.Controls.Add(this.listBoxCompromissos);
            this.Controls.Add(this.listBoxTarefasIncompletas);
            this.Name = "TelaListagems";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTarefasIncompletas;
        private System.Windows.Forms.ListBox listBoxCompromissos;
        private System.Windows.Forms.ListBox listBoxContatos;
        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Button buttonItem;
        private System.Windows.Forms.ComboBox comboBoxInserirOpcoes;
        private System.Windows.Forms.ListBox listBoxTarefasCompletas;
    }
}
