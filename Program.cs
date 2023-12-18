using System.Text.Json;
using DesafioBoletim.Classes;
using DesafioBoletim.FilterLinq;

using (HttpClient client = new())
{
    string URL_API = "https://raw.githubusercontent.com/Lucas-p0/DesafioBoletim/main/DesafioBoletim.json";

    try
    {
        string response = await client.GetStringAsync(URL_API);
        var resultadoExcel = JsonSerializer.Deserialize<List<Consulta>>(response);
        Filtros.FiltraAlunosDaEscola(resultadoExcel);

    }
    catch (Exception ex)
    {
        System.Console.WriteLine($"Deu erro aquiii: {ex.Message}");
    }
}