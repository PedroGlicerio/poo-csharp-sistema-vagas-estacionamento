## <p align="center">Sistema de Cobrança de Estacionamento Inteligente | Console Application em C#</p>

<p align="center"> Este projeto consiste em um <b>sistema desenvolvido em C# (.NET)</b> para cobrança de estacionamento. <br> A aplicação aplica regras específicas conforme o tipo de vaga, permitindo acréscimos, bônus, descontos promocionais e geração de relatório detalhado da cobrança. </p>

---

## 📃 Filosofia do Projeto

O objetivo deste projeto é consolidar os principais conceitos de **Programação Orientada a Objetos (POO)** aplicando regras reais de negócio em um cenário simulado. O sistema permite cadastrar múltiplas vagas e calcula automaticamente o valor final com base nas regras específicas de cada modalidade.

A implementação prioriza:

- Organização e clareza
- Encapsulamento das regras de negócio
- Reaproveitamento de código com herança
- Uso de polimorfismo para comportamentos específicos
- Validação robusta no domínio da aplicação

---

## 🅿️ Tipos de Vaga

### 1️⃣ Vaga Comum
- Valor base por hora
- Cobrança por hora cheia
- Acréscimo de 20% se permanecer mais de 8 horas
- Pode ter desconto promocional percentual

### 2️⃣ Vaga Premium
- Valor base por hora
- Cobrança por hora cheia
- Taxa fixa de manobrista (+ R$ 25)
- Desconto fidelidade de 10% se permanecer mais de 5 horas
- Pode ter desconto promocional percentual

### 3️⃣ Vaga Mensalista
- Valor mensal fixo
- Se ultrapassar 30 horas extras no mês, paga R$ 5 por hora excedente
- Pode ter desconto promocional percentual

### 4️⃣ Vaga Noturna
- Valor base por hora
- Período especial noturno com teto máximo de R$ 50
- Caso ultrapasse o horário especial, cobra valor normal por hora
- Pode ter desconto promocional percentual

---

## 🎟 Regras do Desconto Promocional

- Percentual
- Aplicado após todas as regras da vaga
- Nunca pode deixar o valor final negativo

---

## 🧠 Conceitos de POO Aplicados

- Abstração com classe abstrata `Vaga`
- Herança com classe intermediária `VagaPorHora`
- Polimorfismo através da sobrescrita do método `ObterValorFinal()`
- Encapsulamento com validações nos construtores
- Enum (`TipoVaga`) para representação dos tipos
- Sobrescrita de `ToString()` para geração de relatório formatado
- Separação entre camada de entrada (Program) e domínio (Entities)

---

## 📂 Estrutura do Projeto

```
SistemaEstacionamento
│
├── Program.cs
│
├── Entities
│   ├── Vaga.cs
│   ├── VagaPorHora.cs
│   ├── VagaComum.cs
│   ├── VagaPremium.cs
│   ├── VagaMensalista.cs
│   └── VagaNoturna.cs
│
└── Enums
    └── TipoVaga.cs
```

---

## 💻 Tech Stack

- C#
- .NET 8 (Console Application)

---

## 🎈 Como Instalar e Executar

### Pré-requisitos
- .NET SDK 8.0 ou superior instalado  

Download: https://dotnet.microsoft.com/download

---

### Passos para execução

```bash
# Clonar o repositório
git clone https://github.com/PedroGlicerio/poo-csharp-sistema-vagas-estacionamento.git

# Acessar o diretório do projeto
cd poo-csharp-sistema-vagas-estacionamento

# Executar a aplicação
dotnet run
```

---

## ⌨️ Entrada de Dados

O sistema solicita as informações diretamente pelo terminal, seguindo esta ordem:

- Quantidade de vagas a cadastrar
- Nome do cliente
- Tipo da vaga  
  - 0 - Comum  
  - 1 - Premium  
  - 2 - Mensalista  
  - 3 - Noturna  
- Valores e horas conforme o tipo selecionado
- Percentual de desconto promocional

### Exemplo de entrada (Vaga Premium)

```bash
Quantas vagas deseja cadastrar: 1

Vaga #1:
Nome do cliente: Mariana
Tipo de vaga [ 0 - Comum | 1 - Premium | 2 - Mensalista | 3 - Noturna ]: 1
Valor por hora: 15
Horas estacionadas: 6
Desconto promocional (%): 5
```

📌 Regras aplicadas neste exemplo:
- 6h x R$15 = R$90  
- R$25 taxa fixa de manobrista → R$115  
- 10% desconto fidelidade (acima de 5h)  
- 5% desconto promocional  

---

## 📤 Saída do Sistema

```bash
RELATÓRIO DO ESTACIONAMENTO

Cliente: Mariana
Tipo: Premium
Valor base: R$15.00
Horas estacionadas: 6
Desconto promocional: 5%
Valor final: R$98.33
------------------------------
```
---

## 📌 Regras e Validações

- Nome não pode ser vazio
- Valores devem ser maiores que zero
- Horas devem ser maiores que zero
- Tipo da vaga deve ser válido
- Validações aplicadas tanto na entrada quanto nos construtores das entidades

As regras críticas estão encapsuladas no domínio, garantindo integridade dos dados.

---

## 📝 Aprendizados

Durante o desenvolvimento deste projeto, pude consolidar diversos conceitos de **Programação Orientada a Objetos (POO)** aplicados na prática:

- Uso de **classe intermediária** (`VagaPorHora`) para evitar duplicação de código entre subclasses com o mesmo modelo de entrada/saída
- Aplicação de **modificadores de acesso** (`public`, `protected`, `private`) para organizar visibilidade e proteger métodos e propriedades
- Implementação de **herança e polimorfismo** para representar comportamentos específicos de cada tipo de vaga
- Criação de **validações robustas** no domínio da aplicação e no construtor, garantindo integridade dos dados
- Sobrescrita de métodos (`override`) e uso de `ToString()` para gerar relatórios detalhados de forma consistente

---

## 📎 Considerações Finais

Este projeto foi desenvolvido como exercício prático de modelagem orientada a objetos, aplicando regras reais de negócio em um cenário simulado.

A estrutura foi pensada para facilitar manutenção e futuras extensões, como:

- Persistência em banco de dados  
- Interface gráfica  
- API REST  
- Controle de vagas disponíveis  

Um exercício sólido para consolidar abstração, herança, polimorfismo e encapsulamento em C#.
