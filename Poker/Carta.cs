using System;

namespace Poker {
    public class Carta : IComparable<Carta> {

        public Naipe Naipe { get; set; }
        public Valor Valor { get; set; }

        public Carta(string source) {
            var valor = source[0];
            var naipe = source[1];
            Naipe = (Naipe) naipe;
            Valor = (Valor) valor;
        }

        public int CompareTo(Carta other) {
            return Valor.ToInt().CompareTo(other.Valor.ToInt());
        }
    }
}
