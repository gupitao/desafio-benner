using System.Timers;

namespace DesafioBenner.models;

internal abstract class MicrowaveTimer
{
    private System.Timers.Timer _timer = new();
    private bool _isPaused = false;

    public System.Timers.Timer Timer
    {
        get => _timer;
    }

    public bool IsPaused
    {
        get => _isPaused;
    }

    public MicrowaveTimer()
    {
        _timer.Interval = 1000;
        _timer.Elapsed += TimerElapsed;
        _timer.AutoReset = true;
    }

    public abstract void TimerElapsed(object sender, ElapsedEventArgs e);


    public virtual void StartTimer()
    {
        _timer.Start();
    }

    public virtual void StopTimer()
    {
        if (Timer.Enabled)
        {
            _isPaused = true;
        }
        else
        {
            _isPaused = false;
        }

        _timer.Stop();
    }
}
