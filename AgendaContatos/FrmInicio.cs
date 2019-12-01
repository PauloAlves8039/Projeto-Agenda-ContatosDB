using System;
using System.Windows.Forms;

namespace AgendaContatos
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 2;
            }
            else
            {
                timer1.Enabled = false;
                FrmAgenda frmAgenda = new FrmAgenda();
                frmAgenda.Show();
                Visible = false;
            }
        }
    }
}
