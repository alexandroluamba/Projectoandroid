using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Arduino_DHT
{
    public partial class Smart : Form
    {
        public Smart()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Smart_Load(object sender, EventArgs e)
        {
            PortaCom();
        }

        private void PortaCom()
        {
            cboPortaCom.Items.Clear();
            foreach (string portas in SerialPort.GetPortNames())
            {
                cboPortaCom.Items.Add(portas);
            }
            cboPortaCom.SelectedIndex = 0;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
             try
            {
                if (serialPort1.IsOpen)
                    serialPort1.Close();
                else
                {
                    serialPort1.PortName = cboPortaCom.Text;
                    serialPort1.BaudRate = Int16.Parse(cboBaudRate.Text);

                }
                serialPort1.Open();
                serialPort1.DataReceived += serialPort1_DataReceived;
                btnConectar.Enabled = false;
                btnConectar.ForeColor = Color.Blue;
                btnExit.Enabled = false;
                btnExit.ForeColor = Color.Blue;
                btnDisconectar.Enabled = true;
                btnDisconectar.ForeColor = Color.Black;
                cboPortaCom.Enabled = false;
                cboBaudRate.Enabled = false;
                lbMensagem.Text = "A porta esta aberta";
                lbMensagem.ForeColor = Color.Green;
            }
            catch
            {
                MessageBox.Show("Erro na inserçao dos parametros");
                serialPort1.Open();
                btnConectar.Enabled = true;
                btnConectar.ForeColor = Color.Black;
                btnExit.Enabled = true;
                btnExit.ForeColor = Color.Black;
                btnDisconectar.Enabled = false;
                btnDisconectar.ForeColor = Color.Blue;
                cboPortaCom.Enabled = true;
                cboBaudRate.Enabled = true;

            }

        
        }

        private void btnDisconectar_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();

                btnConectar.Enabled = true;
                btnConectar.ForeColor = Color.Black;
                btnExit.Enabled = true;
                btnExit.ForeColor = Color.Black;

                btnDisconectar.Enabled = false;
                btnDisconectar.ForeColor = Color.Blue;

                cboPortaCom.Enabled = true;
                cboBaudRate.Enabled = true;
                lbMensagem.Text = "A porta esta fechada";
                lbMensagem.ForeColor = Color.Red;



            }
            catch
            {

                btnConectar.Enabled = false;
                btnConectar.ForeColor = Color.Blue;
                btnExit.Enabled = false;
                btnExit.ForeColor = Color.Blue;
                btnDisconectar.Enabled = true;
                btnDisconectar.ForeColor = Color.Black;
                cboPortaCom.Enabled = false;
                cboBaudRate.Enabled = false;


            }
        }
        bool lamp = false;
        private void btnLigarDesligar_Click(object sender, EventArgs e)
        {
            if (lamp == false)
            {
                serialPort1.Write("1");
                btnLigarDesligar.Text = "Desligar Lampada";
                lamp = !lamp;
            }
            else
            {
                serialPort1.Write("0");
                btnLigarDesligar.Text = "Ligar Lampada";
                lamp = !lamp;
            }
        }
        bool imagem = false;
        private void pbimagelamp_Click(object sender, EventArgs e)
        {
            if (imagem == false)
            {
                serialPort1.Write("1");
                imagem = !imagem;

            }
            else
            {
                serialPort1.Write("0");
                imagem = !imagem;
            }    }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string dados = serialPort1.ReadLine(); 
                string[] valores = dados.Split(','); 

                if (valores.Length >= 2)
                {
                    
                    this.Invoke(new Action(() =>
                    {
                        lblTemp.Text = ""+ valores[0] +" °C";
                        lblUmid.Text = ""+ valores[1] +" %";
                    }));
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
