class Program
{
    static void Main(string[] args)
    {
        /*********** parede de tijolos **********/
        int[][] tijolos =
        [
            [1, 2, 2, 1],
            [3, 1, 2],
            [1, 3, 2],
            [2, 4],
            [3, 1, 2],
            [1, 3, 1, 1]
        ];
        int resposta = NumeroCortes(tijolos);
        Console.WriteLine($"{resposta}");
    }
    public static int NumeroCortes(int[][] tijolos)
    {
        // dicionário contar linha/coluna
        Dictionary<int, int> cortes = [];
        // iterar as linhas
        foreach (var tijolo in tijolos) /* ->Big O(n), temos Big O(n * t) = N número de linhas e T número de tijolos na linha, o algoritmo cresce linearmente*/
        {
            int linha = 0;
            // iterar os tijolos, menos o último tijolo
            for (int i = 0; i < tijolo.Length - 1; i++)
            {
                linha += tijolo[i];
                // adiciona cortes ao valor associado na chave
                if (cortes.TryGetValue(linha, out int valor))
                {
                    cortes[linha] = ++valor;
                }
                else
                {
                    cortes[linha] = 1;
                }
            }
        }
        // valor total dos cortes
        int totalCortes = 0;
        foreach (var i in cortes.Values) // -> Big O(n), N número de cortes, cresce linearmente
        {
            if (i > totalCortes)
            {
                totalCortes = i;
            }
        }
        // totalLinha na parede - totalMaximoCortes em uma só coluna
        return tijolos.Length - totalCortes;
    }
}
