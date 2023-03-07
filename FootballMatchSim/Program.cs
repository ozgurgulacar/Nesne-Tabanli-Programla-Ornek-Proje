using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatchSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Team1 Takımı Kuruluyor
            List<Players> Team1 = new List<Players>();
            Team1.Add(new GoalKeeper(75, "Fernando", "Muslera", 1, "Kaleci"));
            Team1.Add(new Other(70, "Sacha", "Boey", 2, "Defans"));
            Team1.Add(new Other(70, "Victor", "Nellson", 3, "Defans"));
            Team1.Add(new Other(65, "AbdülKerim", "Bardakçı", 4, "Defans"));
            Team1.Add(new Other(55, "KazımCan", "Karataş", 5, "Defans"));
            Team1.Add(new Other(70, "Sergio", "Oliveira", 6, "OrtaSaha"));
            Team1.Add(new Other(70, "Lucas", "Torreira", 7, "OrtaSaha"));
            Team1.Add(new Other(70, "Nicolo", "Zaniolo", 8, "OrtaSaha"));
            Team1.Add(new Other(70, "Dries", "Mertens", 9, "OrtaSaha"));
            Team1.Add(new Other(65, "Kerem", "Aktürkoğlu", 10, "OrtaSaha"));
            Team1.Add(new Other(75, "Mauro", "İcardi", 11, "Forvet"));

            //Team2 Takımı Kuruluyo
            List<Players> Team2 = new List<Players>();
            Team2.Add(new GoalKeeper(70, "Altay", "Bayındır", 1, "Kaleci"));
            Team2.Add(new Other(70, "Ferdi", "Kadıoğlu", 2, "Defans"));
            Team2.Add(new Other(70, "Attila", "Szalai", 3, "Defans"));
            Team2.Add(new Other(65, "Serdar", "Aziz", 4, "Defans"));
            Team2.Add(new Other(65, "Osayi", "Samuel", 5, "Defans"));
            Team2.Add(new Other(65, "Willian", "Arao", 6, "OrtaSaha"));
            Team2.Add(new Other(75, "Arda", "Güler", 7, "OrtaSaha"));
            Team2.Add(new Other(70, "Miha", "Zajc", 8, "OrtaSaha"));
            Team2.Add(new Other(70, "İrfanCan", "Kahveci", 9, "OrtaSaha"));
            Team2.Add(new Other(65, "Joshua", "King", 10, "Forvet"));
            Team2.Add(new Other(75, "Enner", "Valencia", 11, "Forvet"));

            Random rnd = new Random();

            // Her hangi bir takım 3 gole ulaşana dek döngü devam edecek
            int golteam1 = 0, golteam2 = 0, pas = 0;
            bool topteam1 = true, calindi = false;
            int kimde = 12;
            while (golteam1 < 3 && golteam2 < 3)
            {
                //Topa Sahip Olan Takım Team1 İse
                if (topteam1)
                {
                    int siradaki = kimde;
                    //Top Önceden Çalınarak Alınmadı ise (Yani Pas Atıldıysa) Farklı Kişinin Topa Sahip olması Gerekir 
                    //Bunun kontrolünü calindi ile yapacaz
                    if (calindi == false)
                    {
                    //Pası Atan ile Pası Alan Oyuncunun Aynı kişi olmaması gerekecektir. Döngü içerisinde farklı biri olmasını kontrol edecez.
                    don:
                        siradaki = rnd.Next(1, 12);
                        if (kimde == siradaki)
                        {
                            goto don;
                        }
                        kimde = siradaki;
                    }
                    calindi = false;
                geri:
                    //Pas mı Şut mu Çalım mı atacağına rastgele karar vermek için  rand isimli değişkeni kullacaz
                    int rand = rnd.Next(1, 11);
                    //Eğer Rand 1 ise Bu oyuncu Pas Atacaktır
                    if (rand <5)
                    {
                        //PasAt fonksiyonu ile gelen değer 70'den büyük ise pas Başarılı sayılacak
                        if (Team1[siradaki - 1].pasat()+rnd.Next(1,20) > 77+rnd.Next(1,20))
                        {
                            pas++;
                            Console.WriteLine(Team1[siradaki - 1].Ad + " Mükemmel Bir pas Gönderdi");
                            System.Threading.Thread.Sleep(2000);
                        }
                        //Değilse Pas Başarısız Sayılacak
                        else
                        {
                            topteam1 = false;
                            pas = 0;
                            Console.WriteLine(Team1[siradaki - 1].Ad + " Hatalı Bir pas Gönderdi");
                            System.Threading.Thread.Sleep(2000);
                        }
                    }
                    //Eğer Rand=2 ise Bu oyuncu Şut Çekecektir
                    else if (rand <9)
                    {
                        //Şut Çeken Kişinin Kaleci olmadığı ve En az 5 pas Atıldığı Kontrol Edilmektedir
                        if (Team1[siradaki - 1].Mevki == "Kaleci" || pas < 5)
                        {
                            //Yeni Bir Seçim yapmak için Rand Sayısını Tekrar belirlenmeli ve geri dönmelidir
                            goto geri;
                        }
                        else
                        {
                            //Şutun Gücü İle Kalecinin kurtarış puanları kıyaslanır. Şut gücü yüksekse vuruş gol sayılır
                            if (Team1[siradaki - 1].sutat() + Convert.ToInt32(pas / 1.5)+rnd.Next(1, 20) < Team2[0].kurtar()+rnd.Next(1, 24))
                            {
                                kimde = 1;
                                topteam1 = false;
                                calindi = true;
                                Console.WriteLine(Team1[siradaki - 1].Ad + " Çok Güzel Vurdu Fakat Olmadı " + Team2[0].Ad + " Aynı Güzellikte Çıkardı");
                                System.Threading.Thread.Sleep(2000);
                                pas = 0;
                            }
                            else
                            {
                                golteam1++;
                                Console.WriteLine(Team1[siradaki - 1].Ad + " Çok Güzel Vurdu Top Ağlarda \n" + Team2[0].Ad + " Çaresiz \n MÜKEMMEL BİR GOL OLDU");
                                Console.WriteLine("             TEAM1= " + golteam1 + " TEAM2= " + golteam2);
                                System.Threading.Thread.Sleep(2000);
                                pas = 0;
                                topteam1 = false;

                            }
                        }
                    }
                    //Eğer Rand = 3 ise oyuncu Çalım Atacak
                    else
                    {
                        //Top Kalecide ise Çalım Atamaz 
                        if (Team1[siradaki - 1].Mevki == "Kaleci")
                        {
                            goto geri;
                        }
                        int calimgucu = Team1[siradaki - 1].calım();
                        //Defans Oyuncusu Çalım Atmaya Kalktığında Çalım Gücü 5 Düşer
                        if (Team1[siradaki - 1].Mevki == "Defans")
                        {
                            calimgucu -= 5;
                        }
                        //Topu Kapmaya Çalışan Oyuncuyu Forvet ise top Çalma gücü 5 Düşer
                        int kim = rnd.Next(1, 11);
                        int topkap = Team2[kim - 1].topkap();
                        if (Team2[kim - 1].Mevki == "Forvet")
                        {
                            topkap -= 5;
                        }
                        //Çalım Atma Gücü İle Top Kapma Gücü puanları kıyaslanır. Çalım gücü yüksekse Çalım Başarılı sayılır ve Bu 3 Pas Değerindedir.
                        if (calimgucu + rnd.Next(1, 25) > topkap + rnd.Next(1, 25))
                        {
                            Console.WriteLine(Team1[siradaki - 1].Ad + " Çok Güzel Bir Çalım Attı " + Team2[kim].Ad + " Adeta Bakkala Ekmek Almaya Gitti");
                            System.Threading.Thread.Sleep(2000);
                            pas += 3;
                            //Top Aynı Oyuncuda Kalacağı için geri Gidip Bu oyuncuya Bir Hamle daha Yaptıracaz.
                            goto geri;
                        }
                        else
                        {
                            topteam1 = false;
                            kimde = kim;
                            calindi = true;
                            Console.WriteLine(Team1[siradaki - 1].Ad + " Bir Çalım Denedi Fakat Olmadı " + Team2[kim].Ad + " Adeta Söktü Aldı Topu");
                            System.Threading.Thread.Sleep(2000);
                            pas = 0;
                        }
                    }
                }
                if (topteam1 == false)
                {
                    int siradaki = kimde;
                    //Top Önceden Çalınarak Alınmadı ise (Yani Pas Atıldıysa) Farklı Kişinin Topa Sahip olması Gerekir 
                    //Bunun kontrolünü calindi ile yapacaz
                    if (calindi == false)
                    {
                    //Pası Atan ile Pası Alan Oyuncunun Aynı kişi olmaması gerekecektir. Döngü içerisinde farklı biri olmasını kontrol edecez.
                    don:
                        siradaki = rnd.Next(1, 12);
                        if (kimde == siradaki)
                        {
                            goto don;
                        }
                        kimde = siradaki;
                    }
                    calindi = false;
                geri:
                    //Pas mı Şut mu Çalım mı atacağına rastgele karar vermek için  rand isimli değişkeni kullacaz
                    int rand = rnd.Next(1, 11);
                    //Eğer Rand 1 ise Bu oyuncu Pas Atacaktır
                    if (rand <5)
                    {
                        //PasAt fonksiyonu ile gelen değer 70'den büyük ise pas Başarılı sayılacak
                        if (Team2[siradaki - 1].pasat() + rnd.Next(1, 20) > 77 + rnd.Next(1, 20))
                        {
                            pas++;
                            Console.WriteLine(Team2[siradaki - 1].Ad + " Mükemmel Bir pas Gönderdi");
                            System.Threading.Thread.Sleep(2000);
                        }
                        //Değilse Pas Başarısız Sayılacak
                        else
                        {
                            topteam1 = true;
                            pas = 0;
                            Console.WriteLine(Team2[siradaki - 1].Ad + " Pası Başarısız");
                            System.Threading.Thread.Sleep(2000);
                        }
                    }
                    //Eğer Rand=2 ise Bu oyuncu Şut Çekecektir
                    else if (rand <9)
                    {
                        //Şut Çeken Kişinin Kaleci olmadığı ve En az 5 pas Atıldığı Kontrol Edilmektedir
                        if (Team2[siradaki - 1].Mevki == "Kaleci" || pas < 5)
                        {
                            //Yeni Bir Seçim yapmak için Rand Sayısını Tekrar belirlenmeli ve geri dönmelidir
                            goto geri;
                        }
                        else
                        {
                            //Şutun Gücü İle Kalecinin kurtarış puanları kıyaslanır. Şut gücü yüksekse vuruş gol sayılır
                            if (Team2[siradaki - 1].sutat() + Convert.ToInt32(pas / 1.5) + rnd.Next(1, 20) < Team1[0].kurtar() + rnd.Next(1, 24))
                            {
                                kimde = 1;
                                topteam1 = true;
                                calindi = true;
                                Console.WriteLine(Team2[siradaki - 1].Ad + " Güzel Vurdu Fakat Olmadı " + Team1[0].Ad + " Aynı Güzellikte Çıkardı");
                                System.Threading.Thread.Sleep(2000);
                                pas = 0;
                            }
                            else
                            {
                                golteam2++;
                                Console.WriteLine(Team2[siradaki - 1].Ad + " Çok Güzel Vurdu Top Ağlarda \n" + Team1[0].Ad + " Çaresiz \n MÜKEMMEL BİR GOL OLDU");
                                Console.WriteLine("             TEAM1= " + golteam1 + " TEAM2= " + golteam2);
                                pas = 0;
                                System.Threading.Thread.Sleep(2000);
                                topteam1 = true;

                            }
                        }
                    }
                    //Eğer Rand = 3 ise oyuncu Çalım Atacak
                    else
                    {
                        //Top Kalecide ise Çalım Atamaz 
                        if (Team2[siradaki - 1].Mevki == "Kaleci")
                        {
                            goto geri;
                        }
                        int calimgucu = Team2[siradaki - 1].calım();
                        //Defans Oyuncusu Çalım Atmaya Kalktığında Çalım Gücü 5 Düşer
                        if (Team2[siradaki - 1].Mevki == "Defans")
                        {
                            calimgucu -= 5;
                        }
                        //Topu Kapmaya Çalışan Oyuncuyu Forvet ise top Çalma gücü 5 Düşer
                        int kim = rnd.Next(1, 11);
                        int topkap = Team1[kim - 1].topkap();
                        if (Team1[kim - 1].Mevki == "Forvet")
                        {
                            topkap -= 5;
                        }
                        //Çalım Atma Gücü İle Top Kapma Gücü puanları kıyaslanır. Çalım gücü yüksekse Çalım Başarılı sayılır ve Bu 3 Pas Değerindedir.
                        if (calimgucu + rnd.Next(1, 25) > topkap + rnd.Next(1, 25))
                        {
                            Console.WriteLine(Team2[siradaki - 1].Ad + " Çok Güzel Bir Çalım Attı " + Team1[kim].Ad + " Adeta Bakkala Ekmek Almaya Gitti");
                            System.Threading.Thread.Sleep(2000);
                            pas += 3;
                            //Top Aynı Oyuncuda Kalacağı için geri Gidip Bu oyuncuya Bir Hamle daha Yaptıracaz.
                            goto geri;
                        }
                        else
                        {
                            topteam1 = true;
                            kimde = kim;
                            calindi = true;
                            Console.WriteLine(Team2[siradaki - 1].Ad + " Bir Çalım Denedi Fakat Olmadı " + Team1[kim].Ad + " Adeta Söktü Aldı Topu");
                            System.Threading.Thread.Sleep(2000);
                            pas = 0;
                        }
                    }
                }
            }
            Console.WriteLine("VEEE MAÇ BİTTİ\nTEAM1="+golteam1+" TEAM2="+golteam2);
            Console.ReadLine();
        }

    }
}
