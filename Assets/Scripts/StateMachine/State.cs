using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bird))]
public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Bird Bird;

    private void Awake()
    {
        Bird = GetComponent<Bird>();
    }

    public void Enter()
    {
        if (!enabled)
        {
            enabled = true;

            foreach(var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Bird);
            }
        }
    }

    public State GetNextState()
    {
        foreach(var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

 }
