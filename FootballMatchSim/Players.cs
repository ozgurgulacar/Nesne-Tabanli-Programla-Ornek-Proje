using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatchSim
{
    class Players
    {
        protected Random rnd = new Random();
        int Reyting { get; set; }
        public string Mevki { get; set; } 
        public string Ad { get; set;     }
        public string Soyad { get; set; }
        public int Numara { get; set; }
        public int Cesaret { get; set; }
        public int KararAlma { get; set; }
        protected int Onsezi { get; set; }
        protected int OzelYetenek { get; set; }
        protected int PozisyonAlma { get; set; }
        protected int Guc { get; set; }
        protected int Hiz { get; set; }
        protected int Dayaniklilik { get; set; }
        public Players(int reyt)
        {
            Reyting = reyt;
            
            puanata();
        }
        
        void puanata()
        {
            Cesaret= rnd.Next(Reyting,101);
            KararAlma = rnd.Next(Reyting, 101);
            Onsezi = rnd.Next(Reyting, 101);
            OzelYetenek = rnd.Next(Reyting, 101);
            PozisyonAlma = rnd.Next(Reyting, 101);
            Guc = rnd.Next(Reyting, 101);
            Hiz = rnd.Next(Reyting, 101);
            Dayaniklilik = rnd.Next(Reyting, 101);
        }
        public virtual int pasat()
        {
            return 0;
        }
        public virtual int sutat()
        {
            return 0;
        }
        public virtual int calım()
        {
            return 0;
        }
        public virtual int topkap()
        {
            return 0;
        }
        public virtual int kurtar()
        {
            return 0;   
        }
    }
    class GoalKeeper:Players
    {
        int Reytinggk { get; set; }
        protected int Birebir { get; set; }
        protected int Ziplama { get; set; }
        protected int Refleks { get; set; }
        protected int Pas { get; set; }
        public GoalKeeper(int reyt, string ad, string soyad, int no,string mevki) : base(reyt)
        {
            Ad = ad; Soyad = soyad; Numara = no; Mevki = mevki;
            Reytinggk = reyt;
            puanata();
        }
        void puanata()
        {
            Birebir = rnd.Next(Reytinggk, 101);
            Ziplama = rnd.Next(Reytinggk, 101);
            Refleks = rnd.Next(Reytinggk, 101);
            Pas = rnd.Next(Reytinggk, 101);
        }
        public override int pasat()
        {
            return Convert.ToInt32(Cesaret * 0.1 + KararAlma * 0.2 + Onsezi * 0.2 + Pas * 0.5);
        }
        public override int kurtar()
        {
            return Convert.ToInt32(Birebir * 0.2 + PozisyonAlma * 0.2 + Refleks * 0.3 + Ziplama * 0.3);
        }
    }

    class Other:Players
    {
        int Reytingoth { get; set; }
        protected int Bitiricilik { get; set; }
        protected int Sut { get; set; }
        protected int Pas { get; set; }
        protected int OrtaYapma { get; set; }
        protected int Markaj { get; set; }
        protected int TopCalma { get; set; }
        public Other(int reyt,string ad,string soyad,int no,string mevki) : base(reyt) 
        {
            Ad = ad; Soyad = soyad; Numara = no; Mevki = mevki;
            Reytingoth = reyt;
            puanata();
        }
        void puanata()
        {
            Bitiricilik = rnd.Next(Reytingoth, 101);
            Sut = rnd.Next(Reytingoth, 101);
            Pas = rnd.Next(Reytingoth, 101);
            OrtaYapma = rnd.Next(Reytingoth, 101);
            Markaj = rnd.Next(Reytingoth, 101);
            TopCalma = rnd.Next(Reytingoth, 101);
        }

        public override int pasat()
        {
            return Convert.ToInt32(Cesaret * 0.1 + KararAlma * 0.1 + Onsezi * 0.1 + Pas * 0.5 + OrtaYapma * 0.2);
        }
        public override int sutat()
        {
            return Convert.ToInt32(Guc * 0.2 + Sut * 0.4 + Bitiricilik * 0.4);
        }
        public override int calım()
        {
            return Convert.ToInt32(OzelYetenek * 0.5 + Hiz * 0.2 + Guc * 0.1 + Dayaniklilik * 0.1);
        }
        public override int topkap()
        {
            return Convert.ToInt32(Markaj * 0.3 + TopCalma * 0.4 + Guc * 0.1 + Dayaniklilik * 0.1 + PozisyonAlma * 0.1);
        }
    }
}
