using AgendaContatos.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {

        }
    }
}
