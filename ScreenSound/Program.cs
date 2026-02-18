using ScreenSound.Models.ByteBank;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string enderecoArquivo = "contas.txt";
        //int numeroDeBytesLidos = -1;

        //using (FileStream fluxoDeArquivo = new FileStream(enderecoArquivo, FileMode.Open))
        //{
        //    var buffer = new byte[1024];
        //    while (numeroDeBytesLidos != 0)
        //    {
        //        numeroDeBytesLidos = fluxoDeArquivo.Read(buffer, 0, 1024);
        //        EscreverBuffer(buffer, numeroDeBytesLidos);
        //    }
        //}

        List<ContaCorrente> listaContas = new();
        using (var fluxoDeArquivo = new FileStream(enderecoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);
            while (!leitor.EndOfStream)
            {
                var texto = leitor.ReadLine();
                ContaCorrente conta = ConvererStringParaContaCorrente(texto);
                listaContas.Add(conta);
                Console.WriteLine(@$"A conta do {conta.Titular.Nome} possue R${conta.Saldo} de saldo.");
            }
        }

        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        var UTF8 = new UTF8Encoding();

        string texto = UTF8.GetString(buffer, 0, bytesLidos);

        Console.Write(texto);

    }

    static ContaCorrente ConvererStringParaContaCorrente(string linha)
    {
        string[] campos = linha.Split(',');
        int agencia = int.Parse(campos[0]);
        int numero = int.Parse(campos[1]);
        double saldo = Convert.ToDouble(campos[2].Replace('.', ','));
        string titular = campos[3];

        ContaCorrente conta = new ContaCorrente(agencia, numero);
        conta.Depositar(saldo);
        conta.Titular = new()
        {
            Nome = titular
        };

        return conta; ;
    }
}