using UnityEngine;

public class TimeState
{
    public TimeState()
    {
        Play();
    }

    public void Play() => Time.timeScale = 1;
    public void Stop() => Time.timeScale = 0;
}
