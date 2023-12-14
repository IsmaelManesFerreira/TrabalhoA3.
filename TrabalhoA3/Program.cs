using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TrabalhoA3
{
    public static class Program
    {
        public static void Main()
        {
            
            string diretorioExecucao = AppDomain.CurrentDomain.BaseDirectory;

            
            string caminhoArquivo = Path.Combine(diretorioExecucao, "distancias.txt");

            
            if (!File.Exists(caminhoArquivo))
            {
                Console.WriteLine($"O arquivo 'distancias.txt' não foi encontrado no diretório: {diretorioExecucao}");
                Console.WriteLine("Certifique-se de colocar o arquivo no mesmo diretório do executável.");
                Console.WriteLine("Pressione qualquer tecla para sair.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            
            List<Distancia> distancias = LeitorArquivoDistancias.LerDistanciaDoArquivo(caminhoArquivo);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("1) Calcular distâncias entre pontos");
                Console.WriteLine("2) Criar pilha");
                Console.WriteLine("3) Criar fila");
                Console.WriteLine("4) Sair");

                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    Console.Clear();
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Lista de cidades:");
                            foreach (var item in distancias.Select(d => d.PontoInicial).Union(distancias.Select(d => d.PontoFinal)).Distinct())
                            {
                                Console.WriteLine(item);
                            }

                            Console.WriteLine("Qual o ponto de partida:");
                            var ponto1 = Console.ReadLine();
                            Console.WriteLine("Qual o destino final:");
                            var ponto2 = Console.ReadLine();

                            Dijkstra.EncontrarDistancia(distancias, ponto1!, ponto2!);
                            break;

                        case 2:
                            Stack<string> pilha = new Stack<string>();
                            foreach (var distancia in distancias)
                            {
                                if (!pilha.Contains(distancia.PontoInicial))
                                    pilha.Push(distancia.PontoInicial);
                            }

                            Console.WriteLine("Pilha:");
                            foreach (var cidade in pilha)
                                Console.WriteLine(cidade);
                            break;

                        case 3:
                            Queue<string> fila = new Queue<string>();
                            foreach (var distancia in distancias)
                            {
                                if (!fila.Contains(distancia.PontoInicial))
                                    fila.Enqueue(distancia.PontoInicial);
                            }

                            Console.WriteLine("Fila:");
                            foreach (var cidade in fila)
                                Console.WriteLine(cidade);
                            break;

                        case 4:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Opção inválida");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida, insira um número válido");
                }

                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
        }
    }
}
