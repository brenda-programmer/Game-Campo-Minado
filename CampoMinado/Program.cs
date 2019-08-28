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


            //---------POPULA OS VIZINHOS DAS BOMBAS DA MATRIZ MINA ------

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    // Encontrando onde está a bomba
                    if (mina[i, j] == "*")
                    {
                        // Definindo os vizinhos da bomba (onde será acrescido 1)

                        int[] a = new int[3];// valores para linha dos vizinhos
                        int[] b = new int[3];// valores para coluna dos vizinhos

                        a[0] = i; a[1] = i + 1; a[2] = i - 1;
                        b[0] = j; b[1] = j + 1; b[2] = j - 1;

                        /* (i , j) - é o local da bomba (não acrescenta)
                         *
                         * vizinhos da bomba (onde acrescenta 1):
                         * 
                         * (i , j+1)
                         * (i , j-1)
                         * 
                         * (i+1 , j)
                         * (i+1 , j+1)
                         * (i+1 , j-1)
                         * 
                         * (i-1 , j)
                         * (i-1 , j+1)
                         * (i-1 , j-1)
                         * 
                         */

                        // Fazendo a combinação dos valores de linha e coluna para listar os vizinhos
                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 3; y++)
                            {

                                if (a[x] == i && b[y] == j)
                                {
                                    //mesma linha, mesma coluna (não acrescenta)
                                }
                                else if (a[x] < 5 && b[y] < 5 && a[x] >= 0 && b[y] >= 0)
                                {
                                    //se os valores de linha e coluna estiverem entre 0 e 5, acessa a função Soma
                                    Soma(a[x], b[y]);
                                }


                            }
                        }

                    }

                }
            }

            /* imprimindo o campo definido

           Console.WriteLine();
           Console.WriteLine("Campo criado:");

           for(int i=0; i < 5; i++)
           {
               Console.WriteLine("");

               for (int j = 0; j < 5; j++)
               {
                   Console.Write(mina[i,j]+" ");
               }
           }
           Console.WriteLine(); */



            //Apaga o que tiver na tela para iniciar o jogo
            Console.Clear();

            //Função que inicia o jogo para o usuário
            Jogar();


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

        //-----------FUNÇÃO QUE SOMA 1 NOS VIZINHOS DA BOMBA------------------------
        static void Soma(int x, int y)
        {
            //se o vizinho não for uma bomba, pode acrescentar 1
            if (mina[x, y] != "*")
            {
                int mod1 = int.Parse(mina[x, y]) + 1;
                mina[x, y] = mod1.ToString(); // converte inteiro para string
            }

        }

        //-----------FUNÇÃO ONDE O USUÁRIO JOGA O CAMPO MINADO-----------------------------------------
        static void Jogar()
        {
            string escolha = "";
            int pontos = 0;

            // campo inicial antes de entrar no while
            CampoInicial();

            //entra no while e mostra o campo atualizado conforme a escolha do usuário
            while (escolha != "*")
            {
                pontos++;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.WriteLine("JOGAR: ");
                Console.WriteLine("");

                Console.WriteLine("Digite a coordenada desejada x,y ");
                Console.Write(">> ");

                Console.ForegroundColor = ConsoleColor.Green;
                string[] temp = Console.ReadLine().Split(',');

                int x = int.Parse(temp[0]) - 1;
                int y = int.Parse(temp[1]) - 1;

                // se o usuário informar coordenada já informada antes, o ponto recebido será anulado
                if (campo[x, y] != "#")
                {
                    pontos--;
                }

                campo[x, y] = mina[x, y];
                escolha = mina[x, y];

                Console.Clear(); // apaga o que estava na tela e mostra o campo atualizado

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("▒▒▒▒▒ CAMPO MINADO ▒▒▒▒▒ ");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("     1  2  3  4  5");
                Console.WriteLine("   ╔═══════════════╗ ");

                for (int k = 0; k < 5; k++)
                {
                    Console.Write(" " + (k + 1) + " ║");

                    for (int j = 0; j < 5; j++)
                    {
                        if (campo[k, j] != "#")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        if (campo[k, j] == "*")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            pontos--;
                        }
                        Console.Write(" " + campo[k, j] + " ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("║");
                    Console.WriteLine("");
                }
                Console.WriteLine("   ╚═══════════════╝ ");
                Console.WriteLine("               " + pontos + " pts");


            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("BOMBA!!! Tente novamente ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("PONTUAÇÃO TOTAL: " + pontos + " pts");

        }
    }
}
