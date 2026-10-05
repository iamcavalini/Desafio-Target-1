using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Venda
{
    [JsonPropertyName("vendedor")]
    public string Vendedor { get; set; } = string.Empty;

    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}

public class RelatorioVendas
{
    [JsonPropertyName("vendas")]
    public List<Venda> Vendas { get; set; } = new();
}

public class Program
{
    public static void Main()
    {
        string jsonVendas = @"
        {
          ""vendas"": [
            { ""vendedor"": ""João Silva"", ""valor"": 1200.50 },
            { ""vendedor"": ""João Silva"", ""valor"": 950.75 },
            { ""vendedor"": ""João Silva"", ""valor"": 1800.00 },
            { ""vendedor"": ""João Silva"", ""valor"": 1400.30 },
            { ""vendedor"": ""João Silva"", ""valor"": 1100.90 },
            { ""vendedor"": ""João Silva"", ""valor"": 1550.00 },
            { ""vendedor"": ""João Silva"", ""valor"": 1700.80 },
            { ""vendedor"": ""João Silva"", ""valor"": 250.30 },
            { ""vendedor"": ""João Silva"", ""valor"": 480.75 },
            { ""vendedor"": ""João Silva"", ""valor"": 320.40 },
            
            { ""vendedor"": ""Maria Souza"", ""valor"": 2100.40 },
            { ""vendedor"": ""Maria Souza"", ""valor"": 1350.60 },
            { ""vendedor"": ""Maria Souza"", ""valor"": 950.20 },
            { ""vendedor"": ""Maria Souza"", ""valor"": 1600.75 },
            { ""vendedor"": ""Maria Souza"", ""valor"": 1750.00 },
            { ""vendedor"": ""Maria Souza"", ""valor"": 1450.90 },
            { ""vendedor"": ""Maria Souza"", ""valor"": 400.50 },
            { ""vendedor"": ""Maria Souza"", ""valor"": 180.20 },
            { ""vendedor"": ""Maria Souza"", ""valor"": 90.75 },
            
            { ""vendedor"": ""Carlos Oliveira"", ""valor"": 800.50 },
            { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1200.00 },
            { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1950.30 },
            { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1750.80 },
            { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1300.60 },
            { ""vendedor"": ""Carlos Oliveira"", ""valor"": 300.40 },
            { ""vendedor"": ""Carlos Oliveira"", ""valor"": 500.00 },
            { ""vendedor"": ""Carlos Oliveira"", ""valor"": 125.75 },
            
            { ""vendedor"": ""Ana Lima"", ""valor"": 1000.00 },
            { ""vendedor"": ""Ana Lima"", ""valor"": 1100.50 },
            { ""vendedor"": ""Ana Lima"", ""valor"": 1250.75 },
            { ""vendedor"": ""Ana Lima"", ""valor"": 1400.20 },
            { ""vendedor"": ""Ana Lima"", ""valor"": 1550.90 },
            { ""vendedor"": ""Ana Lima"", ""valor"": 1650.00 },
            { ""vendedor"": ""Ana Lima"", ""valor"": 75.30 },
            { ""vendedor"": ""Ana Lima"", ""valor"": 420.90 },
            { ""vendedor"": ""Ana Lima"", ""valor"": 315.40 }
          ]
        }";

        var relatorio = JsonSerializer.Deserialize<RelatorioVendas>(jsonVendas);
        var comissoesPorVendedor = new Dictionary<string, decimal>();

        if (relatorio?.Vendas != null)
        {
            foreach (var venda in relatorio.Vendas)
            {
                // Regras de comissão por venda
                decimal percentual = venda.Valor switch
                {
                    < 100.00m => 0.00m,       // Abaixo de 100 não gera
                    < 500.00m => 0.01m,       // Abaixo de 500 gera 1%
                    _ => 0.05m                 // A partir de 500 gera 5%
                };

                decimal comissao = venda.Valor * percentual;

                if (!comissoesPorVendedor.ContainsKey(venda.Vendedor))
                    comissoesPorVendedor[venda.Vendedor] = 0;

                comissoesPorVendedor[venda.Vendedor] += comissao;
            }
        }

        Console.WriteLine("--- COMISSÕES CALCULADAS ---");
        foreach (var kvp in comissoesPorVendedor)
        {
            Console.WriteLine($"Vendedor: {kvp.Key} | Comissão Total: R$ {kvp.Value:F2}");
        }
    }
}