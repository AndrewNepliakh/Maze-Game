using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPLH;

public class LookAtCamera : Actor, IStarter, IUpdater
{
    private Transform _camera;

    public void Initialize()
    {
        _camera = Camera.main.transform;
    }

    public void StartLocal()
    {
        Initialize();
    }

    public void UpdateLocal()
    {
        transform.LookAt(_camera);
    }
}
