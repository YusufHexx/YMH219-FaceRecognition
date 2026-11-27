using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuzTanima
{
    internal class YuzAlgilayici
    {
        private CascadeClassifier yuzModeli;

        public YuzAlgilayici(string modelYolu)
        {
            if (!File.Exists(modelYolu))
            {
                throw new FileNotFoundException(
                    "Yüz algılama modeli bulunamadı!", modelYolu);
            }

            yuzModeli = new CascadeClassifier(modelYolu);

            if (yuzModeli.Empty())
            {
                throw new Exception("Yüz modeli yüklenemedi!");
            }
        }

        public Rect[] YuzleriBul(Mat goruntu)
        {
            using Mat griGoruntu = new Mat();

            Cv2.CvtColor(
                goruntu,
                griGoruntu,
                ColorConversionCodes.BGR2GRAY
            );

            Cv2.EqualizeHist(griGoruntu, griGoruntu);

            Rect[] yuzler = yuzModeli.DetectMultiScale(
                griGoruntu,
                1.1,
                5,
                HaarDetectionTypes.ScaleImage,
                new OpenCvSharp.Size(30, 30)
            );

            return yuzler;
        }
    }
}
