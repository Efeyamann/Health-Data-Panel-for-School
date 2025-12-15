using LiveCharts.Maps;
using LiveCharts.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace HealthDataPanel
{
    public partial class Form1 : Form
    {
        VeriKaynagi veriYonetici = new VeriKaynagi();

        GeoMap dunyaHaritasi;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
                System.Windows.Forms.Application.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
                dunyaHaritasi = new LiveCharts.WinForms.GeoMap();
                dunyaHaritasi.Dock = DockStyle.Fill;
                string tamYol = System.IO.Path.Combine(Application.StartupPath, "World.xml");
                dunyaHaritasi.Source = tamYol;

                dunyaHaritasi.LandClick += HaritayaTiklandi;
                dunyaHaritasi.Hoverable = true;

                splitContainer1.Panel1.Controls.Add(dunyaHaritasi);
                GrafikBaslikla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Harita yüklenirken kritik hata: " + ex.Message);
            }
        }

        private void HaritayaTiklandi(object sender, MapData data)
        {
            string tiklananKod = data.Id;
            List<SaglikVerisi> gecmis = veriYonetici.GecmisiGetir(tiklananKod);

            if (gecmis.Count > 0)
            {
                this.Text = "Seçilen Ülke: " + gecmis[0].UlkeAdi.ToUpper();
                PaneliGuncelle(gecmis);
            }
            else
            {
                MessageBox.Show($"Bu ülke ({data.Name}) için veritabanında kayıt yok.");
            }
        }

        private void PaneliGuncelle(List<SaglikVerisi> veriListesi)
        {
            GrafikCiz(chartAnne, veriListesi, "Anne Ölümü (100k'da)", Color.PaleVioletRed, x => x.AnneOlumOrani);
            GrafikCiz(chartBebek, veriListesi, "Bebek Ölümü (1000'de)", Color.SteelBlue, x => x.BebekOlumOrani);
            GrafikCiz(chartHIV, veriListesi, "HIV Prevalansı (%)", Color.Crimson, x => x.HivOrani);
            GrafikCiz(chartTB, veriListesi, "Tüberküloz (100k'da)", Color.DarkOrange, x => x.TuberkulozOrani);
        }

        private void GrafikCiz(Chart grafik, List<SaglikVerisi> liste, string baslik, Color renk, Func<SaglikVerisi, double> veriSecici)
        {
            grafik.Series.Clear();
            grafik.Titles.Clear();
            grafik.Titles.Add(baslik).Font = new Font("Segoe UI", 10, FontStyle.Bold);

            ChartArea alan = grafik.ChartAreas[0];
            alan.AxisX.MajorGrid.LineColor = Color.LightGray;
            alan.AxisY.MajorGrid.LineColor = Color.LightGray;
            alan.AxisY.MajorGrid.LineColor = Color.LightGray;
            alan.AxisX.LabelStyle.Enabled = true;
            
            alan.AxisY.Minimum = double.NaN;
            alan.AxisY.Maximum = double.NaN;
            alan.AxisY.Interval = double.NaN;
            alan.AxisY.IsStartedFromZero = true;

            Series seri = new Series("Veri");
            seri.ChartType = SeriesChartType.Line;
            seri.BorderWidth = 3;
            seri.Color = renk;
            seri.MarkerStyle = MarkerStyle.Circle;
            seri.MarkerSize = 6;

            foreach (var kayit in liste)
            {
                double deger = veriSecici(kayit);
                if (deger > 0)
                {
                    seri.Points.AddXY(kayit.Yil, deger);
                }
            }

            grafik.Series.Add(seri);
            alan.RecalculateAxesScale();
        }

        private void GrafikBaslikla()
        {
            chartAnne.Titles.Add("Anne Ölümü");
            chartBebek.Titles.Add("Bebek Ölümü");
            chartHIV.Titles.Add("HIV Oranı");
            chartTB.Titles.Add("Tüberküloz");
        }
    }
}