internal class Program
{
    private static void Main(string[] args)
    {
        string enderecoArquivo = "contas.txt";
        int numeroDeBytesLidos = -1;

        FileStream fluxoDeArquivo = new FileStream(enderecoArquivo, FileMode.Open);

        var buffer = new byte[1024];

        while (numeroDeBytesLidos != 0)
        {
            numeroDeBytesLidos = fluxoDeArquivo.Read(buffer, 0, 1024);
            EscreverBuffer(buffer);
        }

        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer)
    {
        foreach (var meuByte in buffer)
        {
            Console.Write(meuByte);
            Console.Write(" ");
        }
    }
}