using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Cadastro2
{
    public partial class Form1 : Form
    {
        // ==========================================
        // CAMINHO DO BANCO DE DADOS
        // ==========================================

        string caminhoBanco =
            @"Data Source=C:\Users\felipe.csilva104\Documents\Cadastro2\Cadastro2\contato.db;Version=3;";

        // ==========================================
        // CONTROLA O CÓDIGO SELECIONADO NA GRID
        // ==========================================

        int codigoselecionado = -1;

        // ==========================================
        // CONTROLA SE ESTÁ EDITANDO
        // ==========================================

        bool modoEdiao = false;

        // ==========================================
        // FORMULÁRIO
        // ==========================================

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
            // DATA E HORA
            // ==========================================

            lblHorario.Text =
                DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // ==========================================
            // INICIA RELÓGIO
            // ==========================================

            timerHorario.Start();

            // ==========================================
            // ESTADO INICIAL
            // ==========================================

            modoEdiao = false;
            codigoselecionado = -1;

            BTNeditar.Text = "Editar";
            BTNexcluir.Text = "Excluir";

            // ==========================================
            // LIMPA CAMPOS
            // ==========================================

            LimparCampos();

            // ==========================================
            // TESTE DE CONEXÃO
            // ==========================================

            try
            {
                using (SQLiteConnection conexao =
                       new SQLiteConnection(caminhoBanco))
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
                    "ERRO AO CONECTAR AO BANCO DE DADOS:\n\n" +
                    erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // RELÓGIO
        // ==========================================

        private void timerHorario_Tick(
            object sender,
            EventArgs e)
        {
            lblHorario.Text =
                DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // ==========================================
        // BOTÃO INCLUIR
        // ==========================================

        private void BTNincluir_Click(
            object sender,
            EventArgs e)
        {
            // ==========================================
            // VALIDA NOME
            // ==========================================

            if (string.IsNullOrWhiteSpace(
                TXTnomedocliente.Text))
            {
                MessageBox.Show(
                    "O CAMPO NOME DO CONTATO É OBRIGATÓRIO.",
                    "ATENÇÃO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                TXTnomedocliente.Focus();
                return;
            }

            // ==========================================
            // VALIDA TELEFONE
            // ==========================================

            if (string.IsNullOrWhiteSpace(
                TXTtelefone.Text))
            {
                MessageBox.Show(
                    "O CAMPO TELEFONE DO CONTATO É OBRIGATÓRIO.",
                    "ATENÇÃO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                TXTtelefone.Focus();
                return;
            }

            // ==========================================
            // VALIDA TELEFONE COM 10 DIGITOS
            // ==========================================
            string telefone = TXTtelefone.Text.Trim();
            if (telefone.Length != 10)
            {
                MessageBox.Show(
                    "O TELEFONE DEVE POSSUIR SOMENTE 10 DIGITOS.",
                    "ATENÇÃO",
                    MessageBoxButtons.OK,
                MessageBoxIcon.Warning
                );

                TXTtelefone.Focus();
                return;
                    
            }

            // ==========================================
            // VALIDA PROSPECT
            // ==========================================

            if (string.IsNullOrWhiteSpace(
                CBXprospect.Text))
            {
                MessageBox.Show(
                    "O CAMPO PROSPECT DO CONTATO É OBRIGATÓRIO.",
                    "ATENÇÃO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                CBXprospect.Focus();
                return;
            }

            // ==========================================
            // DEFINE LOCAL
            // ==========================================

            string local = ObterLocal();

            if (local == "")
            {
                return;
            }

            // ==========================================
            // DEFINE VIP
            // ==========================================

            int vip = ObterVip();

            if (vip == 0)
            {
                return;
            }

            // ==========================================
            // CADASTRA NO BANCO
            // ==========================================

            try
            {
                using (SQLiteConnection conexao =
                       new SQLiteConnection(caminhoBanco))
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

                    using (SQLiteCommand comando =
                           new SQLiteCommand(sql, conexao))
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
                            DTPdatacadastro.Value
                                .ToString("yyyy-MM-dd")
                        );

                        comando.Parameters.AddWithValue(
                            "@prospect",
                            CBXprospect.Text.Trim()
                        );

                        comando.ExecuteNonQuery();
                    }
                }

                // ==========================================
                // SUCESSO
                // ==========================================

                MessageBox.Show(
                    "CLIENTE CADASTRADO COM SUCESSO!",
                    "Cadastro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // ==========================================
                // ATUALIZA GRID
                // ==========================================

                dataGridView1.DataSource = null;

                // ==========================================
                // LIMPA
                // ==========================================

                LimparCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "ERRO AO CADASTRAR O CLIENTE:\n\n" +
                    erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // OBTER LOCAL
        // ==========================================

        private string ObterLocal()
        {
            if (chkInterno.Checked &&
                chkExterno.Checked)
            {
                MessageBox.Show(
                    "SELECIONE APENAS UM LOCAL: INTERNO OU EXTERNO.",
                    "ATENÇÃO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return "";
            }

            if (chkInterno.Checked)
            {
                return "Interno";
            }

            if (chkExterno.Checked)
            {
                return "Externo";
            }

            MessageBox.Show(
                "SELECIONE O LOCAL: INTERNO OU EXTERNO.",
                "ATENÇÃO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return "";
        }

        // ==========================================
        // OBTER VIP
        // ==========================================

        private int ObterVip()
        {
            int quantidadeVip = 0;
            int vip = 0;

            // ==========================================
            // 3 MESES
            // ==========================================

            if (chk3Meses.Checked)
            {
                quantidadeVip++;
                vip = 3;
            }

            // ==========================================
            // 6 MESES
            // ==========================================

            if (chk6Meses.Checked)
            {
                quantidadeVip++;
                vip = 6;
            }

            // ==========================================
            // 1 ANO
            // ==========================================

            if (chk1Ano.Checked)
            {
                quantidadeVip++;
                vip = 12;
            }

            // ==========================================
            // NENHUM VIP
            // ==========================================

            if (quantidadeVip == 0)
            {
                MessageBox.Show(
                    "SELECIONE UMA OPÇÃO DE VIP.",
                    "ATENÇÃO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return 0;
            }

            // ==========================================
            // MAIS DE UM VIP
            // ==========================================

            if (quantidadeVip > 1)
            {
                MessageBox.Show(
                    "SELECIONE APENAS UMA OPÇÃO DE CLIENTE VIP.",
                    "ATENÇÃO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return 0;
            }

            return vip;
        }

        // ==========================================
        // LIMPAR CAMPOS
        // ==========================================

        private void LimparCampos()
        {
            // ==========================================
            // TEXTBOX
            // ==========================================

            TXTcodigo.Clear();
            TXTnomedocliente.Clear();
            TXTtelefone.Clear();

            // ==========================================
            // LOCAL
            // ==========================================

            chkInterno.Checked = true;
            chkExterno.Checked = false;

            // ==========================================
            // VIP
            // ==========================================

            chk3Meses.Checked = false;
            chk6Meses.Checked = false;
            chk1Ano.Checked = false;

            // ==========================================
            // PROSPECT
            // ==========================================

            if (CBXprospect.Items.Count > 0)
            {
                CBXprospect.SelectedIndex = 0;
            }
            else
            {
                CBXprospect.Text = "";
            }

            // ==========================================
            // DATA
            // ==========================================

            DTPdatacadastro.Value = DateTime.Now;

            // ==========================================
            // CONTROLE
            // ==========================================

            modoEdiao = false;
            codigoselecionado = -1;

            // ==========================================
            // BOTÕES
            // ==========================================

            BTNeditar.Text = "Editar";
            BTNexcluir.Text = "Excluir";

            // ==========================================
            // CAMPOS
            // ==========================================

            BloquearCampos(false);

            // ==========================================
            // BOTÕES PRINCIPAIS
            // ==========================================

            BloquearBotoes(false);

            // ==========================================
            // FOCO
            // ==========================================

            TXTnomedocliente.Focus();
        }

        // ==========================================
        // BLOQUEAR / LIBERAR CAMPOS
        // ==========================================

        private void BloquearCampos(bool bloquear)
        {
            TXTnomedocliente.ReadOnly = bloquear;
            TXTtelefone.ReadOnly = bloquear;

            DTPdatacadastro.Enabled = !bloquear;

            chkInterno.Enabled = !bloquear;
            chkExterno.Enabled = !bloquear;

            chk3Meses.Enabled = !bloquear;
            chk6Meses.Enabled = !bloquear;
            chk1Ano.Enabled = !bloquear;

            CBXprospect.Enabled = !bloquear;
        }

        // ==========================================
        // BLOQUEAR / LIBERAR BOTÕES
        // ==========================================

        private void BloquearBotoes(bool bloquear)
        {
            // ==========================================
            // BOTÕES QUE FICAM BLOQUEADOS NA EDIÇÃO
            // ==========================================

            BTNincluir.Enabled = !bloquear;
            BTNconsulta.Enabled = !bloquear;
            BTNsair.Enabled = !bloquear;
        }

        // ==========================================
        // CONSULTAR
        // ==========================================

        private void Consultar()
        {
            try
            {
                using (SQLiteConnection conexao =
                       new SQLiteConnection(caminhoBanco))
                {
                    conexao.Open();

                    string sql =
                        "SELECT * FROM Clientes " +
                        "ORDER BY CodigoCliente DESC";

                    using (SQLiteDataAdapter adapter =
                           new SQLiteDataAdapter(sql, conexao))
                    {
                        DataTable tabela =
                            new DataTable();

                        adapter.Fill(tabela);

                        dataGridView1.DataSource =
                            tabela;
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "ERRO AO CONSULTAR:\n\n" +
                    erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // BOTÃO CONSULTAR
        // ==========================================

        private void BTNconsulta_Click(
            object sender,
            EventArgs e)
        {
            Consultar();
        }

        // ==========================================
        // TELEFONE
        // ==========================================

        private void TXTtelefone_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        // ==========================================
        // BOTÃO SAIR
        // ==========================================

        private void BTNsair_Click(
            object sender,
            EventArgs e)
        {
            Application.Exit();
        }

        // ==========================================
        // BOTÃO EDITAR / SALVAR
        // ==========================================

        private void BTNeditar_Click(
            object sender,
            EventArgs e)
        {
            // ==========================================
            // ENTRAR NO MODO EDITAR
            // ==========================================

            if (!modoEdiao)
            {
                if (codigoselecionado == -1)
                {
                    MessageBox.Show(
                        "SELECIONE UM CONTATO PARA EDITAR.",
                        "ATENÇÃO",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // ==========================================
                // ATIVA MODO EDIÇÃO
                // ==========================================

                modoEdiao = true;

                // ==========================================
                // ALTERA TEXTO DOS BOTÕES
                // ==========================================

                BTNeditar.Text = "Salvar";
                BTNexcluir.Text = "Cancelar";

                // ==========================================
                // LIBERA CAMPOS
                // ==========================================

                BloquearCampos(false);

                // ==========================================
                // BLOQUEIA INCLUIR / CONSULTAR / SAIR
                // ==========================================

                BloquearBotoes(true);

                return;
            }

            // ==========================================
            // VALIDA NOME
            // ==========================================

            if (string.IsNullOrWhiteSpace(
                TXTnomedocliente.Text))
            {
                MessageBox.Show(
                    "DIGITE O NOME DO CLIENTE.",
                    "ATENÇÃO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                TXTnomedocliente.Focus();
                return;
            }

            // ==========================================
            // VALIDA TELEFONE
            // ==========================================

            if (string.IsNullOrWhiteSpace(
                TXTtelefone.Text))
            {
                MessageBox.Show(
                    "DIGITE O TELEFONE DO CLIENTE.",
                    "ATENÇÃO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                TXTtelefone.Focus();
                return;
            }

            // ==========================================
            // DEFINE LOCAL
            // ==========================================

            string local = ObterLocal();

            if (local == "")
            {
                return;
            }

            // ==========================================
            // DEFINE VIP
            // ==========================================

            int vip = ObterVip();

            if (vip == 0)
            {
                return;
            }

            // ==========================================
            // ATUALIZA BANCO
            // ==========================================

            try
            {
                using (SQLiteConnection conexao =
                       new SQLiteConnection(caminhoBanco))
                {
                    conexao.Open();

                    string sql = @"
                        UPDATE Clientes SET
                            NomeCliente = @nome,
                            TelefoneCliente = @telefone,
                            Local = @local,
                            ClienteVip = @vip,
                            DataCadastro = @data,
                            PROSPECT = @prospect
                        WHERE CodigoCliente = @codigo";

                    using (SQLiteCommand comando =
                           new SQLiteCommand(sql, conexao))
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
                            DTPdatacadastro.Value
                                .ToString("yyyy-MM-dd")
                        );

                        comando.Parameters.AddWithValue(
                            "@prospect",
                            CBXprospect.Text.Trim()
                        );

                        comando.Parameters.AddWithValue(
                            "@codigo",
                            codigoselecionado
                        );

                        comando.ExecuteNonQuery();
                    }
                }

                // ==========================================
                // SUCESSO
                // ==========================================

                MessageBox.Show(
                    "CLIENTE ALTERADO COM SUCESSO!",
                    "Cadastro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // ==========================================
                // LIMPA E RESTAURA FORMULÁRIO
                // ==========================================

                dataGridView1.DataSource = null;
                LimparCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "ERRO AO EDITAR:\n\n" +
                    erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // BOTÃO EXCLUIR / CANCELAR
        // ==========================================

        private void BTNexcluir_Click(
            object sender,
            EventArgs e)
        {
            // ==========================================
            // SE ESTÁ EDITANDO = CANCELAR
            // ==========================================

            if (modoEdiao)
            {
                DialogResult resposta =
                    MessageBox.Show(
                        "DESEJA CANCELAR A EDIÇÃO?",
                        "CANCELAR",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if (resposta == DialogResult.Yes)
                {
                    LimparCampos();
                    Consultar();
                }

                return;
            }

            // ==========================================
            // VERIFICA SE TEM CLIENTE SELECIONADO
            // ==========================================

            if (codigoselecionado == -1)
            {
                MessageBox.Show(
                    "SELECIONE UM CONTATO PARA EXCLUIR.",
                    "ATENÇÃO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // ==========================================
            // CONFIRMA EXCLUSÃO
            // ==========================================

            DialogResult respostaExcluir =
                MessageBox.Show(
                    "DESEJA REALMENTE EXCLUIR O CONTATO?",
                    "CONFIRMAR EXCLUSÃO",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (respostaExcluir == DialogResult.No)
            {
                return;
            }

            // ==========================================
            // EXCLUI DO BANCO
            // ==========================================

            try
            {
                using (SQLiteConnection conexao =
                       new SQLiteConnection(caminhoBanco))
                {
                    conexao.Open();

                    string sql =
                        "DELETE FROM Clientes " +
                        "WHERE CodigoCliente = @codigo";

                    using (SQLiteCommand comando =
                           new SQLiteCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue(
                            "@codigo",
                            codigoselecionado
                        );

                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "CONTATO EXCLUÍDO COM SUCESSO!",
                    "Exclusão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // ==========================================
                // LIMPA
                // ==========================================

                LimparCampos();

                // ==========================================
                // ATUALIZA GRID
                // ==========================================

                Consultar();
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "ERRO AO EXCLUIR O CONTATO:\n\n" +
                    erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // CLIQUE NA GRID
        // ==========================================

        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            try
            {
                // ==========================================
                // PEGA LINHA SELECIONADA
                // ==========================================

                DataGridViewRow linha =
                    dataGridView1.Rows[e.RowIndex];

                // ==========================================
                // CÓDIGO
                // ==========================================

                codigoselecionado =
                    Convert.ToInt32(
                        linha.Cells["CodigoCliente"].Value
                    );

                TXTcodigo.Text =
                    codigoselecionado.ToString();

                // ==========================================
                // NOME
                // ==========================================

                TXTnomedocliente.Text =
                    linha.Cells["NomeCliente"]
                    .Value?.ToString();

                // ==========================================
                // TELEFONE
                // ==========================================

                TXTtelefone.Text =
                    linha.Cells["TelefoneCliente"]
                    .Value?.ToString();

                // ==========================================
                // DATA
                // ==========================================

                DTPdatacadastro.Value =
                    Convert.ToDateTime(
                        linha.Cells["DataCadastro"].Value
                    );

                // ==========================================
                // LOCAL
                // ==========================================

                string local =
                    linha.Cells["Local"]
                    .Value?.ToString();

                chkInterno.Checked =
                    local == "Interno";

                chkExterno.Checked =
                    local == "Externo";

                // ==========================================
                // VIP
                // ==========================================

                int vip =
                    Convert.ToInt32(
                        linha.Cells["ClienteVip"].Value
                    );

                chk3Meses.Checked = vip == 3;
                chk6Meses.Checked = vip == 6;
                chk1Ano.Checked = vip == 12;

                // ==========================================
                // PROSPECT
                // ==========================================

                CBXprospect.Text =
                    linha.Cells["PROSPECT"]
                    .Value?.ToString();

                // ==========================================
                // GARANTE MODO NORMAL
                // ==========================================

                modoEdiao = false;

                BTNeditar.Text = "Editar";
                BTNexcluir.Text = "Excluir";

                // ==========================================
                // BLOQUEIA CAMPOS ATÉ CLICAR EM EDITAR
                // ==========================================

                BloquearCampos(true);

                // ==========================================
                // GARANTE BOTÕES LIBERADOS
                // ==========================================

                BloquearBotoes(false);
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "ERRO AO CARREGAR O CONTATO:\n\n" +
                    erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // VIP 3 MESES
        // ==========================================

        private void chk3Meses_MouseClick(
            object sender,
            MouseEventArgs e)
        {
            if (chk3Meses.Checked)
            {
                chk6Meses.Checked = false;
                chk1Ano.Checked = false;
            }
        }

        // ==========================================
        // VIP 6 MESES
        // ==========================================

        private void chk6Meses_MouseClick(
            object sender,
            MouseEventArgs e)
        {
            if (chk6Meses.Checked)
            {
                chk3Meses.Checked = false;
                chk1Ano.Checked = false;
            }
        }

        // ==========================================
        // VIP 1 ANO
        // ==========================================

        private void chk1Ano_MouseClick(
            object sender,
            MouseEventArgs e)
        {
            if (chk1Ano.Checked)
            {
                chk3Meses.Checked = false;
                chk6Meses.Checked = false;
            }
        }

        // ==========================================
        // LOCAL INTERNO
        // ==========================================

        private void chkInterno_MouseClick(
            object sender,
            MouseEventArgs e)
        {
            if (chkInterno.Checked)
            {
                chkExterno.Checked = false;
            }
        }

        // ==========================================
        // LOCAL EXTERNO
        // ==========================================

        private void chkExterno_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (chkExterno.Checked)
            {
                chkInterno.Checked = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
