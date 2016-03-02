using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator_prosjekt
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
            pictureBox1.Load("https://www.wolfram.com/common/images/products/wolfram-mathematica.png");
        }

        private void erlik_Click(object sender, EventArgs k)
        {
            try
            {
                string s = Variabel_tolk.getResult(textBox1.Text);
                label1.Text = s;
                label1.ForeColor = Color.FromArgb(0, 0, 0);
            }
            catch (Exception e)
            {
                string s = e.Message;
                label1.Text = s;
                label1.ForeColor = Color.FromArgb(255, 0, 0);
            }

        }
    }
}
