using System;

namespace CampoMinado
{
    class Program
    {
        static string[,] mina = new string[5, 5];
        static string[,] campo = new string[5, 5];
        static int quant;
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

            //----------POPULA MATRIZ MINA COM 0----------------------------
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mina[i, j] = "0";
                }
            }

            //----------POPULA MATRIZ MINA COM AS BOMBAS----------------------

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("CRIAR CAMPO: ");

            Console.WriteLine("");
            Console.Write("Digite a quantidade de bombas (de 1 a 5): ");

            Console.ForegroundColor = ConsoleColor.Green;
            quant = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite as coordenadas das bombas x,y ");

            for (int i = 0; i < quant; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(">> ");
                Console.ForegroundColor = ConsoleColor.Green;
                string[] temp = Console.ReadLine().Split(',');

                int x = int.Parse(temp[0]) - 1;
                int y = int.Parse(temp[1]) - 1;

                mina[x, y] = "*";


            }

            // imprimindo o campo definido
             
            Console.WriteLine("Campo criado:");
           
            for(int i=0; i < 5; i++)
            {
                Console.WriteLine("");

                for (int j = 0; j < 5; j++)
                {
                    Console.Write(mina[i,j]+" ");
                }
            }
            Console.WriteLine();
            


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
