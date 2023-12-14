public class Distancia
{
    public string PontoInicial { get; }
    public string PontoFinal { get; }
    public double Valor { get; }

    public Distancia(string pontoInicial, string pontoFinal, double valor)
    {
        PontoInicial = pontoInicial;
        PontoFinal = pontoFinal;
        Valor = valor;
    }
}

