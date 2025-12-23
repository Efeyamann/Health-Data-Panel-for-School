# Sağlık Veri Setleri ile AI/ML Kıyaslama Projesi - Raporu

**Proje Adı:** Health Data Panel (Sağlık Veri Paneli)  
**Tarih:** 20.12.2025  
**Hazırlayan:** (Proje Ekibi / Öğrenci)

---

## 1. GİRİŞ

Bu projenin temel amacı, küresel sağlık verilerini (Anne Ölümü, Bebek Ölümü, HIV Prevalansı ve Tüberküloz İnsidansı) görselleştirerek analiz etmek ve bu veriler üzerinde Yapay Zeka (AI) ve Makine Öğrenmesi (ML) algoritmalarını kullanarak kıyaslamalı analizler yapabilecek bir altyapı sunmaktır.

Mevcut uygulama, kullanıcıların dünya haritası üzerinden etkileşimli olarak ülke seçimi yapmasına, seçilen ülkeye ait geçmiş sağlık verilerini dinamik grafikler (line charts) üzerinde görüntülemesine olanak tanır. Proje, modüler C# WinForms mimarisi üzerine inşa edilmiştir ve veri bilimi süreçlerinin (Keşifsel Veri Analizi - EDA) ilk aşaması olan görselleştirme ve ön işleme adımlarını başarıyla gerçekleştirmektedir.

---

## A. PROJE PLANLAMA ve DOKÜMANTASYON

### 1.1. İş Akışı ve Algoritma Tasarımı

Projenin genel iş akışı aşağıdaki diyagramda özetlenmiştir. Sistem, ham verinin yüklenmesinden görselleştirmeye kadar olan süreci kapsar.

```mermaid
graph TD
    A[Başlat (Program.cs)] --> B[Arayüz Yükle (Form1)]
    B --> C[Veri Kaynağını Başlat (VeriKaynagi.cs)]
    C --> D{Veri Dosyası Var mı? (veriler.csv)}
    D -- Hayır --> E[Hata Mesajı Göster]
    D -- Evet --> F[Dosya Okuma ve Parse Etme]
    F --> G[Ön İşleme (VeriTemizle)]
    G --> H[Verilerin Belleğe Yüklenmesi List<SaglikVerisi>]
    H --> I[Harita ve Arayüz Hazır]
    I --> J{Kullanıcı Etkileşimi}
    J -- Ülke Seçimi --> K[Geçmiş Veriyi Getir (GecmisiGetir)]
    K --> L[Grafikleri Güncelle (PaneliGuncelle)]
    L --> M[Kullanıcıya Sunum]
```

#### Ön İşleme Algoritması (Pseudocode)
Veri setindeki tutarsızlıkları gidermek için kullanılan mevcut algoritma şu şekildedir:

```text
Fonksiyon VeriTemizle(hamVeri):
    EĞER hamVeri boş veya null ise:
        DÖNDÜR 0
    
    hamVeri içerisindeki ',' karakterini '.' ile DEĞİŞTİR (Ondalık ayracı standardizasyonu)
    
    EĞER hamVeri sayıya dönüştürülebilirse (Double.TryParse):
        DÖNDÜR sayısal_değer
    AKSİ HALDE:
        DÖNDÜR 0 (Eksik veya bozuk veri varsayılanı)
```

### 1.2. Sağlık Veri Seti Analizi

**Veri Seti Kaynağı:** Projede kullanılan veri seti (`veriler.csv`), Dünya Sağlık Örgütü (WHO) veya Dünya Bankası gibi açık kaynaklardan derlenen küresel sağlık indikatörlerini içerir.

**Seçilen Değişkenler:**
1.  **Anne Ölüm Oranı (Maternal Mortality Rate):** Her 100.000 canlı doğumda anne ölümü. (Ülkenin sağlık sistemi kalitesini gösterir).
2.  **Bebek Ölüm Oranı (Infant Mortality Rate):** Her 1.000 canlı doğumda bebek ölümü.
3.  **HIV Prevalansı:** 15-49 yaş arası nüfusta HIV pozitif oranı (%).
4.  **Tüberküloz İnsidansı:** Her 100.000 kişide yeni Tüberküloz vakası.

**Veri Profili:**
- Veriler zaman serisi formatındadır (Yıllara göre değişim).
- Bazı yıllar veya ülkeler için eksik veriler mevcuttur; bunlar mevcut sistemde '0' olarak işlenmektedir. Gelecek geliştirmelerde "ortalama ile doldurma" veya "lineer enterpolasyon" yöntemleri planlanmaktadır.

---

## B. GÖRSEL PROGRAMLAMA ve UYGULAMA

### 2.1. Veri Keşfi ve Görselleştirme Paneli

Uygulama arayüzü, kullanıcının veriyi sezgisel olarak keşfetmesini sağlayacak şekilde tasarlanmıştır:

