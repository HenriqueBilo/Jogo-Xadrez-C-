using System;
using tabuleiro;

namespace xadrez
{
    class Rei: Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            //Acima = Linha atual - 1 e a mesma coluna
            pos.definirValores(posicao.linha - 1, posicao.coluna);

            //Se a posição desejada é válida e a peça pode se mover para a mesma
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Posição nordeste (direita da posição acima) = Linha - 1, Coluna + 1
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Direita = Linha, Coluna + 1
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Sudeste = Linha + 1, coluna + 1
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Sul = Linha + 1, coluna
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Sudoeste = linha + 1, coluna - 1
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Esquerda = linha, coluna - 1
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //Noroeste = linha - 1, coluna - 1
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }

        //Verifica se o rei pode se mover para dada posição
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            /*
                Pode se mover quando a posição desejada estiver vazia 
                OU
                Quando a posição tiver uma peça inimiga
             */
            return p == null || p.cor != this.cor;
        }
    }
}
