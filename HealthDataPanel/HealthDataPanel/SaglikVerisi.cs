using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDataPanel
{
    public class SaglikVerisi
    {
        public string UlkeKodu { get; set; }
        public string UlkeAdi { get; set; }
        public int Yil { get; set; }

        public double AnneOlumOrani { get; set; }
        public double BebekOlumOrani { get; set; }
        public double HivOrani { get; set; }
        public double TuberkulozOrani { get; set; }
    }
}
