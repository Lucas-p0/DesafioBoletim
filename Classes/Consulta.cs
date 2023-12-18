using System.Text.Json.Serialization;

namespace DesafioBoletim.Classes;

public class Consulta
{
    [JsonPropertyName("Aluno")]
    public string? NomeAluno { get; protected set; }


    [JsonPropertyName("Matéria")]
    public string? NomeMateria { get; protected set; }


    [JsonPropertyName("Professor")]
    public string? NomeProfessor { get; protected set; }


    [JsonPropertyName("Série")]
    public string? Serie { get; protected set; }


    [JsonPropertyName("Nota")]
    public double Nota { get; protected set; }


    [JsonPropertyName("Telefone")]
    public string? Telefone { get; protected set; }


    [JsonPropertyName("Sexo")]
    public string? Sexo { get; protected set; }


}
