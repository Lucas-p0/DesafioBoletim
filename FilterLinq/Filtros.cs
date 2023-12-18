using System.Runtime.InteropServices.Marshalling;
using DesafioBoletim.Classes;

namespace DesafioBoletim.FilterLinq;

public class Filtros
{
    public static void FiltraAlunosDaEscola(List<Consulta> consulta)
    {
        var filtraTodosOsAlunos = consulta.OrderBy(consulta => consulta.NomeAluno).Distinct().ToList();
        foreach (var NomeAluno in filtraTodosOsAlunos)
        {
            Console.WriteLine(NomeAluno);
        }
    }
}
