using System;

public interface IUpdateable
{
    void Tick();

    event Action<IUpdateable> CloseUpdate;
}
