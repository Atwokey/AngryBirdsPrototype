using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BirdTracker : MonoBehaviour
{
    [SerializeField] private float _offsetX;
    [SerializeField] private Slingshot _slingshot;
    [SerializeField] private float _speed;

    private void Update()
    {
        if(_slingshot.CurrentBird == null)
        {
            if(transform.position.x <= 0)
            {
                _slingshot.NextBird();
                return;
            }

            float xPosition = transform.position.x - (_speed * Time.deltaTime);
            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        }

        if(_slingshot.CurrentBird.StateMachine.CurrentState.GetType() == typeof(BirdFlyingState))
            if(Camera.main.WorldToViewportPoint(_slingshot.CurrentBird.transform.position).x > 0.5f)
                transform.position = new Vector3(_slingshot.CurrentBird.transform.position.x, transform.position.y, transform.position.z);
            
    }
}
