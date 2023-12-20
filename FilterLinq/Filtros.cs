using System.Runtime.InteropServices.Marshalling;
using DesafioBoletim.Classes;
using System.Linq;
using Microsoft.VisualBasic;
using System.Globalization;

namespace DesafioBoletim.FilterLinq;

public class Filtros
{   //1 – Quantos alunos temos em nossa escola? Conte sem repetição
    public static void FiltraAlunosDaEscola(List<Consulta> consultas)
    {

        var filtraTodosOsAlunos = consultas.Select(c => c.NomeAluno).Distinct().ToList();
        int quantidadeAlunos = filtraTodosOsAlunos.Count();
        Console.WriteLine(quantidadeAlunos);

        // foreach (var nomeAluno in filtraTodosOsAlunos)
        // {

        //     Console.WriteLine($"{nomeAluno}");
        // }
    }

    //2 – Quantos professores temos em nossa escola? Conte sem repetição.
    public static void FiltraProfessores(List<Consulta> consultas)
    {
        var filtraProfessores = consultas.Select(c => c.NomeProfessor).Distinct().ToList();
        int quantidadeProfessores = filtraProfessores.Count();
        Console.WriteLine(quantidadeProfessores);
    }

    //3 – Quantas turmas e disciplinas existem em nossas escolas?
    public static void FiltraQuantidadeTurmas(List<Consulta> consultas)
    {
        var filtraQuantidadeDeTumas = consultas.Select(c => c.Serie).Distinct().ToList();
        int quantiadeDeSeries = filtraQuantidadeDeTumas.Count();
        Console.WriteLine(quantiadeDeSeries);
    }
    //3 – Quantas turmas e disciplinas existem em nossas escolas?
    public static void FiltraQuantidadeDeMaterias(List<Consulta> consultas)
    {
        var filtraQuantidadeDeMaterias = consultas.Select(c => c.NomeMateria).Distinct().ToList();
        int quantidadeDeMaterias = filtraQuantidadeDeMaterias.Count();
        Console.WriteLine(quantidadeDeMaterias);
    }
    //4 – Nossa média escolar é 7 pontos. Quantos alunos ficaram de recuperação e quantos alunos passaram de ano?
    //Os alunos que ficaram de recuperação, favor listar o nome e os telefones:
    public static void VerificaAprovados(List<Consulta> consultas)
    {
        var totalDeAlunos = consultas.Select(c => c.NomeAluno).ToList();
        int quantidadetotalDeAlunos = totalDeAlunos.Count();
        var totalDeAlunosReprovados = consultas
                    .Where(consulta => consulta.Nota < 7)
                    .Select(consulta => new { NomeAluno = consulta.NomeAluno, Telefone = consulta.Telefone }).ToList();

        int quantidadeDeAlunosReprovados = totalDeAlunosReprovados.Count();
        int totalDeAlunosAprovados = quantidadetotalDeAlunos - quantidadeDeAlunosReprovados;
        Console.WriteLine($"Quantidade de alunos aprovados: {totalDeAlunosAprovados}");
        foreach (var nomeAluno in totalDeAlunosReprovados)
        {

            Console.WriteLine($"{nomeAluno}");
        }
    }
    // 5 – Nossos alunos são bem inteligentes. Crie uma lista por série e matéria, a nota mais alta de cada turma e disciplina e o nome do aluno. Em caso de mais de uma nota, evidenciar a lista de alunos.
    public static void ListaMaioresNotasPorNomeESerie(List<Consulta> consultas)
    {
        var maiorNota = consultas.Max(consulta => consulta.Nota);
        var maioresNotas = consultas
                    .Where(consulta => consulta.Nota >= maiorNota)
                    .Select(consulta => new { NomeAluno = consulta.NomeAluno, NomeMateria = consulta.NomeMateria, Nota = consulta.Nota });

        foreach (var notas in maioresNotas)
        {

            Console.WriteLine($"{notas}");
        }
    }
    public static void MediaDeNotaPorSerie(List<Consulta> consultas)
    {
        var consultaPorSerie = consultas.GroupBy(consulta => consulta.Serie);
        var mediaPorSerie = consultaPorSerie.Select(grupo => new
        {
            Serie = grupo.Key,
            Media = grupo.Average(consulta => consulta.Nota).ToString("F2", CultureInfo.InvariantCulture)
        });
        var serieComMaiorMedia = mediaPorSerie.OrderByDescending(media => media.Media).FirstOrDefault();

        foreach (var media in mediaPorSerie)
        {

            Console.WriteLine($"{media}");
        }
        if (serieComMaiorMedia != null)
        {
            Console.WriteLine($"\nA série com a média mais alta: {serieComMaiorMedia}\n");
        };

    }
    public static void FiltraAlunosPorGenero(List<Consulta> consulta)
    {
        // Agrupando as consultas por série e gênero
        var consultaPorSerieEGenero = consulta
                    .GroupBy(consulta => new { consulta.Serie, consulta.Sexo, consulta.Nota });

        // Nota mais alta
        var notaMaisAlta = consulta.Max(consulta => consulta.Nota);
        var consultasOrdenadas = consultaPorSerieEGenero
                    .OrderBy(grupo => grupo.Key.Serie)
                    .ThenBy(grupo => grupo.Key.Sexo);

        var maiorNota = consultasOrdenadas.OrderBy(grupo => grupo.Key.Sexo);


        foreach (var grupo in maiorNota)
        {
            Console.WriteLine($"No Série {grupo.Key.Serie}, Gênero {grupo.Key.Sexo}");
            // foreach (var consultaGrupo in grupo)
            // {
            //     Console.WriteLine($"  Aluno: {NomeAluno}, Nota: {consulta.Nota}");
            // }
        }

    }


    //var filmesMelhorAvaliados = filmes.OrderByDescending(f => f.Avaliacao).Take(5);
}
