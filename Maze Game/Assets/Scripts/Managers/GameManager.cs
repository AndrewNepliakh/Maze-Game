using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _mazes = null;

    private int _lvlNumber;

    public event UnityAction<string> OnDefineLevel;

    public void StartGame()
    {
        DisableAllMazes();
        DefineLvlNumber();
        TurnOnCertainMaze();
    }

    private void TurnOnCertainMaze()
    {
        for (int i = 0; i < _mazes.Length; i++)
        {
            if (i == _lvlNumber)
            {
                _mazes[i].SetActive(true);
            }
            else
            {
                _mazes[i].SetActive(false);
            }
        }
    }
    private void DefineLvlNumber()
    {
        if ((PlayerPrefs.GetInt("Level") + 1) <= _mazes.Length)
        {
            _lvlNumber = PlayerPrefs.GetInt("Level");
        }
        else
        {
            _lvlNumber = _mazes.Length - 1;
        }

        OnDefineLevel?.Invoke((_lvlNumber + 1).ToString());
    }
    private void DisableAllMazes() 
    {
        foreach (GameObject maze in _mazes) 
        {
            maze.SetActive(false);
        }
    }
}
