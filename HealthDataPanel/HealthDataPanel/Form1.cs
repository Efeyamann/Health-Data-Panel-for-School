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
        List<string> seciliUlkeler = new List<string>();

        private readonly Color[] grafikRenkleri = new Color[] { Color.SteelBlue, Color.Crimson };

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

            if (seciliUlkeler.Contains(tiklananKod))
            {
                return;
            }

            if (seciliUlkeler.Count >= 2)
            {
                seciliUlkeler.Clear();
            }

            seciliUlkeler.Add(tiklananKod);

            Dictionary<string, List<SaglikVerisi>> karsilastirmaVerileri = new Dictionary<string, List<SaglikVerisi>>();
            List<string> ulkeIsimleri = new List<string>();

            foreach (var kod in seciliUlkeler)
            {
                var veriler = veriYonetici.GecmisiGetir(kod);
                if (veriler.Count > 0)
                {
                    karsilastirmaVerileri.Add(kod, veriler);
                    ulkeIsimleri.Add(veriler[0].UlkeAdi.ToUpper());
                }
            }

            if (karsilastirmaVerileri.Count > 0)
            {
                this.Text = "Karşılaştırma: " + string.Join(" vs ", ulkeIsimleri);
                PaneliGuncelle(karsilastirmaVerileri);
            }
            else
            {
                seciliUlkeler.Remove(tiklananKod); 
                MessageBox.Show($"Bu ülke ({data.Name}) için veritabanında kayıt yok.");
            }
        }

        private void PaneliGuncelle(Dictionary<string, List<SaglikVerisi>> veriSozlugu)
        {
            GrafikCiz(chartAnne, veriSozlugu, "Anne Ölümü (100k'da)", x => x.AnneOlumOrani);
            GrafikCiz(chartBebek, veriSozlugu, "Bebek Ölümü (1000'de)", x => x.BebekOlumOrani);
            GrafikCiz(chartHIV, veriSozlugu, "HIV Prevalansı (%)", x => x.HivOrani);
            GrafikCiz(chartTB, veriSozlugu, "Tüberküloz (100k'da)", x => x.TuberkulozOrani);
        }

        private void GrafikCiz(Chart grafik, Dictionary<string, List<SaglikVerisi>> veriSozlugu, string baslik, Func<SaglikVerisi, double> veriSecici)
        {
            grafik.Series.Clear();
            grafik.Titles.Clear();
            grafik.Titles.Add(baslik).Font = new Font("Segoe UI", 10, FontStyle.Bold);

            if (grafik.Legends.Count == 0)
            {
                grafik.Legends.Add(new Legend("Default"));
            }
            grafik.Legends[0].Docking = Docking.Bottom;
            grafik.Legends[0].Alignment = StringAlignment.Center;

            ChartArea alan = grafik.ChartAreas[0];
            alan.AxisX.MajorGrid.LineColor = Color.LightGray;
            alan.AxisY.MajorGrid.LineColor = Color.LightGray;
            alan.AxisX.LabelStyle.Enabled = true;

            alan.AxisY.Minimum = double.NaN;
            alan.AxisY.Maximum = double.NaN;
            alan.AxisY.Interval = double.NaN;
            alan.AxisY.IsStartedFromZero = true;

            int renkIndex = 0;

            foreach (var kvp in veriSozlugu)
            {
                string ulkeKodu = kvp.Key;
                List<SaglikVerisi> liste = kvp.Value;
                string ulkeAdi = liste.Count > 0 ? liste[0].UlkeAdi : ulkeKodu;

                Series seri = new Series(ulkeAdi);
                seri.ChartType = SeriesChartType.Line;
                seri.BorderWidth = 3;
                
                seri.Color = grafikRenkleri[renkIndex % grafikRenkleri.Length];
                
                seri.MarkerStyle = MarkerStyle.Circle;
                seri.MarkerSize = 6;
                seri.IsValueShownAsLabel = false;

                foreach (var kayit in liste)
                {
                    double deger = veriSecici(kayit);
                    if (deger > 0)
                    {
                        seri.Points.AddXY(kayit.Yil, deger);
                    }
                }

                grafik.Series.Add(seri);
                renkIndex++;
            }

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