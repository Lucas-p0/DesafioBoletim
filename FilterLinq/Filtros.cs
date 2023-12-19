using System.Runtime.InteropServices.Marshalling;
using DesafioBoletim.Classes;
using System.Linq;

namespace DesafioBoletim.FilterLinq;

public class Filtros
{   //1 – Quantos alunos temos em nossa escola? Conte sem repetição
    public static void FiltraAlunosDaEscola(List<Consulta> consultas)
    {

        var filtraTodosOsAlunos = consultas.Select(c => c.NomeAluno).Distinct().ToList();
        int quantidadeAlunos = filtraTodosOsAlunos.Count();
        System.Console.WriteLine(quantidadeAlunos);

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
        System.Console.WriteLine(quantidadeProfessores);
    }

    //3 – Quantas turmas e disciplinas existem em nossas escolas?
    public static void FiltraQuantidadeTurmas(List<Consulta> consultas)
    {
        var filtraQuantidadeDeTumas = consultas.Select(c => c.Serie).Distinct().ToList();
        int quantiadeDeSeries = filtraQuantidadeDeTumas.Count();
        System.Console.WriteLine(quantiadeDeSeries);
    }
    //3 – Quantas turmas e disciplinas existem em nossas escolas?
    public static void FiltraQuantidadeDeMaterias(List<Consulta> consultas)
    {
        var filtraQuantidadeDeMaterias = consultas.Select(c => c.NomeMateria).Distinct().ToList();
        int quantidadeDeMaterias = filtraQuantidadeDeMaterias.Count();
        System.Console.WriteLine(quantidadeDeMaterias);
    }
    //4 – Nossa média escolar é 7 pontos.Quantos alunos ficaram de recuperação e quantos alunos passaram de ano?
    public static void VerificaAprovados(List<Consulta> consultas)
    {
        var totaldeAlunos = consultas.Select(c => c.NomeAluno).Distinct().ToList();
        int quantidadeTotaldeAlunos = totaldeAlunos.Count();

        var totalDeAlunosReprovados = consultas.Where(consulta => consulta.Nota < 7).Select(consulta => consulta.NomeAluno, ).Distinct().ToList();
        int quantidadeDeAlunosReprovados = totalDeAlunosReprovados.Count();

        int totalDeAlunosAprovados = quantidadeTotaldeAlunos - quantidadeDeAlunosReprovados;
        System.Console.WriteLine($"Quantidade de alunos arovados: {totalDeAlunosAprovados}");
        foreach (var nomeAluno in filtraTodosOsAlunos)
        {

            Console.WriteLine($"{nomeAluno}");
        }
    }

}
