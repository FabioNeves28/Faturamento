using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        string json = File.ReadAllText("faturamento.json"); // lê o arquivo JSON com os dados de faturamento
        Faturamento faturamento = JsonSerializer.Deserialize<Faturamento>(json); // desserializa o JSON em um objeto Faturamento

        double menor = double.MaxValue;
        double maior = double.MinValue;
        double soma = 0;
        int diasAcimaMedia = 0;
        int diasValidos = 0;

        foreach (double valor in faturamento.valores)
        {
            if (valor > 0)
            {
                if (valor < menor)
                {
                    menor = valor;
                }
                if (valor > maior)
                {
                    maior = valor;
                }
                soma += valor;
                diasValidos++;
            }
        }

        double media = soma / diasValidos;

        foreach (double valor in faturamento.valores)
        {
            if (valor > media)
            {
                diasAcimaMedia++;
            }
        }

        Console.WriteLine("Menor valor de faturamento: " + menor);
        Console.WriteLine("Maior valor de faturamento: " + maior);
        Console.WriteLine("Número de dias com faturamento superior à média: " + diasAcimaMedia);
    }
}

class Faturamento
{
    public double[] valores { get; set; }
}
