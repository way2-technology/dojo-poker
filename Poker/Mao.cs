using System;
using System.Linq;

namespace Poker {
    public class Mao {
        public override bool Equals(object o) {
            var other = (Mao) o;
            var cartasDaMao = Cartas.OrderBy(x => x).ToList();
            var cartasACompar = other.Cartas.OrderBy(x => x).ToList();

            for (int i = 0; i < 5; i++) {
                if (cartasDaMao[i].CompareTo(cartasACompar[i]) != 0) {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode() {
            return (Cartas != null ? Cartas.GetHashCode() : 0);
        }

        public Carta[] Cartas { get; private set; }

        public Mao(params Carta[] cartas) {
            if (cartas == null || cartas.Length != 5) {
                throw new ArgumentException("cartas");
            }
            Cartas = cartas;
        }

        public static Mao Parse(string s) {
            return new Mao(s.Split(' ').Select(x => new Carta(x)).ToArray());
        }

    }
}