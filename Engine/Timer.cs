using System;

public class Timer
{

    // classe temporizador, pode ser usada para basicamente tudo relacionado a algo ao longo do tempo, exemplo as animaçoes
    // classe Timer = encapsulamento do temporizador
    // metodo start recebe: 
    // callback, um metodo a ser chamado
    // duration, duraçao do metodo chamado/ quanto tempo o temporizador sera usado
    // repeat, definir se ira ou nao repetir

    private Action _callback;
    private float _duration;
    private bool _repeat;
    private float _time;
    private bool _active = false;

    public void Start(Action callback, float duration, bool repeat)
    {
        _callback = callback;
        _duration = duration;
        _repeat = repeat;
        _time = 0.0f;
        _active = true;
    }

    public void Update(float deltaTime)
    {
        if (!_active)
        {
            return;
        }

        _time = _time + deltaTime;

        if (_time > _duration)
        {
            _callback.Invoke();

            if (_repeat)
            {
                _time = 0.0f;
            }
            else
            {
                _active = false;
            }
        }
    }
}