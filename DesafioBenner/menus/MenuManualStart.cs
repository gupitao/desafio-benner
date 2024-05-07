using DesafioBenner.models;

namespace DesafioBenner.menu;

internal class MenuManualStart : Menu
{
    private Microwave _microwave;

    public MenuManualStart(Microwave microwave)
    {
        this._microwave = microwave;
    }

    public void ShowMenu()
    {
        ShowTitle("Inicio Manual");

        _microwave.Time = ShowQuestionTime();
        _microwave.Power = ShowQuestionPower();
    }

    private int ShowQuestionTime()
    {
        int time = 0;
        while (time <= 0 || time > 120)
        {
            Console.WriteLine("Qual o tempo desejado em segundos (1 a 120)?");

            if (!int.TryParse(Console.ReadLine(), out time) || time <= 0 || time > 120)
            {
                Console.WriteLine("Tempo Inválido! O Valor informado deve ser entre 1 e 120");
                Console.WriteLine("Pressione qualquer tecla para continuar.");
                Console.ReadKey(true);
            }

            ClearQuestion();
        }

        return time;
    }

    private int ShowQuestionPower()
    {
        int power = 0;
        while (power <= 1 || power > 10)
        {
            Console.WriteLine("Qual Potencia desejada (1 a 10)?");

            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input!.Trim()))
            {
                power = 10;

            }else if (!int.TryParse(input.Trim(), out power) || power <= 0 || power > 10 )
            {
                Console.WriteLine("Potência Inválida! O Valor informado deve ser entre 1 e 10");
                Console.WriteLine("Pressione qualquer tecla para continuar.");
                Console.ReadKey(true);
            }
        }


        return power;
    }

    private void ClearQuestion()
    {
        for (int i = 4; i <= 7; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }

        Console.SetCursorPosition(0, 4);
    }
}
