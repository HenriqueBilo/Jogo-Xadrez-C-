namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

        public void incrementarQtdeMovimentos()
        {
            qteMovimentos++;
        }

        public void decrementarQtdeMovimentos()
        {
            qteMovimentos--;
        }

        public abstract bool[,] movimentosPossiveis();

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j < tab.colunas; j++)
                {
                    //Se a posição for verdadeira, existe pelo menos esse movimento possível para a peça
                    if(mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Verifica se a posição informada é possível (retorna um true/false da matriz boolean)
        public bool movimentoPossivel(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }
    }
}
