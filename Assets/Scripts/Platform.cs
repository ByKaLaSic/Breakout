using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Platform : MonoBehaviour
{
    [SerializeField] private BlockSpawner _blockSpawner;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Ball _ball;

    private float _minX;
    private float _maxX;
    private bool _isBallOnPlatform = true;
    private readonly string _horizontal = "Horizontal";

    private void Start()
    {
        _minX = _blockSpawner.StartX;
        _maxX = _blockSpawner.StartX + _blockSpawner.TotalWidth;
    }

    private void Update()
    {
        MovePlatform();

        if (Input.GetKey(KeyCode.Space) && _isBallOnPlatform == true)
        {
            RunBall();
        }
    }

    private void MovePlatform()
    {
        float move = Input.GetAxisRaw(_horizontal) * _speed * Time.deltaTime;
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x + move, _minX, _maxX);
        transform.position = position;
    }

    private void RunBall()
    {
        _isBallOnPlatform = false;
        _ball.Run();
    }

    public void ResetBall()
    {
        _isBallOnPlatform = true;
        _ball.Reset(transform);
    }
}
