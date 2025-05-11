using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

// Exercicio 1 - Soma de 1 até INDICE
class Exercicio1
{
    static void Main()
    {
        int INDICE = 13;
        int SOMA = 0;
        int K = 0;

        while (K < INDICE)
        {
            K = K + 1;
            SOMA = SOMA + K;
        }

        Console.WriteLine("Valor final de SOMA: " + SOMA);
    }
}

// Exercicio 2 - Verificar se um número pertence à sequência de Fibonacci
class Exercicio2
{
    static void Main()
    {
        Console.Write("Digite um número para verificar se pertence à sequência de Fibonacci: ");
        int numero = int.Parse(Console.ReadLine());

        int a = 0;
        int b = 1;

        if (numero == a || numero == b)
        {
            Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci.");
            return;
        }

        int fibonacci = a + b;

        while (fibonacci < numero)
        {
            a = b;
            b = fibonacci;
            fibonacci = a + b;
        }

        if (fibonacci == numero)
            Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci.");
        else
            Console.WriteLine($"O número {numero} NÃO pertence à sequência de Fibonacci.");
    }
}

// Exercicio 3 - Faturamento diário e análise
class FaturamentoDiario
{
    public int dia { get; set; }
    public double valor { get; set; }
}

class Exercicio3
{
    static void Main()
    {
        try
        {
            string json = File.ReadAllText("faturamento.json");
            List<FaturamentoDiario> faturamento = JsonSerializer.Deserialize<List<FaturamentoDiario>>(json);

            var diasComFaturamento = faturamento.Where(f => f.valor > 0).ToList();

            if (diasComFaturamento.Count == 0)
            {
                Console.WriteLine("Não há dias com faturamento positivo.");
                return;
            }

            double menorValor = diasComFaturamento.Min(f => f.valor);
            double maiorValor = diasComFaturamento.Max(f => f.valor);
            double media = diasComFaturamento.Average(f => f.valor);
            int diasAcimaDaMedia = diasComFaturamento.Count(f => f.valor > media);

            Console.WriteLine($"Menor faturamento do mês: R$ {menorValor:F2}");
            Console.WriteLine($"Maior faturamento do mês: R$ {maiorValor:F2}");
            Console.WriteLine($"Dias com faturamento acima da média mensal (R$ {media:F2}): {diasAcimaDaMedia}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao processar os dados: " + ex.Message);
        }
    }
}

// Exercicio 4 - Percentual de faturamento por estado
class Exercicio4
{
    static void Main()
    {
        double sp = 67836.43;
        double rj = 36678.66;
        double mg = 29229.88;
        double es = 27165.48;
        double outros = 19849.53;

        double totalFaturamento = sp + rj + mg + es + outros;

        double percentualSP = (sp / totalFaturamento) * 100;
        double percentualRJ = (rj / totalFaturamento) * 100;
        double percentualMG = (mg / totalFaturamento) * 100;
        double percentualES = (es / totalFaturamento) * 100;
        double percentualOutros = (outros / totalFaturamento) * 100;

        Console.WriteLine($"Percentual de SP: {percentualSP:F2}%");
        Console.WriteLine($"Percentual de RJ: {percentualRJ:F2}%");
        Console.WriteLine($"Percentual de MG: {percentualMG:F2}%");
        Console.WriteLine($"Percentual de ES: {percentualES:F2}%");
        Console.WriteLine($"Percentual de Outros: {percentualOutros:F2}%");
    }
}

// Exercicio 5 - Inverter os caracteres de uma string
class Exercicio5
{
    static void Main()
    {
        Console.Write("Digite uma string para inverter: ");
        string entrada = Console.ReadLine();

        string stringInvertida = InverterString(entrada);

        Console.WriteLine($"String invertida: {stringInvertida}");
    }

    static string InverterString(string str)
    {
        char[] caracteres = str.ToCharArray();
        int inicio = 0;
        int fim = caracteres.Length - 1;

        while (inicio < fim)
        {
            char temp = caracteres[inicio];
            caracteres[inicio] = caracteres[fim];
            caracteres[fim] = temp;

            inicio++;
            fim--;
        }

        return new string(caracteres);
    }
}
