using NPLH;
using UnityEngine;

public class CameraFollow : Actor, IUpdater
{
    [SerializeField]
    private Transform _ball = null;
    [SerializeField]
    private float _offset = -7.0f;
    public void UpdateLocal()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _ball.position.z + _offset);
    }
}
