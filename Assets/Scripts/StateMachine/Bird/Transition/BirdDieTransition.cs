using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDieTransition : Transition
{
    private void Update()
    {
        if (Bird.Rigidbody.IsSleeping())
            NeedTransit = true;
    }
}
