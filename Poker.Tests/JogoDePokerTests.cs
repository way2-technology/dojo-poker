using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Poker.Tests {
    public class JogoDePokerTests {
        private JogoDePoker _jogo;

        [SetUp]
        public void SetUp() {
            _jogo = new JogoDePoker();
        }

        [TestCase("2D", Naipe.Ouro, Valor.Dois)]
        [TestCase("2H", Naipe.Copa, Valor.Dois)]
        [TestCase("2S", Naipe.Espadas, Valor.Dois)]
        [TestCase("2C", Naipe.Paus, Valor.Dois)]
        [TestCase("3D", Naipe.Ouro, Valor.Tres)]
        public void Deve_parsear_string(string cartaStr, Naipe naipe, Valor valor) {
            var carta = new Carta(cartaStr);
            Assert.AreEqual(naipe, carta.Naipe);
            Assert.AreEqual(valor, carta.Valor);
        }

        [TestCase("2D", "3D", ExpectedResult = -1)]
        [TestCase("AH", "JH", ExpectedResult = 1)]
        [TestCase("AH", "AH", ExpectedResult = 0)]
        public int Deve_comparar_valor_das_cartas(string carta1, string carta2) {
            var c1 = new Carta(carta1);
            var c2 = new Carta(carta2);
            return c1.CompareTo(c2);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Mao_tem_que_ter_5_cartas() {
            new Mao(new Carta("AD"));
        }

        [Test]
        public void Mao_tem_5_cartas() {
            new Mao(new Carta("AD"), new Carta("AD"), new Carta("AD"), new Carta("AD"), new Carta("AD"));
            Assert.Pass();
        }

        [TestCaseSource("GetParse")]
        public void Deve_parsear_mao(Tuple<string, Mao> tupla) {
            Mao mao = Mao.Parse(tupla.Item1);
            Assert.AreEqual(mao, tupla.Item2);
        }

        public IEnumerable<Tuple<string, Mao>> GetParse() {
            yield return Tuple.Create("2H 2D 4C 4D 4S", (new Mao(new Carta("2H"), new Carta("2D"), new Carta("4C"), new Carta("4D"), new Carta("4S"))));
        }
    }
}