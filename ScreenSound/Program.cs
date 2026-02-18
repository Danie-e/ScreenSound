using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string enderecoArquivo = "contas.txt";
        int numeroDeBytesLidos = -1;

        using (FileStream fluxoDeArquivo = new FileStream(enderecoArquivo, FileMode.Open))
        {
            var buffer = new byte[1024];
            while (numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoDeArquivo.Read(buffer, 0, 1024);
                EscreverBuffer(buffer);
            }
        }
        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer)
    {
        var UTF8 = new UTF8Encoding();

        string texto = UTF8.GetString(buffer);

        Console.Write(texto);

    }
}