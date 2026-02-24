using SistemaEstacionamento.Enums;

namespace SistemaEstacionamento.Entities {
    internal class VagaMensalista : Vaga {
        protected int HoraExtra { get; private set; }
        public VagaMensalista(string nomeCliente, decimal valorBase, decimal desconto, int horaExtra, TipoVaga tipoVaga) : base(nomeCliente, valorBase, desconto, tipoVaga) {

            if (horaExtra <= 0) {

                throw new ArgumentException("Hora inválida!");
            }

            HoraExtra = horaExtra;
        }
        protected override string ObterInformacaoEspecificaVaga() {

            return 
                $"Horas extras no mês: {HoraExtra}";
        }
        private decimal CalcularHoraExcedente() {

            if (HoraExtra > 30) {

                return (HoraExtra - 30) * 5m;
            }

            return 0;
        }
        public override decimal ObterValorFinal() {

            decimal valor = ValorBase;
            valor += CalcularHoraExcedente();

            if (Desconto > 0) {

                valor -= valor * (Desconto / 100m);
            }
            return valor;
        }
    }
}
