using System;

namespace CampoMinado
{
    class Program
    {
        static string[,] mina = new string[5, 5];
        static string[,] campo = new string[5, 5];
        public static void Main(string[] args)
        {


            //----------POPULA MATRIZ CAMPO------------------------------------
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    campo[i, j] = "#";
                }
            }

            // Mostra o campo inicial
            CampoInicial();

        }

        //-----------FUNÇÃO QUE MOSTRA CAMPO INICIAL------------------------
        static void CampoInicial()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("▒▒▒▒▒ CAMPO MINADO ▒▒▒▒▒ ");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("     1  2  3  4  5");
            Console.WriteLine("   ╔═══════════════╗ ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(" " + (i + 1) + " ║");

                for (int j = 0; j < 5; j++)
                {
                    Console.Write(" " + campo[i, j] + " ");
                }
                Console.Write("║");
                Console.WriteLine("");
            }
            Console.WriteLine("   ╚═══════════════╝ ");
            Console.WriteLine("               0 pts");


        }
    }
}
