using System;
using tabuleiro;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                //Bota o número das linhas (de acordo com o tabuleiro de xadrez)
                Console.Write(8 - i + " ");
                for(int j = 0; j < tab.colunas; j++)
                {
                    //Caso não tenha peça, imprime um '-'
                    if(tab.peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    //Se tiver peça, chama a função de imprimir a peça
                    else
                    {
                        imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            //Bota a letra das colunas (de acordo com o tabuleiro de xadrez)
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                //Salva a cor original do fundo
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                //Volta pra cor normal para a próxima peça
                Console.ForegroundColor = aux;
            }
        }

    }
}
