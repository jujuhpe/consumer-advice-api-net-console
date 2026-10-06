using System.Text.Json;

class Conselho
{
    public Slip slip { get; set; }
}

class Slip
{
    public int id { get; set; }
    public string advice { get; set; }
}

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://api.adviceslip.com/advice";

        using HttpClient cliente = new HttpClient();

        try
        {
            HttpResponseMessage resposta = await cliente.GetAsync(url);

            resposta.EnsureSuccessStatusCode();

            string json = await resposta.Content.ReadAsStringAsync();

            Conselho conselho = JsonSerializer.Deserialize<Conselho>(json);

            Console.WriteLine("Conselho de Hoje:");
            Console.WriteLine();
            Console.WriteLine(conselho.slip.advice);
        }
        catch (Exception erro)
        {
            Console.WriteLine("Ocorreu um erro:");
            Console.WriteLine(erro.Message);
        }
    }
}