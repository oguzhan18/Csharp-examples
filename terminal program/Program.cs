using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
  

        static void Main(string[] args)
        { Console.ForegroundColor = ConsoleColor.Cyan; Console.Title = "ÇART APP";
            string klc_adi,komut;


            Console.WriteLine("ÇART APP (c) 2020 komut işlemci  ");//Bu kısmı değiştirmek yasaktır... 
            Console.Write("Komutları görmek için help komutu ile görebilirsinbiz."+"Bir kullanıcı adı belirleyiniz =  ");
            klc_adi = Convert.ToString(Console.ReadLine());
            Console.Write("ÇART APP/" + klc_adi+"> ");
            komut = Convert.ToString(Console.ReadLine());
            if (komut=="help")
            {
                Console.Write("werghew");
             
            }
           else if (komut == "dosya oluştur")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("bütün dosyalar c diskine kayıt olucaktır.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Directory.CreateDirectory(@"C:\ÇART APP TERMİNAL DOSYASI");
            }
            Console.Write("ÇART APP/" + klc_adi + "> " + Console.ReadLine());






            Console.ReadKey();
        }
    }
}
