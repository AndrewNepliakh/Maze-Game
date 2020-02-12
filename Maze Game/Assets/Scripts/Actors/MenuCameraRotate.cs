using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPLH;

public class MenuCameraRotate : Actor, IStarter, IUpdater
{
    [SerializeField]
    private float _speedRotation;

    public void StartLocal() 
    {
        Initialize();
    }

    public void Initialize() 
    {
        _speedRotation = 1.0f;
    }

    public void UpdateLocal()
    {
        transform.Rotate(Vector3.up * _speedRotation * Time.deltaTime, Space.World);     
    }
}
