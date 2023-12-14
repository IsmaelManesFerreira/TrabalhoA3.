using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class LeitorArquivoDistancias
{
    public static List<Distancia> LerDistanciaDoArquivo(string nomeArquivo)
    {
        List<Distancia> distancias = new List<Distancia>();

        try
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);

            foreach (var linha in linhas)
            {
                string[] partes = linha.Split(';');

                if (partes.Length == 3)
                {
                    string pontoInicial = partes[0].Trim();
                    string pontoFinal = partes[1].Trim();

                    if (double.TryParse(partes[2].Trim(), out double valor))
                    {
                        Distancia distancia = new Distancia(pontoInicial, pontoFinal, valor);
                        distancias.Add(distancia);
                    }
                    else
                    {
                        Console.WriteLine($"Erro de leitura: Valor inválido na linha '{linha}'");
                    }
                }
                else
                {
                    Console.WriteLine($"Erro de leitura: Formato inválido na linha '{linha}'");
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro ao ler o arquivo 'distancia.txt': ");
        }

        return distancias;
    }
}


