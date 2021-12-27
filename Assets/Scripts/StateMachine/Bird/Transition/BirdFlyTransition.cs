using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlyTransition : Transition
{
    private void Update()
    {
        if (Bird.Rigidbody.velocity.magnitude > 0)
            NeedTransit = true;
    }
}
