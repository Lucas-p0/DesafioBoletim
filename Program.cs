using System.Text.Json;
using DesafioBoletim.Classes;
using DesafioBoletim.FilterLinq;

using (HttpClient client = new())
{
    string URL_API = "https://raw.githubusercontent.com/Lucas-p0/DesafioBoletim/main/DesafioBoletim.json";

    try
    {
        string response = await client.GetStringAsync(URL_API);
        var consultas = JsonSerializer.Deserialize<List<Consulta>>(response);
        // -----------------------Exercicio 1-----------------------
        //Filtros.FiltraAlunosDaEscola(consultas);

        // -----------------------Exercicio 2-----------------------
        //Filtros.FiltraProfessores(consultas);


        // -----------------------Exercicio 3-----------------------
        //Filtros.FiltraQuantidadeTurmas(consultas);


        // -----------------------Exercicio 3-----------------------
        // Filtros.FiltraQuantidadeDeMaterias(consultas);

        // -----------------------Exercicio 4-----------------------
        // Filtros.VerificaAprovados(consultas);

        // -----------------------Exercicio 5-----------------------

        //Filtros.ListaMaioresNotasPorNomeESerie(consultas);


        // -----------------------Exercicio 6-----------------------
        Filtros.MediaDeNotaPorSerie(consultas);


        // -----------------------Exercicio 7-----------------------



    }
    catch (Exception ex)
    {
        Console.WriteLine($"Deu erro aquiii: {ex.Message}");
    }
}