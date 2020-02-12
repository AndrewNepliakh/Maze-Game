using UnityEngine;
using UnityEngine.UI;
using NPLH;

public class UIManager : Actor, IStarter
{
    [SerializeField]
    private Timer _timer = null;
    [SerializeField]
    private GameManager _gameManager = null;

    [SerializeField]
    private Text _timeText = null;
    [SerializeField]
    private Text _lvlText = null;

    public void StartLocal()
    {
        Initialize();
    }

    public void Initialize()
    {
        _timer.Tick += TimeTextUpdate;
        _gameManager.OnDefineLevel += LvlTextUpdate;
    }

    public void TimeTextUpdate(string value)
    {
        _timeText.text = value;
    }

    public void LvlTextUpdate(string value)
    {
        _lvlText.text = value;
    }
}


