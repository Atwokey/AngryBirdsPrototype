using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestructiveObject))]
public class CollisionController : MonoBehaviour
{
    [SerializeField] private float _destructionBoundary;
    [SerializeField] private float _applyDamageBoundary;
    [SerializeField] private AudioClip _collisionAudioClip;

    private DestructiveObject _object;

    private void Awake()
    {
        _object = GetComponent<DestructiveObject>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _object.SetAudioAndPlay(_collisionAudioClip);

        if (collision.relativeVelocity.magnitude > _destructionBoundary)
            _object.Destruction();

        if (collision.relativeVelocity.magnitude > _applyDamageBoundary)
            _object.ApplyDamage();
    }
}
