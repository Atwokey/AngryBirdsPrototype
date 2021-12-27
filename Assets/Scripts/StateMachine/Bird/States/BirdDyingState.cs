using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDyingState : State
{
    [SerializeField] AudioClip _clip;

    private void Start()
    {
        Bird.StartAnimation("Bang");
        Bird.SetClipAndPlay(_clip);
        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(.5f);

        Bird.Die();
    }
}
