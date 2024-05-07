using DesafioBenner.menu;
using DesafioBenner.models;
using DesafioBenner.services;

namespace DesafioBenner.menus;

internal class MenuRegisterProgram : Menu
{
    private PreDefinedProgramsService _preDefinedProgramsService;
    public MenuRegisterProgram(PreDefinedProgramsService preDefinedProgramsService)
    {
        this._preDefinedProgramsService = preDefinedProgramsService;
    }

    public void ShowMenu()
    {
        List<PreDefinedProgram> programs = _preDefinedProgramsService.getAllPredefinedPrograms();

        ShowTitle("Resgistro de Programas de Aquecimento.");
        PreDefinedProgram program = new("", "", 0, 0, "", '.');


        while (string.IsNullOrEmpty(program.Name.Trim()) || program.Name.Trim().Length <= 0)
        {
            Console.WriteLine("Digite o nome do Programa.");
            program.Name = Console.ReadLine()!.Trim();

            if (program.Name.Length == 0)
            {
                HandleError("Obrigatório informar um nome para o programa");
            }
            else
            {
                ClearConsole(4, 5);
            }

        }

        while (string.IsNullOrEmpty(program.Food.Trim()) || program.Name.Trim().Length <= 0)
        {
            Console.WriteLine("Digite o nome do Alimento.");
            program.Food = Console.ReadLine()!.Trim();

            if (program.Food.Length == 0)
            {
                HandleError("Obrigatório informar um nome de alimento para o programa");
            }else
            {
                ClearConsole(4, 5);
            }
        }

        while (program.Time == 0)
        {
            Console.WriteLine("Qual o tempo de aquecimento? (Deve ser maior que 0)");
            var input = Console.ReadLine();

            if (int.TryParse(input!.Trim(), out int time) && time > 0)
            {
                program.Time = time;
                ClearConsole(4, 5);
            }
            else
            {
                HandleError("Valor Inválido! O tempo a ser informado de ser númerico e maior que 1");
            }

        }

        while (program.Power == 0)
        {
            Console.WriteLine("Qual a potência (1 a 10)?");
            var input = Console.ReadLine();

            if (int.TryParse(input!.Trim(), out int power) && power > 0 && power <= 10)
            {
                program.Power = power;
                ClearConsole(4, 5);
            }
            else
            {
                HandleError("Valor Inválido! A potência informada deve ser de 1 a 10");
            }

        }

        while (program.HeatingChar == '.' || program.HeatingChar == ' ')
        {
            Console.WriteLine("Digite um caracter para representar o aquecimento. (Não utilize espaço em branco ou .)");
            var input = Console.ReadLine();


            if (char.TryParse(input!.Trim(), out char heating) && !programs.Any(program => program.HeatingChar == heating) && heating != '.' && heating != ' ')
            {
                program.HeatingChar = heating;
                ClearConsole(4, 5);
            }
            else
            {
                HandleError("Caracter em uso ou Valor Inválido! Informe um novo Caracter. ");
            }
        }

        Console.WriteLine("Digite as intruções (Caso não queira informar pressione enter).");
        program.Instructions = Console.ReadLine()!;

        _preDefinedProgramsService.RegisterPredefinedProgram(program);
    }


    private void HandleError(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Pressione qualquer tecla para continuar.");
        Console.ReadKey();

        ClearConsole(4, 7);
    }
}
