//Bibliotecas
using System;
using System.Threading;


namespace jogoDaVelha
{
    class jogoDaVelha
    {
        //Algumas variaveis
        private bool fimDeJogo;
        private char[] posicoes;
        private char vez;
        private int qtdpreenchida;
        private string start;
        private int atraso;

        public jogoDaVelha()
        {
            fimDeJogo = false;
            posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'x';
            qtdpreenchida = 0;
            atraso = 2000;
        }

        public void iniciar()
        {
            //Isso aqui é o jogo rodando
            //Vou rodar numa estrutura WHILE até que uma condição para fechar o sistema aconteça

            //Uma interação simples
            Enunciado();
            
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
            Console.WriteLine($"Olá! Bem vindo ao Jogo da velha!\n\nSó um minuto para eu achar aqui a tabela do jogo...");
            Thread.Sleep(atraso);
            Console.Clear();
            Thread.Sleep(atraso);
            Console.WriteLine($"Espero que goste de jogos no console.");
            Thread.Sleep(atraso);
            Console.Clear();
            Console.WriteLine($"Espero que goste de jogos no console..");
            Thread.Sleep(atraso);
            Console.Clear();
            Console.WriteLine($"Espero que goste de jogos no console...");
            Thread.Sleep(atraso);
            Console.WriteLine($"Certo!\n Carregando jogo...");
            Thread.Sleep(atraso);

        }

        //para alternar o input
        private void MudarVez()
        {            
            vez = vez == 'x' ? 'O' : 'x';
        }

        //A partir da terceira jogada é possível validar se há vencedores
        private void VerificarFimdejogo()
        {
            //Contados de rodadas
            if (qtdpreenchida < 3)
                return;
            //Verifica se alguma condição de vitoria foi atingida
            if (vitoriaDiagonal() || vitoriaHorizontal() || vitoriaVertical())
            {
                fimDeJogo = true;
                Console.WriteLine($"Fim de jogo!!! Vitoria de {vez}");
                return;
            }
            //Verifica se o jogo chegou ao limite de preenchimento
            if (qtdpreenchida is 9)
            {
                fimDeJogo = true;
                Console.WriteLine($"Fim de jogo!!! Empate!");
            }
        }
        //Condições de vitoria:
        //Vitoria em linhas
        private bool vitoriaHorizontal()
        {
            bool linha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool linha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool linha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return linha1 || linha2 || linha3;
        }
        //Vitoria em colunas
        private bool vitoriaVertical()
        {
            bool coluna1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool coluna2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool coluna3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return coluna1 || coluna2 || coluna3;

        }
        //Vitoria em X
        private bool vitoriaDiagonal()
        {
            bool diagonal1 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];
            bool diagonal2 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];

            return diagonal1 || diagonal2;

        }
        //Esse metodo vai servir para ler input de tela do usuário e validar se está dentro do range permitido
        // e também chama outro metodo que valida se o campo escolhido já não foi preenchido
        private void lerEscolhaDoUsuario()
        {
            bool conversao = int.TryParse(s:Console.ReadLine(), out int posicaoEscolhida);

            while (posicaoEscolhida > 9 || posicaoEscolhida < 1|| !conversao || !ValidarEscolhaUsuario(posicaoEscolhida) )
            {
                Console.WriteLine("O campo escolhido é invalido! Por favor escolha um valor de  1 a 9 que esteja disponível na tabela");
                conversao = int.TryParse(s: Console.ReadLine(), out posicaoEscolhida);
            }

            atualizarJogo(posicaoEscolhida);

        }
        //Esse metodo atualiza a tabela do jogo de acordo com a jogada
        private void atualizarJogo( int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;

            posicoes[indice] = vez;
            qtdpreenchida++;


        }
        //Isso aqui valida que o local aonde foi selecionada não esteja com valor "o" ou "x" voltando um true or false para o metodo lerEscolhaUsuario
        private bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;
            return posicoes[indice] != 'o' && posicoes[indice] != 'x';
        }
        //Esse metodo abaixo, acho que é autoexplicativo
        //mas se não for, ele renderiza a tabela no console
        private void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine($"Digite um valor de 1 a 9 para preencher um campo:");
            Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            //contrução da tabela
            return $"\n" +
                   $"           __{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"           __{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"           __{posicoes[6]}__|__{posicoes[7]}__|__{posicoes[8]}__\n" +
                   $"                |     |                 \n";

        }
    }
}
