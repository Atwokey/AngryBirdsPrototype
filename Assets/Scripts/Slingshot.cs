using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField] private Bird[] _birds;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _maxMagnitude;
    [SerializeField] private Saddle _saddle;

    private int _currentIndexBirds;
    private Vector3 _directionForce;
    
    public Bird CurrentBird { get; private set; }
    public bool AimingMode { get; private set; }

    private void Start()
    {
        _currentIndexBirds = 0;
        SpawnBird();
    }

    private void SpawnBird()
    {
        CurrentBird = Instantiate(_birds[_currentIndexBirds], _spawnPoint.position, Quaternion.identity);
    }



    private void FixedUpdate()
    {
        if (!AimingMode)
            return;

        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var delta = mousePosition - _spawnPoint.position;

        if (delta.magnitude > _maxMagnitude)
            delta = delta.normalized * _maxMagnitude;

        Vector2 currentPosition = _spawnPoint.position + delta;
        CurrentBird.Rigidbody.position = currentPosition;
        _saddle.SetSaddlePosition(new Vector3(currentPosition.x - 0.25f, currentPosition.y - 0.16f));

        _directionForce = -delta;
    }

    private void OnMouseDown()
    {
        AimingMode = true;
        CurrentBird.Rigidbody.isKinematic = true;
    }

    private void OnMouseUp()
    {
        AimingMode = false;
        CurrentBird.Rigidbody.isKinematic = false;
        CurrentBird.SetVelocity(_directionForce);
        _saddle.ResetStrips();
    }

    public void NextBird()
    {
        _currentIndexBirds++;
        SpawnBird();
    }

}
