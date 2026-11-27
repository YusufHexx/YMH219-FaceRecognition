using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuzTanima
{
    internal class YuzTaniyici
    {
        private List<(string Etiket, Mat Yuz)> kayitliYuzler;

        public YuzTaniyici(string klasorYolu, YuzAlgilayici yuzAlgilayici)
        {
            kayitliYuzler = new List<(string, Mat)>();

            if (!Directory.Exists(klasorYolu))
            {
                Directory.CreateDirectory(klasorYolu);
                return;
            }

            // Kişilerin klasörlerini bul
            string[] kisiKlasorleri =
                Directory.GetDirectories(klasorYolu);

            foreach (string kisiKlasoru in kisiKlasorleri)
            {
                string kisiAdi = Path.GetFileName(kisiKlasoru);

                string[] resimler = Directory.GetFiles(kisiKlasoru);

                foreach (string resimYolu in resimler)
                {
                    string uzanti = Path.GetExtension(resimYolu).ToLower();

                    if (uzanti != ".jpg" &&
                        uzanti != ".jpeg" &&
                        uzanti != ".png" &&
                        uzanti != ".bmp")
                    {
                        continue;
                    }

                    using Mat goruntu = Cv2.ImRead(resimYolu);

                    if (goruntu.Empty())
                        continue;

                    Rect[] yuzler = yuzAlgilayici.YuzleriBul(goruntu);

                    if (yuzler.Length == 0)
                        continue;

                    // İlk bulunan yüzü al
                    using Mat yuzBolgesi = new Mat(goruntu, yuzler[0]);

                    Mat hazirYuz = YuzuHazirla(yuzBolgesi);

                    kayitliYuzler.Add((kisiAdi, hazirYuz));
                }
            }
        }

        // Yüz görüntüsünü karşılaştırmaya hazır hale getir
        private Mat YuzuHazirla(Mat yuz)
        {
            Mat griYuz = new Mat();

            if (yuz.Channels() == 3)
            {
                Cv2.CvtColor(
                    yuz,
                    griYuz,
                    ColorConversionCodes.BGR2GRAY
                );
            }
            else
            {
                yuz.CopyTo(griYuz);
            }

            Mat boyutlandirilmis = new Mat();

            Cv2.Resize(
                griYuz,
                boyutlandirilmis,
                new OpenCvSharp.Size(100, 100)
            );

            griYuz.Dispose();

            Cv2.EqualizeHist(
                boyutlandirilmis,
                boyutlandirilmis
            );

            return boyutlandirilmis;
        }

        // Yeni yüzü kayıtlı yüzlerle karşılaştır
        public string TahminEt(Mat yeniYuz, out double benzerlik)
        {
            benzerlik = 0;

            if (kayitliYuzler.Count == 0)
                return "Kayitli kisi yok";

            using Mat hazirYuz = YuzuHazirla(yeniYuz);

            double enYuksekSkor = 0;
            string tahmin = "Bilinmiyor";

            foreach (var kayit in kayitliYuzler)
            {
                using Mat fark = new Mat();

                Cv2.Absdiff(
                    hazirYuz,
                    kayit.Yuz,
                    fark
                );

                Scalar ortalama = Cv2.Mean(fark);

                // Piksel farkını benzerlik skoruna çevir
                double skor = 100 - (ortalama.Val0 * 100 / 255);

                if (skor > enYuksekSkor)
                {
                    enYuksekSkor = skor;
                    tahmin = kayit.Etiket;
                }
            }

            benzerlik = enYuksekSkor;

            // Düşük benzerlikte kişiyi tanınmamış kabul et
            if (enYuksekSkor < 55)
            {
                tahmin = "Bilinmiyor";
            }

            return tahmin;
        }

        public void Temizle()
        {
            foreach (var kayit in kayitliYuzler)
            {
                kayit.Yuz.Dispose();
            }

            kayitliYuzler.Clear();
        }
    }
}
