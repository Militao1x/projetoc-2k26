using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Cadastro2
{
    public partial class Form1 : Form
    {
        // ==========================================
        // CAMINHO DO BANCO DE DADOS
        // ==========================================
        string caminhoBanco = @"Data Source=C:\Users\felipe.csilva104\Documents\Cadastro2\contato.db;Version=3;";

        // ==========================================
        //VERIFICAR SE SELECIONOU NA GRID
        // ==========================================
        int codigoselecionado = -1;

        // ==========================================
        //CONTROLA SE ESTA EDITANDO OU NÃO
        // ==========================================
        bool modoEdiao = false;

        public Form1()
        {
            InitializeComponent();
        }

        // ==========================================
        // FORMULÁRIO CARREGADO
        // ==========================================
        private void Form1_Load(object sender, EventArgs e)
        {
            // ==========================================
            // MOSTRAR DATA E HORA
            // ==========================================
            lblHorario.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // ==========================================
            // INICIA O RELOGIO
            // ==========================================
            timerHorario.Start();

            // ==========================================
            // TESTE DE CONEXÃO
            // ==========================================
            try
            {
                using (SQLiteConnection conexao = new SQLiteConnection(caminhoBanco))
                {
                    conexao.Open();
                }

                MessageBox.Show(
                    "CONECTADO AO BANCO DE DADOS!",
                    "Conexão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "ERRO AO CONECTAR AO BANCO DE DADOS:\n\n" + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // RELÓGIO
        // ==========================================
        private void timerHorario_Tick(object sender, EventArgs e)
        {
            lblHorario.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // ==========================================
        // BOTÃO INCLUIR
        // ==========================================
        private void BTNincluir_Click(object sender, EventArgs e)
        {
            // ==========================================
            //CAMPOS OBRIGATORIOS
            // ==========================================
            if (string.IsNullOrWhiteSpace(TXTtelefone.Text))
            {
                MessageBox.Show("O CAMPO TELEFONE DO CONTATO É OBRIGARIO",
                    "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(TXTnomedocliente.Text))
            {
                MessageBox.Show("O CAMPO NOME DO CONTATO É OBRIGARIO",
                    "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(CBXprospect.Text))
            {
                MessageBox.Show("O CAMPO PROSPECT DO CONTATO É OBRIGARIO",
                    "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBXprospect.Focus();
                return;
            }

            // ==========================================
            // VALIDAÇÃO DOS CAMPOS
            // ==========================================

            if (string.IsNullOrWhiteSpace(TXTnomedocliente.Text))
            {
                MessageBox.Show(
                    "Digite o nome do cliente.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                TXTnomedocliente.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TXTtelefone.Text))
            {
                MessageBox.Show(
                    "Digite o telefone do cliente.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                TXTtelefone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(CBXprospect.Text))
            {
                MessageBox.Show(
                    "Selecione o tipo de prospect.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                CBXprospect.Focus();
                return;
            }

            if (chk3Meses.Checked && !chk6Meses.Checked && !chk1Ano.Checked)
            {
                MessageBox.Show("SELECIONE UMA OPÇÃO DE VIP",
                    "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                return;
            }

            // ==========================================
            // DEFINE O LOCAL
            // ==========================================

            string local = "";

            if (chkInterno.Checked && chkExterno.Checked)
            {
                MessageBox.Show(
                    "Selecione apenas um local: Interno ou Externo.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (chkInterno.Checked)
            {
                local = "Interno";
            }
            else if (chkExterno.Checked)
            {
                local = "Externo";
            }
            else
            {
                MessageBox.Show(
                    "Selecione o local: Interno ou Externo.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // ==========================================
            // DEFINE O CLIENTE VIP
            // ==========================================

            int vip = 0;

            int quantidadeVip = 0;

            if (chk3Meses.Checked)
                quantidadeVip++;

            if (chk6Meses.Checked)
                quantidadeVip++;

            if (chk1Ano.Checked)
                quantidadeVip++;

            if (quantidadeVip > 1)
            {
                MessageBox.Show(
                    "Selecione apenas uma opção de Cliente Vip.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (chk3Meses.Checked)
            {
                vip = 3;
            }
            else if (chk6Meses.Checked)
            {
                vip = 6;
            }
            else if (chk1Ano.Checked)
            {
                vip = 12;
            }

            // ==========================================
            // INSERE NO BANCO
            // ==========================================

            try
            {
                using (SQLiteConnection conexao = new SQLiteConnection(caminhoBanco))
                {
                    conexao.Open();

                    string sql = @"
                        INSERT INTO Clientes
                        (
                            NomeCliente,
                            TelefoneCliente,
                            Local,
                            ClienteVip,
                            DataCadastro,
                            PROSPECT
                        )
                        VALUES
                        (
                            @nome,
                            @telefone,
                            @local,
                            @vip,
                            @data,
                            @prospect
                        )";

                    using (SQLiteCommand comando = new SQLiteCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue(
                            "@nome",
                            TXTnomedocliente.Text.Trim()
                        );

                        comando.Parameters.AddWithValue(
                            "@telefone",
                            TXTtelefone.Text.Trim()
                        );

                        comando.Parameters.AddWithValue(
                            "@local",
                            local
                        );

                        comando.Parameters.AddWithValue(
                            "@vip",
                            vip
                        );

                        comando.Parameters.AddWithValue(
                            "@data",
                            DTPdatacadastro.Value.ToString("yyyy-MM-dd")
                        );

                        comando.Parameters.AddWithValue(
                            "@prospect",
                            CBXprospect.Text.Trim()
                        );

                        comando.ExecuteNonQuery();
                    }
                }

                // ==========================================
                // MENSAGEM DE SUCESSO
                // ==========================================

                MessageBox.Show(
                    "CLIENTE CADASTRADO COM SUCESSO!",
                    "Cadastro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimparCampos();
                Consultar();
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "ERRO AO CADASTRAR O CLIENTE:\n\n" + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
               );
            }
        }

        // ==========================================
        // LIMPA OS CAMPOS
        // ==========================================
        private void LimparCampos()
        {
            TXTnomedocliente.Clear();
            TXTtelefone.Clear();

            chkInterno.Checked = true;
            chkExterno.Checked = false;

            chk3Meses.Checked = false;
            chk6Meses.Checked = false;
            chk1Ano.Checked = false;

            CBXprospect.SelectedIndex = 0;

            DTPdatacadastro.Value = DateTime.Now;

            TXTnomedocliente.Focus();
        }

        private void BloquearCampos(bool bloquear)
        {
            //TXTcodigo.ReadOnly = true;

            TXTnomedocliente.ReadOnly = bloquear;
            TXTtelefone.ReadOnly = bloquear;

            DTPdatacadastro.Enabled = !bloquear;

            chkInterno.Enabled = !bloquear;
            chkExterno.Enabled = !bloquear;

            chk1Ano.Enabled = !bloquear;
            chk3Meses.Enabled = !bloquear;
            chk6Meses.Enabled = !bloquear;

            CBXprospect.Enabled = !bloquear;
        }

        // ==========================================
        // METODO CONSULTA
        // ==========================================

        private void Consultar()
        {
            try
            {
                // ==========================================
                //CONECTAR BANCO DE DADOS
                // ==========================================
                SQLiteConnection conexao = new SQLiteConnection(caminhoBanco);

                // ==========================================
                //ABRE BANCO
                // ==========================================
                conexao.Open();

                // ==========================================
                //PREPARA SQL
                // ==========================================
                string sql = "SELECT * FROM Clientes ORDER BY CodigoCliente DESC";

                // ==========================================
                //EXECUTA O SQL E GAURDA OS DADOS
                // ==========================================
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conexao);

                // ==========================================
                // CRIA TABELA EM MEMORIA
                // ==========================================
                DataTable tabela = new DataTable();

                // ==========================================
                //PREENCHE A TABELA COM OS DADOS
                // ==========================================
                adapter.Fill(tabela);

                dataGridView1.DataSource = tabela;

                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "ERRO AO CONSULTAR:\n\n" + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void BTNconsulta_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void TXTtelefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTNsair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BTNexcluir_Click(object sender, EventArgs e)
        {
            if (codigoselecionado == -1)
            {
                MessageBox.Show("SELECIONE UM CONTATO PARA EXCLUIR");
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "DESEJA REALMENTE EXCLUIR O CONTATO?",
                "CONFIRMAR EXCLUSÃO",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (resposta == DialogResult.No)
                return;

            // ==========================================
            //EXCLUINDO CONTATO
            // ==========================================
            try
            {
                using (SQLiteConnection conexao = new SQLiteConnection(caminhoBanco))
                {
                    conexao.Open();

                    string sql = "DELETE FROM Clientes WHERE CodigoCliente = @codigo";

                    using (SQLiteCommand comando = new SQLiteCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@codigo", codigoselecionado);
                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "CONTATO EXCLUÍDO COM SUCESSO!",
                    "Exclusão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                codigoselecionado = -1;
                LimparCampos();
                Consultar();
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "ERRO AO EXCLUIR O CONTATO:\n\n" + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        // ==========================================
        //VERIFICA SE A LINHA É VALIDA
        // ==========================================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // ==========================================
            //PEGANDO A LINHA SELECIONADA
            // ==========================================
            DataGridViewRow linha = dataGridView1.Rows[e.RowIndex];

            // ==========================================
            //CARREGA OS CAMPOS DO CADASTRO SELECIONADO
            // ==========================================
            codigoselecionado = Convert.ToInt32(linha.Cells["CodigoCliente"].Value);
            TXTcodigo.Text = codigoselecionado.ToString();
            TXTnomedocliente.Text = linha.Cells["NomeCliente"].Value.ToString();
            TXTtelefone.Text = linha.Cells["TelefoneCliente"].Value.ToString();

            DTPdatacadastro.Value = Convert.ToDateTime(linha.Cells["DataCadastro"].Value);

            string local = linha.Cells["Local"].Value.ToString();
            chkInterno.Checked = (local == "Interno");
            chkExterno.Checked = (local == "Externo");

            int vip = Convert.ToInt32(linha.Cells["ClienteVip"].Value.ToString());
            chk3Meses.Checked = (vip == 3);
            chk6Meses.Checked = (vip == 6);
            chk1Ano.Checked = (vip == 12);

            CBXprospect.Text = linha.Cells["PROSPECT"].Value.ToString();

            BloquearCampos(true);

        }

        // ==========================================
        //EDITAR
        // ==========================================

        private void BTNeditar_Click(object sender, EventArgs e)
        {
            if(modoEdiao == false)
            {
                if (codigoselecionado == -1)
                {
                    MessageBox.Show("SELECIONE O CONTATO PARA EDITAR");
                    return;
                }

                BTNeditar.Text = "Salvar";
                BTNexcluir.Text = "Cancelar";

                BloquearCampos (false);

                modoEdiao = true;
                return;
            }

            string local = "";

            if (chkInterno.Checked && chkExterno.Checked)
            {
                MessageBox.Show(
                    "Selecione apenas um local: Interno ou Externo.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (chkInterno.Checked)
            {
                local = "Interno";
            }
            else if (chkExterno.Checked)
            {
                local = "Externo";
            }
            else
            {
                MessageBox.Show(
                    "Selecione o local: Interno ou Externo.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // ==========================================
            // DEFINE O CLIENTE VIP DO EDITAR
            // ==========================================

            int vip = 0;

            int quantidadeVip = 0;

            if (chk3Meses.Checked)
                quantidadeVip++;

            if (chk6Meses.Checked)
                quantidadeVip++;

            if (chk1Ano.Checked)
                quantidadeVip++;

            if (quantidadeVip > 1)
            {
                MessageBox.Show(
                    "Selecione apenas uma opção de Cliente Vip.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (chk3Meses.Checked)
            {
                vip = 3;
            }
            else if (chk6Meses.Checked)
            {
                vip = 6;
            }
            else if (chk1Ano.Checked)
            {
                vip = 12;
            }

            try
            {
                using (SQLiteConnection conexao = new SQLiteConnection(caminhoBanco))
                {
                    conexao.Open();

                    string sql = @"UPDATE Clientes SET
                                   NomeCliente = @nome,
                                   Local = @local,
                                   TelefoneCliente = @telefone,
                                   ClienteVip = @vip,
                                   DataCadastro = @data,
                                   PROSPECT = @prospect
                                   WHERE CodigoCliente = @codigo"; 

                    using (SQLiteCommand comando = new SQLiteCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue(
                            "@nome",
                            TXTnomedocliente.Text.Trim()
                        );

                        comando.Parameters.AddWithValue(
                            "@telefone",
                            TXTtelefone.Text.Trim()
                        );

                        comando.Parameters.AddWithValue(
                            "@local",
                            local
                        );

                        comando.Parameters.AddWithValue(
                            "@vip",
                            vip
                        );

                        comando.Parameters.AddWithValue(
                            "@data",
                            DTPdatacadastro.Value.ToString("yyyy-MM-dd")
                        );

                        comando.Parameters.AddWithValue(
                            "@prospect",
                            CBXprospect.Text.Trim()
                        );

                        comando.Parameters.AddWithValue(
                            "@codigo", TXTcodigo.Text.Trim());

                        comando.ExecuteNonQuery();
                    }
                }

                // ==========================================
                // MENSAGEM DE SUCESSO DO EDITAR
                // ==========================================

                MessageBox.Show(
                    "CLIENTE ALTERADO COM SUCESSO!",
                    "Cadastro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // ==========================================
                // ATUALIZAR O EDITAR
                // ==========================================

                Consultar();

                BTNeditar.Text = "Editar";
                BTNexcluir.Text = "Excluir";

                TXTnomedocliente.Clear();
                TXTtelefone.Clear();

                chkInterno.Checked = true;
                chkExterno.Checked = false;

                chk3Meses.Checked = false;
                chk6Meses.Checked = false;
                chk1Ano.Checked = false;

                CBXprospect.SelectedIndex = 0;

                DTPdatacadastro.Value = DateTime.Now;

                TXTnomedocliente.Focus();

                // ==========================================
                // BLOQUEAR BOTÕES NA GRIP
                // ==========================================


            }
            catch (Exception erro)
            {
                MessageBox.Show("ERRO AO EDITAR: " + erro.Message);
            }
        }


        // ==========================================
        // BLOQUEAR CAMPOS
        // ==========================================

        private void chk3Meses_MouseClick(object sender, MouseEventArgs e)
        {
            if (chk3Meses.Checked == true)

            {
                chk6Meses.Checked = false;
                chk1Ano.Checked = false;
            }
        }

        private void chk6Meses_MouseClick(object sender, MouseEventArgs e)
        {
            if (chk6Meses.Checked == true)

            {
                chk3Meses.Checked = false;
                chk1Ano.Checked = false;
            }
        }

        private void chk1Ano_MouseClick(object sender, MouseEventArgs e)
        {
            if (chk1Ano.Checked == true)

            {
                chk6Meses.Checked = false;
                chk3Meses.Checked = false;
            }
        }

        private void chkInterno_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkInterno.Checked == true)
            {
                chkExterno.Checked = false;
            }
        }

        private void chkExterno_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExterno.Checked == true)
            {
                chkInterno.Checked = false;
            }
        }
    }
}