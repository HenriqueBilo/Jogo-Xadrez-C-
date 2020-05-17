using System;
using tabuleiro;

namespace xadrez
{
    class Rei: Peca
    {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
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

            //Jogada Especial = Roque
            if(qteMovimentos == 0 && !partida.xeque)
            {
                //Roque pequeno = A torre está 3 colunas de diferença do rei
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if(testeTorreParaRoque(posT1))
                {
                    //Verifica se as 2 colunas entre o rei e a Torre estão livres
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if(tab.peca(p1) == null && tab.peca(p2) == null) 
                    {
                        //Disponibiliza o movimento
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                //Roque Grande = A torre está 4 colunas de diferença do rei
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeTorreParaRoque(posT2))
                {
                    //Verifica se as 2 colunas entre o rei e a Torre estão livres
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                    {
                        //Disponibiliza o movimento
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return mat;
        }

        //Testa se a torre está disponível para realizar a jogada Roque
        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;
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
