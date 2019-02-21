using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graph = System.Windows.Forms.DataVisualization.Charting;

namespace Kare_Dalga_Deneme_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int genlik, frekans, harmonik;

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas.Add("ChartArea1");
            chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            chart1.ChartAreas["ChartArea1"].AxisX.Maximum = 4;
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 0.5;
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.White;
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            chart1.ChartAreas["ChartArea1"].AxisY.Minimum = -1;
            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 1;
            chart1.ChartAreas["ChartArea1"].AxisY.Interval =0.5;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.White;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            chart1.ChartAreas["ChartArea1"].BackColor = Color.Black;
           

        }
        double[] toplam =new double[1000];
        double deger(int i, double x, int genlik, int frekans)
        {
            if (i == 1)
            {
                return 0;
            }
            else
            {

                return (4 * genlik / (i * Math.PI) * (Math.Sin(10 * i * 2 * frekans * x * Math.PI / 180))) + deger(i - 2, x, genlik, frekans);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            genlik = int.Parse(textBox1.Text);
            frekans = int.Parse(textBox2.Text);
            harmonik = int.Parse(textBox3.Text);
           

            chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            chart1.ChartAreas["ChartArea1"].AxisX.Maximum = 72;
            chart1.ChartAreas["ChartArea1"].AxisX.Interval =1;
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.White;
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            chart1.ChartAreas["ChartArea1"].AxisY.Minimum = -genlik * 1.5;
            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = genlik*1.5;
            chart1.ChartAreas["ChartArea1"].AxisY.Interval =1.5;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.White;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            chart1.Series.Clear();
            int a = 1;
            toplam[0] = 0.0;
            chart1.Series.Add("Kare Dalga");
            chart1.Series["Kare Dalga"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series["Kare Dalga"].Color = Color.Green;
            chart1.Series["Kare Dalga"].BorderWidth = 5;
                for (int i = 1; i <= harmonik; i=i+2)
                {
                    chart1.Series.Add("Harmonik"+i);
                    chart1.Series["Harmonik" + i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                    for (double x = 0; x <= 72; x += 0.1)
                    {
                        if(checkBox1.Checked==true)
                            chart1.Series["Harmonik" + i].Points.AddXY(x, 4 * genlik / (i * Math.PI) * (Math.Sin(10 * i * frekans * 2 * x * Math.PI / 180)));                                           
                    }
                }
                for (int i = 1; i <= harmonik; i = i + 2)
                {
                    chart1.Series["Kare Dalga"].Points.Clear();
                    for (double x = 0; x <= 72; x += 0.1)
                    {
                        chart1.Series["Kare Dalga"].Points.AddXY(x, (4 * genlik / (1 * Math.PI) * (Math.Sin(10 * 1 * frekans * 2 * x * Math.PI / 180))) + deger(i, x, genlik, frekans));
                    }
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            for (int i = 1; i <= harmonik; i = i + 2)
            {
                for (double x = 0; x <= 36; x += 0.1)
                {
                    chart1.Series["Harmonik" + i].Points.Clear();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
