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
        }

        private void erlik_Click(object sender, EventArgs k)
        {
            try
            {
                string s = Variabel_tolk.getResult(textBox1.Text);
                label1.Text = s;
                //print s til svarfelt
            }
            catch (Exception e)
            {
                string s = e.Message;
                label1.Text = s;
                //print s til svarfelt som feilmelding (rød tekst)
            }

        }
    }
}
