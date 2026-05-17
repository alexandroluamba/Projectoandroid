using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arduino_DHT
{
    public partial class abertura : Form
    {
        public abertura()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 2;
            }
            else
            {
                timer1.Enabled = false;

                Login frl = new Login();
                frl.Show();
                this.Visible = false;
            }
        }
    }
}
