using DesafioBenner.menu;
using DesafioBenner.menus;
using DesafioBenner.models;
using DesafioBenner.services;

class Program
{
    static void Main(string[] args)
    {
        PreDefinedProgramsService preDefinedProgramsService = new PreDefinedProgramsService();

        Microwave microwave = new Microwave();

        MenuManualStart menuManualStart = new(microwave);
        MenuListPreDefinedPrograms menuListPreDefined = new(microwave, preDefinedProgramsService);
        MenuRegisterProgram menuRegisterProgram = new(preDefinedProgramsService);

        MainMenu menuPrincipal = new MainMenu(microwave, menuManualStart, menuListPreDefined, menuRegisterProgram);

        Console.CursorVisible = false;

        menuPrincipal.ShowMenu();
    }
}