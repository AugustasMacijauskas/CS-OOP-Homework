using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDS_14GeometrinesFiguros
{
    class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", x, y);
        }
    }

    class Figura
    {
        public string vardas { get; set; }
        public List<Point> kampai { get; set; }

        private double[] krastiniuIlgiai;

        public virtual double Perimetras
        {
            get
            {
                if (krastiniuIlgiai == null)
                    KrastiniuIlgiai();

                return Math.Round(krastiniuIlgiai.Sum(), 6);
            }
        }

        public virtual double Plotas
        {
            get
            {
                double plotas = 0;
                for (int i = 0; i < kampai.Count; i++)
                {
                    if (i == kampai.Count - 1)
                        plotas += kampai[i].x * kampai[0].y - kampai[i].y * kampai[0].x;
                    else plotas += kampai[i].x * kampai[i + 1].y - kampai[i].y * kampai[i + 1].x; 
                }
                return Math.Round(Math.Abs(plotas / 2));
            }
        }

        public bool arStatusisTrikampis
        {
            get
            {
                if (kampai.Count != 3)
                    return false;

                if (krastiniuIlgiai == null)
                    KrastiniuIlgiai();

                double izambine = krastiniuIlgiai.Max();
                
                double statiniuKvadratas = 0;
                foreach (double krastine in krastiniuIlgiai)
                {
                    if (krastine != izambine)
                        statiniuKvadratas += Math.Pow(krastine, 2);
                }

                if (Math.Round(Math.Pow(izambine, 2), 5) == Math.Round(statiniuKvadratas, 5))
                    return true;
                else return false;
            }
        }

        public bool arKvadratas
        {
            get
            {
                if (krastiniuIlgiai == null)
                    KrastiniuIlgiai();

                return krastiniuIlgiai.All(x => x == krastiniuIlgiai[0]);
            }
        }

        public bool arLygiakrastis
        {
            get
            {
                if (krastiniuIlgiai == null)
                    KrastiniuIlgiai();

                return krastiniuIlgiai.All(x => x == krastiniuIlgiai[0]);
            }
        }

        public Figura(string vardas)
        {
            this.vardas = vardas;
            kampai = new List<Point>();
        }

        public void PridetiKampa(Point kampas)
        {
            kampai.Add(kampas);
        }

        public override string ToString()
        {
            string taskai = "";
            kampai.ForEach(x => taskai += " " + x.ToString());
            return vardas + " " + taskai;
        }

        public bool ArIbreztas(Apskritimas apskritimas)
        {
            if (krastiniuIlgiai == null)
                KrastiniuIlgiai();

            if (!arStatusisTrikampis)
                return false;

            double izambine = krastiniuIlgiai.Max();
            if (apskritimas.spindulys * 2 != izambine)
                return false;

            double izambinesVidX = 0, izambinesVidY = 0;
            for (int i = 0; i < kampai.Count; i++)
            {
                double ilgis;
                if (i == kampai.Count - 1)
                {
                    ilgis = AtstumasTarpDviejuTasku(kampai[i], kampai[0]);
                    if (ilgis == izambine)
                    {
                        izambinesVidX = Math.Round((kampai[i].x + kampai[0].x) / 2, 6);
                        izambinesVidY = Math.Round((kampai[i].y + kampai[0].y) / 2, 6);
                        break;
                    }
                }
                else
                {
                    ilgis = AtstumasTarpDviejuTasku(kampai[i], kampai[i + 1]);
                    if (ilgis == izambine)
                    {
                        izambinesVidX = Math.Round((kampai[i].x + kampai[i + 1].x) / 2, 6);
                        izambinesVidY = Math.Round((kampai[i].y + kampai[i + 1].y) / 2, 6);
                        break;
                    }
                }
            }
            
            if (izambinesVidX == apskritimas.kampai[0].x && izambinesVidY == apskritimas.kampai[0].y)
                return true;
            else return false;
        }

        public bool ArApibreztas(Apskritimas apskritimas)
        {
            if (krastiniuIlgiai == null)
                KrastiniuIlgiai();

            if (!arKvadratas)
                return false;

            if (krastiniuIlgiai[0] != apskritimas.spindulys * 2)
                return false;


            double apsX = Math.Round((kampai[0].x + kampai[2].x) / 2, 6);
            double apsY = Math.Round((kampai[0].y + kampai[2].y) / 2, 6);
            
            if (apsX == apskritimas.kampai[0].x && apsY == apskritimas.kampai[0].y)
                return true;
            else return false;
        }

        private void KrastiniuIlgiai()
        {
            krastiniuIlgiai = new double[kampai.Count];
            int index = 0;

            for (int i = 0; i < kampai.Count; i++)
            {
                double ilgis;
                if (i == kampai.Count - 1)
                {
                    ilgis = AtstumasTarpDviejuTasku(kampai[i], kampai[0]);
                    krastiniuIlgiai[index] = ilgis;
                }
                else
                {
                    ilgis = AtstumasTarpDviejuTasku(kampai[i], kampai[i + 1]);
                    krastiniuIlgiai[index] = ilgis;
                    index++;
                }
            }
        }

        private double AtstumasTarpDviejuTasku(Point pt1, Point pt2)
        {
            return Math.Round(Math.Sqrt(Math.Pow(pt1.x - pt2.x, 2) + Math.Pow(pt1.y - pt2.y, 2)), 6);
        }
    }

    class Apskritimas : Figura
    {
        public double spindulys { get; set; }

        public override double Perimetras
        {
            get
            {
                return Math.Round(2 * Math.PI * spindulys, 6);
            }
        }

        public override double Plotas
        {
            get
            {
                return Math.Round(Math.PI * spindulys * spindulys, 6);
            }
        }

        public Apskritimas(string vardas, double spindulys) : base(vardas)
        {
            this.spindulys = spindulys;
        }      

        public override string ToString()
        {
            return base.ToString() + " " + spindulys;
        }
    }
}
