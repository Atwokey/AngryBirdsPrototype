using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Bird Bird;

    public State TargetState => _targetState;
    public bool NeedTransit {get; protected set;}

    public void Init(Bird bird)
    {
        Bird = bird;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
