using NPLH;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MainApp : Singleton<MainApp>
{
    private static List<Actor> _actors;

    public UnityEvent StartScene;

    private void Awake()
    {
        _actors = (FindObjectsOfType<MonoBehaviour>().OfType<Actor>()).ToList();
        StartUpActors();
    }

    private void Start()
    {
        StartScene?.Invoke();
    }

    private void Update()
    {
        UpdateActors();
    }

    private void FixedUpdate()
    {
        FixedUpdateActors();
    }

    private void StartUpActors()
    {
        foreach (Actor actor in _actors)
        {
            if (actor is IStarter)
            {
                (actor as IStarter).StartLocal();
            }
        }
    }

    private void UpdateActors()
    {
        foreach (Actor actor in _actors)
        {
            if (actor is IUpdater)
            {
                (actor as IUpdater).UpdateLocal();
            }
        }
    }

    private void FixedUpdateActors()
    {
        foreach (Actor actor in _actors)
        {
            if (actor is IFixedUpdater)
            {
                (actor as IFixedUpdater).FixedUpdateLocal();
            }
        }
    }
}
