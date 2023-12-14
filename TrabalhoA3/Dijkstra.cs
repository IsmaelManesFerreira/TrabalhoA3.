using System;
using System.Collections.Generic;
using System.Linq;

public static class Dijkstra
{
    public static void EncontrarDistancia(List<Distancia> distancias, string pontoInicial, string pontoFinal)
    {
        Dictionary<string, double> distanciasMinimas = new Dictionary<string, double>();
        Dictionary<string, string> predecessores = new Dictionary<string, string>();
        List<string> verticesNaoVisitados = new List<string>();

        foreach (Distancia distancia in distancias)
        {
            if (!distanciasMinimas.ContainsKey(distancia.PontoInicial))
            {
                distanciasMinimas[distancia.PontoInicial] = double.MaxValue;
                verticesNaoVisitados.Add(distancia.PontoInicial);
            }

            if (!distanciasMinimas.ContainsKey(distancia.PontoFinal))
            {
                distanciasMinimas[distancia.PontoFinal] = double.MaxValue;
                verticesNaoVisitados.Add(distancia.PontoFinal);
            }
        }

        distanciasMinimas[pontoInicial] = 0;

        while (verticesNaoVisitados.Any())
        {
            string verticeAtual = verticesNaoVisitados.OrderBy(v => distanciasMinimas[v]).FirstOrDefault();

            if (verticeAtual == null)
            {
                break; 
            }

            verticesNaoVisitados.Remove(verticeAtual);

            foreach (Distancia vizinho in distancias.Where(d => d.PontoInicial == verticeAtual))
            {
                double distanciaAtual = distanciasMinimas[verticeAtual] + vizinho.Valor;

                if (distanciaAtual < distanciasMinimas[vizinho.PontoFinal])
                {
                    distanciasMinimas[vizinho.PontoFinal] = distanciaAtual;
                    predecessores[vizinho.PontoFinal] = verticeAtual;
                }
            }
        }

        ExibirMenorCaminho(distanciasMinimas, predecessores, pontoInicial, pontoFinal);
    }

    private static void ExibirMenorCaminho(Dictionary<string, double> distanciasMinimas, Dictionary<string, string> predecessores, string pontoInicial, string pontoFinal)
    {
        List<string> caminho = new List<string>();

        string pontoAtual = pontoFinal;

        while (!string.IsNullOrEmpty(pontoAtual))
        {
            caminho.Insert(0, pontoAtual);
            pontoAtual = predecessores.TryGetValue(pontoAtual, out string value) ? value : null;
        }

        Console.WriteLine("Menor caminho de {pontoInicial} para {pontoFinal}:");
        Console.WriteLine(string.Join(" -> ", caminho));

        var distanciaTotal = distanciasMinimas.TryGetValue(pontoFinal, out double valor) ? valor : 0;
        Console.WriteLine("Distância total: {distanciaTotal}");

        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
    }
}

