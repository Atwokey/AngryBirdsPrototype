using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlyingState : State
{
    [SerializeField] private AudioClip _clip;

    private void Start()
    {
        Bird.SetClipAndPlay(_clip);
    }
}