- **Etkileşimli Dünya Haritası (GeoMap):** Kullanıcılar coğrafi konumlarına göre ülkeleri seçebilir. `LiveCharts.WinForms.GeoMap` bileşeni kullanılarak, ülke sınırları ve kodları (ISO formatı) veri seti ile eşleştirilmiştir.
- **Çoklu Grafik Paneli (Dashboard):** Seçilen ülkeye ait 4 temel sağlık göstergesi eş zamanlı olarak gösterilir.
  - *chartAnne*: Kırmızı tonlarında, anne ölüm oranını gösterir.
  - *chartBebek*: Mavi tonlarında, bebek ölüm oranını gösterir.
  - *chartHIV*: Koyu kırmızı, HIV yaygınlığını gösterir.
  - *chartTB*: Turuncu, tüberküloz vakalarını gösterir.
- **Dinamik Ölçeklendirme:** Grafikler, seçilen ülkenin veri aralığına göre eksenleri otomatik olarak yeniden ölçeklendirir (`RecalculateAxesScale`).

### 2.2. Ön İşleme Kontrolleri

Mevcut sürümde ön işleme arka planda otomatik yapılmaktadır:
- **Encoding/Parsing:** CSV formatındaki metin verileri nesne tabanlı yapıya (`SaglikVerisi` sınıfı) dönüştürülür.
- **Kültür Bağımsızlığı:** Uygulama, farklı bölgesel ayarlarda (TR/EN) çalışabilmesi için `InvariantCulture` kullanmaya zorlanmıştır (`Form1_Load`). Bu, ondalık ayraç hatalarını (. vs ,) önler.

### 2.3. Model Kıyaslama ve Tahmin Modülü (Planlanan)

Rubrik gereklilikleri doğrultusunda, bir sonraki aşamada eklenecek modüller:

- **Algoritmalar:**
    1.  **Lineer Regresyon:** Gelecek yıllardaki ölüm oranlarını tahmin etmek için (Trend Analizi).
    2.  **Random Forest Regressor:** Karmaşık ilişkileri (örneğin HIV oranının Tüberküloz üzerindeki etkisi) modellemek için.
    3.  **K-Means Clustering:** Ülkeleri sağlık risk seviyelerine göre gruplamak için.
- **Model Eğitim Arayüzü:** Kullanıcının eğitim/test seti oranını (%70-%30 vb.) seçebileceği bir panel eklenecektir.

---

## C. ALGORİTMA ve KOD KALİTESİ

### 3.1. Modüler Mimari

Proje, Sorumlulukların Ayrılığı (Separation of Concerns) ilkesine uygun olarak tasarlanmıştır:

| Modül / Sınıf | Görev Tanımı |
| :--- | :--- |
| **Program.cs** | Uygulamanın giriş noktası. |
| **Form1.cs** | **Presentation Layer (Sunum Katmanı):** Kullanıcı etkileşimi, grafik çizimleri ve harita olaylarını yönetir. İş mantığını doğrudan içermez, veri yöneticisinden veri ister. |
| **VeriKaynagi.cs** | **Data Access Layer (Veri Erişim Katmanı):** Dosya okuma (I/O), parse etme ve temizleme işlemlerini kapsüller. Veriyi `List<SaglikVerisi>` olarak sunar. |
| **SaglikVerisi.cs** | **Model Layer (Varlık Katmanı):** Veri yapısını (DTO) tanımlar. |

### 3.2. Veri Akışı Yönetimi

Veri akışı şu prensiplere dayanır:
1.  **Tek Kaynak (Single Source of Truth):** `VeriKaynagi` sınıfı, bellekteki verinin tek sahibidir.
2.  **LINQ Sorguları:** Veri filtreleme işlemleri (`Where`, `OrderBy`) C#'ın güçlü LINQ kütüphanesi ile optimize edilmiştir.
    *Örnek:* `tumVeriler.Where(x => x.UlkeKodu == kod).OrderBy(x => x.Yil)`
3.  **Hata Yönetimi:** Dosya bulunamaması veya bozuk format durumları `try-catch` blokları ile yakalanır ve kullanıcıya anlamlı mesajlar gösterilir.

---

## D. SONUÇ ve DEĞERLENDİRME

Bu proje, sağlık verilerinin analizi için sağlam bir temel oluşturmuştur. Rubrikte belirtilen "Veri Seti Seçimi", "Veri Profili Raporu" ve "Görsel Programlama" kriterlerini başarıyla karşılamaktadır. Modüler kod yapısı, ilerleyen aşamalarda makine öğrenmesi algoritmalarının (Python entegrasyonu veya ML.NET kullanılarak) sisteme entegre edilmesine olanak tanır.

**Gelecek Çalışmalar:**
- Eksik verilerin (0 değeri dönenler) regresyon ile doldurulması.
- Farklı ülkelerin sağlık verilerinin üst üste bindirilerek (Benchmark) kıyaslanması özelliği.
- Tahminleme (Prediction) modülünün aktifleştirilmesi.

---
*Bu rapor, proje kaynak kodları ve yapılandırması temel alınarak oluşturulmuştur.*
