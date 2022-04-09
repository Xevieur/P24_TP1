using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Program
    {
        static int n;
        static int i;
        static private int _nbcombine;
        static private int[,] _hasardcollection = new int[200, 6];
        static private int[] _gagnantcollection = new int[6];
        
        static void credit()
        {
            string nomapp = "Lotto6/49";
            string version = "1.0.0";
            string par = "Xavier Beaumont";
            Console.SetCursorPosition(40,0);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("{0}: Version {1} : {2}", nomapp, version, par);
            Console.ResetColor();
        }

        static bool terminer()
        {
            char c;
            for (; ; )
            {
                Console.Write("Voulez-vous refaire un tirage? (o/n) ? ");
                c = Convert.ToChar(Console.ReadLine());
                c = char.ToLower(c);
                if (c == 'o' || c == 'n') break;
            }

            if (c == 'n')
                return true;
            else
                return false;
        }

        static void hasard()
        {
            int[] combine = new int[6];
            int nbrow=0;
            Random hasard = new Random();
            bool[] sorti = new bool[49];

            Array.Clear(sorti, 0, sorti.Length);
            int no;

            do
           {
                no = hasard.Next(49);
                if (combine.Contains(no+1)==false)
                {
                    combine[nbrow] = no + 1;
                    _hasardcollection[_nbcombine, nbrow] = no + 1;
                    nbrow++;
                }

            }  while (nbrow <= 5);
            _nbcombine++;

            Array.Sort(combine);

                                                     
            for (i = 0; i < combine.Length; i++)
            {
                Console.Write("{0} ", combine[i]);
            }
            Console.ReadLine();

        }

        static void gagnant()
        {
            int[] combine = new int[6];
            int nbrow2=0;
            Random hasard = new Random(); 
            bool[] sorti = new bool[49]; 

            Array.Clear(sorti, 0, sorti.Length);
            int no;

            do
            {
                no = hasard.Next(49);
                if (combine.Contains(no + 1) == false)
                {
                    combine[nbrow2] = no + 1;
                    _gagnantcollection[nbrow2] = no + 1;
                    nbrow2++;
                }

            } while (nbrow2 <= 5);

            Array.Sort(combine);
            Array.Sort(_gagnantcollection);
            
            for (i = 0; i < combine.Length; i++)
            {
                Console.Write("{0} ", combine[i]);
            }

            Console.ReadLine();

            
        }

        static void complementaire()
        {
            int[] combine = new int[1];
            int i;
            Random hasard = new Random();
            bool[] sorti = new bool[49];

            Array.Clear(sorti, 0, sorti.Length);
            int no;

            for (i = 0; i < combine.Length; i++)
            {
                no = hasard.Next(49);
                combine[i] = no + 1;
            }

            Array.Sort(combine);

            Console.Write("Complementaire : ");
            for (i = 0; i < combine.Length; i++)
            {
                Console.Write("{0} ", combine[i]);
            }

            Console.ReadLine();
        }

        static void statistique()
        {
            Console.WriteLine("                                                                                             ");
            Console.WriteLine("STATISTIQUE :");
            Console.WriteLine("                                                                                             ");
            Console.WriteLine("tirage # : {0}", n);
            Console.WriteLine("                                                                                          ");
            statnum();
            Console.WriteLine("                                                                ");
            int _0sur6 = 0,_1sur6 =0 ,_2sur6 = 0, _3sur6 = 0, _4sur6 = 0, _5sur6 = 0, _6sur6 = 0;
            for (int e = 0; e <= _nbcombine-1; e++)
            {
                
                int resultat = 0;
                for (int i = 0; i <= 5; i++)
                {
                    int a = _hasardcollection[e, i];
                    resultat = resultat + System.Convert.ToInt32(_gagnantcollection.Contains(a));   
                }
                if (resultat == 3)
                {
                    _3sur6++;
                }
                else
                if (resultat == 4)
                {
                    _4sur6++;
                }
                else
                if (resultat == 5)
                {
                    _5sur6++;
                }
                else
                if (resultat == 6)
                {
                    _6sur6++;
                }
                else
                if (resultat == 2)
                {
                    _2sur6++;
                }
                else
                if (resultat == 1)
                {
                    _1sur6++;
                }
                else
                if (resultat == 0)
                {
                    _0sur6++;
                }
            }
            _0sur6 = 100*_0sur6/_nbcombine;
            Console.WriteLine("{0}% des combinaisons n'ont aucun chiffre sur les 6 gagnants. ",_0sur6);
            Console.WriteLine("                                                                ");


            _1sur6 = 100 * _1sur6 / _nbcombine;
            Console.WriteLine("{0}% des combinaisons n'ont que 1 chiffre gagnant sur les 6 gagnants. ", _1sur6);
            Console.WriteLine("                                                                ");


            _2sur6 = 100 * _2sur6 / _nbcombine;
            Console.WriteLine("{0}% des combinaisons n'ont que 2 chiffres gagnant sur les 6 gagnants. ", _2sur6);
            Console.WriteLine("                                                                ");


            _3sur6 = 100 * _3sur6 / _nbcombine;
            Console.WriteLine("{0}%  des combinaisons ont 3 chiffres gagnant sur les 6 gagnants. ", _3sur6);
            Console.WriteLine("                                                                ");


            _4sur6 = 100 * _4sur6 / _nbcombine;
            Console.WriteLine("{0}%  des combinaisons ont 4 chiffres gagnant sur les 6 gagnants. ", _4sur6);
            Console.WriteLine("                                                                ");

            _5sur6 = 100 * _5sur6 / _nbcombine;
            Console.WriteLine("{0}% des combinaisons ont 5 chiffres gagnant sur les 6 gagnants. ", _5sur6);
            Console.WriteLine("                                                                ");

            _6sur6 = 100 * _6sur6 / _nbcombine;
            Console.WriteLine("{0}% des combinaisons ont les 6 chiffres gagnant. ", _6sur6);
            Console.WriteLine("                                                                ");
            Console.ReadLine();
        }
        
        static void statnum()
        {
            int r1 = 0, r2 = 0, r3 = 0, r4 = 0, r5 = 0, r6 = 0;

            for (int e = 0; e <= _nbcombine - 1; e++)
            {
                int resultat = 0;
                for (int i = 0; i <= 5; i++)
                {
                    int a = _hasardcollection[e, i];
                    resultat =  Convert.ToInt32(_gagnantcollection.Contains(a));
                    if (resultat == 1 && i == 0)
                    {
                        r1++;
                    }
                    else
                    if (resultat == 1 && i==1)
                    {                      
                        r2++;
                    }
                    else
                    if (resultat == 1 && i==2)
                    {
                        r3++;
                    }
                    else
                    if (resultat == 1 && i==3)
                    {
                        r4++;
                    }
                    else
                    if (resultat == 5 && i == 4)
                    {
                        r5++;
                    }
                    else
                    if (resultat == 6 && i == 5)
                    {
                        r6++;
                    }
                }
            }
            for(int i =0;i<6;i++)
            {
                Console.Write("{0} ",_gagnantcollection[i]);

            }

            Console.WriteLine("                                                        ");
            Console.WriteLine("Le premier numero est apparu : {0} fois", r1);
            Console.WriteLine("Le deuxieme numero est apparu : {0} fois", r2);
            Console.WriteLine("Le troisieme numero est apparu : {0} fois", r3);
            Console.WriteLine("Le quatrieme numero est apparu : {0} fois", r4);
            Console.WriteLine("Le cinquieme numero est apparu : {0} fois", r5);
            Console.WriteLine("Le sixieme numero est apparu : {0} fois", r6);
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            
            for (n = 1; n <= 100; n++)
            {
                Console.Clear();
                credit();
                int comb=0;
                string str_rep;
                do
                {
                    Console.WriteLine("                                                                  ");
                    Console.Write("Combien de combinaison voulez-vous? (Entre 10 et 200) : ");
                    str_rep = Console.ReadLine();
                    Console.WriteLine("                                                                  ");

                } while (int.TryParse(str_rep, out comb) == false || comb < 10 || comb > 200);

                for (int i = 1; i <= comb;  i++)
                {
                    Console.WriteLine("combinaison " + i + ":" );
                    hasard();
                    Console.WriteLine("                                                                  ");
                }
                Console.ReadLine();

                Console.Write("La combinaison gagnante est :");
                gagnant();
                complementaire();

                statistique();

                if (terminer() == true) break;
            }
            Console.Clear();
            Console.SetCursorPosition(45,10);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Au Revoir À La Prochaine!");
            Console.ReadLine();
        }
    }
}
