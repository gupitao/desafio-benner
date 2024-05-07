using DesafioBenner.models;
using DesafioBenner.services;

namespace DesafioBenner.menu;

internal class MenuListPreDefinedPrograms : Menu
{
    private Microwave _microwave;
    private PreDefinedProgramsService _predefinedProgramsService;

    public MenuListPreDefinedPrograms(Microwave microwave, PreDefinedProgramsService preDefinedProgramsService)
    {
        this._microwave = microwave;
        this._predefinedProgramsService = preDefinedProgramsService;
    }

    public void ShowMenu()
    {
        List<PreDefinedProgram> programs = _predefinedProgramsService.getAllPredefinedPrograms();

        ShowTitle("Programas Pré Definidos");

        for (int i = 0; i < programs.Count; i++)
        {
            Console.WriteLine($"{i+1} - {programs[i].Name}");
        }

        Console.WriteLine("0 - Voltar \n");

        int option = -1;

        while (option < 0 || option > programs.Count) {

            Console.Write("Digite sua opção: ");
            string input = Console.ReadLine()!;

            if (int.TryParse(input, out option) && (option >= 1 && option <= programs.Count))
            {
                ClearConsole(4, 12);

                PreDefinedProgram selectedProgram = programs[option -1];

                Console.WriteLine(selectedProgram.ToString());
                
                _microwave.SelectProgram(selectedProgram);

                Console.WriteLine("Pressione qualquer tecla para continuar.");
                Console.ReadKey();

            }else if (option != 0)
            {
                Console.WriteLine("Opção inválida! Selecione um numero dentro do intervalo válido.");
                Console.WriteLine("Pressione qualquer tecla para continuar.");
                Console.ReadKey();
            }

            ClearConsole(11, 13);
        }

    }
}
