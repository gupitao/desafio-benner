using DesafioBenner.menus;
using DesafioBenner.models;

namespace DesafioBenner.menu;

internal class MainMenu : Menu
{
    private readonly MenuManualStart _menuManualStart;
    private readonly MenuListPreDefinedPrograms _menuPreDefinedPrograms;
    private readonly MenuRegisterProgram _menuRegisterProgram;

    private Microwave microwave;

    public MainMenu(
        
        Microwave microwave,
        MenuManualStart menuManualStart,
        MenuListPreDefinedPrograms menuPreDefinedPrograms,
        MenuRegisterProgram menuRegisterProgram
        )
    {
        this.microwave = microwave;
        this._menuManualStart = menuManualStart;
        this._menuPreDefinedPrograms = menuPreDefinedPrograms;
        this._menuRegisterProgram = menuRegisterProgram;
    }

    public void ShowMenu()
    {
        ConsoleKeyInfo consoleKey = new ConsoleKeyInfo();

        while (consoleKey.Key != ConsoleKey.D0 && consoleKey.Key != ConsoleKey.NumPad0)
        {
            ShowTitle("Micro-ondas Benner");

            Console.WriteLine($"Tempo: {(microwave.Time/60):D2}:{microwave.Time % 60:D2}");
            Console.WriteLine($"Potencia: {microwave.Power} \n \n");

            if (!microwave.Timer.Enabled && !microwave.IsPaused && microwave.Time == 0)
            {
                Console.WriteLine("1 - Inicio Manual");
                Console.WriteLine("2 - Programas de Aquecimento");
            }

            if ((!microwave.Timer.Enabled && !microwave.IsPaused ) || (microwave.Timer.Enabled && microwave.IsAddTime) || (!microwave.Timer.Enabled && microwave.IsPaused))
            {
                Console.WriteLine("3 - Iniciar / Inicio Rápido");
            }

            Console.WriteLine("4 - Pausar / Cancelar");

            if (!microwave.Timer.Enabled && !microwave.IsPaused && microwave.Time == 0)
            {
                Console.WriteLine("5 - Registrar Programas de aquecimento");
            }

            if (!microwave.Timer.Enabled && !microwave.IsPaused)
            {
                Console.WriteLine("0 - Sair");
            }

            consoleKey = Console.ReadKey(true);

            SelectOption(consoleKey);
        }
    }

    private void SelectOption(ConsoleKeyInfo consoleKey)
    {
        switch (consoleKey.Key)
        {
            case ConsoleKey.NumPad1:
            case ConsoleKey.D1:
                if (!microwave.Timer.Enabled && !microwave.IsPaused && microwave.Time == 0)
                {
                    _menuManualStart.ShowMenu();
                }
                break;

            case ConsoleKey.NumPad2:
            case ConsoleKey.D2:
                if (!microwave.Timer.Enabled && !microwave.IsPaused)
                {
                    _menuPreDefinedPrograms.ShowMenu();
                }
                break;

            case ConsoleKey.NumPad3:
            case ConsoleKey.D3:
                if ((!microwave.Timer.Enabled && !microwave.IsPaused) || (microwave.Timer.Enabled && microwave.IsAddTime) || (!microwave.Timer.Enabled && microwave.IsPaused))
                {
                    microwave.StartTimer();
                }
                break;

            case ConsoleKey.NumPad4:
            case ConsoleKey.D4:
                microwave.StopTimer();
                break;

            case ConsoleKey.NumPad5:
            case ConsoleKey.D5:
                _menuRegisterProgram.ShowMenu();
                break;

            case ConsoleKey.NumPad0:
            case ConsoleKey.D0:
                if (!microwave.Timer.Enabled && !microwave.IsPaused)
                {
                    Console.Clear();
                    Console.WriteLine("Obrigado por utilizar nosso micro-ondas :)");
                }
                break;

            default:
                Console.WriteLine("\n Opção Inválida.");
                break;
        }
    }

}
