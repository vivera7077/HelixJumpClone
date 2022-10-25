using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _lenght;

    private Ball _ball;
    private Cylinder _cylinder;
    private Vector3 _cameraPosition;
    private Vector3 _minBallPos;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _cylinder = FindObjectOfType<Cylinder>();

        _cameraPosition = _ball.transform.position;
        _minBallPos = _ball.transform.position;


        BallTracking();
    }

    private void Update()
    {
        if (_ball.transform.position.y < _minBallPos.y)
        {
            BallTracking();
            _minBallPos = _ball.transform.position;
        }
    }

    private void BallTracking()
    {

        Vector3 cylinderPos = _cylinder.transform.position;
        cylinderPos.y = _ball.transform.position.y;
        _cameraPosition = _ball.transform.position;

        Vector3 dir = (cylinderPos - _ball.transform.position).normalized + _directionOffset;
        _cameraPosition -= dir * _lenght;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}
