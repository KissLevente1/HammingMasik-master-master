using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HammingMasik
{
    class Program
    {

        static string sokszorVege(string szo, int mennyi)
        {
            string vege = "";
            for (int j = 0; j < mennyi+1; j++)
            {
                for (int i = mennyi; i > 0; i--)
                {
                    vege += szo[szo.Length - i];
                }
            }

            

            return vege;

            
        }

        static List<string> HammingLista(string szo, List<string> lista)
        {
            List<string> jok = new List<string>();
            foreach (var x in lista)
            {
                if (HammingErtek(szo ,x)<=3)
                {
                    jok.Add(x);
                }
            }
            return jok;
        }
        static int HammingErtek(string szo1, string szo2) 
        {
            int ham = 0;
            for (int i = 0; i < szo2.Length; i++)
            {
                if (szo1[i]!=szo2[i])
                {
                    ham++;
                }
            }
            Console.WriteLine($"Hamming távolság: {ham} ");
            return ham;
            
            
        }
        static void Main(string[] args)
        {

            StreamReader be = new StreamReader("humming.txt");
            StreamWriter kiir=new StreamWriter("kiir.txt");
            string szo = "";
            List<string> lista = new List<string>();

            while (!be.EndOfStream)
            {
                // adatok beolvasása és lista elkészítése
                szo = be.ReadLine();
                string[] tmp = be.ReadLine().Split(';');
                lista.Clear();
                foreach (var t in tmp)
                {
                    lista.Add(t);
                }

                Console.WriteLine($"szó: {szo}");
                Console.Write("lista: ");
                kiir.Write(szo);
                foreach (var l in lista)
                {
                    Console.Write($"{l}, ");
                    kiir.Write($"{l}, ");
                }

                Console.Write("\nEredmény:");
                kiir.Write("\nEredmény:");
                HammingLista(szo,lista);
                foreach (var item in HammingLista(szo, lista))
                {
                    Console.Write($"{item} ");
                    kiir.Write($"{item} ");
                }

                Console.WriteLine();
            }

            
            

            be.Close();
            kiir.Close();


            Console.Write("Adj meg egy szót     ");
            string szoo=Console.ReadLine();

            Console.Write("Adj meg egy számot   ");
            int szam = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(sokszorVege(szoo, szam));


            Console.ReadKey();
        }
    }
}
