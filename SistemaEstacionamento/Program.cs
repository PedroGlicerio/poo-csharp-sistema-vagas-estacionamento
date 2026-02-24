using System;
using System.Globalization;
using SistemaEstacionamento.Entities;
using SistemaEstacionamento.Enums;
class Program {
    public static void Main(string[] args) {

        List<Vaga> vagas = new List<Vaga>();

        int quantidadeVaga;
        bool quantidadeVagaValida;

        do {

            Console.Write("Quantas vagas deseja cadastrar: ");
            quantidadeVagaValida = int.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out quantidadeVaga);

            if (!quantidadeVagaValida || quantidadeVaga <= 0) {

                Console.WriteLine("Quantidade de vaga inválida! Por favor, digite apenas números inteiros maiores que zero.");
                quantidadeVagaValida = false;
            }

        } while (!quantidadeVagaValida);

        for (int i = 0; i < quantidadeVaga; i++) {

            Console.WriteLine();
            Console.WriteLine($"Vaga #{i + 1}:");

            string nomeCliente;
            bool nomeClienteValido;

            do {

                Console.Write("Nome do cliente: ");
                nomeCliente = Console.ReadLine();

                nomeClienteValido = !string.IsNullOrWhiteSpace(nomeCliente) && nomeCliente.All(x => char.IsLetter(x) || char.IsWhiteSpace(x));

                if (!nomeClienteValido) {

                    Console.WriteLine("Nome inválido! Por favor, digite apenas letras para o nome.");
                }

            } while (!nomeClienteValido);

            TipoVaga tipoVaga;
            bool tipoVagaValida;

            do {

                Console.Write("Tipo de vaga [ 0 - Comum | 1 - Premium | 2 - Mensalista | 3 - Noturna ]: ");
                tipoVagaValida = Enum.TryParse(Console.ReadLine(), out tipoVaga);

                if (!tipoVagaValida || tipoVaga < TipoVaga.Comum || tipoVaga > TipoVaga.Noturna) {

                    Console.WriteLine("Tipo de vaga inválida! Por favor, verifique o tipo de vaga que deseja e digite novamente o número correspondente da vaga.");
                    tipoVagaValida = false;
                }

            } while (!tipoVagaValida);

            Vaga vaga;

            switch (tipoVaga) {

                case TipoVaga.Comum:

                    int valorPorHora = ObterValorPorHora();
                    int horasEstacionadas = ObterHorasEstacionadas();
                    decimal descontoPromocional = ObterDescontoPromocional();

                    vaga = new VagaComum(nomeCliente, valorPorHora, descontoPromocional, horasEstacionadas, tipoVaga);

                    break;

                case TipoVaga.Premium:

                    valorPorHora = ObterValorPorHora();
                    horasEstacionadas = ObterHorasEstacionadas();
                    descontoPromocional = ObterDescontoPromocional();

                    vaga = new VagaPremium(nomeCliente, valorPorHora, descontoPromocional, horasEstacionadas, tipoVaga);

                    break;

                case TipoVaga.Mensalista:

                    int valorMensal;
                    bool valorMensalValido;

                    do {

                        Console.Write("Valor mensal: ");
                        valorMensalValido = int.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out valorMensal);

                        if (!valorMensalValido || valorMensal <= 0) {

                            Console.WriteLine("Valor inválido! Por favor, digite apenas valores inteiros maiores que zero.");
                            valorMensalValido = false;
                        }

                    } while (!valorMensalValido);

                    int horaExtra;
                    bool horaExtraValida;

                    do {

                        Console.Write("Horas extras no mês: ");
                        horaExtraValida = int.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out horaExtra);

                        if (!horaExtraValida || horaExtra <= 0) {

                            Console.WriteLine("Horas inválida! Por favor, digite apenas valores inteiros maiores que zero.");
                            horaExtraValida = false;
                        }

                    } while (!horaExtraValida);

                    descontoPromocional = ObterDescontoPromocional();

                    vaga = new VagaMensalista(nomeCliente, valorMensal, descontoPromocional, horaExtra, tipoVaga);

                    break;

                case TipoVaga.Noturna:

                    valorPorHora = ObterValorPorHora();
                    horasEstacionadas = ObterHorasEstacionadas();

                    int horasNoturna;
                    bool horasNortunaValida;

                    do {

                        Console.Write("Horas noturnas: ");
                        horasNortunaValida = int.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out horasNoturna);

                        if (!horasNortunaValida || horasNoturna <= 0) {

                            Console.WriteLine("Horas inválida! Por favor, digite apenas valores inteiros maiores que zero.");
                            horasNortunaValida = false;
                        }

                    } while (!horasNortunaValida);

                    descontoPromocional = ObterDescontoPromocional();

                    vaga = new VagaNoturna(nomeCliente, valorPorHora, descontoPromocional, horasEstacionadas, horasNoturna, tipoVaga);

                    break;

                default:
                    throw new ArgumentException("Tipo inválido!");
            }

            vagas.Add(vaga);
        }

        Console.WriteLine();
        Console.WriteLine("RELATÓRIO DO ESTACIONAMENTO");
        Console.WriteLine();
        foreach (var vaga in vagas) {

            Console.WriteLine(vaga.ToString());
        }
    }
    private static int ObterValorPorHora() {

        int valorPorHora;
        bool valorPorHoraValida;

        do {

            Console.Write("Valor por hora: ");
            valorPorHoraValida = int.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out valorPorHora);

            if (!valorPorHoraValida || valorPorHora <= 0) {

                Console.WriteLine("Valor de hora inválido! Por favor, digite apenas valores inteiros maiores que zero.");
                valorPorHoraValida = false;
            }

        } while (!valorPorHoraValida);

        return valorPorHora;
    }
    private static int ObterHorasEstacionadas() {

        int horasEstacionadas;
        bool horasEstacionadasValida;

        do {

            Console.Write("Horas estacionadas: ");
            horasEstacionadasValida = int.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out horasEstacionadas);

            if (!horasEstacionadasValida || horasEstacionadas <= 0) {

                Console.WriteLine("Horas inválida! Por favor, digite apenas valores inteiros maiores que zero.");
                horasEstacionadasValida = false;
            }

        } while (!horasEstacionadasValida);

        return horasEstacionadas;
    }
    private static decimal ObterDescontoPromocional() {

        decimal valorDesconto;
        bool valorDescontoValido;

        do {

            Console.Write("Desconto promocional (%): ");
            valorDescontoValido = decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out valorDesconto);

            if (!valorDescontoValido || valorDesconto < 0) {

                Console.WriteLine("Valor inválido! Por favor, digite apenas valores inteiros positivos.");
                valorDescontoValido = false;
            }

        } while (!valorDescontoValido);

        return valorDesconto;
    }
}