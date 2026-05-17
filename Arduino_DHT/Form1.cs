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
using System.Windows.Forms.DataVisualization.Charting;

namespace Arduino_DHT
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;
        string latestData = "";
        public Form1()
        {
            InitializeComponent();
            chart1.Series.Clear();
            chart1.Series.Add("Temperatura");
            chart1.Series["Temperatura"].ChartType = SeriesChartType.Line;
            chart1.Series.Add("Umidade");
            chart1.Series["Umidade"].ChartType = SeriesChartType.Line;

            
            serialPort = new SerialPort("COM12", 9600); 
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();

            // Timer para atualizar o gráfico
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();


        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadLine();
                latestData = data.Trim(); // remove espaços ou \r\n
            }
            catch { }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(latestData))
            {
                string dataCopy = latestData; // evita problemas de thread
                latestData = "";

                
                this.BeginInvoke((Action)(() =>
                {
                    try
                    {
                        string[] valores = dataCopy.Split(',');
                        if (valores.Length == 2)
                        {
                            float temp = float.Parse(valores[0].Replace('.', ','));
                            float hum = float.Parse(valores[1].Replace('.', ','));

                            chart1.Series["Temperatura"].Points.AddY(temp);
                            chart1.Series["Umidade"].Points.AddY(hum);

                            
                            if (chart1.Series["Temperatura"].Points.Count > 30)
                                chart1.Series["Temperatura"].Points.RemoveAt(0);
                            if (chart1.Series["Umidade"].Points.Count > 30)
                                chart1.Series["Umidade"].Points.RemoveAt(0);
                        }
                    }
                    catch { }
                }));
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort.Close();
            Smart frlSmart = new Smart();
            frlSmart.Show();
            this.Hide();
        }
    }
}
