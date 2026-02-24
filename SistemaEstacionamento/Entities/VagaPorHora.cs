using SistemaEstacionamento.Enums;

namespace SistemaEstacionamento.Entities {
    internal abstract class VagaPorHora : Vaga {
        protected int HorasEstacionadas { get; private set; }
        public VagaPorHora(string nomeCliente, decimal valorBase, decimal desconto, int horasEstacionadas, TipoVaga tipoVaga) : base(nomeCliente, valorBase, desconto, tipoVaga) {

            if (horasEstacionadas <= 0) {

                throw new ArgumentException("Hora inválida!");
            }

            HorasEstacionadas = horasEstacionadas;
        }
        protected override string ObterInformacaoEspecificaVaga() {

            return
                $"Horas estacionadas: {HorasEstacionadas}";
        }
        protected decimal CalcularValorPorHora() {

            return ValorBase * HorasEstacionadas;
        }
        protected decimal CalcularDescontoPromocional(decimal valorAtual) {

            return valorAtual * (Desconto / 100m);
        }
    }
}
