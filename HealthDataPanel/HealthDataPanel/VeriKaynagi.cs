using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HealthDataPanel
{
    public class VeriKaynagi
    {
        private List<SaglikVerisi> tumVeriler;

        public VeriKaynagi()
        {
            tumVeriler = new List<SaglikVerisi>();
            DosyayiOku();
        }

        private void DosyayiOku()
        {
            string yol = "veriler.csv";
            int i = 0;

            if (!File.Exists(yol))
            {
                MessageBox.Show("veriler.csv dosyası bulunamadı!");
                return;
            }

            try
            {
                var satirlar = File.ReadAllLines(yol);
                while (i < satirlar.Length)
                {
                    if (string.IsNullOrWhiteSpace(satirlar[i]))
                        continue;

                    var parcalar = satirlar[i].Split(';');

                    SaglikVerisi veri = new SaglikVerisi();
                    veri.UlkeKodu = parcalar[0].Trim();
                    veri.UlkeAdi = parcalar[1].Trim();

                    if (int.TryParse(parcalar[2], out int yil))
                        veri.Yil = yil;

                    veri.AnneOlumOrani = VeriTemizle(parcalar[3]);
                    veri.BebekOlumOrani = VeriTemizle(parcalar[4]);
                    veri.HivOrani = VeriTemizle(parcalar[5]);
                    veri.TuberkulozOrani = VeriTemizle(parcalar[6]);

                    tumVeriler.Add(veri);
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri Okuma Hatası: " + ex.Message);
            }
        }

        private double VeriTemizle(string hamVeri)
        {
            if (string.IsNullOrWhiteSpace(hamVeri)) return 0;
            hamVeri = hamVeri.Replace(',', '.');
            if (double.TryParse(hamVeri, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double sonuc)) return sonuc;
            return 0;
        }

        public List<SaglikVerisi> GecmisiGetir(string kod)
        {
            return tumVeriler
                .Where(x => x.UlkeKodu == kod)
                .OrderBy(x => x.Yil)
                .ToList();
        }
    }
}
