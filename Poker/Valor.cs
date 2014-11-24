namespace Poker {
    public enum Valor {
        Dois = '2',
        Tres = '3',
        Quatro = '4',
        Cinco = '5',
        Seis = '6',
        Sete = '7',
        Oito = '8',
        Nove = '9',
        Dez = 'T',
        Valete = 'J',
        Rainha = 'Q',
        Rei = 'K',
        As = 'A'
    }

    public static class ValorHelper {
        public static int ToInt(this Valor valor) {
            switch (valor) {
                case Valor.Dez:
                    return 10;
                case Valor.Valete:
                    return 11;
                case Valor.Rainha:
                    return 12;
                case Valor.Rei:
                    return 13;
                case Valor.As:
                    return 14;
                default:
                    return (int) valor;
            }
        }
    }
}