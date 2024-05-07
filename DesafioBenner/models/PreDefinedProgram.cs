using System.Text.Json.Serialization;

namespace DesafioBenner.models;

internal class PreDefinedProgram
{
    private string _name;
    private string _food;
    private int _time;
    private int _power;
    private string _instroduction;
    private char _heatingChar;


    [JsonPropertyName("name")]
    public string Name {
        get => _name;
        set => _name = value;
    }

    [JsonPropertyName("food")]
    public string Food {
        get => _food;
        set => _food = value; }

    [JsonPropertyName("time")]
    public int Time {
        get => _time;
        set => _time = value; }

    [JsonPropertyName("power")]
    public int Power {
        get => _power;
        set => _power = value;
    }

    [JsonPropertyName("instructions")]
    public string Instructions {
        get => _instroduction;
        set => _instroduction = value;
    }


    [JsonPropertyName("heatingChar")]
    public char HeatingChar { 
        get => _heatingChar; 
        set => _heatingChar = value; 
    }

    public PreDefinedProgram(string name, string food, int time, int power, string instructions, char heatingChar = '.')
    {
        _name = name;
        _food = food;
        _time = time;
        _power = power;
        _instroduction  = instructions;
        _heatingChar = heatingChar;
    }

    public override string ToString()
    {
        return $""""
            nome: {Name}
            Alimento: {Food}
            Tempo: {Time}
            Potencia: {Power}
            Instruções: {Instructions}
            Marcador: {HeatingChar}
            """";
    }
}
