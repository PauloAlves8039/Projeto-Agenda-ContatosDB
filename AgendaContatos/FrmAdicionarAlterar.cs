using AgendaContatos.Dao;
using AgendaContatos.Entities;
using System;
using System.Windows.Forms;

namespace AgendaContatos
{
    public partial class FrmAdicionarAlterar : Form
    {
        private Contato contato;

        public FrmAdicionarAlterar(Contato contato = null)
        {
            this.contato = contato;
            InitializeComponent();
        }

        private void FrmAdicionarAlterar_Load(object sender, EventArgs e)
        {
            if (contato != null)
            {
                txtNome.Text = contato.Nome;
                txtEmail.Text = contato.Email;
                mktTelefone.Text = contato.Telefone.ToString();
            }
            else
            {
                txtNome.Text = string.Empty;
                txtEmail.Text = string.Empty;
                mktTelefone.Text = string.Empty;
            }
            txtNome.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ContatoDao contatoDao = new ContatoDao();

            if (contato == null)
            {
                Contato contato = new Contato
                {
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    Telefone = Convert.ToInt32(mktTelefone.Text)
                };
                contatoDao.Inserir(contato);
                Close();
            }
            else
            {
                contato.Nome = txtNome.Text;
                contato.Email = txtEmail.Text;
                contato.Telefone = Convert.ToInt32(mktTelefone.Text);
                contatoDao.Atualizar(contato);
                Close();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            mktTelefone.Text = "";
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
