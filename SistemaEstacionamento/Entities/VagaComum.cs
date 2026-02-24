using SistemaEstacionamento.Enums;

namespace SistemaEstacionamento.Entities {
    internal class VagaComum : VagaPorHora {
        public VagaComum(string nomeCliente, decimal valorBase, decimal desconto, int horasEstacionadas, TipoVaga tipoVaga) : 
            base(nomeCliente, valorBase, desconto, horasEstacionadas, tipoVaga) { }
        private decimal CalcularAcrescimo(decimal valor) {

            if (HorasEstacionadas > 8) {

                return valor * 0.20m;
            }

            return 0m;
        }
        public override decimal ObterValorFinal() {

            decimal valor = CalcularValorPorHora();
            valor += CalcularAcrescimo(valor);
            valor -= CalcularDescontoPromocional(valor);

            return valor;
        }
    }
}
