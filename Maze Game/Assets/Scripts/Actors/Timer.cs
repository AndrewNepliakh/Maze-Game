using NPLH;
using UnityEngine.Events;
public class Timer : Actor, IStarter
{
    public event UnityAction<string> Tick;
    public UnityEvent TimeIsEnd;

    private int _counter;
    public void Initialize()
    {
        _counter = 30;
    }

    public void StartLocal()
    {
        Initialize();
        InvokeRepeating("Count", 0.0f, 1.0f);
    }

    private void Count()
    {
        _counter -= 1;

        Tick?.Invoke(_counter.ToString());

        if (_counter == 0.0f)
        {
            TimeIsEnd?.Invoke();
            CancelInvoke();
        }
    }

    public void StopTimer() 
    {
        CancelInvoke();
    }


}
