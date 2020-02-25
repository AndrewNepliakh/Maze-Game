using UnityEngine;
using NPLH;

public class Ball : Actor, IStarter, IFixedUpdater
{
    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField]
    private float _gravity = -9.8f;
    private bool isOnControl;
    private Rigidbody _rigidbody;

    private float _zatstart = 0.0f;
    private float _xatstart = 0.0f;
    private float _hzMovement = 0.0f;
    private float _vtMovement = 0.0f;


    public void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();
        isOnControl = true;

        Calibrate();
    }

    public void StartLocal()
    {
        Initialize();
    }

    public void FixedUpdateLocal()
    {
        if (isOnControl) Move();
    }
    private void Move()
    {
#if UNITY_EDITOR_WIN
        float moveHorizontal = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        var movement = new Vector3(moveHorizontal, _gravity, moveVertical);
        movement = Vector3.ClampMagnitude(movement, _speed);

        _rigidbody.velocity = movement;
#endif

#if UNITY_ANDROID && !UNITY_EDITOR

        _hzMovement = Input.acceleration.x - _xatstart;
        _vtMovement = Input.acceleration.y - _zatstart;

        var movement = new Vector3( _hzMovement * _speed * 4.0f * Time.deltaTime, 
                                    _gravity,
                                    _vtMovement * _speed * 4.0f * Time.deltaTime);

        movement = Vector3.ClampMagnitude(movement, _speed);

        _rigidbody.velocity = movement;

#endif

    }

    private void Calibrate()
    {
        _xatstart = Input.acceleration.x;
        _zatstart = Input.acceleration.y;
    }

    public void TurnOffControl()
    {
        _rigidbody.velocity = Vector3.zero;
        isOnControl = !isOnControl;
    }
}
