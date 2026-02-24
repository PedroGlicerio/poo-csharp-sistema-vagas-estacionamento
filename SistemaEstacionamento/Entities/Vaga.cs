using System.Globalization;
using System.Text;
using SistemaEstacionamento.Enums;

namespace SistemaEstacionamento.Entities {
    internal abstract class Vaga {
        protected string NomeCliente { get; init; }
        protected decimal ValorBase { get; private set; }
        protected decimal Desconto { get; private set; }
        protected TipoVaga TipoVaga { get; }
        protected Vaga(string nomeCliente, decimal valorBase, decimal desconto, TipoVaga tipoVaga) {

            if (string.IsNullOrWhiteSpace(nomeCliente)) {

                throw new ArgumentException("Nome inválido!");
            }

            if (valorBase <= 0) {

                throw new ArgumentException("Valor inválido!");
            }

            if (desconto < 0) {

                throw new ArgumentException("Desconto inválido!");
            }

            if (tipoVaga < TipoVaga.Comum || tipoVaga > TipoVaga.Noturna) {

                throw new ArgumentException("Tipo inválido!");
            }

            NomeCliente = nomeCliente;
            ValorBase = valorBase;
            Desconto = desconto;
            TipoVaga = tipoVaga;
        }
        public abstract decimal ObterValorFinal();
        protected abstract string ObterInformacaoEspecificaVaga();
        public override string ToString() {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cliente: {NomeCliente}");
            sb.AppendLine($"Tipo: {TipoVaga}");
            sb.AppendLine($"Valor base: R${ValorBase.ToString("F2", CultureInfo.InvariantCulture)}");
            sb.AppendLine(ObterInformacaoEspecificaVaga());

            if (Desconto > 0) {

                sb.AppendLine($"Desconto promocional: {Desconto}%");
            }

            sb.AppendLine($"Valor final: R${ObterValorFinal().ToString("F2", CultureInfo.InvariantCulture)}");
            sb.AppendLine(new string('-', 30));

            return sb.ToString();
        }
    }
}
