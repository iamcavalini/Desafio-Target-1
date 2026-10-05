Cálculo de Comissão do Time Comercial

Este projeto consiste em uma aplicação de linha de comando desenvolvida em **C# (.NET 8.0)** que lê um conjunto de dados de vendas no formato JSON e calcula a comissão total acumulada para cada vendedor do time comercial, aplicando regras de negócio progressivas por venda.

---

Regras de Negócio

Para cada venda individual registrada, a comissão é calculada com base na seguinte tabela de regras:

| Faixa de Valor da Venda | % de Comissão |
| :--- | :---: |
| Vendas abaixo de R$ 100,00 | **0%** |
| Vendas de R$ 100,00 até R$ 499,99 | **1%** |
| Vendas a partir de R$ 500,00 | **5%** |

---

Tecnologias Utilizadas

- Linguagem: C# (.NET 8.0)
- Biblioteca de Serialização: `System.Text.Json`
- Ambiente de Desenvolvimento: Visual Studio 2022

---

Como Executar o Projeto

Pré-requisitos
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado na máquina.
- IDE  (Visual Studio).

Passos
1. Clonar o repositório
2. Acessar a pasta do projeto
3. Executar a aplicação via terminal
