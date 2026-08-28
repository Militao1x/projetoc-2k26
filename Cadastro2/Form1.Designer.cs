namespace Cadastro2
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CDTROclientes = new System.Windows.Forms.Label();
            this.LBLcodigo = new System.Windows.Forms.Label();
            this.LBLnomedocliente = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LBLtelefone = new System.Windows.Forms.Label();
            this.BTNincluir = new System.Windows.Forms.Button();
            this.BTNeditar = new System.Windows.Forms.Button();
            this.BTNconsulta = new System.Windows.Forms.Button();
            this.BTNexcluir = new System.Windows.Forms.Button();
            this.BTNsair = new System.Windows.Forms.Button();
            this.GBXlocal = new System.Windows.Forms.GroupBox();
            this.chkExterno = new System.Windows.Forms.CheckBox();
            this.chkInterno = new System.Windows.Forms.CheckBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.GBXprospect = new System.Windows.Forms.GroupBox();
            this.CBXprospect = new System.Windows.Forms.ComboBox();
            this.GBXclientevip = new System.Windows.Forms.GroupBox();
            this.chk6Meses = new System.Windows.Forms.CheckBox();
            this.chk1Ano = new System.Windows.Forms.CheckBox();
            this.chk3Meses = new System.Windows.Forms.CheckBox();
            this.GBXdatacadastro = new System.Windows.Forms.GroupBox();
            this.DTPdatacadastro = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TXTcodigo = new System.Windows.Forms.TextBox();
            this.TXTnomedocliente = new System.Windows.Forms.TextBox();
            this.TXTtelefone = new System.Windows.Forms.TextBox();
            this.PBXfotoperfil = new System.Windows.Forms.PictureBox();
            this.timerHorario = new System.Windows.Forms.Timer(this.components);
            this.lblHorario = new System.Windows.Forms.Label();
            this.GBXlocal.SuspendLayout();
            this.GBXprospect.SuspendLayout();
            this.GBXclientevip.SuspendLayout();
            this.GBXdatacadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBXfotoperfil)).BeginInit();
            this.SuspendLayout();
            // 
            // CDTROclientes
            // 
            this.CDTROclientes.AutoSize = true;
            this.CDTROclientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CDTROclientes.Location = new System.Drawing.Point(0, 0);
            this.CDTROclientes.Name = "CDTROclientes";
            this.CDTROclientes.Size = new System.Drawing.Size(233, 25);
            this.CDTROclientes.TabIndex = 0;
            this.CDTROclientes.Text = "Cadastro de Clientes";
            // 
            // LBLcodigo
            // 
            this.LBLcodigo.AutoSize = true;
            this.LBLcodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLcodigo.Location = new System.Drawing.Point(16, 38);
            this.LBLcodigo.Name = "LBLcodigo";
            this.LBLcodigo.Size = new System.Drawing.Size(57, 16);
            this.LBLcodigo.TabIndex = 0;
            this.LBLcodigo.Text = "Codigo";
            // 
            // LBLnomedocliente
            // 
            this.LBLnomedocliente.AutoSize = true;
            this.LBLnomedocliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLnomedocliente.Location = new System.Drawing.Point(12, 89);
            this.LBLnomedocliente.Name = "LBLnomedocliente";
            this.LBLnomedocliente.Size = new System.Drawing.Size(122, 16);
            this.LBLnomedocliente.TabIndex = 0;
            this.LBLnomedocliente.Text = "Nome do Cliente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 0;
            // 
            // LBLtelefone
            // 
            this.LBLtelefone.AutoSize = true;
            this.LBLtelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLtelefone.Location = new System.Drawing.Point(164, 137);
            this.LBLtelefone.Name = "LBLtelefone";
            this.LBLtelefone.Size = new System.Drawing.Size(69, 16);
            this.LBLtelefone.TabIndex = 0;
            this.LBLtelefone.Text = "Telefone";
            // 
            // BTNincluir
            // 
            this.BTNincluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNincluir.Location = new System.Drawing.Point(213, 247);
            this.BTNincluir.Name = "BTNincluir";
            this.BTNincluir.Size = new System.Drawing.Size(75, 23);
            this.BTNincluir.TabIndex = 10;
            this.BTNincluir.Text = "Incluir";
            this.BTNincluir.UseVisualStyleBackColor = true;
            this.BTNincluir.Click += new System.EventHandler(this.BTNincluir_Click);
            // 
            // BTNeditar
            // 
            this.BTNeditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNeditar.Location = new System.Drawing.Point(312, 247);
            this.BTNeditar.Name = "BTNeditar";
            this.BTNeditar.Size = new System.Drawing.Size(75, 23);
            this.BTNeditar.TabIndex = 11;
            this.BTNeditar.Text = "Editar";
            this.BTNeditar.UseVisualStyleBackColor = true;
            this.BTNeditar.Click += new System.EventHandler(this.BTNeditar_Click);
            // 
            // BTNconsulta
            // 
            this.BTNconsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNconsulta.Location = new System.Drawing.Point(407, 247);
            this.BTNconsulta.Name = "BTNconsulta";
            this.BTNconsulta.Size = new System.Drawing.Size(75, 23);
            this.BTNconsulta.TabIndex = 12;
            this.BTNconsulta.Text = "Consultar";
            this.BTNconsulta.UseVisualStyleBackColor = true;
            this.BTNconsulta.Click += new System.EventHandler(this.BTNconsulta_Click);
            // 
            // BTNexcluir
            // 
            this.BTNexcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNexcluir.Location = new System.Drawing.Point(502, 247);
            this.BTNexcluir.Name = "BTNexcluir";
            this.BTNexcluir.Size = new System.Drawing.Size(75, 23);
            this.BTNexcluir.TabIndex = 13;
            this.BTNexcluir.Text = "Excluir";
            this.BTNexcluir.UseVisualStyleBackColor = true;
            this.BTNexcluir.Click += new System.EventHandler(this.BTNexcluir_Click);
            // 
            // BTNsair
            // 
            this.BTNsair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNsair.Location = new System.Drawing.Point(600, 247);
            this.BTNsair.Name = "BTNsair";
            this.BTNsair.Size = new System.Drawing.Size(75, 23);
            this.BTNsair.TabIndex = 14;
            this.BTNsair.Text = "Sair";
            this.BTNsair.UseVisualStyleBackColor = true;
            this.BTNsair.Click += new System.EventHandler(this.BTNsair_Click);
            // 
            // GBXlocal
            // 
            this.GBXlocal.Controls.Add(this.chkExterno);
            this.GBXlocal.Controls.Add(this.chkInterno);
            this.GBXlocal.Controls.Add(this.radioButton4);
            this.GBXlocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBXlocal.Location = new System.Drawing.Point(305, 38);
            this.GBXlocal.Name = "GBXlocal";
            this.GBXlocal.Size = new System.Drawing.Size(177, 75);
            this.GBXlocal.TabIndex = 2;
            this.GBXlocal.TabStop = false;
            this.GBXlocal.Text = "Local";
            // 
            // chkExterno
            // 
            this.chkExterno.AutoSize = true;
            this.chkExterno.Location = new System.Drawing.Point(6, 47);
            this.chkExterno.Name = "chkExterno";
            this.chkExterno.Size = new System.Drawing.Size(78, 20);
            this.chkExterno.TabIndex = 1;
            this.chkExterno.Text = "Externo";
            this.chkExterno.UseVisualStyleBackColor = true;
            this.chkExterno.CheckedChanged += new System.EventHandler(this.chkExterno_CheckedChanged);
            // 
            // chkInterno
            // 
            this.chkInterno.AutoSize = true;
            this.chkInterno.Location = new System.Drawing.Point(7, 22);
            this.chkInterno.Name = "chkInterno";
            this.chkInterno.Size = new System.Drawing.Size(73, 20);
            this.chkInterno.TabIndex = 1;
            this.chkInterno.Text = "Interno";
            this.chkInterno.UseVisualStyleBackColor = true;
            this.chkInterno.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkInterno_MouseClick);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(241, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(72, 20);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Interno";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // GBXprospect
            // 
            this.GBXprospect.Controls.Add(this.CBXprospect);
            this.GBXprospect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBXprospect.Location = new System.Drawing.Point(305, 137);
            this.GBXprospect.Name = "GBXprospect";
            this.GBXprospect.Size = new System.Drawing.Size(197, 58);
            this.GBXprospect.TabIndex = 3;
            this.GBXprospect.TabStop = false;
            this.GBXprospect.Text = "Prospect";
            // 
            // CBXprospect
            // 
            this.CBXprospect.FormattingEnabled = true;
            this.CBXprospect.Items.AddRange(new object[] {
            "SIM",
            "NÂO"});
            this.CBXprospect.Location = new System.Drawing.Point(7, 20);
            this.CBXprospect.Name = "CBXprospect";
            this.CBXprospect.Size = new System.Drawing.Size(121, 24);
            this.CBXprospect.TabIndex = 5;
            // 
            // GBXclientevip
            // 
            this.GBXclientevip.Controls.Add(this.chk6Meses);
            this.GBXclientevip.Controls.Add(this.chk1Ano);
            this.GBXclientevip.Controls.Add(this.chk3Meses);
            this.GBXclientevip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBXclientevip.Location = new System.Drawing.Point(527, 38);
            this.GBXclientevip.Name = "GBXclientevip";
            this.GBXclientevip.Size = new System.Drawing.Size(235, 75);
            this.GBXclientevip.TabIndex = 4;
            this.GBXclientevip.TabStop = false;
            this.GBXclientevip.Text = "Cliente Vip";
            // 
            // chk6Meses
            // 
            this.chk6Meses.AutoSize = true;
            this.chk6Meses.Location = new System.Drawing.Point(7, 47);
            this.chk6Meses.Name = "chk6Meses";
            this.chk6Meses.Size = new System.Drawing.Size(84, 20);
            this.chk6Meses.TabIndex = 1;
            this.chk6Meses.Text = "6 Meses";
            this.chk6Meses.UseVisualStyleBackColor = true;
            this.chk6Meses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chk6Meses_MouseClick);
            // 
            // chk1Ano
            // 
            this.chk1Ano.AutoSize = true;
            this.chk1Ano.Location = new System.Drawing.Point(115, 19);
            this.chk1Ano.Name = "chk1Ano";
            this.chk1Ano.Size = new System.Drawing.Size(65, 20);
            this.chk1Ano.TabIndex = 1;
            this.chk1Ano.Text = "1 Ano";
            this.chk1Ano.UseVisualStyleBackColor = true;
            this.chk1Ano.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chk1Ano_MouseClick);
            // 
            // chk3Meses
            // 
            this.chk3Meses.AutoSize = true;
            this.chk3Meses.Location = new System.Drawing.Point(8, 22);
            this.chk3Meses.Name = "chk3Meses";
            this.chk3Meses.Size = new System.Drawing.Size(84, 20);
            this.chk3Meses.TabIndex = 1;
            this.chk3Meses.Text = "3 Meses";
            this.chk3Meses.UseVisualStyleBackColor = true;
            this.chk3Meses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chk3Meses_MouseClick);
            // 
            // GBXdatacadastro
            // 
            this.GBXdatacadastro.Controls.Add(this.DTPdatacadastro);
            this.GBXdatacadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBXdatacadastro.Location = new System.Drawing.Point(527, 137);
            this.GBXdatacadastro.Name = "GBXdatacadastro";
            this.GBXdatacadastro.Size = new System.Drawing.Size(261, 58);
            this.GBXdatacadastro.TabIndex = 5;
            this.GBXdatacadastro.TabStop = false;
            this.GBXdatacadastro.Text = "Data de Cadastro";
            // 
            // DTPdatacadastro
            // 
            this.DTPdatacadastro.Location = new System.Drawing.Point(7, 20);
            this.DTPdatacadastro.Name = "DTPdatacadastro";
            this.DTPdatacadastro.Size = new System.Drawing.Size(248, 22);
            this.DTPdatacadastro.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 288);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(743, 150);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // TXTcodigo
            // 
            this.TXTcodigo.Enabled = false;
            this.TXTcodigo.Location = new System.Drawing.Point(19, 54);
            this.TXTcodigo.Name = "TXTcodigo";
            this.TXTcodigo.Size = new System.Drawing.Size(100, 20);
            this.TXTcodigo.TabIndex = 7;
            // 
            // TXTnomedocliente
            // 
            this.TXTnomedocliente.Location = new System.Drawing.Point(19, 105);
            this.TXTnomedocliente.Name = "TXTnomedocliente";
            this.TXTnomedocliente.Size = new System.Drawing.Size(246, 20);
            this.TXTnomedocliente.TabIndex = 1;
            // 
            // TXTtelefone
            // 
            this.TXTtelefone.Location = new System.Drawing.Point(154, 161);
            this.TXTtelefone.Name = "TXTtelefone";
            this.TXTtelefone.Size = new System.Drawing.Size(145, 20);
            this.TXTtelefone.TabIndex = 2;
            this.TXTtelefone.TextChanged += new System.EventHandler(this.TXTtelefone_TextChanged);
            // 
            // PBXfotoperfil
            // 
            this.PBXfotoperfil.ErrorImage = null;
            this.PBXfotoperfil.Image = global::Cadastro2.Properties.Resources.trabalho;
            this.PBXfotoperfil.Location = new System.Drawing.Point(19, 137);
            this.PBXfotoperfil.Name = "PBXfotoperfil";
            this.PBXfotoperfil.Size = new System.Drawing.Size(121, 133);
            this.PBXfotoperfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBXfotoperfil.TabIndex = 8;
            this.PBXfotoperfil.TabStop = false;
            // 
            // timerHorario
            // 
            this.timerHorario.Enabled = true;
            this.timerHorario.Interval = 1000;
            this.timerHorario.Tick += new System.EventHandler(this.timerHorario_Tick);
            // 
            // lblHorario
            // 
            this.lblHorario.AutoSize = true;
            this.lblHorario.Location = new System.Drawing.Point(672, 455);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(0, 13);
            this.lblHorario.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 477);
            this.Controls.Add(this.lblHorario);
            this.Controls.Add(this.PBXfotoperfil);
            this.Controls.Add(this.TXTtelefone);
            this.Controls.Add(this.TXTnomedocliente);
            this.Controls.Add(this.TXTcodigo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.GBXdatacadastro);
            this.Controls.Add(this.GBXclientevip);
            this.Controls.Add(this.GBXprospect);
            this.Controls.Add(this.GBXlocal);
            this.Controls.Add(this.BTNsair);
            this.Controls.Add(this.BTNexcluir);
            this.Controls.Add(this.BTNconsulta);
            this.Controls.Add(this.BTNeditar);
            this.Controls.Add(this.BTNincluir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LBLtelefone);
            this.Controls.Add(this.LBLnomedocliente);
            this.Controls.Add(this.LBLcodigo);
            this.Controls.Add(this.CDTROclientes);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GBXlocal.ResumeLayout(false);
            this.GBXlocal.PerformLayout();
            this.GBXprospect.ResumeLayout(false);
            this.GBXclientevip.ResumeLayout(false);
            this.GBXclientevip.PerformLayout();
            this.GBXdatacadastro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBXfotoperfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CDTROclientes;
        private System.Windows.Forms.Label LBLcodigo;
        private System.Windows.Forms.Label LBLnomedocliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LBLtelefone;
        private System.Windows.Forms.Button BTNincluir;
        private System.Windows.Forms.Button BTNeditar;
        private System.Windows.Forms.Button BTNconsulta;
        private System.Windows.Forms.Button BTNexcluir;
        private System.Windows.Forms.Button BTNsair;
        private System.Windows.Forms.GroupBox GBXlocal;
        private System.Windows.Forms.GroupBox GBXprospect;
        private System.Windows.Forms.GroupBox GBXclientevip;
        private System.Windows.Forms.GroupBox GBXdatacadastro;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.ComboBox CBXprospect;
        private System.Windows.Forms.DateTimePicker DTPdatacadastro;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox TXTcodigo;
        private System.Windows.Forms.TextBox TXTnomedocliente;
        private System.Windows.Forms.TextBox TXTtelefone;
        private System.Windows.Forms.PictureBox PBXfotoperfil;
        private System.Windows.Forms.Timer timerHorario;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.CheckBox chkExterno;
        private System.Windows.Forms.CheckBox chkInterno;
        private System.Windows.Forms.CheckBox chk6Meses;
        private System.Windows.Forms.CheckBox chk1Ano;
        private System.Windows.Forms.CheckBox chk3Meses;
    }
}

