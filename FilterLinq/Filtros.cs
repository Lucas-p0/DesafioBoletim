using System.Runtime.InteropServices.Marshalling;
using DesafioBoletim.Classes;

namespace DesafioBoletim.FilterLinq;

public class Filtros
{
    public static void FiltraAlunosDaEscola(List<Consulta> consultas)
    {
        var filtraTodosOsAlunos = consultas.OrderBy(consulta => consulta.NomeAluno).Where(NomeAluno).Distinct().ToList();
        foreach (var nome in filtraTodosOsAlunos)
        {
            Console.WriteLine($"{nome}");
        }
    }
}
