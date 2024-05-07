using DesafioBenner.services;
using System.Text.Json;
using System.Timers;

namespace DesafioBenner.models;

internal class Microwave : MicrowaveTimer
{
    private int _time = 0;
    private int _ticker = 0;
    private int _power = 10;
    private bool _isAddTime = true;
    private char _heatingChar = '.';

    public int Time
    {
        get => _time;
        set => _time = value;
    }

    public int Power
    {
        get => _power;
        set
        {
            if (value < 1 || value > 10)
            {
                Console.WriteLine("Potência inválida! O valor informado deve ser entre 1 e 10");
            }
            else
            {
                _power = value;
            }
        }
    }

    public bool IsAddTime { get => _isAddTime; }

    public void SelectProgram(PreDefinedProgram preDefinedProgram)
    {
        _time = preDefinedProgram.Time;
        _power = preDefinedProgram.Power;
        _heatingChar = preDefinedProgram.HeatingChar;
        _isAddTime = false;
    }

    public override void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        if (_time > 0)
        {
            _time--;

            Console.SetCursorPosition(7, 4);
            Console.WriteLine($"{(_time / 60):D2}:{Time % 60:D2}");

            if ((_ticker * _power) >= Console.WindowWidth)
            {
                Console.SetCursorPosition(0, 6);
                Console.WriteLine(new string(' ', Console.WindowWidth));
                _ticker = 0;
            }

            Console.SetCursorPosition(_ticker * _power, 6);

            Console.WriteLine(new string(_heatingChar, _power));

            _ticker++;
        }
        else
        {
            Timer.Stop();
            Console.SetCursorPosition(0, 6);
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.WriteLine($"Aquecimento Concluido");
        }
    }

    public override void StartTimer()
    {
        if (_time == 0 || Timer.Enabled)
        {
            _time += 30;
        }

        base.StartTimer();
    }

    public override void StopTimer()
    {
        if (!Timer.Enabled)
        {
            _time = 0;
            _power = 10;
            _isAddTime = true;
            _heatingChar = '.';
        }

        _ticker = 0;
        Console.SetCursorPosition(0, 6);
        Console.WriteLine(new string(' ', Console.WindowWidth));

        base.StopTimer();
    }

}