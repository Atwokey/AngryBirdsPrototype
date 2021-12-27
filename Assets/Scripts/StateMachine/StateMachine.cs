using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] State _startState;

    public State CurrentState { get; private set;}

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        if (CurrentState == null)
            return;

        State nextState = CurrentState.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    private void Reset()
    {
        CurrentState = _startState;

        if (CurrentState != null)
            CurrentState.Enter();
    }

    private void Transit(State nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        CurrentState.Enter();
    }
}
