using SistemaEstacionamento.Enums;

namespace SistemaEstacionamento.Entities {
    internal class VagaNoturna : VagaPorHora {
        protected int HorasNoturnas { get; private set; }
        public VagaNoturna(string nomeCliente, decimal valorBase, decimal desconto, int horasEstacionadas, int horasNoturna, TipoVaga tipoVaga) : 
            base(nomeCliente, valorBase, desconto, horasEstacionadas, tipoVaga) { 
        
            if (horasNoturna <= 0) {

                throw new ArgumentException("Hora inválida!");
            }

            HorasNoturnas = horasNoturna;
        }
        private decimal CalcularValorNoturno(decimal valor) {

            decimal valorNoturno = HorasNoturnas * valor;

            if (valorNoturno > 50) {

                return valorNoturno = 50m;
            }

            return valorNoturno;
        }
        private decimal CalcularValorDiurno(decimal valor) {

            int horasDiurna = HorasEstacionadas - HorasNoturnas;

            return horasDiurna * valor;
        }
        public override decimal ObterValorFinal() {

            decimal valor = ValorBase;
            decimal valorTotal = CalcularValorNoturno(valor) + CalcularValorDiurno(valor);
            decimal desconto = CalcularDescontoPromocional(valorTotal);

            if (Desconto > 0) {

                return valorTotal -= desconto;
            }

            return valorTotal;
        }
    }
}
