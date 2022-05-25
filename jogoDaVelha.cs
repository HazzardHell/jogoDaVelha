using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoDaVelha
{
    class jogoDaVelha
    {
        private bool fimDeJogo;
        private char[] posicoes;
        private char vez;
        private int qtdpreenchida;
        private char enunciado;

        public jogoDaVelha()
        {
            fimDeJogo = false;
            posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'x';
            qtdpreenchida = 0;
        }

        public void iniciar()
        {
            
            while (!fimDeJogo)
            {                
                RenderizarTabela();
                lerEscolhaDoUsuario();
                RenderizarTabela();
                VerificarFimdejogo();
                MudarVez();
                 
            }
        }

        private void Enunciado()
        {
            Console.WriteLine($"Olá! digite um valor de 0 a 9 para podermos começar o jogo!");
        }

        private void MudarVez()
        {
            vez = vez == 'x' ? 'O' : 'x';
        }

        private void VerificarFimdejogo()
        {
            if (qtdpreenchida < 3)
                return;

            if (vitoriaDiagonal() || vitoriaHorizontal() || vitoriaVertical())
            {
                fimDeJogo = true;
                Console.WriteLine($"Fim de jogo!!! Vitoria de {vez}");
                return;
            }

            if(qtdpreenchida is 9)
            {
                fimDeJogo = true;
                Console.WriteLine($"Fim de jogo!!! Empate!");
            }
        }

        private bool vitoriaHorizontal()
        {
            bool linha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool linha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool linha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return linha1 || linha2 || linha3;
        }

        private bool vitoriaVertical()
        {
            bool coluna1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool coluna2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool coluna3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return coluna1 || coluna2 || coluna3;

        }

        private bool vitoriaDiagonal()
        {
            bool diagonal1 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];
            bool diagonal2 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];

            return diagonal1 || diagonal2;

        }

        private void lerEscolhaDoUsuario()
        {
            bool conversao = int.TryParse(s:Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
                Console.WriteLine("O campo escolhido é invalido! Por favor escolha um valor de  1 a 9 que esteja disponível na tabela");
                conversao = int.TryParse(s: Console.ReadLine(), out posicaoEscolhida);
            }

            atualizarJogo(posicaoEscolhida);

        }

        private void atualizarJogo( int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            posicoes[indice] = vez;
            qtdpreenchida++;


        }

        private bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;
            return posicoes[indice] != 'o' && posicoes[indice] != 'x';
        }

        private void RenderizarTabela()
        {
            Console.Clear();
            Enunciado();
            Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            return $"\n" +
                   $"           __{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"           __{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"           __{posicoes[6]}__|__{posicoes[7]}__|__{posicoes[8]}__\n" +
                   $"                |     |                 \n";

        }
    }
}
