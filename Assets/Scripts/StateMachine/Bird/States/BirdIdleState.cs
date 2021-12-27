using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdIdleState : State
{
    [SerializeField] private float _stepRotation;

    private void FixedUpdate()
    {
        Bird.Rigidbody.rotation += Time.deltaTime * _stepRotation;

        if (Mathf.Abs(Bird.Rigidbody.rotation) >= 30)
        {
            _stepRotation *= -1;
        }
    }
}
