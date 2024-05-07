using DesafioBenner.models;
using System.Text.Json;
using System;
using System.Runtime.ConstrainedExecution;

namespace DesafioBenner.services;

internal class PreDefinedProgramsService
{
    private const string FILE_PATH = "../../../PrePrograms.json";

    private string json;

    public List<PreDefinedProgram> getAllPredefinedPrograms() {

        try
        {
            json = File.ReadAllText(FILE_PATH);
            var result = JsonSerializer.Deserialize<List<PreDefinedProgram>>(json);
            
            return result == null ? [] : result;

        }
        catch(Exception e)
        {
            throw new Exception("Ocorreu um erro ao buscar os programas pré definidos. " + e.Message);
        }
    }

    public void RegisterPredefinedProgram(PreDefinedProgram preDefinedProgram)
    {
        var programs = getAllPredefinedPrograms();

        programs.Add(preDefinedProgram);

        File.WriteAllText(FILE_PATH, JsonSerializer.Serialize(programs));
    }

}
