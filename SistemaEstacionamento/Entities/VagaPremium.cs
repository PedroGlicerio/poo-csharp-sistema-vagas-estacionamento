using SistemaEstacionamento.Enums;

namespace SistemaEstacionamento.Entities {
    internal class VagaPremium : VagaPorHora {
        public VagaPremium(string nomeCliente, decimal valorBase, decimal desconto, int horasEstacionadas, TipoVaga tipoVaga) : 
            base(nomeCliente, valorBase, desconto, horasEstacionadas, tipoVaga) { }

        private decimal TaxaManobristaFixo() {

            return 25m;
        }
        private decimal CalcularDescontoFidelidade(decimal valor) {

            if (HorasEstacionadas > 5) {

                return valor * 0.10m;
            }

            return 0m;
        }
        public override decimal ObterValorFinal() {

            decimal valor = CalcularValorPorHora();
            valor += TaxaManobristaFixo();
            valor -= CalcularDescontoFidelidade(valor);
            valor -= CalcularDescontoPromocional(valor);

            return valor;
        }
    }
}
