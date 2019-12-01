using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using AgendaContatos.Entities;
using AgendaContatos.Dao;

namespace AgendaContatos
{
    public partial class FrmAgenda : Form
    {
        public FrmAgenda()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToShortDateString();
            toolStripStatusLabel5.Text = DateTime.Now.ToShortTimeString();
        }

        private void FrmAgenda_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmAgenda_Load(object sender, EventArgs e)
        {
            CarregarDgv();
        }

        private void CarregarDgv()
        {
            ContatoDao contatoDao = new ContatoDao();
            DataTable dgvDataTable = contatoDao.BuscarTodos();
            dgvAgenda.DataSource = dgvDataTable;
            dgvAgenda.Refresh();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            FrmAdicionarAlterar frmAdicionarAlterar = new FrmAdicionarAlterar();
            frmAdicionarAlterar.ShowDialog();
            CarregarDgv();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato
            {
                Id = (int)dgvAgenda.CurrentRow.Cells[0].Value,
                Nome = dgvAgenda.CurrentRow.Cells[1].Value.ToString(),
                Email = dgvAgenda.CurrentRow.Cells[2].Value.ToString(),
                Telefone = (int)dgvAgenda.CurrentRow.Cells[3].Value
            };
            FrmAdicionarAlterar frmAdicionarAlterar = new FrmAdicionarAlterar(contato);
            frmAdicionarAlterar.ShowDialog();
            CarregarDgv();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int Id = (int)dgvAgenda.CurrentRow.Cells[0].Value;
            ContatoDao contatoDao = new ContatoDao();
            contatoDao.Excluir(Id);
            MessageBox.Show("Contato excluído com sucesso!!!");
            CarregarDgv();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
