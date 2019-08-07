public class Utilidades {

    public static string formatarZerosEsquerda(int number) {
        string numberString = "" + number;

        numberString = retornarQtdeZeros(5 - numberString.Length) + number;

        return numberString;
    }

    public static string retornarQtdeZeros(int qtdeZeros) {
        string retorno = "";

        for (int i = 0; i < qtdeZeros; i++) {
            retorno += "0";
        }

        return retorno;
    }

}